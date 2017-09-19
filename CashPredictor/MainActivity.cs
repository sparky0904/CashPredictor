using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CashPredictor
{
    [Activity(Label = "CashPredictor", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button mBtnUpdateOutgoings;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

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
        }
    }
}