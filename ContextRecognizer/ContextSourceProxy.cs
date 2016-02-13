using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ContextRecognizer
{
    public class ContextSourceProxy
    {
        ContextHelper contextHelper_;

        public ContextSourceProxy()
        {
            contextHelper_ = new ContextHelper();
        }

        private List<string> getDllFromConfig()
        {
            //reads a directory from a config and iterates over all dlls in this dir
            //DEBUG: for now hardcode the links
            List<string> dlls = new List<string>();

            dlls.Add(@"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Masterarbeit\InternetExplorerContext\bin\Debug\InternetExplorerContext.dll");
            dlls.Add(@"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Masterarbeit\WindowsOSContext\bin\Debug\WindowsOSContext.dll");
            dlls.Add(@"C:\Users\Administrator\Documents\Visual Studio 2013\Projects\Masterarbeit\GenericContext\bin\Debug\GenericContext.dll");
            return dlls;
        }

        public List<ContextSet> GetContext()
        {
            List<ContextSet> results = new List<ContextSet>();

            foreach (string pathdoClientSearchdll in getDllFromConfig())
            {
                try
                {
                    //parse the dll name here
                    string dllname = pathdoClientSearchdll.Substring(pathdoClientSearchdll.LastIndexOf("\\")).Replace("\\", String.Empty);
                    dllname = dllname.Substring(0, dllname.Length - 4);

                    var asm = Assembly.LoadFile(pathdoClientSearchdll);
                    var type = asm.GetType(dllname + ".Context");

                    if (type != null)
                    {
                        MethodInfo methodInfo = type.GetMethod("GetContext");
                        if (methodInfo != null)
                        {
                            object classInstance = Activator.CreateInstance(type, null);

                            object[] parametersArray = new object[] { };

                            string[] res = methodInfo.Invoke(classInstance, parametersArray) as string[];

                            foreach (string str in res)
                            {
                                if (str.Contains(";"))
                                {
                                    string[] splitted = str.Split(';');
                                    ContextSet set = new ContextSet();

                                    set.Type = splitted[0];
                                    set.Value = splitted[1];
                                   
                                    results.Add(set);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogInfo("An error occurred in the Search DLL: " + pathdoClientSearchdll);
                    Logger.LogError(ex);
                }
            }

            return results;
        }

        public List<SensiumResultPhrase> GetInteresstingPhrasesFromActualContext()
        {
            SensiumConnector conn = new SensiumConnector();

            List<SensiumResultPhrase> results = new List<SensiumResultPhrase>();

            List<ContextSet> actualContextSets = GetContext();

            for (int i = 0; i < actualContextSets.Count; i++)
            {
                if (actualContextSets[i].Type.ToLower() == "url")
                {
                    List<SensiumResultPhrase> phrases = conn.GetInteressingPhrasesFromUrl(actualContextSets[i].Value);
                    results.AddRange(phrases);
                }
                else
                {
                    List<SensiumResultPhrase> phrases = conn.GetInteressingPhrases(actualContextSets[i].Value);
                    results.AddRange(phrases);
                }
            }
            
            //filter fillwords like Und here
            results = contextHelper_.FilterWordsWithoutInformation(results);

            double scoresum = 0;
            foreach(SensiumResultPhrase phrase in results)
            {
                scoresum += phrase.Score;
            }

            double mean = scoresum / results.Count;

            List<SensiumResultPhrase> normalized = new List<SensiumResultPhrase>();
            foreach(SensiumResultPhrase ph in results)
            {
                if(ph.Type == "url")
                {
                    double highermean = mean + mean / 2;

                    while(highermean >= 1)
                    {
                        highermean = highermean - highermean / 4;
                    }

                    if (ph.Score > highermean)
                    {
                        normalized.Add(ph);
                    }

                }
                else
                {

                    if (ph.Score > mean)
                    {
                        normalized.Add(ph);
                    }
                }
            }

            //filter fillwords like Und here
            normalized = contextHelper_.FilterWordsWithoutInformation(normalized);

            return normalized;
        }

    }
}
