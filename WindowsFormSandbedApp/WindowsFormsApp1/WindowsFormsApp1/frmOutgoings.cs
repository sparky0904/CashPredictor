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
        private bool creatingNewEntry = false;

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

            //fldOutgoings.DataSource = Program.OutgoingsManager.GetOutGoingsTable();
            //fldOutgoings.DisplayMember = "Description";

            creatingNewEntry = false;
            isEditingForm = false;
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
            creatingNewEntry = false;
            isEditingForm = false;

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

        private int SaveSingleRecord()
        {
            int returnValue = 0;

            // Check if were updtaing an exisiting record
            if (creatingNewEntry)
            {
                // New record
                // Insert a new record

                // Create an instance of the DataSet:
                DataSetv1 myDataSet = new DataSetv1();

                // To add a row we first need a strongly typed row object.
                //The only difficult thing about creating a row is working out exactly what the method is that creates the row object. In general, while the row data type belongs to the DataSet, the creation method belongs to the table that the row belongs to
                // DataSetv1.OutGoingsRow row = myDataSet.OutGoings.NewOutGoingsRow();
                DataSetv1.OutGoingsRow row = dataSetv1.OutGoings.NewOutGoingsRow();

                // Now we can add the data
                row.Description = this.fldDescription.Text;
                row.Amount = Convert.ToDouble(this.fldAmount.Text);
                row.DayPaid = Convert.ToInt16(this.fldDayPaid.SelectedValue);
                row.ReOccuring = Convert.ToBoolean(this.fldReoccuring.Checked);
                row.DayOfWeekPaid = Convert.ToInt16(this.fldDayOfWeekPaid.SelectedIndex);
                row.Frequency = Convert.ToInt16(this.fldFrequency.Text);

                // save the row to the dataset
                // myDataSet.OutGoings.Rows.Add(row);

                dataSetv1.OutGoings.Rows.Add(row);

                myDataSet.AcceptChanges();

                SaveDataToDataSet();
            }
            else
            {
                // We are updating an exisitn record

                // Update exisiting row in dataset
            }

            return returnValue;
        }

        private int SaveDataToDataSet()
        {
            return (clsOutgoingsManagerDB.SaveData());
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
            SaveSingleRecord();
            dataTableisDirty = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Lets ask if they want to save before they exit
            bool saveData = true;

            // if we have changed some data or we are editing then dont exit form
            // we need ask if we are saving the data
            if (formIsDirty || isEditingForm)
            {
                // set flags
                isEditingForm = false;
                formIsDirty = false;
                creatingNewEntry = false;

                MessageBox.Show("Changes  made would you like to save?");

                //TODO: Set up Save data on outgoings form if we cancel
            }

            if (dataTableisDirty)
            {
                // Data table has changed so save changes to the local XML file
                if (SaveSingleRecord() == 0)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Set up flags
            isEditingForm = true;
            creatingNewEntry = true;

            // Set up buttons

            // Clear fields
        }

        #endregion Form Events

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void dataSetv1BindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }
    }
}