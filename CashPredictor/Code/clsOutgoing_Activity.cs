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

        // Activity (form) fields
        private EditText mDescription;

        private EditText mAmount;
        private EditText mDayLeavesAccount;
        private CheckBox mReoccuring;
        private Spinner mDayOfWeekLeavesAccount;
        private EditText mFrequency;

        private int mSelectedDayOfWeekPosition = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create the view
            SetContentView(Resource.Layout.Outgoing);

            // Hook up activity variables we will use to save data
            mDescription = this.FindViewById<EditText>(Resource.Id.fldDescription);
            mAmount = this.FindViewById<EditText>(Resource.Id.fldAmount);
            mDayLeavesAccount = this.FindViewById<EditText>(Resource.Id.fldDayLeavesAccount);
            mReoccuring = this.FindViewById<CheckBox>(Resource.Id.fldReoccuring);
            mDayOfWeekLeavesAccount = this.FindViewById<Spinner>(Resource.Id.fldDayOfWeekLeavesAccount);
            mFrequency = this.FindViewById<EditText>(Resource.Id.fldFrequency);

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
            Spinner spinner = FindViewById<Spinner>(Resource.Id.fldDayOfWeekLeavesAccount);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_Itemselected);

            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.DaysOfTheWeek, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
        }

        private void spinner_Itemselected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            mSelectedDayOfWeekPosition = e.Position;
            string toast = string.Format("{0} selected...", spinner.GetItemAtPosition(mSelectedDayOfWeekPosition));
            // Toast.MakeText(this, toast, ToastLength.Short).Show();
        }

        private void MBtnSave_Click(object sender, EventArgs e)
        {
            // Save the outgoing
            using (var toast = Toast.MakeText(this, "Saving....", ToastLength.Short)) { toast.Show(); }

            Code.clsOutgoing Outgoing = new Code.clsOutgoing();

            double value = 0;
            string fldString = "";

            Outgoing.Description = mDescription.EditableText.ToString();

            fldString = mAmount.EditableText.ToString();
            if (IsNumeric(fldString)) { value = Convert.ToDouble(fldString); }
            Outgoing.Amount = value;

            Outgoing.DayleavesAccount = Convert.ToInt16(mDayLeavesAccount.EditableText.ToString());
            Outgoing.Reoccuring = mReoccuring.Checked;
            Outgoing.DayOfWeekLeavesAccount = mSelectedDayOfWeekPosition;  //TODO: hook up the day of week to extract on save click
            Outgoing.Frequency = Convert.ToInt16(mFrequency.EditableText.ToString());

            Outgoing.Save();

            Finish();
        }

        public static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
    }
}