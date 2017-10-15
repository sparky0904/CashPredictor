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
        private static int nextID = 1;

        private int mID;
        private string mDescription;
        private double mAmount;
        private int mDayLeavesAccount;
        private DateTime mDateLeaveAccount;
        private bool mIncludeInCalculation;

        public string Description { get => mDescription; set => mDescription = value; }
        public double Amount { get => mAmount; set => mAmount = value; }
        public int DayLeavesAccount { get => mDayLeavesAccount; set => mDayLeavesAccount = value; }
        public DateTime DateLeaveAccount { get => mDateLeaveAccount; set => mDateLeaveAccount = value; }
        public int ID { get => mID; set => mID = value; }
        public bool IncludeInCalculation { get => mIncludeInCalculation; set => mIncludeInCalculation = value; }

        public clsBankDebit(string _Description, double _Amount, int _DayLeavesAccount, DateTime _DateLeavesAccount)
        {
            ID = nextID;
            Description = _Description;
            Amount = _Amount;
            DayLeavesAccount = _DayLeavesAccount;
            DateLeaveAccount = _DateLeavesAccount;
            IncludeInCalculation = true;

            nextID++;
        }
    }
}