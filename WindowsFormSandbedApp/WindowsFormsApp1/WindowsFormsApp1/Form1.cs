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
    public partial class Form1 : Form
    {
        private DataSet ds;
        private DataTable outgoingsListDataTable;
        private frmChangePayDay ChangePayDayForm;
        private frmOutgoings OutGoingsForm;

        public Form1()
        {
            InitializeComponent();
            ChangePayDayForm = new frmChangePayDay();
            OutGoingsForm = new frmOutgoings();
        }

        private void eventFormLoad(object sender, EventArgs e)
        {
            SetUpForm();
        }

        private void btnPredictBalance_Click(object sender, EventArgs e)
        {
            CalaculateAndUpdatePredictedBalance();
        }

        private void CalaculateAndUpdatePredictedBalance()
        {
            // obtain the costs for the rest of the month
            double theOutgoings = Program.OutgoingsManager.CalculateOutgoingsByDay(outgoingsListDataTable);

            // take from current balance
            double predictedBalance = Convert.ToDouble(this.fldBalance.Text.ToString()) - theOutgoings;

            this.fldPredictedBalanceLabel.Text = "£" + predictedBalance;

            // display info
            // MessageBox.Show("Predicted Balance is - " + predictedBalance.ToString());
        }

        private void btnChangePayDay_Click(object sender, EventArgs e)
        {
            ChangePayDayForm.ShowDialog();
        }

        private void SetUpForm()
        {
            ds = Program.OutgoingsManager.ReturnAll();
            outgoingsListDataTable = ds.Tables["OutGoingsList"];

            // Set the data grid source
            this.dataGridView1.DataSource = outgoingsListDataTable;

            // Select today in the day drop down box
            string theCurrentDay = DateTime.Now.Day.ToString();
            this.fldCurrentDayLabel.Text = "Today is the" + theCurrentDay;

            // Set the pay day text
            this.fldPayDayText.Text = "Pay day is the " + clsParameters.DayOfMonthPaid.ToString();
        }

        private void RefreshDataSources()
        {
            this.dataGridView1.Refresh();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
        }

        private void onActivated(object sender, EventArgs e)
        {
            SetUpForm();
            RefreshDataSources();
            CalaculateAndUpdatePredictedBalance();
        }

        private void btnUpdateOutgoings_Click(object sender, EventArgs e)
        {
            OutGoingsForm.Show();
        }
    }
}