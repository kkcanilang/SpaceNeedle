using OpenQA.Selenium.Remote;
using SeleniumAutomation.Frameworks;
using System;
using System.Text;
using System.Threading;
using System.Collections;
using SeleniumAutomation.Frameworks.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using SeleniumAutomation.Automation.Record.Utilities;

namespace SeleniumAutomation.Automation.Record
{
    public class TruantPropertyTaxRecord : GeneralRun
    {
        private SearchFramework _searchFramework;
        private AccountParcelSummaryFramework _accountParcelSummaryFramework;
        private Hashtable _row = new Hashtable();

        public const int MAX_COLUMN = 3;
        public const int MAX_ROW = 7;

        private string _parcelNumber;
        private CaptchaSolver _captchaSolver;

        private string _userName;
        private string _password;
        private string _captchaBalance;
        public TruantPropertyTaxRecord(RemoteWebDriver driver, string ParcelNumber) :
               base(driver)
        {
            _searchFramework = new SearchFramework(_driver);
            _accountParcelSummaryFramework = new AccountParcelSummaryFramework(_driver);
            _parcelNumber = ParcelNumber;
            _captchaSolver = new CaptchaSolver(_userName, _password);
            //_captchaBalance = _captchaSolver.Balance;
        }

        public string GetRow()
        {

            StringBuilder sb = new StringBuilder();


            GoToAccountParcelSummaryPage();

            var taxPayerName = _accountParcelSummaryFramework.TaxPayerName().Text();
            var taxAccountNumber = _accountParcelSummaryFramework.TaxAccountNumberSpan().Text();
            var accountStatus = _accountParcelSummaryFramework.AccountStatusSpan().Text();
            var mailingAddress = _accountParcelSummaryFramework.MailAddressSpan().Text();
            var paymentStatus = _accountParcelSummaryFramework.PaymentStatusSpan().Text();

            _accountParcelSummaryFramework.ReceiptsTab().Click();

            var recieptsFirstAmount = _accountParcelSummaryFramework.RecieptsTable(2, 3).Text();
            var recieptsSecondAmount = _accountParcelSummaryFramework.RecieptsTable(3, 3).Text();


            //sb.Append(taxPayerName. + ',');
            sb.Append(taxAccountNumber + ',');
            sb.Append(accountStatus.Replace("\r\n", " ") + ',');
            sb.Append(mailingAddress.Replace("\r\n", " ") + ',');
            sb.Append(paymentStatus.Replace("\r\n", " ") + ',');
            sb.Append(recieptsFirstAmount.Replace(",", " ") + ',');
            sb.Append(recieptsSecondAmount.Replace(",", " "));

            _driver.Close();
            _driver.Quit();

            return sb.ToString();
        }

        public override Hashtable GetRow(Hashtable row)
        {
            _row = row;

            try
            {
                GoToAccountParcelSummaryPage();
                _row["CachedURL"] = _driver.Url;
                var taxPayerName = _accountParcelSummaryFramework.TaxPayerName().Text();
                var accountStatus = _accountParcelSummaryFramework.AccountStatusSpan().Text();
                var mailingAddress = _accountParcelSummaryFramework.MailAddressSpan().Text();
                var paymentStatus = _accountParcelSummaryFramework.PaymentStatusSpan().Text();
                var IsDilinquent = _accountParcelSummaryFramework.DlinquentAmountYears().Exists();

                _accountParcelSummaryFramework.ReceiptsTab().Click();


                List<Receipt> Receipts = new List<Receipt>();
                string reciptID = string.Empty;
                for (int i = 2; i <= MAX_ROW; i++)
                {
                    reciptID = _accountParcelSummaryFramework.RecieptsTable(i, 2).Text();
                    if (!string.IsNullOrEmpty(reciptID.Trim()))
                    {
                        Receipts.Add(
                            new Receipt
                            {
                                Date = _accountParcelSummaryFramework.RecieptsTable(i, 1).Text(),
                                ReceiptNumber = _accountParcelSummaryFramework.RecieptsTable(i, 2).Text(),
                                Amount = _accountParcelSummaryFramework.RecieptsTable(i, 3).Text()
                            });
                    }
                }


                StringBuilder sb = new StringBuilder();

                sb.AppendLine("<RECEIPTS>");

                foreach (var r in Receipts)
                {

                    sb.AppendLine("<RECEIPT>");
                    sb.AppendLine("<DATE>" + r.Date + "</DATE>");
                    sb.AppendLine("<RECEIPT>" + r.ReceiptNumber + "</RECEIPT>");
                    sb.AppendLine("<AMOUNT>" + r.Amount + "</AMOUNT>");
                    sb.AppendLine("</RECEIPT>");
                }

                sb.AppendLine("</RECEIPTS>");

                ProcessName(taxPayerName.Replace("\r\n", " "));
                ProccessAdressSections(mailingAddress.Replace("\r\n", " "));


                _row.Add("ReceiptsList", sb.ToString().Replace("\r\n", " "));
                //_row.Add("FirstName", taxPayerName.Replace("\r\n", " "));
                //_row.Add("OwnerTwo", taxPayerName.Replace("\r\n", " "));
                _row.Add("Status", accountStatus.Replace("\r\n", " "));
                //_row.Add("MailingStreetOne", mailingAddress.Replace("\r\n", " "));

                _row.Add("PaymentStatus", paymentStatus.Replace("\r\n", " "));
                _row.Add("IsDilinquent", IsDilinquent);
                _row["QueryResult"] = "READY";

                Thread.Sleep(1000);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString().Replace("\r\n", " "));
                _row["QueryResult"] = "ERROR";
                _driver.Quit();
            }

            return _row;
        }

        private void GoToAccountParcelSummaryPage()
        {

            _driver.Navigate().GoToUrl("http://info.kingcounty.gov/finance/treasury/propertytax/RealProperty.aspx?Parcel=" + _parcelNumber);

            bool captchaExists = false;
            try
            {
                captchaExists = _searchFramework.CapatchaTextField().Displayed();

            }
            catch (Exception e)
            {

            };


            if (captchaExists)
            {

                //recaptcha_challenge_image
                var arrScreen = _driver.GetScreenshot().AsByteArray;

                using (var msScreen = new MemoryStream(arrScreen))
                {
                    var bmpScreen = new Bitmap(msScreen);
                    var cap = _driver.FindElementById("recaptcha_challenge_image");
                    var rcCrop = new Rectangle(cap.Location, cap.Size);
                    Image imgCap = bmpScreen.Clone(rcCrop, bmpScreen.PixelFormat);

                    using (var msCaptcha = new MemoryStream())
                    {
                        imgCap.Save(msCaptcha, ImageFormat.Png);
                        string captchaText = _captchaSolver.SolveCaptcha(msCaptcha);
                        _captchaBalance = _captchaSolver.Balance;
                        _searchFramework.CapatchaTextField().Type(captchaText);
                    }
                }


            }

            while (!_searchFramework.ParcelNumberTextField().Displayed())
            {
                Thread.Sleep(1000);
            }


            while (!_searchFramework.SearchButton().Displayed() ||
                   !_searchFramework.SearchButton().Enabled())
            {
                Thread.Sleep(1000);
            }

            //_searchFramework.ParcelNumberTextField().Type(_parcelNumber);
            _searchFramework.SearchButton().Click();
            if (captchaExists)
            {
                try
                {
                    _searchFramework.SearchButton().Click();

                }
                catch (Exception ex) { Console.WriteLine("Cannot Click Search Button!"); }

            }
        }

        private void ProcessName(string rawName)
        {
            string[] names = null;
            string[] fullName = null;
            string firstName = string.Empty;
            string lastName = string.Empty;

            string pat = @"[\d-]";
            string removeSymbols = @"[^\w\.@\- ]";

            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            //Regex r2 = new Regex(removeSymbols, RegexOptions.IgnoreCase);
            string cleanedUpValue = string.Empty;

            cleanedUpValue = r.Replace(rawName, " ");
            cleanedUpValue = cleanedUpValue.Replace("\r\n", " ");
            cleanedUpValue = cleanedUpValue.Trim();
            //cleanedUpValue = r2.Replace(cleanedUpValue, " ");

            if (cleanedUpValue.Contains('+'))
            {
                names = cleanedUpValue.Split('+');

                fullName = names[0].Split(' ');
                ProccessWholeName(fullName);
                _row.Add("OwnerTwo", names[1]);
            }
            else
            {
                names = cleanedUpValue.Split(' ');
                ProccessWholeName(names);

            }
            //}
        }

        public void ProccessWholeName(string[] fullName)
        {
            string firstName = string.Empty;
            string lastName = string.Empty;
            string middleInitial = string.Empty;

            if (fullName.Length > 2)
            {
                lastName = fullName[0];
                for (int i = 1; i < fullName.Length; i++)
                {
                    firstName = firstName + " " + fullName[i].Trim();
                }
            }
            else if (fullName.Length > 1)
            {
                lastName = fullName[0];

                firstName = fullName[1];

            }
            else
            {
                lastName = fullName[0];
            }

            if (fullName.Length > 1)
            {
                _row.Add("FirstName", fullName[1]);
                _row.Add("LastName", fullName[0]);
            }
            else
            {
                _row.Add("LastName", fullName[0]);
            }

        }

        private void ProccessAdressSections(string rawAddress)
        {
            string[] addressSection = rawAddress.Split(' ');
            int length = addressSection.Length;

            string mailingStreetOne = string.Empty;
            string mailingStreetAddress = string.Empty;
            string mailCity = string.Empty;
            string mailState = string.Empty;
            string zip = string.Empty;

            if (length > 3)
            {
                zip = addressSection[length - 1];
                mailState = addressSection[length - 2];
                mailCity = addressSection[length - 3];
                mailingStreetOne = addressSection[0];

                //mailingStreetAddress = rawAddress.Replace(mailingStreetOne, "").
                //    Replace(mailCity, "").
                //    Replace(mailState, "").
                //    Replace(mailingStreetOne, "").
                //    Replace(zip, "");

                mailingStreetAddress = rawAddress.Replace(mailingStreetOne, "");

                if (!string.IsNullOrEmpty(mailCity))
                {
                    mailingStreetAddress = mailingStreetAddress.Replace(mailCity, "");
                }

                if (!string.IsNullOrEmpty(mailState))
                {
                    mailingStreetAddress = mailingStreetAddress.Replace(mailState, "");
                }

                if (!string.IsNullOrEmpty(mailingStreetOne))
                {
                    mailingStreetAddress = mailingStreetAddress.Replace(mailingStreetOne, "");
                }

                if (!string.IsNullOrEmpty(zip))
                {
                    mailingStreetAddress = mailingStreetAddress.Replace(zip, "");
                }

            }
            else
            {
                mailingStreetOne = addressSection[0];
            }
            _row.Add("MailingStreetOne", mailingStreetOne.Replace("\r\n", " "));
            _row.Add("MailingStreetTwo", mailingStreetAddress.Replace("\r\n", " "));
            _row.Add("MailingStateProvince", mailState.Replace("\r\n", " "));
            _row.Add("MailingCity", mailCity.Replace("\r\n", " "));
            _row.Add("MailingZip", zip.Replace("\r\n", " "));
        }

        public string DeathByCaptchaUserName
        {
            set { _userName = value; }
            get { return _userName; }
        }
         public string DeathByCaptchPassword
         {
            set { _password = value; }
            get { return _password; }
         }

        public string DeathByCaptchaBalance
        {
            get { return _captchaBalance; }
        }
    }
}
