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
    internal class clsListOugoingsDialog : DialogFragment
    {
        private Button mBtnAddNewOutgoing;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Create and Inflate the view
            var view = inflater.Inflate(Resource.Layout.ListOutgoings, container, false);

            // Hook up button
            mBtnAddNewOutgoing = view.FindViewById<Button>(Resource.Id.btnAddNewOutgoing);

            mBtnAddNewOutgoing.Click += BtnAddNewOutgoing_Click;
            // Pull up the new outgoing dialog

            // Return the view
            return view;
        }

        private void BtnAddNewOutgoing_Click(object sender, EventArgs e)
        {
            // User has clicked the ass new outgoing button
            // Show the dialog
            /*
             * FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Code.clsOutgoingDialog OutgoingDialog = new Code.clsOutgoingDialog();
            OutgoingDialog.Show(transaction, "Outgoing Dialog");
            */
            // var ListOutgoingsActivity = new Intent(this, typeof(Code.clsListOutgoings_Activity));
        }
    }
}