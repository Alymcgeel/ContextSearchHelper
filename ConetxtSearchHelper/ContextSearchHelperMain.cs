using ContextRecognizer;
using Data;
using DAL;
using SearchProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using System.Diagnostics;
using System.Threading;
using ConetxtSearchHelper.Forms;

namespace ConetxtSearchHelper
{
    public class ContextSearchHelperMain
    {
        ContextSourceProxy contextProxy_;
        SearchClientWrapper searchProxy_;
        DBWriter DBLogger_;

        public ContextSearchHelperMain()
        {
            contextProxy_ = new ContextSourceProxy();
            searchProxy_ = new SearchClientWrapper();
            DBLogger_ = new DBWriter();
        }

        public void Start()
        {
            //Hide the settings for now, as the dialog is far from finished 
            //Settings settings = new Settings();
            //settings.ShowDialog();

            while (true)
            {
                //set the prio to low this way...
                Thread.CurrentThread.Priority = ThreadPriority.Lowest;
                
                Stopwatch stop = new Stopwatch();
                stop.Start();

                List<SensiumResultPhrase> result = contextProxy_.GetInteresstingPhrasesFromActualContext();
                Console.WriteLine("Got actual Context results. Found " + result.Count + " context phrases.");

                string[] resultAsString = Helper.GetStringArrayFromSensiumResultSetList(result);

                Console.WriteLine("+++++++");
                foreach (string str in resultAsString)
                {
                    Console.WriteLine(str);
                }
                Console.WriteLine("+++++++");

                List<SearchResult> searchResults = searchProxy_.DoSearch(resultAsString);
                Console.WriteLine("Got actual Search results. Found " + searchResults.Count + " search Results.");

                //Console.WriteLine(Helper.ReturnConcattedString(Helper.GetStringArrayFromSearchResultSetList(searchResults)));

                DBLogger_.LogSearchResults(searchResults);

                stop.Stop();
                Console.WriteLine("Iteration took " + stop.ElapsedMilliseconds / 1000 + " seconds.");
                Console.WriteLine("#-------------------------------------------------------------#");

                //DEBUG : press enter to perform cycle
                //Console.ReadLine();
            }
        }
    }
}
