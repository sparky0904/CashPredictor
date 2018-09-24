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
    internal class clsParameters
    {
        #region Singleton

        private static clsParameters mInstance;

        // Constructor is protected
        protected clsParameters()
        {
        }

        public static clsParameters Instance()
        {
            if (mInstance == null) { mInstance = new clsParameters(); }

            return mInstance;
        }

        #endregion Singleton

        private int mPayDay = 26;
        public int PayDay { get => mPayDay; set => mPayDay = value; }

        private bool mSetReoccuringToFalseIfSameDayAsCurrentDay = true;

        public bool SetReoccuringToFalseIfSameDayAsCurrentDay
        {
            get => mSetReoccuringToFalseIfSameDayAsCurrentDay;
            set => mSetReoccuringToFalseIfSameDayAsCurrentDay = value;
        }

        public string OutGoingsDataFilename = "Outgoings.dat";
    }
}