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
    internal class clsOutgoing
    {
        private string mDescription;
        private double mAmount;
        private int mDayleavesAccount;
        private bool mReoccuring;
        private int mDayOfWeekLeavesAccount;
        private int mFrequency;

        public string Description { get => mDescription; set => mDescription = value; }
        public double Amount { get => mAmount; set => mAmount = value; }
        public int DayleavesAccount { get => mDayleavesAccount; set => mDayleavesAccount = value; }
        public bool Reoccuring { get => mReoccuring; set => mReoccuring = value; }
        public int DayOfWeekLeavesAccount { get => mDayOfWeekLeavesAccount; set => mDayOfWeekLeavesAccount = value; }
        public int Frequency { get => mFrequency; set => mFrequency = value; }
    }
}