using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CashPredictor.Code
{
    public class OnIncludeInCalculationCheckboxArgs : EventArgs
    {
        private int mRecordID;
        public int RecordID { get => mRecordID; set => mRecordID = value; }

        public OnIncludeInCalculationCheckboxArgs(int recordID) : base()
        {
            RecordID = recordID;
        }
    }

    // Link here has some code on how to enable the events for checkboxes http://www.appliedcodelog.com/2015/07/working-on-issues-with-listview-in.html

    public class clsBankDebitsListViewAdapter : BaseAdapter<clsBankDebit>, View.IOnClickListener
    {
        private List<clsBankDebit> mItems;
        private Context mContext;
        private string mClassName;

        public event EventHandler<OnIncludeInCalculationCheckboxArgs> mOnIncudeInCalculationClicked;

        public clsBankDebitsListViewAdapter(Context context, List<clsBankDebit> items)
        {
            mItems = items;
            mContext = context;
            mClassName = this.GetType().Name;
        }

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override clsBankDebit this[int position]
        {
            get
            {
                return mItems[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.BankDebit_Row, null, false);
                if (!mItems[position].IncludeInCalculation)
                {
                    row = LayoutInflater.From(mContext).Inflate(Resource.Layout.BankDebit_Row, null, false);
                }
            }

            TextView txtID = row.FindViewById<TextView>(Resource.Id.txt_id);
            txtID.Text = mItems[position].ID.ToString();

            TextView txDescription = row.FindViewById<TextView>(Resource.Id.txtDescription);
            txDescription.Text = "" + mItems[position].Description + "";

            TextView txtAmount = row.FindViewById<TextView>(Resource.Id.txtAmount);
            txtAmount.Text = mItems[position].Amount.ToString("0.00");

            TextView txtDay = row.FindViewById<TextView>(Resource.Id.txtDayLeavesAccount);
            txtDay.Text = mItems[position].DayLeavesAccount.ToString() + HelperMethods.DaySuffix(mItems[position].DayLeavesAccount);

            CheckBox txtIncudeInCalculation = row.FindViewById<CheckBox>(Resource.Id.txtIncudeInCalculation);
            txtIncudeInCalculation.Checked = mItems[position].IncludeInCalculation;

            if (!mItems[position].IncludeInCalculation)
            {
                //row.(Android.Graphics.Color.Red);
            }

            // Set the tag so we can refernce the ID of the bank debit
            txtIncudeInCalculation.Tag = txtID.Text;

            // Set up the onClick listener
            txtIncudeInCalculation.SetOnClickListener(this);

            return row;
        }

        void View.IOnClickListener.OnClick(View v)
        {
            Console.WriteLine("[{0}] Tag data: [{1}]", mClassName, v.Tag);

            Int16 theID = Convert.ToInt16(v.Tag.ToString());

            // Console.WriteLine("Checked: {0}", v.FindViewById<CheckBox>(Resource.Id.txtIncudeInCalculation).Checked.ToString());
            // Console.WriteLine("ID: {0}", theID);

            // Set the checked item in the bank debits
            Console.WriteLine("[{0}] ID from mItems in : {1}", mClassName, mItems.Find(x => x.ID.Equals(theID)).ID.ToString());

            // Fire the event
            if (mOnIncudeInCalculationClicked != null)
            {
                mOnIncudeInCalculationClicked.Invoke(this, new OnIncludeInCalculationCheckboxArgs((int)theID));
            }
        }
    }
}