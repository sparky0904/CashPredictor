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
using Android.Telephony;
using Android.Provider;

namespace CashPredictor.Code
{
    [BroadcastReceiver(Enabled = true, Exported = false)]
    [IntentFilter(new string[] { "android.provider.Telephony.SMS_RECEIVED" })]
    public class ClsSMSBroadcastReceiver : BroadcastReceiver
    {
        public ClsSMSBroadcastReceiver()
        {
            Console.WriteLine("*** SMS Broadcaster created ***");
        }

        public override void OnReceive(Context context, Intent intent)
        {
            Console.WriteLine("*** SMS OnReceive fired ***");

            SmsMessage[] messages = Telephony.Sms.Intents.GetMessagesFromIntent(intent);

            var sb = new StringBuilder();

            for (int i = 0; i < messages.Length; i++)
            {
                sb.Append(string.Format("SMS From: {0}{1}Body: {2}{1}", messages[i].OriginatingAddress, System.Environment.NewLine, messages[i].MessageBody));

                Toast.MakeText(context, sb.ToString(), ToastLength.Short).Show();
            }
        }
    }
}