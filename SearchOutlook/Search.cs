using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace SearchOutlook
{
    public class Search
    {
        public string[] DoSearch(string[] phrases)
        {
            List<string> result = new List<string>();

            Outlook.Application app = GetApplicationObject();
            NameSpace ns = app.GetNamespace("MAPI");
            ns.Logon(null, null, false, false);
            Outlook.MAPIFolder emailFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
            var folders = ns.Folders;

            string filter = @"@SQL=(";

            for (int i = 0; i < phrases.Count(); i++)
            {
                filter += @"""urn:schemas:httpmail:subject"" LIKE '%" + phrases[i].Replace("'", "''") + @"%' OR ""urn:schemas:httpmail:body"" LIKE '%" + phrases[i].Replace("'", "''") + @"%' OR ""urn:schemas:httpmail:from"" LIKE '%" + phrases[i].Replace("'", "''") + @"%'  OR ""urn:schemas:httpmail:sender"" LIKE '%" + phrases[i].Replace("'", "''") + @"%'";

                if (i != phrases.Count() - 1)
                {
                    filter += " OR ";
                }
            }

            filter += ")";

            int cnt = 0;
          
            Outlook.Items restrictedItems = emailFolder.Items.Restrict(filter);


            foreach (Outlook.MailItem item in restrictedItems)
            {
                try
                {
                    if (cnt == 30)
                    {
                        break;
                    }

                    result.Add("mail" + item.EntryID + ";1;" + item.Subject + " from " + item.Sender.Address + " on " + item.ReceivedTime);
                    cnt++;
                }
                catch(System.Exception ex)
                {
                    //silent catch if entry fails...
                }
            }

            Outlook.MAPIFolder folderContacts = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
            Outlook.Items searchFolder = folderContacts.Items;
            foreach (Outlook.ContactItem foundContact in searchFolder)
            {
                if (foundContact.LastName.Contains(phrases[0]))
                {
                }
            }


            return result.ToArray();
        }



        Outlook.Application GetApplicationObject()
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
                    nameSpace.Logon("", "", Missing.Value, Missing.Value);
                    nameSpace = null;
                }

            }
            else
            {

                // If not, create a new instance of Outlook and log on to the default profile. 
                application = new Outlook.Application();
                Outlook.NameSpace nameSpace = application.GetNamespace("MAPI");
                nameSpace.Logon("", "", Missing.Value, Missing.Value);
                nameSpace = null;
            }

            // Return the Outlook Application object. 
            return application;
        }


    }
}
