using OpenQA.Selenium.Remote;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SeleniumAutomation.Automation.Record
{
    public abstract class GeneralRun : IRecord
    {
        protected RemoteWebDriver _driver;

        public GeneralRun(RemoteWebDriver driver)
        {
            _driver = driver;
        }
        public abstract Hashtable GetRow(Hashtable row);

    }
}
