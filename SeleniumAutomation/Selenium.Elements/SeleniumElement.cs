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
    public abstract class SeleniumElement
    {
        protected RemoteWebDriver _driver;
        protected string _id;
        public SeleniumElement(RemoteWebDriver driver,string id)
        {
            _driver = driver;
            _id = id;
        }

        public virtual void Click()
        {
            IWebElement element = GetElement();
            element.Click();
        }
        public virtual string Text()
        {
            IWebElement element = null;

            try
            {
                element = GetElement();
            }
            catch (System.Exception ex)
            {
                return string.Empty;
            }
            return element.Text;
        }
        public virtual bool Displayed()
        {

            return _driver.FindElementById(_id).Displayed;
        }
        public virtual bool Enabled()
        {
           
            return _driver.FindElementById(_id).Enabled;
        }

        public virtual bool Exists()
        {
            bool exists = true;
            try
            {
               exists =  _driver.FindElementById(_id).Displayed;
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
                throw new NoSuchElementException("The element: " + _id + " Does Not Exist");
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.ToString());
            }

            return element; 

        }

        public RemoteWebDriver Driver
        {
               get { return _driver; }
        }

        public string Id
        {
            get { return _id; }
        }

    }
}

