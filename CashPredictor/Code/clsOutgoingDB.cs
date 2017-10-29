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
    internal class clsOutgoingDB
    {
        public static void ClearOutGoings()
        {
            clsDatabase DatabaseInstance = clsDatabase.Instance();
            DatabaseInstance.ClearOutgoings();
        }

        public static void New(clsOutgoing _OutgoingRecord)
        {
            clsDatabase DatabaseInstance = clsDatabase.Instance();

            DatabaseInstance.NewOutgoing(_OutgoingRecord);
        }

        public static void Save(clsOutgoing _OutgoingRecord)
        {
            //TODO: Check if outgoing already exists
            New(_OutgoingRecord);
        }

        public static List<clsOutgoing> GetOutgoings()
        {
            clsDatabase DatabaseInstance = clsDatabase.Instance();

            return DatabaseInstance.GetOutgoings();
        }
    }
}