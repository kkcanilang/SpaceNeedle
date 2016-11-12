using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomation.Frameworks;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;

namespace PKITA.Online.Test.Automation
{
    [TestClass]
    public class PKITAOnlineTests
    {
        private PKITAOnlineSplashPageFramework pkitaOnlineSplashPageFramework;
        private PKITAOnlineRequestSearchFramework pkitaOnlineRequestSearchFramework;

        private RemoteWebDriver _driver;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new InternetExplorerDriver(@"C:\Users\v-krcani\Documents\Work\");

            pkitaOnlineSplashPageFramework = new PKITAOnlineSplashPageFramework(_driver);
            pkitaOnlineRequestSearchFramework = new PKITAOnlineRequestSearchFramework(_driver);


        }

        [TestMethod]
        public void SpashPageElementsExistsTest()
        {
            _driver.Navigate().GoToUrl("https://cpst1pkiweb.redmond.corp.microsoft.com/PKITAWeb/");

            //pkitaOnlineSplashPageFramework.SearchRequestTile.Click();

            Assert.IsTrue(pkitaOnlineSplashPageFramework.SearchRequestTile.Exists());
            Assert.IsTrue(pkitaOnlineSplashPageFramework.SearchCertificateTile.Exists());
            Assert.IsTrue(pkitaOnlineSplashPageFramework.SubmissionErrorsTile.Exists());
            Assert.IsTrue(pkitaOnlineSplashPageFramework.UserRolesTile.Exists());
            Assert.IsTrue(pkitaOnlineSplashPageFramework.CertificateAuthorityGroupsTile.Exists());
            Assert.IsTrue(pkitaOnlineSplashPageFramework.PendingApprovalTile.Exists());
            Assert.IsTrue(pkitaOnlineSplashPageFramework.CertificateTemplatesTile.Exists());

            
        }

        [TestMethod]
        public void NavigateToCertificateTest()
        {
            _driver.Navigate().GoToUrl("https://cpst1pkiweb.redmond.corp.microsoft.com/PKITAWeb/");

            pkitaOnlineSplashPageFramework.SearchRequestTile.Click();

            Assert.IsTrue(pkitaOnlineRequestSearchFramework.LaneSelect.Exists());
            Assert.IsTrue(pkitaOnlineRequestSearchFramework.SrNumberTextField.Exists());
            Assert.IsTrue(pkitaOnlineRequestSearchFramework.SubmittedFromDateTextField.Exists());
            Assert.IsTrue(pkitaOnlineRequestSearchFramework.SubmittedFromTimeTextfield.Exists());
            Assert.IsTrue(pkitaOnlineRequestSearchFramework.DescriptionTextField.Exists());
            Assert.IsTrue(pkitaOnlineRequestSearchFramework.SubmitedToTimeTextField.Exists());
            Assert.IsTrue(pkitaOnlineRequestSearchFramework.SubmittedFromDateTextField.Exists());
            Assert.IsTrue(pkitaOnlineRequestSearchFramework.SubmittedByTextField.Exists());
            Assert.IsTrue(pkitaOnlineRequestSearchFramework.RequestStatusSelect.Exists());
            Assert.IsTrue(pkitaOnlineRequestSearchFramework.SearchButton.Exists());
          
        }

        [TestMethod]
        public void SearchRequestTest()
        {
            _driver.Navigate().GoToUrl("https://cpst1pkiweb.redmond.corp.microsoft.com/PKITAWeb/Search/Requests");

            pkitaOnlineRequestSearchFramework.SrNumberTextField.Type("AOCON-1653570");
            pkitaOnlineRequestSearchFramework.SubmittedFromDateTextField.Clear();
            pkitaOnlineRequestSearchFramework.SubmittedFromDateTextField.Type("07/03/2016");
            pkitaOnlineRequestSearchFramework.SearchButton.Click();
            Assert.AreEqual(pkitaOnlineRequestSearchFramework.SrNumberTextField.Text(), "");

        }

        [TestMethod]
        public void SearchBySubmittedByTest()
        {
            _driver.Navigate().GoToUrl("https://cpst1pkiweb.redmond.corp.microsoft.com/PKITAWeb/Search/Requests");

            pkitaOnlineRequestSearchFramework.SubmittedByTextField.Clear();
            pkitaOnlineRequestSearchFramework.SubmittedByTextField.Type(@"Redmond\pkitasbt");
            pkitaOnlineRequestSearchFramework.SubmittedFromDateTextField.Clear();
            pkitaOnlineRequestSearchFramework.SubmittedFromDateTextField.Type("07/03/2016");
            pkitaOnlineRequestSearchFramework.SearchButton.Click();



        }






        [TestCleanup]
        public void CleanUp()
        {
            _driver.Close();
            _driver.Quit();
            
        }
    }
}
