using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashPredictor
{
    internal static class Program
    {
        public static clsOutgoingsManager OutgoingsManager = new clsOutgoingsManager();
        // public static clsParameters Parameters = new clsParameters();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Console.WriteLine("Loading opening form");
            Application.Run(new Form1());
        }
    }
}