using ContextRecognizer;
using Data;
using DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace SearchHost
{
    class Program
    {
        static void Main(string[] args)
        {

            //SensiumConnector conn = new SensiumConnector();
            //List<SensiumResultPhrase> results = new List<SensiumResultPhrase>();


            //ContextSourceProxy prox = new ContextSourceProxy();
            //List<ContextSet> bla = prox.GetContext();

            //foreach(ContextSet set in bla)
            //{
            //    if (set.Type.ToLower() == "url")
            //    {
            //        results.AddRange(conn.GetInteressingPhrasesFromUrl(set.Value));
            //    }
            //    else
            //    {
            //        results.AddRange(conn.GetInteressingPhrases(set.Value));
            //    }
            //}

            //foreach(SensiumResultPhrase phr in results)
            //{
            //    Console.WriteLine(phr.Text + "  -  " + phr.Score);
            //}

            //GenericContext.Context gen = new GenericContext.Context();
            //var bla = gen.GetContext();

            //DAL.DBWriter log = new DBWriter();
            //log.LogPhrases("contextphrases112", "resultphrase232323s");

            SearchKnowCetner.Search s = new SearchKnowCetner.Search();
            s.DoSearch(new string[] { "test" });
            //Console.Read();
        }
    }
}
