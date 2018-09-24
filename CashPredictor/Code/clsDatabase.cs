using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CashPredictor.Code
{
    internal class clsDatabase
    {
        private static List<clsOutgoing> mOutgoings = new List<clsOutgoing>();
        private static List<clsBankDebit> mBankDebits = new List<clsBankDebit>();

        public List<clsBankDebit> BankDebits { get => mBankDebits; set => mBankDebits = value; }
        public List<clsOutgoing> Outgoings { get => mOutgoings; set => mOutgoings = value; }

        private static string docFolder;
        private static string dataFileName;
        private static Code.clsParameters parameters;
        private BinaryFormatter formatter;

        // We only need one instance so the Singleton code creates an instance of the Database class to be used

        #region Singleton

        private static clsDatabase mInstance;

        // constructor is 'protected'
        protected clsDatabase()
        {
            parameters = Code.clsParameters.Instance();
            docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            dataFileName = Path.Combine(docFolder, parameters.OutGoingsDataFilename);

            formatter = new BinaryFormatter();
        }

        public static clsDatabase Instance()
        {
            if (mInstance == null)
            {
                mInstance = new clsDatabase();
            }

            return mInstance;
        }

        #endregion Singleton

        #region Methods

        // Create a new outgoing
        public int NewOutgoing(clsOutgoing outgoing)
        {
            int ReturnValue = 0;

            //TODO: Check if outgoing were try to add already exists
            mOutgoings.Add(outgoing);

            return ReturnValue;
        }

        // Retrieve the list of outgoings
        public List<clsOutgoing> GetOutgoings()
        {
            return mOutgoings;
        }

        // Clear the list of OutGoings
        public void ClearOutgoings()
        {
            mOutgoings.Clear();
        }

        // Will update the records in the list that match the ID in the provided bankdebit
        public int SaveBankDebit(clsBankDebit theBankDebit)
        {
            try
            {
                // If the bankdebit ID is -1 inidcates is a new record so just add to the list and return a code of 1
                if (theBankDebit.ID == -1)
                {
                    mBankDebits.Add(theBankDebit);
                    return (1);
                }

                // Search through list and replace with loaded Bank Debit
                int numberOfRecordsUpdated = 0;
                for (int i = 0; i < mBankDebits.Count - 1; i++)
                {
                    if (mBankDebits[i].ID == theBankDebit.ID)
                    {
                        mBankDebits[i] = theBankDebit;
                        numberOfRecordsUpdated++;
                    }
                }
                return (numberOfRecordsUpdated); // Indicate the number of records updated in the return value
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in saving BankDebit, erro description is [{0}]", e.Message);
                return (-1);
            }
        }

        // Save the Outgoings to a file on the local storage
        // Used this as a reference https://www.techcoil.com/blog/how-to-save-and-load-objects-to-and-from-file-in-c/
        public int SaveOutgoings(Context context)
        {
            // Get reference to paramaters

            int ReturnCode = -1;

            try
            {
                // Create the filestream
                FileStream writerFileStream = new FileStream(dataFileName, FileMode.Create, FileAccess.Write);

                // Save the list of outgoings to the data file
                formatter.Serialize(writerFileStream, mOutgoings);
                //formatter.Serialize(writerFileStream, "Test");

                ReturnCode = mOutgoings.Count();

                // Close the file stream
                writerFileStream.Close();

                Toast.MakeText(context, "Outgoings have been saved...", ToastLength.Short).Show();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to save the Outgoings list, error is [{0]", e.ToString());
            }
            return ReturnCode;
        }

        // Load the Outgoings From a file on the local storage
        public bool LoadOutgoings(Context context)
        {
            bool returnFlag = false;

            if (File.Exists(dataFileName))
            {
                try
                {
                    // Create a filestream which will gain access to the data file
                    FileStream readerFileStream = new FileStream(dataFileName, FileMode.Open, FileAccess.Read);

                    // Load the file into the outgoing list
                    mOutgoings.Clear();
                    mOutgoings = (List<clsOutgoing>)formatter.Deserialize(readerFileStream);

                    // Close the filestream
                    readerFileStream.Close();

                    Toast.MakeText(context, "Outgoings have been loaded...", ToastLength.Short).Show();

                    // Set the return flag to true as we have loaded some data
                    returnFlag = true;

                    // Console.WriteLine(mOutgoings.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to load outgoings data, error is [{0}]", e.ToString());
                }
            }

            return returnFlag;
        }

        #endregion Methods
    }
}