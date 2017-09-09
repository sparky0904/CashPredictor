using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashPredictor
{
    public class clsOutgoing
    {
        private string description;
        private float amount;
        private int dayLeaveAccount;
        private bool reOccuring;
        private int dayOfWeekPaid;
        private int frequency;

        public string Description { get => description; set => description = value; }
        public float Amount { get => amount; set => amount = value; }
        public int DayLeaveAccount { get => dayLeaveAccount; set => dayLeaveAccount = value; }
        public bool ReOccuring { get => reOccuring; set => reOccuring = value; }
        public int DayOfWeekPaid { get => dayOfWeekPaid; set => dayOfWeekPaid = value; }
        public int Frequency { get => frequency; set => frequency = value; }

        // Constructor whihc populates data
        public clsOutgoing(string theDescription, float theAmount, int theDateLeaveAccount, bool theReOccuring, int theDayOfTheWeekPaid, int theFrequency)
        {
            Description = theDescription;
            Amount = theAmount;
            DayLeaveAccount = theDateLeaveAccount;
            ReOccuring = theReOccuring;
            DayOfWeekPaid = theDayOfTheWeekPaid;
            Frequency = theFrequency;
        }

        // Blank Constructor
        public clsOutgoing()
        {
        }
    }
}