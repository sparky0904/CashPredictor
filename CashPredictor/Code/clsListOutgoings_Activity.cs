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
    [Activity(Label = "CashPredictor", MainLauncher = false, Icon = "@drawable/icon")]
    internal class clsListOutgoings_Activity : Activity
    {
        private Button mBtnAddNewOutgoing;
        private Button mBtnCancel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create the view
            SetContentView(Resource.Layout.ListOutgoings);

            ListView outgoingsListView = FindViewById<ListView>(Resource.Id.OutgoingsListView);

            // TODO: Hook up the List of outgoing classes to the ListView

            // Hook up the add new button
            mBtnAddNewOutgoing = FindViewById<Button>(Resource.Id.btnAddNewOutgoing);
            mBtnCancel = FindViewById<Button>(Resource.Id.btnCancel);

            mBtnAddNewOutgoing.Click += (object sender, EventArgs e) =>
            {
                var OutGoingActivity = new Intent(this, typeof(Code.clsOutgoing_Activity));

                StartActivity(OutGoingActivity);
            };

            // Hook up Cancel button
            mBtnCancel.Click += (object sender, EventArgs e) =>
            {
                Finish();
                // Console.WriteLine("Clicked Cancel button in ListOutgoing activity.");
            };
        }
    }
}