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
        public frmOutgoings()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetupForm();
        }

        private void SetupForm()
        {
            // Set up dropdowns
            for (int i = 1; i <= 31; i++)
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
    }
}