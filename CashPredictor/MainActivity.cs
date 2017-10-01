using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

// TODO: Add option for one off payments, i.e. holiday, or school presents

namespace CashPredictor
{
    [Activity(Label = "CashPredictor", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mBtnUpdateOutgoings;
        public List<Code.clsOutgoing> Outgoings = new List<Code.clsOutgoing>();
        private ListView mListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Get reference to paramaters
            Code.clsParameters parameters = Code.clsParameters.Instance();

            // Add some data for test purposes
            Code.clsTestHarness.AddOutgoings();

            // Calculate the outogings so we can show balance !!
            Code.HelperMethods.CalculateListOfBankDebits();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mListView = FindViewById<ListView>(Resource.Id.fldBankDebitsListView);

            Code.clsBankDebitsListViewAdapter adapter = new Code.clsBankDebitsListViewAdapter(this, Code.clsBankDebitDB.GetBankDebits());

            mListView.Adapter = adapter;

            mBtnUpdateOutgoings = FindViewById<Button>(Resource.Id.btnUpdateOutgoings);
            mBtnUpdateOutgoings.Click += (object sender, EventArgs e) =>
            {
                var ListOutgoingsActivity = new Intent(this, typeof(Code.clsListOutgoings_Activity));
                StartActivity(ListOutgoingsActivity);
            };

            EditText mfldCurrentBalance = FindViewById<EditText>(Resource.Id.fldCurrentBalance);
            mfldCurrentBalance.AfterTextChanged += MfldCurrentBalance_AfterTextChanged;

            // Set the Payday
            TextView txtPayDate = FindViewById<TextView>(Resource.Id.txtPayDate);
            txtPayDate.Text = "Pay Day is set for: " + parameters.PayDay.ToString() + Code.HelperMethods.DaySuffix(parameters.PayDay).ToString();
        }

        private void MfldCurrentBalance_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            EditText editText = (EditText)sender;

            double CurrentBalance;
            if (editText.Text == "") { CurrentBalance = 0; } else { CurrentBalance = Convert.ToDouble(editText.Text); }

            TextView mtxtBalance = FindViewById<TextView>(Resource.Id.txtBalance);
            mtxtBalance.Text = CalculateBalance(CurrentBalance).ToString();
        }

        protected override void OnRestart()
        {
            base.OnRestart();

            UpdateBalance();
        }

        protected override void OnResume()
        {
            base.OnResume();

            Code.clsBankDebitsListViewAdapter adapter = new Code.clsBankDebitsListViewAdapter(this, Code.clsBankDebitDB.GetBankDebits());

            mListView.Adapter = adapter;

            mListView.RefreshDrawableState();
        }

        // Updates the balance
        private void UpdateBalance()
        {
            // Calaculate the BankDebits
            Code.HelperMethods.CalculateListOfBankDebits();

            // Calcultae the new balance
            double CurrentBalance;

            TextView CurrentBalanceText;
            CurrentBalanceText = FindViewById<TextView>(Resource.Id.fldCurrentBalance);

            if (CurrentBalanceText.Text == "") { CurrentBalance = 0; } else { CurrentBalance = Convert.ToDouble(CurrentBalanceText.Text); }

            // Update the text on screen
            TextView mtxtBalance = FindViewById<TextView>(Resource.Id.txtBalance);
            mtxtBalance.Text = CalculateBalance(CurrentBalance).ToString();
        }

        private double CalculateBalance(double CurrentBalance)
        {
            double NewBalance = CurrentBalance;
            Code.clsDatabase DatabaseInstance = Code.clsDatabase.Instance();

            foreach (Code.clsBankDebit OutgoingItem in DatabaseInstance.BankDebits)
            {
                NewBalance -= OutgoingItem.Amount;
            }

            return NewBalance;
        }
    }
}