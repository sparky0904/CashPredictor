using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class clsOutgoing
    {
        private string description;
        private float amount;
        private DateTime dateLeaveAccount;

        public string Description { get => description; set => description = value; }
        public float Amount { get => amount; set => amount = value; }
        public DateTime DateLeaveAccount { get => dateLeaveAccount; set => dateLeaveAccount = value; }
    }
}