using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SearchGoogle
{
    public class Search
    {
        public string[] DoSearch(string[] phrases)
        {
            List<string> result = new List<string>();
            string search = String.Empty;
            foreach (string str in phrases)
            {
                search += str + " ";
            }

            string uriString = "http://www.google.com/search";
            string keywordString = "Test Keyword";

            WebClient webClient = new WebClient();

            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("q", keywordString);

            webClient.QueryString.Add(nameValueCollection);
            string response = webClient.DownloadString(uriString);


            return result.ToArray();
        }
    }
}
