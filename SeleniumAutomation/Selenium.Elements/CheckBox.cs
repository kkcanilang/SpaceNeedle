using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Selenium.Elements
{
    public class CheckBox : SeleniumElement
    {

        public CheckBox(RemoteWebDriver driver, string id) : base(driver,id)
        {
        }

        public void Check()
        {
            Click();
        }

    }
}
