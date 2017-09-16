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
        private int payDay;

        // Constructor
        public clsOutgoingsManager()
        {
            // Load the outgoings into the Outgoings array
            // Outgoings = clsOutgoingsManagerDB.LoadAllOutgoings();
            clsOutgoingsManagerDB.InitaliseTheDataset();

            Outgoings = clsOutgoingsManagerDB.LoadAllOutgoings();
            payDay = clsParameters.DayOfMonthPaid;
        }

        public DataTable GetOutGoingsTable()
        {
            return Outgoings.Tables["Outgoings"];
        }

        public DataSet ReturnAll()
        {
            return Outgoings;
        }

        public void RefreshData()
        {
            // Outgoings = clsOutgoingsManagerDB.LoadAllOutgoings();
            Console.WriteLine("Have taken out the line to reload the data as it should now be coming from the static outgoings manager class in program namespace.");
            payDay = clsParameters.DayOfMonthPaid;
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

        public double CalculateOutgoingsByDay(DataTable theDataTable)
        {
            double theTotal = 0;

            // cycle through all the days in the outgoings table/
            foreach (DataRow row in theDataTable.Rows)
            {
                var xvalue = row["DayPaid"];
                int dayPaid = Convert.ToInt32(xvalue);

                xvalue = row["Amount"];
                theTotal += Convert.ToDouble(xvalue);
            }

            return theTotal;
        }
    }
}