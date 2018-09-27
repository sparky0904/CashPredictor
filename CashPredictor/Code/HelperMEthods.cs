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
    internal class HelperMethods
    {
        public static string DaySuffix(int date)
        {
            string returnValue = "";

            switch (date)
            {
                case 1:
                case 21:
                case 31:
                    returnValue = "st";
                    break;

                case 2:
                case 22:
                    returnValue = "nd";
                    break;

                case 3:
                case 23:
                    returnValue = "rd";
                    break;

                case 4:
                    returnValue = "th";
                    break;

                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:

                    returnValue = "th";
                    break;

                default:
                    returnValue = "";
                    break;
            }

            return returnValue;
        }

        public static int LastDayInMonth(DateTime DateToCheck)
        {
            return DateTime.DaysInMonth(DateToCheck.Year, DateToCheck.Month);
        }

        public static float DaysUntilNextPayDay()
        {
            DateTime TodaysDate = DateTime.Now;
            DateTime NextPayDate = TodaysDate;

            // Get reference to paramaters
            Code.clsParameters parameters = Code.clsParameters.Instance();

            // Detrmine the next pay day month
            // If today is more than the payday then it is next month so add a month
            if (TodaysDate.Day >= parameters.PayDay)
                NextPayDate = NextPayDate.AddMonths(1);

            // Set the next pay date using the payday and current next pay day field
            NextPayDate = new DateTime(NextPayDate.Year, NextPayDate.Month, parameters.PayDay);

            return (float)(NextPayDate - TodaysDate).TotalDays;
        }

        public static float DaysInThisPayPeriod()
        {
            DateTime LastPayDate = DateTime.Now;
            DateTime TodaysDate = DateTime.Now;
            DateTime NextPayDate = TodaysDate;

            // Get reference to paramaters
            Code.clsParameters parameters = Code.clsParameters.Instance();

            // Check if today is less than payday if so then last payday was last month
            if (TodaysDate.Day <= parameters.PayDay)
            {
                LastPayDate = LastPayDate.AddMonths(-1);
            }

            // Set last pay date now we now the month
            LastPayDate = new DateTime(LastPayDate.Year, LastPayDate.Month, parameters.PayDay);

            // Set Next payday
            // Check if payday is in this onth or next by seeing if today is greater than payday
            if (TodaysDate.Day >= parameters.PayDay)
            {
                NextPayDate = NextPayDate.AddMonths(1);
            }

            // set the nextpay date now we know the month
            NextPayDate = new DateTime(NextPayDate.Year, NextPayDate.Month, parameters.PayDay);

            // Now  to the matsh and return
            return (float)(NextPayDate - LastPayDate).TotalDays;
        }
    }
}