using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsOSContext
{
    public class Context
    {
        public string[] GetContext()
        {
            List<string> returnValue = new List<string>();

            #region WindowTitles

            //Titles of the open windows
            //take only the first part of a string seperated by - if existing
            //Windows sets the windows title like "Masterarbeit - Visual Studio"
            //the information which program it is, like VS oder IE is not important as it is not used

            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (process.MainWindowTitle.Contains("-"))
                    {
                        //returnValue.Add("Phrase;" + process.MainWindowTitle);
                        returnValue.Add("Phrase;" + process.MainWindowTitle.Split(new char[] { '-' })[0].Trim());
                        //Phrase;Outlook;
                    }
                    else
                    {
                        returnValue.Add("Phrase;" + process.MainWindowTitle);
                    }
                }
            }

            #endregion

            #region UserInformation

            //DEBUG: Take my name as username
            returnValue.Add("Phrase;Alexander Adelmann");
            //returnValue.Add("Phrase;" + System.Security.Principal.WindowsIdentity.GetCurrent().Name);

            #endregion

            return returnValue.ToArray();
        }
    }
}
