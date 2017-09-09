using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashPredictor
{
    // Manager for the oputgoings
    public class clsOutgoingsManager
    {
        private DataSet Outgoings;

        // Constructor
        public clsOutgoingsManager()
        {
            // Load the outgoings into the Outgoings array
            Outgoings = clsOutgoingsManagerDB.LoadAllOutgoings();
        }

        public DataSet ReturnAll()
        {
            return Outgoings;
        }

        public clsOutgoing FindOutgoingByDescription(string SearchString)
        {
            clsOutgoing theOutgoing = new clsOutgoing();

            /*
             * foreach (clsOutgoing T in Outgoings)
            {
                if (T.Description == SearchString)
                {
                    theOutgoing = T;
                    return (theOutgoing);
                }
            }
            */

            return theOutgoing;
        }

        public double CalculateOutgoingsByDay(int currentDay)
        {
            double theTotal = 0;

            // cycle through all the days in the outgoings table/
            foreach (DataRow row in Outgoings.Tables["OutGoings"].Rows)
            {
                var xvalue = row["DayPaid"];
                int Day = Convert.ToInt32(xvalue);

                // add to total if they >= to current day
                if (Day >= currentDay)
                {
                    xvalue = row["Amount"];
                    theTotal += Convert.ToDouble(xvalue);
                }
            }

            return theTotal;
        }
    }
}