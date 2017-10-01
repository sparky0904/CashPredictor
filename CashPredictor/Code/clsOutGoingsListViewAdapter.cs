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
    internal class clsOutGoingsListViewAdapter : BaseAdapter<clsOutgoing>
    {
        private List<clsOutgoing> mItems;
        private Context mContext;

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public clsOutGoingsListViewAdapter(Context context, List<clsOutgoing> items)
        {
            mItems = items;
            mContext = context;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override clsOutgoing this[int position]
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
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.OutgoingListView_Row, null, false);
            }

            TextView txtDescription = row.FindViewById<TextView>(Resource.Id.txtDescription);
            txtDescription.Text = mItems[position].Description;

            TextView txtAmount = row.FindViewById<TextView>(Resource.Id.txtAmount);
            txtAmount.Text = mItems[position].Amount.ToString();

            TextView txtDayLeavesAccount = row.FindViewById<TextView>(Resource.Id.txtDayLeavesAccount);
            int dayLeavesAcount = mItems[position].DayleavesAccount;
            txtDayLeavesAccount.Text = dayLeavesAcount.ToString() + Code.HelperMethods.DaySuffix(dayLeavesAcount);

            TextView txtReoccuring = row.FindViewById<TextView>(Resource.Id.txtReoccuring);
            txtReoccuring.Text = (mItems[position].Reoccuring == true) ? "Yes" : "no";

            return row;
        }
    }
}