using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Selenium.Elements
{
    public class Span : SeleniumElement
    {

        public Span(RemoteWebDriver driver, string id) : base(driver,id)
        {
            _driver = driver;
        }

        public Span TaxAccountSpan()
        {
            return new Span(_driver,_id);
        }

        public Span AccountStatusSpan()
        {
            return new Span(_driver, _id);
        }

        public Span MailAddressSpan()
        {
            return new Span(_driver, _id);
        }

        public Span PaymentStatusSpan()
        {
            return new Span(_driver, _id);
        }
    }
}
