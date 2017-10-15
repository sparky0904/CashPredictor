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
    internal class clsBankDebitsListViewAdapter : BaseAdapter<clsBankDebit>
    {
        private List<clsBankDebit> mItems;
        private Context mContext;

        public clsBankDebitsListViewAdapter(Context context, List<clsBankDebit> items)
        {
            mItems = items;
            mContext = context;
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
            }

            TextView txDescription = row.FindViewById<TextView>(Resource.Id.txtDescription);
            txDescription.Text = "[" + mItems[position].Description + "]";

            TextView txtAmount = row.FindViewById<TextView>(Resource.Id.txtAmount);
            txtAmount.Text = mItems[position].Amount.ToString("0.00");

            TextView txtDay = row.FindViewById<TextView>(Resource.Id.txtDayLeavesAccount);
            txtDay.Text = mItems[position].DayLeavesAccount.ToString() + HelperMethods.DaySuffix(mItems[position].DayLeavesAccount);

            CheckBox txtIncudeInCalculation = row.FindViewById<CheckBox>(Resource.Id.txtIncudeInCalculation);
            txtIncudeInCalculation.Checked = mItems[position].IncludeInCalculation;

            return row;
        }
    }
}