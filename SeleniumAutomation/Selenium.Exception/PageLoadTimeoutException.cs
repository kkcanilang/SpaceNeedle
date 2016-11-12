using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Selenium.Exception
{
    public class PageLoadTimeoutException : System.Exception
    {
        public PageLoadTimeoutException(string message) : base(message) { }
        public PageLoadTimeoutException(string message,System.Exception innerException) : base(message) { }

        public override string ToString()
        {
            return "Page Load Timeout.";
        }
    }
}
