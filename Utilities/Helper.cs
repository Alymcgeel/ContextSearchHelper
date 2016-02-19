using Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Utilities
{
    public static class Helper
    {
        public static string GetBase64ImageByName(string name)
        {
            String Image = String.Empty;

            var xml = XDocument.Load(@"C:\Users\Administrator\Desktop\Master_Arbeit\Files\Icons.xml");

            Image = (from c in xml.Root.Descendants("Icon")
                        where c.Attribute("Name").ToString().ToLower().Contains(name.ToLower())
                        select c.Value).First();


            Image.Replace("rn", String.Empty);
            Image.Replace(" ", String.Empty);
            return Image;
        }

        public static bool SensiumResultListContainsText(List<SensiumResultPhrase> sensiumResults, string text)
        {
            foreach(SensiumResultPhrase sen in sensiumResults)
            {
                if(sen.Text == text)
                {
                    return true;
                }
            }

            return false;
        }

        public static string[] GetStringArrayFromSensiumResultSetList(List<SensiumResultPhrase> resultlist)
        {
            List<string> toreturn = new List<string>();

            foreach(SensiumResultPhrase sensphrase in resultlist)
            {
                if (sensphrase != null)
                {
                    toreturn.Add(sensphrase.Text);
                }
            }

            return toreturn.ToArray();
        }

        public static string[] GetStringArrayFromSearchResultSetList(List<SearchResult> resultlist)
        {
            List<string> toreturn = new List<string>();

            foreach (SearchResult sensphrase in resultlist)
            {
                if (sensphrase != null)
                {
                    toreturn.Add(sensphrase.Path);
                }
            }

            return toreturn.ToArray();
        }

        public static string ReturnConcattedString(string[] input, string concatChar = ";")
        {
            string returnvalue = string.Empty;

            foreach(string inp in input)
            {
                returnvalue += inp + concatChar;
            }

            if(input.Length > 0)
            {
                returnvalue = returnvalue.Substring(0, returnvalue.Length - concatChar.Length);
            }

            return returnvalue;
        }

        //This function is taken from the MSDN :
        //https://msdn.microsoft.com/en-us/library/office/ff462097.aspx
        public static Outlook.Application GetApplicationObject()
        {

            Outlook.Application application = null;

            // Check if there is an Outlook process running. 
            if (Process.GetProcessesByName("OUTLOOK").Count() > 0)
            {
                try
                {
                    // If so, use the GetActiveObject method to obtain the process and cast it to an Application object. 
                    application = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
                }
                catch
                {
                    //log to windows logs
                    application = new Outlook.Application();
                    Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");
                    nameSpace.Logon("", "", false, Missing.Value);
                    nameSpace = null;
                }

            }
            else
            {

                // If not, create a new instance of Outlook and log on to the default profile. 
                application = new Outlook.Application();
                Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");
                nameSpace.Logon("", "", false, Missing.Value);
                nameSpace = null;
            }

            // Return the Outlook Application object. 
            return application;
        }

        public static List<string> GetListChanges(HashSet<string> list1, HashSet<string> list2)
        {
            return list1.Except(list2).ToList<string>();
        }

        public static string StringArrayToString(string[] array)
        {
            string toreturn = String.Empty;

            for(int i = 0; i < array.Length; i++)
            {
                toreturn += array[i];
            }

            return toreturn;
        }
    }
}
