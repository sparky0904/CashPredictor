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
            txtDayLeavesAccount.Text = dayLeavesAcount.ToString() + DaySuffix(dayLeavesAcount);

            TextView txtReoccuring = row.FindViewById<TextView>(Resource.Id.txtReoccuring);
            txtReoccuring.Text = (mItems[position].Reoccuring == true) ? "Yes" : "no";

            return row;
        }

        private string DaySuffix(int date)
        {
            string returnValue = "";

            switch (date)
            {
                case 1:
                case 21:
                case 31:
                    returnValue = "st";
                    break;

                case 2:
                case 22:
                    returnValue = "nd";
                    break;

                case 3:
                case 23:
                    returnValue = "rd";
                    break;

                case 4:
                    returnValue = "th";
                    break;

                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:

                    returnValue = "th";
                    break;

                default:
                    returnValue = "";
                    break;
            }

            return returnValue;
        }
    }
}