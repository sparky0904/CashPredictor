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
        #region Variables

        private bool mDataLoaded = false;

        // Get reference to paramaters
        private clsParameters parameters = clsParameters.Instance();

        #endregion Variables

        // constructor is 'protected'
        protected clsCashPredictor(Context context)
        {
            LoadData(context);
            CalculateListOfBankDebits();
        }

        // This needs to be a singleton so we have some code to ensure this happens

        #region Singleton

        // Global variablein the valss to hold an instance of the class
        private static clsCashPredictor mInstance;

        public static clsCashPredictor Instance(Context context)
        {
            if (mInstance == null)
            {
                mInstance = new clsCashPredictor(context);
            }

            return mInstance;
        }

        #endregion Singleton

        #region Methods

        public List<clsBankDebit> GetBankDebits()
        {
            return Code.clsBankDebitDB.GetBankDebits();
        }

        public void CalculateListOfBankDebits()
        {
            //TODO: Ensure this takes into consideration that user may of set an include-in-calculation manually

            // Generate the list
            List<clsBankDebit> ListOfAllBankDebits = new List<clsBankDebit>();

            // Get reference to paramaters
            clsParameters parameters = clsParameters.Instance();

            DateTime Today = DateTime.Now;

            // Today = new DateTime(2017, 10, 27);

            int PayDay = parameters.PayDay;
            bool PayDayIsNextMonth = Today.Day > PayDay;

            // Cycle through the outgoings
            foreach (clsOutgoing Outgoing in clsOutgoingDB.GetOutgoings())
            {
                if (Outgoing.Reoccuring == true)
                {
                    DateTime TodayDateToUse = Today;

                    // Calculate number remaining before pay day
                    List<clsBankDebit> bankDebits = new List<clsBankDebit>();
                    bool HaveMovedToNextMonth = false;
                    int DaysSinceLastBankDebit = Outgoing.Frequency;

                    // Generate a list of the debits from one payday to the next

                    int LastDayToCheck = PayDay; // Set last day to check as payday intially

                    // If payday is next month then set lastdaytocheck to lastday of the month
                    if (PayDayIsNextMonth) { LastDayToCheck = Code.HelperMethods.LastDayInMonth(TodayDateToUse); }

                    // Loop from today to lastdaytocheck
                    for (int d = TodayDateToUse.Day; d <= LastDayToCheck; d++)
                    {
                        DaysSinceLastBankDebit++;

                        // check if this day is the same day of week as the outgoing
                        DateTime CheckDate = new DateTime(TodayDateToUse.Year, TodayDateToUse.Month, d);
                        if (((int)CheckDate.DayOfWeek == Outgoing.DayOfWeekLeavesAccount) && (DaysSinceLastBankDebit >= Outgoing.Frequency))
                        {
                            DateTime DateLeavesAccount = new DateTime(TodayDateToUse.Year, TodayDateToUse.Month, d);
                            bankDebits.Add(new clsBankDebit(-1, Outgoing.Description, Outgoing.Amount, d, DateLeavesAccount));
                            DaysSinceLastBankDebit = 0;
                        }

                        if (d == LastDayToCheck)
                        {
                            if (PayDayIsNextMonth && !HaveMovedToNextMonth)
                            {
                                LastDayToCheck = PayDay;
                                d = 0;
                                HaveMovedToNextMonth = true;
                                TodayDateToUse = TodayDateToUse.AddMonths(1);
                                TodayDateToUse = new DateTime(TodayDateToUse.Year, TodayDateToUse.Month, 1);
                            }
                        }
                    }

                    // Loop from today to Payday

                    // Cycle throught the debits and remove those that are not valid i.e. before todays date but after pay day

                    // Add the bankdebits to the list of bank debits
                    foreach (clsBankDebit theBankDebit in bankDebits)
                    {
                        ListOfAllBankDebits.Add(theBankDebit);
                    }
                }
                else
                {
                    // If not re-occuring, add to the list if before next payday
                    DateTime DateLeavesAccount = new DateTime(Today.Year, Today.Month, Outgoing.DayleavesAccount);

                    // check if date in outgoing is next month, if so need to ass one to the month
                    if (Outgoing.DayleavesAccount < Today.Day)
                    {
                        DateLeavesAccount = DateLeavesAccount.AddMonths(1);
                    }

                    bool saveBankDebit = true;

                    if (PayDayIsNextMonth && (DateLeavesAccount.Day > PayDay)) { saveBankDebit = false; }
                    if (!PayDayIsNextMonth && (DateLeavesAccount.Day < Today.Day)) { saveBankDebit = false; }

                    if (saveBankDebit)
                    {
                        ListOfAllBankDebits.Add(new clsBankDebit(-1, Outgoing.Description, Outgoing.Amount, Outgoing.DayleavesAccount, DateLeavesAccount));
                    }
                }
            }

            // Sort the list by date order, using a bubble sort routine
            Code.clsBankDebit tempBankDebit;
            bool ListIsInOrder = false;

            do
            {
                ListIsInOrder = true;
                for (int i = 0; i < ListOfAllBankDebits.Count - 1; i++)
                {
                    if (ListOfAllBankDebits[i + 1].DateLeaveAccount < ListOfAllBankDebits[i].DateLeaveAccount)
                    {
                        // Swap the entries over
                        tempBankDebit = ListOfAllBankDebits[i];
                        ListOfAllBankDebits[i] = ListOfAllBankDebits[i + 1];
                        ListOfAllBankDebits[i + 1] = tempBankDebit;
                        ListIsInOrder = false;
                    }
                }
            } while (!ListIsInOrder);

            // Loop through all the bank debits and set include in calculation to false if today is the day it is due to come out of account and it is set do do so in the parameters
            if (parameters.SetReoccuringToFalseIfSameDayAsCurrentDay)
            {
                foreach (clsBankDebit i in ListOfAllBankDebits)
                {
                    if (i.DateLeaveAccount.Day == Today.Day)
                    {
                        i.IncludeInCalculation = false;
                    }
                }
            }

            //Save the list to the database class so can be used by other scripts
            clsDatabase DatabaseInstance = clsDatabase.Instance();
            DatabaseInstance.BankDebits = ListOfAllBankDebits;
        }

        private void LoadData(Context context)
        {
            // Get reference to Database class
            clsDatabase DatabaseInstance = clsDatabase.Instance();

            // Ask the database class to load the data from the device
            mDataLoaded = DatabaseInstance.LoadOutgoings(context);

            // else Add some data for test purposes
            if (!mDataLoaded)
            {
                Code.clsTestHarness.LoadTestOutgoings();

                if (DatabaseInstance.SaveOutgoings(context) >= 0)
                {
                    mDataLoaded = true;
                }
            }
        }

        #endregion Methods

        public double CalculateBalance(double CurrentBalance)
        {
            // Calculates the balance
            // We take an input balance figure and deduct all outgoings marked IncludeInCalculation
            double NewBalance = CurrentBalance;

            // Obtain a copy of the database instance where the data is stored internally
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