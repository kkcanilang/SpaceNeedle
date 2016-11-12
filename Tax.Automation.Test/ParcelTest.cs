using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using SeleniumAutomation.Frameworks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Tax.Automation.Test
{
    [TestClass]
    public class ParcelTest
    {
        private RemoteWebDriver _driver;

        private ERealTermsAndConditionsFramework _eRealTermsAndCondition;
        private ERealPropertySearchFramework _eRealPropertySearchFramework;
        private ERealPropertyDetailsFramework _eRealPropertyDetailsFramework;

        [TestInitialize]
        public void SetUp()
        {

        }

        [TestMethod]
        public void GoToERealPropertyPageSearchParcel()
        {





        }

        [TestCleanup]
        public void ClearUp()
        {
            _driver.Quit();
        }
    }
}
