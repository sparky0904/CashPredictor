using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

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

            // Add some data for test purposes
            Code.clsTestHarness.AddOutgoings();

            // Calculate the outogings so we can show balance !!
            Code.HelperMEthods.CalculateListOfOutgoings();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mListView = FindViewById<ListView>(Resource.Id.fldOutgoingsListView);

            // clsOutGoingsListViewAdapter adapter = new clsOutGoingsListViewAdapter(this, mItems);
            // clsOutGoingsListViewAdapter adapter = new clsOutGoingsListViewAdapter(this, clsOutgoingDB.GetOutgoings());

            // mListView.Adapter = adapter;

            mBtnUpdateOutgoings = FindViewById<Button>(Resource.Id.btnUpdateOutgoings);
            mBtnUpdateOutgoings.Click += (object sender, EventArgs e) =>
            {
                /*
                 * FragmentTransaction transaction = FragmentManager.BeginTransaction();
                // Pull up dialog
                Code.clsListOugoingsDialog ListOutgoingsDialog = new Code.clsListOugoingsDialog();
                ListOutgoingsDialog.Show(transaction, "List Outgoings Dialog");
                */
                var ListOutgoingsActivity = new Intent(this, typeof(Code.clsListOutgoings_Activity));
                StartActivity(ListOutgoingsActivity);
            };

            EditText mfldCurrentBalance = FindViewById<EditText>(Resource.Id.fldCurrentBalance);
            mfldCurrentBalance.AfterTextChanged += MfldCurrentBalance_AfterTextChanged;
        }

        private void MfldCurrentBalance_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            EditText editText = (EditText)sender;

            double CurrentBalance;
            if (editText.Text == "") { CurrentBalance = 0; } else { CurrentBalance = Convert.ToDouble(editText.Text); }

            TextView mtxtBalance = FindViewById<TextView>(Resource.Id.txtBalance);
            mtxtBalance.Text = CalculateBalance(CurrentBalance).ToString();
        }

        private double CalculateBalance(double CurrentBalance)
        {
            double NewBalance = CurrentBalance;
            Code.clsDatabase DatabaseInstance = Code.clsDatabase.Instance();

            foreach (Code.clsOutgoingListItem OutgoingItem in DatabaseInstance.ListOfAllOutgoings)
            {
                NewBalance -= OutgoingItem.Amount;
            }

            return NewBalance;
        }
    }
}