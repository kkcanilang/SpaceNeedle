using SeleniumAutomation.Selenium.Elements;
using SeleniumAutomation.Selenium.Exception;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomation.Selenium.Utilities
{
    public class GeneralUntilities
    {

        public static void KillAllBrowsersAndWebDrivers()
        {
            var webDrivers = Process.GetProcessesByName("IEDriverServer").Select(p => p.Id);
            var browsers = Process.GetProcessesByName("iexplore").Select(p => p.Id);
            var processIds = webDrivers.Concat(browsers);
            foreach (var pid in processIds)
            {
                Process.GetProcessById(pid).Kill();
            }
        }
        public static void Wait(SeleniumElement element, int timeout)
        {
            int seconds = 0;
            while (!element.Exists())
            {
                Thread.Sleep(1000);
                seconds++;
                if (seconds > timeout) {
                    throw new PageLoadTimeoutException("Page Load Timeout.");
                }
            }
        }
    }
}
