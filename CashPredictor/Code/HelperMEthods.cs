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
    internal class HelperMEthods
    {
        public static void CalculateListOfOutgoings()
        {
            // Generate the list
            List<clsOutgoingListItem> ListOfAllOutgoings = new List<clsOutgoingListItem>();

            // Cycle through the outgoings
            foreach (clsOutgoing Outgoing in clsOutgoingDB.GetOutgoings())
            {
                if (Outgoing.Reoccuring == true)
                {
                    // If reoccuring, calculate number remianiang before pay day

                    ListOfAllOutgoings.Add(new clsOutgoingListItem(Outgoing.Description, Outgoing.Amount, Outgoing.DayleavesAccount));
                }
                else
                {
                    // If not re-occuring, add to the list
                    ListOfAllOutgoings.Add(new clsOutgoingListItem(Outgoing.Description, Outgoing.Amount, Outgoing.DayleavesAccount));
                }
            }

            // Sort the list by date order

            //Dave the list to the database class so can be used by other scripts
            clsDatabase DatabaseInstance = clsDatabase.Instance();
            DatabaseInstance.ListOfAllOutgoings = ListOfAllOutgoings;
        }
    }
}