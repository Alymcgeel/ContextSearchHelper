using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Logger
    {
        public static void LogError(Exception ex)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                string message = String.Empty;

                message += ex.Message;
                message += Environment.NewLine + "StackTrace: " + ex.StackTrace + Environment.NewLine;

                if (ex.InnerException != null)
                {
                    message += Environment.NewLine + "InnerException: " + Environment.NewLine + ex.InnerException.Message;
                    message += Environment.NewLine + "StackTrace InnerException: " + ex.InnerException.StackTrace + Environment.NewLine;
                }


                eventLog.Source = "ContextSearchHelper";
                eventLog.WriteEntry(message, EventLogEntryType.Error, 234);

                
            } 
        }

        public static void LogError(string errmess)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "ContextSearchHelper";
                eventLog.WriteEntry(errmess, EventLogEntryType.Error, 234);
            } 
        }

        public static void LogInfo(string message)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "ContextSearchHelper";
                eventLog.WriteEntry(message, EventLogEntryType.Information, 234);
            } 
        }
    }
}
