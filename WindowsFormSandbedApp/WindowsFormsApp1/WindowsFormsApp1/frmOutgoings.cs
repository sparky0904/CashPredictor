using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashPredictor
{
    public partial class frmOutgoings : Form
    {
        private string[] DaysOfWeek = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        private bool isDirty = false;

        public frmOutgoings()
        {
            InitializeComponent();
        }

        private void SetupForm()
        {
            // Set up dropdowns
            for (int i = 0; i <= 31; i++)
            {
                fldDayPaid.Items.Add(i.ToString());
            }

            fldDayOfWeekPaid.Items.Add("Sunday");
            fldDayOfWeekPaid.Items.Add("Monday");
            fldDayOfWeekPaid.Items.Add("Tuesday");
            fldDayOfWeekPaid.Items.Add("Wednesday");
            fldDayOfWeekPaid.Items.Add("Thursday");
            fldDayOfWeekPaid.Items.Add("Friday");
            fldDayOfWeekPaid.Items.Add("Saturday");

            fldOutgoings.DataSource = Program.OutgoingsManager.GetOutGoingsTable();
            fldOutgoings.DisplayMember = "Description";
        }

        // Refresh the fields so they represent the clicked entry in the list
        private void RefreshFields()
        {
            fldDayPaid.Enabled = true;
            fldDayOfWeekPaid.Enabled = true;
            fldFrequency.Enabled = true;

            // Find and Load the clsOutgoing record
            string selectedItem = fldOutgoings.GetItemText(fldOutgoings.SelectedItem);
            clsOutgoing theOutgoing = new clsOutgoing();

            DataTable OutgoingsTable = Program.OutgoingsManager.GetOutGoingsTable();
            foreach (DataRow row in OutgoingsTable.Rows)
            {
                if ((string)row["Description"] == selectedItem)
                {
                    theOutgoing = new clsOutgoing(
                    (string)row["Description"], (float)row["Amount"], (int)row["DayPaid"], (bool)row["ReOccuring"], (int)row["DayOfWeekPaid"], (int)row["Frequency"]);
                    break;
                }
            }

            // Update the fields
            fldDescription.Text = theOutgoing.Description;
            fldDayPaid.SelectedItem = theOutgoing.DayLeaveAccount.ToString();
            fldAmount.Text = theOutgoing.Amount.ToString();
            fldReoccuring.Checked = theOutgoing.ReOccuring;
            fldDayOfWeekPaid.SelectedItem = DaysOfWeek[theOutgoing.DayOfWeekPaid];
            fldFrequency.Text = theOutgoing.Frequency.ToString();
        }

        private void UpdateFieldsAfterReoccuringSelectionChanged()
        {
            if (fldReoccuring.Checked)
            {
                fldDayPaid.Enabled = false;
                fldDayOfWeekPaid.Enabled = true;
                fldFrequency.Enabled = true;
            }
            else
            {
                fldDayOfWeekPaid.Enabled = false;
                fldFrequency.Enabled = false;
                fldDayPaid.Enabled = true;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetupForm();
        }

        private void onActiviated(object sender, EventArgs e)
        {
            RefreshFields();
            UpdateFieldsAfterReoccuringSelectionChanged();
        }

        private void onSelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFields();
            UpdateFieldsAfterReoccuringSelectionChanged();
        }

        private void onCheckedChange(object sender, EventArgs e)
        {
            UpdateFieldsAfterReoccuringSelectionChanged();
        }
    }
}