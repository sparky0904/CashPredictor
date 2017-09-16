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
        private bool formIsDirty = false;
        private bool dataTableisDirty = false;
        private bool isEditingForm = false;

        private DataTable OutgoingsTable = Program.OutgoingsManager.GetOutGoingsTable();

        public frmOutgoings()
        {
            InitializeComponent();
        }

        #region Form Methods

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
            btnCancel.Text = "Exit";
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

        private void LoadData()
        {
        }

        private int SaveData()
        {
            return (clsOutgoingsManagerDB.SaveData(OutgoingsTable));
        }

        private void OnFormDataHAsChanged()
        {
            formIsDirty = true;
            isEditingForm = true;
            btnCancel.Text = "Cancel";
        }

        #endregion Form Methods

        #region Form Events

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // TODO: Add save option on Outgoings form
            dataTableisDirty = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (formIsDirty)
            {
                // Form data has changed
                // Lets ask if they want to save before they exit
            }

            if (dataTableisDirty)
            {
                // Data table has changed so save changes to the local XML file
                if (SaveData() == 0)
                {
                    this.Close();
                }
                else
                {
                    // data did not save so report error then close form gracefully
                }
            }
        }

        private void fldReoccuring_OnCheckedChange(object sender, EventArgs e)
        {
            UpdateFieldsAfterReoccuringSelectionChanged();
        }

        #endregion Form Events
    }
}