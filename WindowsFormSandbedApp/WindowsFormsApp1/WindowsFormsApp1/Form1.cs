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
        public Form1()
        {
            InitializeComponent();
        }

        private void eventFormLoad(object sender, EventArgs e)
        {
            DataSet ds = Program.OutgoingsManager.ReturnAll();

            this.dataGridView1.DataSource = ds.Tables["OutGoingsList"];

            string theCurrentDay = DateTime.Now.Day.ToString();
            this.fldCurrentDay.SelectedItem = theCurrentDay;

            //this.dataGridView1.DataSource = Program.OutgoingsManager.ReturnAll();
            //this.dataGridView1.Sort(this.dataGridView1.Columns["Description"], ListSortDirection.Ascending);
        }

        private void btnPredictBalance_Click(object sender, EventArgs e)
        {
            // obtain the costs for the rest of the month
            int CurrentDay;
            CurrentDay = Convert.ToInt32(this.fldCurrentDay.SelectedItem.ToString());
            double theOutgoings = Program.OutgoingsManager.CalculateOutgoingsByDay(CurrentDay);

            // take from current balance
            double predictedBalance = Convert.ToDouble(this.fldBalance.Text.ToString()) - theOutgoings;

            // display info
            MessageBox.Show("Predicted Balance is - " + predictedBalance.ToString());
        }
    }
}