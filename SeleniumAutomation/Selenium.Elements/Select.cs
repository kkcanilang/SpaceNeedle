using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Selenium.Elements
{
    public class Select : SeleniumElement
    {
        private SelectElement _selectElement; 
        public Select(RemoteWebDriver driver, string id) : base(driver,id)
        {
            
        }

        public void SetValue(string value)
        {
            _selectElement = new SelectElement(_driver.FindElementByXPath(_id));

            _selectElement.SelectByValue(value);
        }
    }
}
