using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Selenium.Elements
{
    public class Anchor : SeleniumElement
    {
        public Anchor(RemoteWebDriver driver, string id) : base(driver,id)
        {

        }

        public override void Click()
        {
            _driver.FindElementByLinkText(_id).Click();
        }
    }
}
