using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashPredictor
{
    public static class clsParameters
    {
        private static int dayOfMonthPaid = 26;

        public static int DayOfMonthPaid { get => dayOfMonthPaid; set => dayOfMonthPaid = value; }

        static clsParameters()
        {
        }
    }
}