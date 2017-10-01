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

        public static void CalculateListOfBankDebits()
        {
            // Generate the list
            List<clsBankDebit> ListOfAllBankDebits = new List<clsBankDebit>();

            // Get reference to paramaters
            clsParameters parameters = clsParameters.Instance();

            // Cycle through the outgoings
            foreach (clsOutgoing Outgoing in clsOutgoingDB.GetOutgoings())
            {
                DateTime Today = DateTime.Now;

                // Today = new DateTime(2017, 10, 27);

                int PayDay = parameters.PayDay;
                bool PayDayIsNextMonth = Today.Day > PayDay;

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
                    if (PayDayIsNextMonth) { LastDayToCheck = LastDayInMonth(TodayDateToUse); }

                    // Loop from today to lastdaytocheck
                    for (int d = TodayDateToUse.Day; d <= LastDayToCheck; d++)
                    {
                        DaysSinceLastBankDebit++;

                        // check if this day is the same day of week as the outgoing
                        DateTime CheckDate = new DateTime(TodayDateToUse.Year, TodayDateToUse.Month, d);
                        if (((int)CheckDate.DayOfWeek == Outgoing.DayOfWeekLeavesAccount) && (DaysSinceLastBankDebit >= Outgoing.Frequency))
                        {
                            DateTime DateLeavesAccount = new DateTime(TodayDateToUse.Year, TodayDateToUse.Month, d);
                            bankDebits.Add(new clsBankDebit(Outgoing.Description, Outgoing.Amount, d, DateLeavesAccount));
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

                    ListOfAllBankDebits.Add(new clsBankDebit(Outgoing.Description, Outgoing.Amount, Outgoing.DayleavesAccount, DateLeavesAccount));
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
                    if (ListOfAllBankDebits[i + 1].DateLeaveAccounts < ListOfAllBankDebits[i].DateLeaveAccounts)
                    {
                        // Swap the entries over
                        tempBankDebit = ListOfAllBankDebits[i];
                        ListOfAllBankDebits[i] = ListOfAllBankDebits[i + 1];
                        ListOfAllBankDebits[i + 1] = tempBankDebit;
                        ListIsInOrder = false;
                    }
                }
            } while (!ListIsInOrder);

            //Save the list to the database class so can be used by other scripts
            clsDatabase DatabaseInstance = clsDatabase.Instance();
            DatabaseInstance.BankDebits = ListOfAllBankDebits;
        }

        private static int LastDayInMonth(DateTime DateToCheck)
        {
            return DateTime.DaysInMonth(DateToCheck.Year, DateToCheck.Month);
        }
    }
}