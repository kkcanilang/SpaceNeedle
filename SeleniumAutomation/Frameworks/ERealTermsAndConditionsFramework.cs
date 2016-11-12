using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using SeleniumAutomation.Selenium.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleniumAutomation.Frameworks
{
    public class ERealTermsAndConditionsFramework
    {
        private const string ACKNOWLDGE_CHECKBOX = "kingcounty_gov_cphContent_checkbox_acknowledge";

        private RemoteWebDriver _driver;

        private CheckBox _acknolledgeCheckBox;
        public ERealTermsAndConditionsFramework(RemoteWebDriver driver)
        {
            _driver = driver;
            _acknolledgeCheckBox = new CheckBox(_driver, ACKNOWLDGE_CHECKBOX);
        }

        public CheckBox AcknolledgementCheckBox()
        {
            return _acknolledgeCheckBox;
        }
    }
}
