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
        public static void LoadTestOutgoings()
        {
            clsOutgoingDB.ClearOutGoings(); // Clear the outgoings before we load new ones

            clsOutgoingDB.New(new clsOutgoing() { Description = "Mortage", Amount = 684.45, DayleavesAccount = 1, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "Car Loan", Amount = 280.52, DayleavesAccount = 1, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "Sky TV", Amount = 74, DayleavesAccount = 1, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "Santander Credit", Amount = 200, DayleavesAccount = 1, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "AIL QUOTE ME HAPPY", Amount = 55.04, DayleavesAccount = 24, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });
            clsOutgoingDB.New(new clsOutgoing() { Description = "AVIVA", Amount = 83.78, DayleavesAccount = 09, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "British Gas", Amount = 169.84, DayleavesAccount = 5, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "CREATION.CO.UK", Amount = 102.06, DayleavesAccount = 1, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "EE - Georgie", Amount = 33.73, DayleavesAccount = 15, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "EE - Min", Amount = 32.98, DayleavesAccount = 15, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "FDA", Amount = 29, DayleavesAccount = 1, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "L&G I LTD XBM-MI", Amount = 22.16, DayleavesAccount = 24, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "LEGAL & GEN MI C/L", Amount = 9.62, DayleavesAccount = 1, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "PC/SOURCE INS", Amount = 25.23, DayleavesAccount = 11, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "ROYAL SUNALLIANCE", Amount = 17.29, DayleavesAccount = 17, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "SEVERN TRENT WATER", Amount = 33.89, DayleavesAccount = 4, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "TALKTALK LIMITED", Amount = 40.01, DayleavesAccount = 23, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "TV LICENCE MBP", Amount = 12.12, DayleavesAccount = 1, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "WALSALL M.B.C", Amount = 145, DayleavesAccount = 11, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "WWF-UK DD", Amount = 6, DayleavesAccount = 27, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "Amazon Prime", Amount = 7.99, DayleavesAccount = 7, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "Google Drive", Amount = 1.59, DayleavesAccount = 24, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "Amazon Music", Amount = 7.99, DayleavesAccount = 26, DayOfWeekLeavesAccount = 0, Frequency = 0, Reoccuring = false });

            clsOutgoingDB.New(new clsOutgoing() { Description = "Petrol", Amount = 70, DayleavesAccount = 1, DayOfWeekLeavesAccount = 0, Frequency = 28, Reoccuring = false });

            // Recoccuring
            clsOutgoingDB.New(new clsOutgoing() { Description = "Pocket Money", Amount = 70, DayleavesAccount = 1, DayOfWeekLeavesAccount = 5, Frequency = 7, Reoccuring = true });
        }
    }
}