using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace CashPredictor
{
    public class clsTestHarness
    {
        // Set up some test data
        public static DataSet SetUpOutgoingsData()
        {
            // Set up some outgoings
            DataTable outgoingsTable = new DataTable("OutGoings");

            outgoingsTable.Columns.Add("Description");
            outgoingsTable.Columns[0].DataType = typeof(string);

            outgoingsTable.Columns.Add("Amount");
            outgoingsTable.Columns[1].DataType = typeof(float);

            outgoingsTable.Columns.Add("DayPaid");
            outgoingsTable.Columns[2].DataType = typeof(int);

            outgoingsTable.Columns.Add("ReOccuring");
            outgoingsTable.Columns[3].DataType = typeof(bool);

            outgoingsTable.Columns.Add("DayOfWeekPaid");
            outgoingsTable.Columns[4].DataType = typeof(int);

            outgoingsTable.Columns.Add("Frequency");
            outgoingsTable.Columns[5].DataType = typeof(int);

            DateTime defaultDate = DateTime.Now;

            outgoingsTable.Rows.Add("Mortage", 650, 1, 0, 0, 0);
            outgoingsTable.Rows.Add("Santander Credit", 200, 1, 0, 0, 0);
            outgoingsTable.Rows.Add("EE - Georgie", 37, 23, 0, 0, 0);
            outgoingsTable.Rows.Add("Loan - Car", 275, 1, 0, 0, 0);
            outgoingsTable.Rows.Add("WMBC", 125, 11, 0, 0, 0);
            outgoingsTable.Rows.Add("British Gas", 169, 9, 0, 0, 0);
            outgoingsTable.Rows.Add("Pocket Money", 70, 0, 1, 6, 7);
            outgoingsTable.Rows.Add("Petrol", 60, 0, 1, 0, 14);

            // Create the table of the full outgoings list
            // This will cycle through the Outgoings and repeat any that are reoccuring
            DataTable outgoingsListTable = new DataTable("OutGoingsList");

            outgoingsListTable.Columns.Add("Description");
            outgoingsListTable.Columns[0].DataType = typeof(string);

            outgoingsListTable.Columns.Add("Amount");
            outgoingsListTable.Columns[1].DataType = typeof(float);

            outgoingsListTable.Columns.Add("DayPaid");
            outgoingsListTable.Columns[2].DataType = typeof(int);

            outgoingsListTable.Columns.Add("DateDue");
            outgoingsListTable.Columns[3].DataType = typeof(DateTime);

            DateTime currentDate = DateTime.Now;

            int payDay = clsParameters.DayOfMonthPaid;
            // check if PayDay is greater than the number of days in month, if so make it the same so we do not get errors
            if (DateTime.DaysInMonth(currentDate.Year, currentDate.Month) < payDay)
            {
                payDay = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            }

            // check to see if pay day is actually next month, i..e paid pn 16th and it is the 20th when we are checking.
            bool PayDayIsNextMonth = currentDate.Day > payDay ? true : false;

            // cycle through the rows in the outgoings table
            foreach (DataRow row in outgoingsTable.Rows)
            {
                // Create clsOutgoing
                clsOutgoing outGoing = new clsOutgoing(
                    (string)row["Description"], (float)row["Amount"], (int)row["DayPaid"], (bool)row["ReOccuring"], (int)row["DayOfWeekPaid"], (int)row["Frequency"]);

                currentDate = DateTime.Now;

                if (Convert.ToBoolean(row["ReOccuring"]))
                {
                    // If reoccuring calculate how many left until end of month and add these to the
                    int currentDayOfWeek = (int)DateTime.Now.DayOfWeek;
                    if (PayDayIsNextMonth) // set the payday to end last day in month, will reset when we move to next month
                    {
                        payDay = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
                    }

                    // start loop from current day and increment up to pay day
                    for (int i = currentDate.Day; i <= payDay; i++)
                    {
                        // check if if the day = the DayOfWeek paid
                        DateTime newDate = new DateTime(currentDate.Year, currentDate.Month, i);
                        if (outGoing.DayOfWeekPaid == (int)newDate.DayOfWeek)
                        {
                            Console.WriteLine("Adding recocuring line to Outgoing lists Descr {0} - {1} - {2}.", outGoing.Description, outGoing.DayOfWeekPaid, outGoing.Amount);
                            outgoingsListTable.Rows.Add(outGoing.Description, outGoing.Amount, i, newDate);
                        }

                        // If pay date is next month and day is last day of this month then increase month and set day back to 1
                        if (PayDayIsNextMonth)
                        {
                            // check if last day of month
                            if (isLastDayInMonth(currentDate, i))
                            {
                                // Increase Month and also set day back to 1
                                Console.WriteLine("Last Day in month check has triggered");
                                currentDate = currentDate.AddMonths(1);
                                currentDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                                payDay = clsParameters.DayOfMonthPaid;
                                i = 0;
                            }
                        }

                        // If so add to the table
                    }

                    // End loop
                }
                else
                {
                    // If not reoccuring then add to the list
                    if (PayDayIsNextMonth)
                    {
                        if (outGoing.DayLeaveAccount <= payDay)
                        {
                            outgoingsListTable.Rows.Add(outGoing.Description, outGoing.Amount, outGoing.DayLeaveAccount, currentDate);
                        }
                    }
                    else
                    {
                        if (outGoing.DayLeaveAccount >= currentDate.Day)
                        {
                            outgoingsListTable.Rows.Add(outGoing.Description, outGoing.Amount, outGoing.DayLeaveAccount, currentDate);
                        }
                    }
                }
            }

            DataSet ds = new DataSet("Data");
            ds.Tables.Add(outgoingsTable);
            ds.Tables["OutGoings"].DefaultView.Sort = "Description";

            ds.Tables.Add(outgoingsListTable);
            ds.Tables["OutGoingsList"].DefaultView.Sort = "DayPaid";

            return (ds);
        }

        private static bool isLastDayInMonth(DateTime DateToCheck, int dayToCheck)
        {
            int daysInMonth = DateTime.DaysInMonth(DateToCheck.Year, DateToCheck.Month);

            return dayToCheck >= daysInMonth;
        }
    }
}