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
    internal class clsOutgoingDialog : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Setup the view
            var view = inflater.Inflate(Resource.Layout.Outgoing, container, false);

            // Hook up the button

            // Add an event to the onclick event of the button

            // Return the view
            return view;
        }
    }
}