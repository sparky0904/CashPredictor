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
        // Set up soe test data
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

            outgoingsTable.Rows.Add("Mortage", 650, 1, 0, 0, 0);
            outgoingsTable.Rows.Add("Santander Credit", 200, 1, 0, 0, 0);
            outgoingsTable.Rows.Add("EE - Georgie", 37, 23, 0, 0, 0);
            outgoingsTable.Rows.Add("Loan - Car", 275, 1, 0, 0, 0);
            outgoingsTable.Rows.Add("WMBC", 125, 11, 0, 0, 0);
            outgoingsTable.Rows.Add("British Gas", 169, 9, 0, 0, 0);
            outgoingsTable.Rows.Add("Pocket Money", 70, 0, 1, 6, 7);
            outgoingsTable.Rows.Add("Petrol", 60, 0, 1, 6, 14);

            // Create the table of the full outgoings list
            // This will cycle through the Outgoings and repeat any that are reoccuring
            DataTable outgoingsListTable = new DataTable("OutGoingsList");

            outgoingsListTable.Columns.Add("Description");
            outgoingsListTable.Columns[0].DataType = typeof(string);

            outgoingsListTable.Columns.Add("Amount");
            outgoingsListTable.Columns[1].DataType = typeof(float);

            outgoingsListTable.Columns.Add("DayPaid");
            outgoingsListTable.Columns[2].DataType = typeof(int);

            // cycle through the rows in the outgoings table
            foreach (DataRow row in outgoingsTable.Rows)
            {
                // Create clsOutgoing
                clsOutgoing outGoing = new clsOutgoing(
                    (string)row["Description"], (float)row["Amount"], (int)row["DayPaid"], (bool)row["ReOccuring"], (int)row["DayOfWeekPaid"], (int)row["Frequency"]);

                // If not reoccuring then add to the list
                if (Convert.ToBoolean(row["ReOccuring"]))
                {
                    // If reoccuring calculate how many left until end of month and add these to the
                    int CurrentDay = DateTime.Now.Day;
                    int CurrentDayOfWeek = (int)DateTime.Now.DayOfWeek;
                }
                else
                {
                    outgoingsListTable.Rows.Add(outGoing.Description, outGoing.Amount, outGoing.DayLeaveAccount);
                }
            }

            DataSet ds = new DataSet("Data");
            ds.Tables.Add(outgoingsTable);
            ds.Tables["OutGoings"].DefaultView.Sort = "Description";

            ds.Tables.Add(outgoingsListTable);
            ds.Tables["OutGoingsList"].DefaultView.Sort = "DayPaid";

            return (ds);
        }
    }
}