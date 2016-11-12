using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Selenium.Exception
{
    public class CaptachaExistsException : System.Exception
    {
        public CaptachaExistsException(string message) : base(message) { }
        public CaptachaExistsException(string message, System.Exception innerException) : base(message, innerException) { }

        public override string ToString()
        {
            return "Page Blocked by Captacha.";
        }

    }
}
