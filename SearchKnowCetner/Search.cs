using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SearchKnowCetner
{
    public class Search
    {
        public string[] DoSearch(string[] phrases)
        {
            List<string> result = new List<string>();

            foreach(string phrase in phrases)
            {
                using (var client = new WebClient())
                {
                    try
                    {
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        client.Headers[HttpRequestHeader.Accept] = "application/json";

                        string toupload = "{" +
                                            "\"indexName\": \"news\"," +
                                            "\"query\": \"" + phrase + "\"," +
                                            "\"searchSettings\": { \"chunkSize\": \"30\"  }" +
                                          "}";

                        var response = client.UploadData("https://saas.know-center.tugraz.at/news-demo/api/search/search", Encoding.UTF8.GetBytes(toupload));

                        var responseString = Encoding.UTF8.GetString(response);
                        dynamic obj = JsonConvert.DeserializeObject(responseString);

                        //keyphrases extraction here
                        //only take the one with the highest relevance
                        double highestRel = 0;
                        string highestString = String.Empty;
                        foreach (var hit in obj.searchHits)
                        {
                            string dbl = hit.relevance.ToString();
                            double rel = Convert.ToDouble(dbl);
                            string hitstring = hit.id.ToString();
                            hitstring = hitstring.Replace("NEWS|", String.Empty);

                            if(rel > highestRel)
                            {
                                highestRel = rel;
                                highestString = hitstring;
                            }
                        }

                        highestRel = highestRel / 10.0f;
                        highestRel = Math.Round(highestRel, 2);
                        result.Add("web;" + highestRel + ";" + highestString);
                    }
                    catch (WebException ex)
                    {
                        var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();

                        dynamic obj = JsonConvert.DeserializeObject(resp);
                    }
                }
            }

            return result.ToArray();
        }
    }
}
