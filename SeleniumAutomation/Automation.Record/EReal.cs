using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomation.Frameworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomation.Automation.Record
{
    public class EReal : GeneralRun
    {
        private string _parcelNumber;
        private ERealTermsAndConditionsFramework _eRealTermsAndCondition;
        private ERealPropertySearchFramework _eRealPropertySearchFramework;
        private ERealPropertyDetailsFramework _eRealPropertyDetailsFramework;
        private HtmlAgilityPack.HtmlDocument _htmlDoc;
        private Hashtable _row;

        public EReal(RemoteWebDriver driver, string parcelNumber): base(driver)
        {
            _driver = driver;
            _htmlDoc = new HtmlAgilityPack.HtmlDocument();
            _parcelNumber = parcelNumber;
            _eRealTermsAndCondition = new ERealTermsAndConditionsFramework(_driver);
            _eRealPropertySearchFramework = new ERealPropertySearchFramework(_driver);
            _eRealPropertyDetailsFramework = new ERealPropertyDetailsFramework(_driver);  
                     

        }

        public override Hashtable GetRow(Hashtable row)
        {
            _row = row;
            return GotToERealHTMLPage(_row);
        }

        private Hashtable GotToERealHTMLPage(Hashtable row)
        {
            try
            {

                HttpWebRequest oReq = (HttpWebRequest)WebRequest.Create("http://blue.kingcounty.com/Assessor/eRealProperty/Detail.aspx?ParcelNbr=" + _parcelNumber);
                HttpWebResponse resp = (HttpWebResponse)oReq.GetResponse();


                _htmlDoc.Load(resp.GetResponseStream());


                string zoneCode = GetElement(_eRealPropertyDetailsFramework.ZoneingCodeCell().Id);
                string presentUseCell = GetElement(_eRealPropertyDetailsFramework.PresentUseCell().Id);


                string appraisedTotalValueCell = GetElement(_eRealPropertyDetailsFramework.AppraisedTotalValueCell().Id);
                string appriasdedTotalImprOvementCell = GetElement(_eRealPropertyDetailsFramework.AppraisedTotalImporvementCell().Id);
                string appraisedLandTotalValueCell = GetElement(_eRealPropertyDetailsFramework.AppraisedLandValueCell().Id);

                string lastSalesDate = GetElement(_eRealPropertyDetailsFramework.LastSalesDateCell().Id);
                string lastSalesPrice = GetElement(_eRealPropertyDetailsFramework.LastSalesPriceCell().Id);

                string buildingSQRFoot = GetElement(_eRealPropertyDetailsFramework.BuildingSqrFootCell().Id);
                string lotSqrFoot = GetElement(_eRealPropertyDetailsFramework.LotSqrFootCell().Id);
                string effectiveYearCell = GetElement(_eRealPropertyDetailsFramework.EffectiveYearCell().Id);
                string buildYear = GetElement(_eRealPropertyDetailsFramework.BuildYearCell().Id);
                string siteAddress = GetElement(_eRealPropertyDetailsFramework.SiteAddressCell().Id);
                string numberOfUnits = GetElement(_eRealPropertyDetailsFramework.NumberOfUnitsCell().Id);

                row.Add("ZoningCode", zoneCode.Replace("\r\n", " "));

                row.Add("LandUse", presentUseCell.Replace("\r\n", " "));

                row.Add("AssessedValueTotal", appraisedTotalValueCell.Replace("\r\n", " "));

                row.Add("AssessedValueLand", appraisedLandTotalValueCell.Replace("\r\n", " "));

                row.Add("AssessedValueImproved", appriasdedTotalImprOvementCell.Replace("\r\n", " "));

                row.Add("LastSaleDate", lastSalesDate.Replace("\r\n", " "));
                row.Add("LastSalesPrice", lastSalesPrice.Replace("\r\n", " "));

                row.Add("BuildingSquareFoot", buildingSQRFoot.Replace("\r\n", " "));

                row.Add("LotSquareFoot", lotSqrFoot.Replace("\r\n", " "));

                row.Add("EffectiveYear", effectiveYearCell.Replace("\r\n", " "));

                row.Add("YearBuilt", buildYear.Replace("\r\n", " "));

                row.Add("NumberOfUnits", numberOfUnits.Replace("\r\n", " "));

                //row.Add("SiteStreet", siteAddress);
                row.Add("SiteCity", GetElement(_eRealPropertyDetailsFramework.SiteCity().Id).Replace("\r\n", " "));
                ProccessAdressSections(siteAddress);

                row["QueryResult"] = "COMPLETED";

                _driver.Close();
                _driver.Quit();
                return row;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                row["QueryResult"] = "ERROR";
                _driver.Quit();
                return row;
            }
        }


        private Hashtable GotToERealPage(Hashtable row)
        {
            try
            {
                //_driver.Navigate().GoToUrl("http://blue.kingcounty.com/Assessor/eRealProperty/Default.aspx");


                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));


                //wait.Until(x => x.FindElement(By.Id(_eRealTermsAndCondition.AcknolledgementCheckBox().Id)));

                //_eRealTermsAndCondition.AcknolledgementCheckBox().Check();

                //wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

                //wait.Until(x => x.FindElement(By.Id(_eRealPropertySearchFramework.ParcelNumberTextField().Id)));

                //_eRealPropertySearchFramework.ParcelNumberTextField().Type(_parcelNumber);

                //_eRealPropertySearchFramework.SearchButton().Click();
                _driver.Navigate().GoToUrl("http://blue.kingcounty.com/Assessor/eRealProperty/Detail.aspx?ParcelNbr=" + _parcelNumber);

                _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                // wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

                //wait.Until(x => x.FindElement(By.LinkText(_eRealPropertyDetailsFramework.PropertyDetailLink().Id)));

                //_eRealPropertyDetailsFramework.PropertyDetailLink().Click();

                //wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

                wait.Until(x => x.FindElement(By.XPath(_eRealPropertyDetailsFramework.ZoneingCodeCell().Id)));


                _eRealPropertyDetailsFramework.ZoneingCodeCell().Click();
                string zoneCode = _eRealPropertyDetailsFramework.ZoneingCodeCell().Text();

                string presentUseCell = _eRealPropertyDetailsFramework.PresentUseCell().Text();
                string appraisedTotalValueCell = _eRealPropertyDetailsFramework.AppraisedTotalValueCell().Text();

                
                string appriadedTotalImprOvementCell = _eRealPropertyDetailsFramework.AppraisedTotalImporvementCell().Text();
                string appraisedLandTotalValueCell = _eRealPropertyDetailsFramework.AppraisedLandValueCell().Text();
                string lastSalesDate = _eRealPropertyDetailsFramework.LastSalesDateCell().Text();
                string buildingSQRFoot = _eRealPropertyDetailsFramework.BuildingSqrFootCell().Text();
                string lotSqrFoot = _eRealPropertyDetailsFramework.LotSqrFootCell().Text();
                string effectiveYearCell = _eRealPropertyDetailsFramework.EffectiveYearCell().Text();
                string buildYear = _eRealPropertyDetailsFramework.BuildYearCell().Text();
                string siteAddress = _eRealPropertyDetailsFramework.SiteAddressCell().Text();

                row.Add("ZoningCode", zoneCode);

                row.Add("LandUse", presentUseCell);

                row.Add("AssessedValueTotal", appraisedTotalValueCell);

                row.Add("AssessedValueLand",appraisedLandTotalValueCell);

                row.Add("AssessedValueImproved", appriadedTotalImprOvementCell);

                row.Add("LastSaleDate", lastSalesDate);

                row.Add("BuildingSquareFoot", buildingSQRFoot);

                row.Add("LotSquareFoot", lotSqrFoot);

                row.Add("EffectiveYear", effectiveYearCell);

                row.Add("YearBuilt", buildYear);

                row.Add("SiteCity", _eRealPropertyDetailsFramework.SiteCity().Text());

                ProccessAdressSections(siteAddress);
                //row.Add("SiteStreet", siteAddress);

                row["QueryResult"] = "COMPLETED";

                _driver.Close();
                _driver.Quit();
                return row;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                 row["QueryResult"] = "ERROR";
                _driver.Quit();
                return row;
            }
        }

        private void ProccessAdressSections(string rawAddress)
        {
            string[] addressSection = rawAddress.Split(' ');
            int length = addressSection.Length;

            string mailingStreetOne = string.Empty;
            string mailingStreetAddress = string.Empty;
            string zip = string.Empty;

            if (length > 3)
            {
                zip = addressSection[length - 1];
                mailingStreetOne = addressSection[0];

                mailingStreetAddress = rawAddress.Replace(mailingStreetOne, "");


                if (!string.IsNullOrEmpty(zip)) {
                    mailingStreetAddress = mailingStreetAddress.Replace(zip, "");
                }
            }
            else
            {
                mailingStreetOne = addressSection[0];
            }
            _row.Add("SiteStreet", mailingStreetOne.Replace("\r\n", " "));
            _row.Add("SiteStreetThree", mailingStreetAddress.Replace("\r\n", " "));
            _row.Add("SiteZipPostalCode",zip.Replace("\r\n", " "));
           
        }

        private string GetElement(string identifier)
        {
            return (null == (_htmlDoc.DocumentNode.SelectSingleNode(identifier)) ? "" : _htmlDoc.DocumentNode.SelectSingleNode(identifier).InnerText);
        }

    }
}
