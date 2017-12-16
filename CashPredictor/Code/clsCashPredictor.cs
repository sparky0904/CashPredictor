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
    // This class is used to bring together all the information
    // Can return a balance update, list of outgoings, bank debits
    // Is not used to update the outgoings directly this is done from the Outgoing Class
    internal class clsCashPredictor
    {
        // This needs to be a singleton so we have some code to ensure this happens

        #region Singleton

        // Global variablein the valss to hold an instance of the class
        private static clsCashPredictor mInstance;

        // constructor is 'protected'
        protected clsCashPredictor()
        {
        }

        public static clsCashPredictor Instance()
        {
            if (mInstance == null)
            {
                mInstance = new clsCashPredictor();
            }

            return mInstance;
        }

        #endregion Singleton

        public double CalculateBalance(double CurrentBalance)
        {
            // Calculates the balance
            // We take an inbound balanace figure and deduct all outgoings marked IncludeInCalculation
            double NewBalance = CurrentBalance;
            Code.clsDatabase DatabaseInstance = Code.clsDatabase.Instance();

            foreach (Code.clsBankDebit OutgoingItem in DatabaseInstance.BankDebits)
            {
                if (OutgoingItem.IncludeInCalculation)
                {
                    NewBalance -= OutgoingItem.Amount;
                }
            }

            return NewBalance;
        }
    }
}