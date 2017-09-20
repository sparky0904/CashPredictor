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
    internal class clsOutgoing_Activity : Activity
    {
        private Button mBtnCancel;
        private Button mBtnSave;
        private EditText mDescription;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create the view
            SetContentView(Resource.Layout.Outgoing);

            // Hook up activity variables we will use to save data
            mDescription = this.FindViewById<EditText>(Resource.Id.fldDescription);

            // Hook up the Cancel button
            mBtnCancel = FindViewById<Button>(Resource.Id.btnCancel);
            mBtnCancel.Click += (object sender, EventArgs e) =>
            {
                Finish();
                // Console.WriteLine("Clicked Cancel button in Outgoing activity.");
            };

            // Hook up the Save button
            mBtnSave = FindViewById<Button>(Resource.Id.btnSave);
            mBtnSave.Click += MBtnSave_Click;

            // Hook up the data adapters to the Activity fields
            // Day of Week
            Spinner spinner = FindViewById<Spinner>(Resource.Id.fldDayLeavesAccount);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_Itemselected);

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.DaysOfTheWeek, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
        }

        private void spinner_Itemselected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("{0} selected...", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Short).Show();
        }

        private void MBtnSave_Click(object sender, EventArgs e)
        {
            // Save the outgoing
            // TODO: Implement Save
            using (var toast = Toast.MakeText(this, "Saving....", ToastLength.Short)) { toast.Show(); }

            Code.clsOutgoing Outgoing = new Code.clsOutgoing();

            Outgoing.Description = mDescription.EditableText.ToString();

            clsOutgoingManager.Outgoings.Add(Outgoing);
        }
    }
}