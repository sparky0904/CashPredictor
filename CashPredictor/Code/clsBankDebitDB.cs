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
    internal class clsBankDebitDB
    {
        public static List<clsBankDebit> GetBankDebits()
        {
            clsDatabase DatabaseInstance = clsDatabase.Instance();

            return DatabaseInstance.BankDebits;
        }
    }
}