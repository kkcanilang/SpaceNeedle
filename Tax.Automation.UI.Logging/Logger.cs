using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax.Automation.UI.Logging
{
    public class Logger
    {
        public void LogInfo(string errorMessage)
        {
            if (!EventLog.SourceExists("Tax.Automation.UI"))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("Tax.Automation.UI", "TAX.ID");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");
                // The source is created.  Exit the application to allow it to be registered.
                return;
            }

            EventLog myLog = new EventLog();
            myLog.Source = "Tax.Automation.UI";

            // Write an informational entry to the event log.    
            myLog.WriteEntry(errorMessage,EventLogEntryType.Information);

        }

        public void LogError(string errorMessage)
        {
            if (!EventLog.SourceExists("Tax.Automation.UI"))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("Tax.Automation.UI", "TAX.ID");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");
                // The source is created.  Exit the application to allow it to be registered.
                return;
            }

            EventLog myLog = new EventLog();
            myLog.Source = "Tax.Automation.UI";

            // Write an informational entry to the event log.    
            myLog.WriteEntry(errorMessage, EventLogEntryType.Error);
        }
    }
}
