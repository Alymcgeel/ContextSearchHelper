using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetExplorerContext
{
    public class Context
    {
        public string[] GetContext()
        {
            List<string> returnValue = new List<string>();

            SHDocVw.InternetExplorer browser;
            string myLocalLink;
            mshtml.IHTMLDocument2 myDoc;
            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
            string filename;
            foreach (SHDocVw.InternetExplorer ie in shellWindows)
            {
                filename = System.IO.Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                if ((filename == "iexplore"))
                {
                    browser = ie;
                    myDoc = browser.Document;
                    myLocalLink = myDoc.url;
                    returnValue.Add("URL;" + myLocalLink);
                }
            }

            return returnValue.ToArray();
        }
    }
}
