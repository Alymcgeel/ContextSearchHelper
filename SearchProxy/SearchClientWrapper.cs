using Data;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace SearchProxy
{
    public class SearchClientWrapper
    {
        DBWriter logger = null;
        public SearchClientWrapper()
        {
            logger = new DBWriter();
        }

        private List<string> getDllFromConfig()
        {
            //reads a directory from a config and iterates over all dlls in this dir
            //DEBUG: for now hardcode the links
            List<string> dlls = new List<string>();

            dlls.Add(@"C:\Users\Administrator\Documents\visual studio 2013\Projects\Masterarbeit\SearchWindows\bin\Debug\SearchWindows.dll");
            dlls.Add(@"C:\Users\Administrator\Documents\visual studio 2013\Projects\Masterarbeit\SearchChromeHistory\bin\Debug\SearchChromeHistory.dll");
            dlls.Add(@"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Masterarbeit\SearchOutlook\bin\Debug\SearchOutlook.dll");
            dlls.Add(@"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Masterarbeit\SearchKnowCetner\bin\Debug\SearchKnowCetner.dll");

            return dlls;
        }
        public List<SearchResult> DoSearch(string[] phrases)
        {
            List<SearchResult> results = new List<SearchResult>();

            //use a string var here instead of parsing the result list later
            //because of performance reasons
            string resultPhrasesString = String.Empty;
            
            foreach (string pathdoClientSearchdll in getDllFromConfig())
            {
                try
                {
                    //parse the dll name here
                    string dllname = pathdoClientSearchdll.Substring(pathdoClientSearchdll.LastIndexOf("\\")).Replace("\\", String.Empty);
                    dllname = dllname.Substring(0, dllname.Length - 4);

                    var asm = Assembly.LoadFile(pathdoClientSearchdll);
                    var type = asm.GetType(dllname + ".Search");

                    if (type != null)
                    {
                        MethodInfo methodInfo = type.GetMethod("DoSearch");
                        if (methodInfo != null)
                        {

                            object classInstance = Activator.CreateInstance(type, null);

                            object[] parametersArray = new object[] { phrases };

                            string[] res = methodInfo.Invoke(classInstance, parametersArray) as string[];

                            foreach (string str in res)
                            {
                                if (str.Contains(";"))
                                {
                                    string[] splitted = str.Split(';');

                                    if (splitted.Length > 0)
                                    {
                                        resultPhrasesString += splitted[2] + ";";
                                        string relevance = splitted[1];

                                        double rel = Double.Parse(relevance);
                                        

                                        SearchResult sres = new SearchResult();

                                        //special handling for EMAILS
                                        if (splitted[0].ToLower().Contains("mail"))
                                        {
                                            sres.Path = splitted[2];
                                            sres.Type = "mail";
                                            sres.AdditionalInformation = splitted[0].ToLower().Replace("mail", String.Empty);
                                            sres.Score = relevance;
                                        }
                                        else
                                        {
                                            if (!String.IsNullOrEmpty(splitted[2]))
                                            {
                                                sres.Path = splitted[2];
                                                sres.Type = splitted[0].ToLower();
                                                sres.Score = relevance;
                                            }
                                        }

                                        if(!String.IsNullOrEmpty(sres.Path) && !String.IsNullOrEmpty(sres.Score))
                                        {
                                            results.Add(sres);
                                        }                                        
                                    }
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Utilities.Logger.LogInfo("An error occurred in the Search DLL: " + pathdoClientSearchdll);
                    Utilities.Logger.LogError(ex);
                }
            }

            //now calculate the mean score and sort out bad results
            double mean = 0;
            foreach(SearchResult res in results)
            {
                mean += Double.Parse(res.Score);
            }

            mean = mean / results.Count;

            if(resultPhrasesString.Length > 2)
            {
                resultPhrasesString = resultPhrasesString.Substring(0, resultPhrasesString.Length - 1);
            }

            //log here everything to the DB
            logger.LogPhrases(Helper.ReturnConcattedString(phrases), resultPhrasesString);

            //sort them by relevance


            return results;
        }
    }
}
