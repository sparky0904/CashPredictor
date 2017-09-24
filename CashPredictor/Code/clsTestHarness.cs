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
    internal class clsTestHarness
    {
        public static void AddOutgoings()
        {
            clsOutgoingDB.New(new clsOutgoing() { Description = "Mortage", Amount = 650, DayleavesAccount = 1, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "Car Loan", Amount = 250, DayleavesAccount = 1, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "Sky TV", Amount = 74, DayleavesAccount = 13, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "Pocket Money", Amount = 70, DayleavesAccount = 1, DayOfWeekLeavesAccount = 6, Frequency = 7, Reoccuring = true });

            clsOutgoingDB.New(new clsOutgoing() { Description = "Petrol", Amount = 70, DayleavesAccount = 1, DayOfWeekLeavesAccount = 6, Frequency = 7, Reoccuring = false });
        }
    }
}