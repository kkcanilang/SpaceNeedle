using OpenQA.Selenium.IE;
using SeleniumAutomation.Automation.Data;
using SeleniumAutomation.Automation.Record;
using SeleniumAutomation.Selenium.Exception;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SeleniumAutomation.Automation.Run
{
    public class SeattleLeadsCrawl : ICrawl
    {
        private static InternetExplorerDriver driver;
        public static int retryCount = 0;
        public static int maxRun = 10;
        public static bool runAutomation = true;
        public static bool appendRow = true;
        public static bool IsERealInfo = true;

        private PropertyTaxReader _dataReader;
        private string _databaseServer;
        private string _seleniumDriverFolder;

        public SeattleLeadsCrawl()
        {
            _dataReader = new PropertyTaxReader(_databaseServer);
        }

        public void Run()
        {
          
            StringBuilder sb = new StringBuilder();

            //string[] parcels = { "6610000350", "7625703040" };
            _dataReader.DatabaseServer = _databaseServer;
            List<string> parcels = _dataReader.SelectRecord();
          
            driver = new InternetExplorerDriver(_seleniumDriverFolder);
            runAutomation = true;
            maxRun = 2;

            retryCount = 0;

            appendRow = true;

            string parcelNumber = string.Empty;


            RunParcelTaxReaderInfo(_dataReader.SelectRecord());
        }

        public void  RunParcelTaxReaderInfo(List<string> parcels)
        {
            int numberOfParcels = parcels.Count;
            int rowCount = 0;
            Stopwatch stopWatch = new Stopwatch();
            Hashtable currentRow = null;
            currentRow = new Hashtable();
            bool runAutomation = true;

            string parcelNumber = string.Empty;
            string rawParcelNumber = string.Empty;

            while (runAutomation && numberOfParcels > 0)
            {
                appendRow = true;
           
                driver = new InternetExplorerDriver(_seleniumDriverFolder);
                try
                {
                    rawParcelNumber = parcels[rowCount];
                    parcelNumber = rawParcelNumber.Replace(" ", string.Empty);

                    stopWatch.Start();

                    currentRow = new TruantPropertyTaxRecord(driver, parcelNumber).GetRow(new Hashtable());
                    currentRow = new EReal(driver, parcelNumber).GetRow(currentRow);
                  
                    currentRow["TaxId"] = rawParcelNumber;
                    currentRow["RawTaxId"] = rawParcelNumber;

                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                        ts.Hours,
                                        ts.Minutes,
                                        ts.Seconds,
                                        ts.Milliseconds / 10);


                    currentRow["QueryTime"] = elapsedTime;

                    _dataReader.InsertRecord(currentRow);
                    Console.WriteLine("Current Row : " + rowCount);
                    if (rowCount != 0 && rowCount % 20 == 0) {
                        //Thread.Sleep(300000);
                        Console.WriteLine("Execution Paused");
                    }


                    stopWatch.Reset();
                    driver.Dispose();
                }
                catch (ReRerunException re)
                {
                    runAutomation = ReRunLogic(re);
                }
                if (appendRow)
                {
                    retryCount = 0;
                    rowCount++;

                    if ((rowCount > numberOfParcels -1))
                    {
                        runAutomation = false;
                    }
                }
            }

            driver.Dispose();
            Console.WriteLine("Crawl Complete");
        }
        private static bool ReRunLogic(ReRerunException re)
        {
            Console.WriteLine(re.Message);
            driver.Close();
            Random rand = new Random();

            int timeout = rand.Next(15, 25) * 1000;
            Thread.Sleep(timeout);
            if (retryCount > maxRun)
            {
                return  false;
            }

            retryCount++;
            appendRow = false;
            return true;
        }

        public PropertyTaxReader DataReader
        {
            set { _dataReader = value; }
            get { return _dataReader; }
        }

        public string DatabaseServer
        {
            set { _databaseServer = value; }
            get { return _databaseServer; }
        }

        public string SeleniumWebDriverFolder
        {
            set { _seleniumDriverFolder = value; }
            get { return _seleniumDriverFolder; }
        }
    }
}
