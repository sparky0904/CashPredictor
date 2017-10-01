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
    internal class clsDatabase
    {
        private static List<clsOutgoing> mOutgoings = new List<clsOutgoing>();
        private static List<clsBankDebit> mBankDebits = new List<clsBankDebit>();

        public List<clsBankDebit> BankDebits { get => mBankDebits; set => mBankDebits = value; }
        public List<clsOutgoing> Outgoings { get => mOutgoings; set => mOutgoings = value; }

        #region Singleton

        private static clsDatabase mInstance;

        // constructor is 'protected'
        protected clsDatabase()
        {
        }

        public static clsDatabase Instance()
        {
            if (mInstance == null)
            {
                mInstance = new clsDatabase();
            }

            return mInstance;
        }

        #endregion Singleton

        #region Methods

        public int NewOutgoing(clsOutgoing outgoing)
        {
            int ReturnValue = 0;

            //TODO: Check if outgoing were try to add already exists
            mOutgoings.Add(outgoing);

            return ReturnValue;
        }

        public List<clsOutgoing> GetOutgoings()
        {
            return mOutgoings;
        }

        #endregion Methods
    }
}