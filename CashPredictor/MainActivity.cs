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
        public List<Code.clsOutgoing> Outgoings = new List<Code.clsOutgoing>();

        public Code.ClsSMSBroadcastReceiver SMSBroadcastReceiver;
        private Code.clsCashPredictor CashPredictorInstance = Code.clsCashPredictor.Instance();

        private ListView mBankDebitListView;
        private Button mBtnUpdateOutgoings;
        private bool mDataLoaded = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Get reference to paramaters
            Code.clsParameters parameters = Code.clsParameters.Instance();

            // Add some data for test purposes
            if (!mDataLoaded)
            {
                Code.clsTestHarness.LoadTestOutgoings();
                mDataLoaded = true;
            }

            // Calculate the outogings so we can show balance !!
            Code.HelperMethods.CalculateListOfBankDebits();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mBankDebitListView = FindViewById<ListView>(Resource.Id.fldBankDebitsListView);

            Code.clsBankDebitsListViewAdapter adapter = new Code.clsBankDebitsListViewAdapter(this, Code.clsBankDebitDB.GetBankDebits());

            mBankDebitListView.Adapter = adapter;
            mBankDebitListView.ItemClick += BankDebitListView_ItemClick;

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
        }

        #region Activity Form Events

        private void BankDebitListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, "Bank Debit list view item clicked!", ToastLength.Short);
        }

        private void mfldIncudeInCalculation_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Console.WriteLine("Include in calculation clicked");
            Toast.MakeText(this, "Include in calculation clicked", ToastLength.Short);
        }

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

            Code.clsBankDebitsListViewAdapter adapter = new Code.clsBankDebitsListViewAdapter(this, Code.clsBankDebitDB.GetBankDebits());

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

        #endregion Activity Form Events

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

            // Recalaculate the balance
            mtxtBalance.Text = CashPredictorInstance.CalculateBalance(CurrentBalance).ToString();
        }
    }
}