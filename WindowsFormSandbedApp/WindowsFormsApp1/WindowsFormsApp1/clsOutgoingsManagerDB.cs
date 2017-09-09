using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashPredictor
{
    public class clsOutgoingsManagerDB
    {
        public static DataSet LoadAllOutgoings()
        {
            // Load from test harness
            return (clsTestHarness.SetUpOutgoingsData());
        }
    }
}