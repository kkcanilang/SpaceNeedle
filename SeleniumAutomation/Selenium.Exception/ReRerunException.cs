using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Selenium.Exception
{
    public class ReRerunException : System.Exception
    {
        public ReRerunException(string message) : base(message) { }
        public ReRerunException(string message, System.Exception innerException) : base(message) { }

        public override string ToString()
        {
            return "Exception triggers ReRun";
        }

    }
}
