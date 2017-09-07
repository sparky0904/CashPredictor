using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    // Manager for the oputgoings
    public class clsOutgoingsManager
    {
        private List<clsOutgoing> Outgoings;

        public List<clsOutgoing> ReturnAll()
        {
            return Outgoings;
        }

        public clsOutgoing FindOutgoingByDescription(string SearchString)
        {
            clsOutgoing theOutgoing = new clsOutgoing();

            foreach (clsOutgoing T in Outgoings)
            {
                if (T.Description == SearchString)
                {
                    theOutgoing = T;
                    return (theOutgoing);
                }
            }
            return theOutgoing;
        }
    }
}