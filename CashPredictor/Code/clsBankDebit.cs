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
    public class clsBankDebit
    {
        private string mDescription;
        private double mAmount;
        private int mDayLeavesAccount;
        private DateTime mDateLeaveAccounts;

        public string Description { get => mDescription; set => mDescription = value; }
        public double Amount { get => mAmount; set => mAmount = value; }
        public int DayLeavesAccount { get => mDayLeavesAccount; set => mDayLeavesAccount = value; }
        public DateTime DateLeaveAccounts { get => mDateLeaveAccounts; set => mDateLeaveAccounts = value; }

        public clsBankDebit(string _Description, double _Amount, int _DayLeavesAccount, DateTime _DateLeavesAccount)
        {
            Description = _Description;
            Amount = _Amount;
            DayLeavesAccount = _DayLeavesAccount;
            DateLeaveAccounts = _DateLeavesAccount;
        }
    }
}