using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;
using SeleniumAutomation.Automation.Record;
using SeleniumAutomation.Selenium.Exception;
using System.Text;
using System.Collections;
using SeleniumAutomation.Automation.Run;
                                                        
namespace SeleniumAutomation
{
    public class Program
    {
        public static void Main(string[] args)
        {

            new SeattleLeadsCrawl().Run();
        }
    }
}
