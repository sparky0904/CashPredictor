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
    public partial class frmChangePayDay : Form
    {
        private Form callingForm;

        public frmChangePayDay()
        {
            InitializeComponent();
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            for (int i = 1; i <= 31; i++)
            {
                fldPayDay.Items.Add(i.ToString());
            }

            fldPayDay.SelectedItem = clsParameters.DayOfMonthPaid.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            clsParameters.DayOfMonthPaid = Convert.ToInt16(fldPayDay.SelectedItem.ToString());
            Program.OutgoingsManager.RefreshData();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}