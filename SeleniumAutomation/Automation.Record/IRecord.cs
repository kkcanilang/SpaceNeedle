using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Automation.Record
{
    public interface IRecord
    {
        Hashtable GetRow(Hashtable row);
    }
}
