using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Selenium.Elements
{
    public class TextField : SeleniumElement
    {
        public TextField(RemoteWebDriver driver, string id) : base(driver,id) { }

        public void Type(string message)
        {
            _driver.FindElementById(_id).SendKeys(message);
        }

        public void Clear()
        {
            _driver.FindElementById(_id).Clear();
        }


    }
}
