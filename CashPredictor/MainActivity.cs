using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using System.Collections.Generic;
using Android.Content.Res;

// TODO: Add option for one off payments, i.e. holiday, or school presents

namespace CashPredictor
{
    // [Activity(Label = "CashPredictor", MainLauncher = true, Icon = "@drawable/icon")]
    [Activity(Label = "CashPredictor", MainLauncher = true, Icon = "@drawable/icon", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : Activity
    {
        public Code.ClsSMSBroadcastReceiver SMSBroadcastReceiver;
        private Code.clsCashPredictor CashPredictorInstance = Code.clsCashPredictor.Instance();
        private string mClassName;

        private ListView mBankDebitListView;
        private Button mBtnUpdateOutgoings;

        #region Activity Form Events

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            // Handles any configuration changes including rotation of the screen
            base.OnConfigurationChanged(newConfig);
        }

        private void MfldCurrentBalance_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            EditText editText = (EditText)sender;

            double CurrentBalance;
            if (editText.Text == "") { CurrentBalance = 0; } else { CurrentBalance = Convert.ToDouble(editText.Text); }

            TextView mtxtBalance = FindViewById<TextView>(Resource.Id.txtBalance);
            mtxtBalance.Text = CashPredictorInstance.CalculateBalance(CurrentBalance).ToString();
        }

        protected override void OnRestart()
        {
            base.OnRestart();

            UpdateBalance();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnDestroy()
        {
            UnregisterReceiver(SMSBroadcastReceiver);

            base.OnDestroy();
        }

        protected override void OnResume()
        {
            base.OnResume();

            // Code.clsBankDebitsListViewAdapter adapter = new Code.clsBankDebitsListViewAdapter(this, Code.clsBankDebitDB.GetBankDebits());

            Code.clsBankDebitsListViewAdapter adapter = new Code.clsBankDebitsListViewAdapter(this, CashPredictorInstance.GetBankDebits());

            mBankDebitListView.Adapter = adapter;

            mBankDebitListView.RefreshDrawableState();

            if (SMSBroadcastReceiver == null)
            {
                SMSBroadcastReceiver = new Code.ClsSMSBroadcastReceiver();
                RegisterReceiver(SMSBroadcastReceiver, new IntentFilter("android.provider.Telephony.SMS_RECEIVED"));
            }
        }

        protected override void OnPause()
        {
            // UnregisterReceiver(SMSBroadcastReceiver);
            base.OnPause();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            mClassName = this.GetType().Name;

            // Get reference to paramaters
            Code.clsParameters parameters = Code.clsParameters.Instance();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mBankDebitListView = FindViewById<ListView>(Resource.Id.fldBankDebitsListView);

            Code.clsBankDebitsListViewAdapter adapter = new Code.clsBankDebitsListViewAdapter(this, Code.clsBankDebitDB.GetBankDebits());

            mBankDebitListView.Adapter = adapter;
            mBankDebitListView.ItemClick += BankDebitListView_ItemClick;
            Console.WriteLine("[{0}] Registered the item click event for the bank debit list view..", mClassName);

            mBtnUpdateOutgoings = FindViewById<Button>(Resource.Id.btnUpdateOutgoings);
            mBtnUpdateOutgoings.Click += (object sender, EventArgs e) =>
            {
                var ListOutgoingsActivity = new Intent(this, typeof(Code.clsListOutgoings_Activity));
                StartActivity(ListOutgoingsActivity);
            };

            EditText mfldCurrentBalance = FindViewById<EditText>(Resource.Id.fldCurrentBalance);
            mfldCurrentBalance.AfterTextChanged += MfldCurrentBalance_AfterTextChanged;

            CheckBox mfldIncudeInCalculation = FindViewById<CheckBox>(Resource.Id.txtIncudeInCalculation);
            // mfldIncudeInCalculation.CheckedChange += mfldIncudeInCalculation_CheckedChange;

            // Set the Payday
            TextView txtPayDate = FindViewById<TextView>(Resource.Id.txtPayDate);
            string myText = "";

            myText = "Pay Day is the: " + parameters.PayDay.ToString() + Code.HelperMethods.DaySuffix(parameters.PayDay).ToString();

            // Set the todays day text..
            myText += " - Today is the " + DateTime.Now.Day.ToString() + Code.HelperMethods.DaySuffix(DateTime.Now.Day);

            txtPayDate.Text = myText;

            // Register the update balance method for any changes in the include in clacluation checkbox
            //Code.clsBankDebitsListViewAdapter.
        }

        private void BankDebitListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Code.clsBankDebit bankDebit = CashPredictorInstance.GetBankDebits()[e.Position];

            Console.WriteLine("[{0}] Bank debit clicked - ID: [{1}] {2}", mClassName, bankDebit.ID.ToString(), bankDebit.Description);
            Toast.MakeText(this, "Bank Debit list view item clicked!", ToastLength.Short);

            // Update the bank debit to change the include in calculation flag
            bankDebit.IncludeInCalculation = !bankDebit.IncludeInCalculation; // Reverse the includeincalulation
            bankDebit.Save(); // Save the Bankdebit

            // refresh the bankdebit listview
            OnResume();

            UpdateBalance(); // Update the balance
        }

        private void mfldIncudeInCalculation_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Console.WriteLine("[{0}] Include in calculation clicked", mClassName);
            Toast.MakeText(this, "Include in calculation clicked", ToastLength.Short);
        }

        #endregion Activity Form Events

        #region Methods

        private double GrabCurrentBalance()
        {
            double CurrentBalance;

            TextView CurrentBalanceText;
            CurrentBalanceText = FindViewById<TextView>(Resource.Id.fldCurrentBalance);

            if (CurrentBalanceText.Text == "") { CurrentBalance = 0; } else { CurrentBalance = Convert.ToDouble(CurrentBalanceText.Text); }

            return CurrentBalance;
        }

        // Updates the balance
        private void UpdateBalance()
        {
            // Calculate the BankDebits
            // CashPredictorInstance.CalculateListOfBankDebits();

            // Calculate the new balance
            double CurrentBalance;

            TextView CurrentBalanceText;
            CurrentBalanceText = FindViewById<TextView>(Resource.Id.fldCurrentBalance);

            if (CurrentBalanceText.Text == "") { CurrentBalance = 0; } else { CurrentBalance = Convert.ToDouble(CurrentBalanceText.Text); }

            // Update the text on screen
            TextView mtxtBalance = FindViewById<TextView>(Resource.Id.txtBalance);

            // Recalaculate the balance
            mtxtBalance.Text = CashPredictorInstance.CalculateBalance(CurrentBalance).ToString();
        }

        #endregion Methods
    }
}