using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


namespace SeleniumAutomation.Selenium.Elements
{
    public class XPathElement : SeleniumElement
    {

        public XPathElement(RemoteWebDriver driver, string id) : base(driver,id)
        {
        }
        public override void Click()
        {
            _driver.FindElementByXPath(_id).Click();
        }
        public override string Text()
        {
            IWebElement element = null;

            try
            {
                element = GetElement();
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
            return element.Text;
        }
        public override bool Displayed()
        {
            return _driver.FindElementByXPath(_id).Displayed;
        }
        public override bool Enabled()
        {
            return _driver.FindElementByXPath(_id).Enabled;
        }

        public override bool Exists()
        {
            bool exists = true;
            try
            {
                exists = _driver.FindElementByXPath(_id).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                exists = false;
            }
            return exists;
        }

        private IWebElement GetElement()
        {

            IWebElement element = null;
            try
            {
                element = _driver.FindElementById(_id);
            }
            catch (NoSuchElementException nse)
            {
                element = _driver.FindElementByXPath(_id);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.ToString());
            }

            return element;
        }


    }
}
