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

        public void ClearOutgoings()
        {
            mOutgoings.Clear();
        }

        // Will update the recoresd sin the list that match the ID in the loaded bankdebit
        public int SaveBankDebit(clsBankDebit theBankDebit)
        {
            try
            {
                // If the bankdebit ID is -1 inidcates is a new record so just add to the list and return a code of 1
                if (theBankDebit.ID == -1)
                {
                    mBankDebits.Add(theBankDebit);
                    return (1);
                }

                // Search through list and replace with loaded Bank Debit
                int numberOfRecordsUpdated = 0;
                for (int i = 0; i < mBankDebits.Count - 1; i++)
                {
                    if (mBankDebits[i].ID == theBankDebit.ID)
                    {
                        mBankDebits[i] = theBankDebit;
                        numberOfRecordsUpdated++;
                    }
                }
                return (numberOfRecordsUpdated); // Indicate the number of records updated in the return value
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in saving BankDebit, erro description is [{0}]", e.Message);
                return (-1);
            }
        }

        #endregion Methods
    }
}