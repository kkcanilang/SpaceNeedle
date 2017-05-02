using OpenQA.Selenium.IE;
using SeleniumAutomation.Automation.Data;
using SeleniumAutomation.Automation.Record;
using SeleniumAutomation.Selenium.Exception;
using SeleniumAutomation.Selenium.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tax.Automation.UI.Logging;

namespace SeleniumAutomation.Automation.Run
{
    public class SeattleLeadsCrawl : ICrawl
    {
        private static InternetExplorerDriver _driver;
        public static int retryCount = 0;
        public static int maxRun = 10;
        public static bool runAutomation = true;
        public static bool appendRow = true;
        public static bool IsERealInfo = true;

        private PropertyTaxReader _dataReader;
        private TruantPropertyTaxRecord _taxRecord;
        private string _databaseServer;
        private string _userName;
        private string _password;
        private string _seleniumDriverFolder;

        private Logger _log;
        public SeattleLeadsCrawl()
        {
            _log = new Logger();
            _dataReader = new PropertyTaxReader(_databaseServer);
        }

        public void Run()
        {
            
            StringBuilder sb = new StringBuilder();

            //string[] parcels = { "6610000350", "7625703040" };
            _dataReader.DatabaseServer = _databaseServer;
            List<string> parcels = _dataReader.SelectRecord();

            //try {
            //    _driver = new InternetExplorerDriver(_seleniumDriverFolder);
            // } catch (Exception ex)
            //{
            //    _log.LogError(ex.Message);
            //}
            runAutomation = true;
            maxRun = 2;

            retryCount = 0;

            appendRow = true;

            string parcelNumber = string.Empty;


            RunParcelTaxReaderInfo(_dataReader.SelectRecord());
        }

        public void Run(List<string> parcels)
        {

            StringBuilder sb = new StringBuilder();

            //string[] parcels = { "6610000350", "7625703040" };
            _dataReader.DatabaseServer = _databaseServer;
            //List<string> parcels = _dataReader.SelectRecord();

            //_driver = new InternetExplorerDriver(_seleniumDriverFolder);
            runAutomation = true;
            maxRun = 2;

            retryCount = 0;

            appendRow = true;

            string parcelNumber = string.Empty;


            RunParcelTaxReaderInfo(_dataReader.SelectRecord());
        }

        public void Stop()
        {
            try
            {
                _driver.Quit();
                //_driver.Close();
                _driver.Dispose();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.StackTrace);
            }


        }

        public void  RunParcelTaxReaderInfo(List<string> parcels)
        {
            try
            {
                string batchId = System.Guid.NewGuid().ToString();
                string batchStartTime = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            
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

                    if (_driver != null)
                    {
                        _driver.Dispose();
                        GeneralUntilities.KillAllBrowsersAndWebDrivers();
                    }
                    _driver = new InternetExplorerDriver(_seleniumDriverFolder);
                    try
                    {
                        rawParcelNumber = parcels[rowCount];
                        parcelNumber = rawParcelNumber.Replace(" ", string.Empty);

                        stopWatch.Start();

                        currentRow = new TruantPropertyTaxRecord(_driver, parcelNumber, _log,_userName,_password).GetRow(new Hashtable());
                        currentRow = new EReal(_driver, parcelNumber, _log).GetRow(currentRow);

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
                        currentRow["BatchID"] = batchId;
                        currentRow["BatchStartTime"] = batchStartTime;

                        _dataReader.UpdateRecord(currentRow);
                        Console.WriteLine("Current Row : " + rowCount);
                        _log.LogInfo("Current Row : " + rowCount);
                        if (rowCount != 0 && rowCount % 20 == 0)
                        {
                            _log.LogInfo("Execution Paused");
                            //Thread.Sleep(300000);
                            Console.WriteLine("Execution Paused");
                        }


                        stopWatch.Reset();
                        _driver.Dispose();
                    }
                    catch (ReRerunException re)
                    {
                        runAutomation = ReRunLogic(re);
                        _log.LogInfo(re.Message);
                    }
                    if (appendRow)
                    {
                        retryCount = 0;
                        rowCount++;

                        if ((rowCount > numberOfParcels - 1))
                        {
                            runAutomation = false;
                        }
                    }
                }

                _driver.Dispose();
                Console.WriteLine("Crawl Complete");
            }
            catch (Exception ex) {
                _log.LogError(ex.Message);
            }
        }
        private static bool ReRunLogic(ReRerunException re)
        {
            Console.WriteLine(re.Message);
            _driver.Close();
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

        public string UserName
        {
            set { _userName = value; }
            get { return _userName; }
        }

        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }


    }
}
