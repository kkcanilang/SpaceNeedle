using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace SeleniumAutomation.Selenium.Elements
{
    public class Button : SeleniumElement
    {
        public Button(RemoteWebDriver driver, string id): base(driver,id)
        {

        }
    
    }
}
