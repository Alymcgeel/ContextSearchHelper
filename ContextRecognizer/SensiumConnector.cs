using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ContextRecognizer
{
    /// <summary>
    /// This class is used to call the Sensium Service with a whole lot of text and infos and retrieve the important
    /// Phrases
    /// </summary>
    public class SensiumConnector
    {
        public List<SensiumResultPhrase> GetInteressingPhrases(string inputText)
        {
            List<SensiumResultPhrase> returnedPhrases = new List<SensiumResultPhrase>();
            
            using (var client = new WebClient())
            {
                try
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";

                    string toupload = "{" +
                                        "\"apiKey\": \"c105f2f6-ca21-4ddb-ab36-480cf438b6f3\"," +
                                        "\"text\": \"" + inputText + "\"," +
                                        "\"extractors\": [ \"Summary\", \"Entities\" ]" +
                                      "}";

                    var response = client.UploadData("https://api.sensium.io/v1/extract", Encoding.UTF8.GetBytes(toupload));

                    var responseString = Encoding.UTF8.GetString(response);
                    dynamic obj = JsonConvert.DeserializeObject(responseString);

                    //keyphrases extraction here
                    foreach (var ph in obj.summary.keyPhrases)
                    {
                        if (!Utilities.Helper.SensiumResultListContainsText(returnedPhrases, ph.text.ToString()))
                        {
                            SensiumResultPhrase phrase = new SensiumResultPhrase();
                            phrase.Text = ph.text.ToString();
                            phrase.Score = Double.Parse(ph.score.ToString());
                            phrase.Type = "phrase";

                            returnedPhrases.Add(phrase);
                        }
                    }

                    //Named entity extraction here
                    foreach (var ent in obj.entities)
                    {
                        SensiumResultPhrase phrase = new SensiumResultPhrase();
                        phrase.Text = ent.normalized.ToString();
                        phrase.Score = 1;

                        returnedPhrases.Add(phrase);
                    }

                }
                catch (WebException ex)
                {
                   //s var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();

                  //  Logger.LogError(resp);

                }

                return returnedPhrases;
            }
        }

        public List<SensiumResultPhrase> GetInteressingPhrasesFromUrl(string url)
        {
            List<SensiumResultPhrase> returnedPhrases = new List<SensiumResultPhrase>();
            
            using (var client = new WebClient())
            {
                try
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";

                    string toupload = "{" +
                                        "\"apiKey\": \"c105f2f6-ca21-4ddb-ab36-480cf438b6f3\"," +
                                        "\"url\": \"" + url + "\"," +
                                        "\"extractors\": [ \"Summary\", \"Entities\"  ]" +
                                      "}";

                    var response = client.UploadData("https://api.sensium.io/v1/extract", Encoding.UTF8.GetBytes(toupload));

                    var responseString = Encoding.UTF8.GetString(response);
                    dynamic obj = JsonConvert.DeserializeObject(responseString);


                    foreach (var ph in obj.summary.keyPhrases)
                    {
                        if (!Utilities.Helper.SensiumResultListContainsText(returnedPhrases, ph.text.ToString()))
                        {
                            SensiumResultPhrase phrase = new SensiumResultPhrase();
                            phrase.Text = ph.text.ToString();
                            phrase.Score = Double.Parse(ph.score.ToString());
                            phrase.Type = "url";

                            returnedPhrases.Add(phrase);
                        }
                    }

                    //Named entity extraction here
                    foreach (var ent in obj.entities)
                    {
                        SensiumResultPhrase phrase = new SensiumResultPhrase();
                        phrase.Text = ent.normalized.ToString();
                        phrase.Score = 0;

                        returnedPhrases.Add(phrase);
                    }


                }
                catch (WebException ex)
                {
                    //var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();

                    //dynamic obj = JsonConvert.DeserializeObject(resp);
                    //var messageFromServer = obj.error.message;

                }

                return returnedPhrases;
            }
        }
    }
        
}
