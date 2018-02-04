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
    }
}