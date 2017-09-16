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
        // private DataSet OutgoingsDataSet;

        public static void InitaliseTheDataset() // Defualt Constructor
        {
            // Create the dataset
            // OutgoingsDataSet = CreateTheDataSet();
            CreateTheDataSet(ref Program.TheDataset);

            // Load the data into the dataset from the device
            LoadData();
        }

        // Create the schema and data set for the app
        // Done in memory to save speed as data items are small
        private static void CreateTheDataSet(DataSet theDataset)
        {
            // Create the data set
            // DataSet ds = new DataSet("Data");
            // DataSet ds = Program.TheDataset;

            // Create the Outgoings data table
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

            // Create the OutgoingsList data table
            DataTable outgoingsListTable = new DataTable("OutGoingsList");

            outgoingsListTable.Columns.Add("Description");
            outgoingsListTable.Columns[0].DataType = typeof(string);

            outgoingsListTable.Columns.Add("Amount");
            outgoingsListTable.Columns[1].DataType = typeof(float);

            outgoingsListTable.Columns.Add("DayPaid");
            outgoingsListTable.Columns[2].DataType = typeof(int);

            outgoingsListTable.Columns.Add("DateDue");
            outgoingsListTable.Columns[3].DataType = typeof(DateTime);

            // Add the data tables to the dataset

            // Add tables to the global dataset
            theDataset.Tables.Add(outgoingsTable);
            theDataset.Tables["OutGoings"].DefaultView.Sort = "Description";

            theDataset.Tables.Add(outgoingsListTable);
            theDataset.Tables["OutGoingsList"].DefaultView.Sort = "DayPaid";

            // return (ds);
        }

        public static DataSet LoadAllOutgoings()
        {
            // Load from test harness
            // return (clsTestHarness.SetUpOutgoingsData());

            return Program.TheDataset;
        }

        // Load the outgoings data from the device
        public static int LoadData()
        {
            DataSet theDataset = Program.TheDataset;
            DataTable theOutGoingsTable = theDataset.Tables["Outgoings"]; ;

            // We use XML to store the data
            int returnValue = 0;

            // create a file name to write to
            string filename = "OutgoingsDataXML.xml";

            // Create the filestream to write with
            System.IO.FileStream stream = new System.IO.FileStream(filename, System.IO.FileMode.Open);

            // Write to the file with the WriteXML method
            theOutGoingsTable.ReadXml(stream);

            // Copy the data to the OutGoings Dataset
            foreach (DataRow row in theOutGoingsTable.Rows)
            {
                theDataset.Tables["Outgoings"].Rows.Add(row);
            }

            return returnValue;
        }

        public static int SaveData(DataTable theOutGoingsTable)
        {
            if (theOutGoingsTable == null)
            {
                Console.WriteLine("Trying to save outgoings, however the table supplied is null.");
                return -1;
            }

            int returnValue = 0;

            // create a file name to write to
            string filename = "OutgoingsDataXML.xml";

            // Create the filestream to write with
            System.IO.FileStream stream = new System.IO.FileStream(filename, System.IO.FileMode.Create);

            // Write to the file with the WriteXML method
            theOutGoingsTable.WriteXml(stream);

            return returnValue;
        }
    }
}