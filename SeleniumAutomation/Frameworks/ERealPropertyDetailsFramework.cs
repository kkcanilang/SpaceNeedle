using OpenQA.Selenium.Remote;
using SeleniumAutomation.Selenium.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Frameworks
{
    public class ERealPropertyDetailsFramework
    {
        private const string PROPERTY_DETAIL_LINK = "Property Detail";
        private const string PARCEL_NUMBER_CELL = "//td[text()='Parcel']";
        private const string ZONEING_CODE_CELL = "//td[text()='Zoning']/following-sibling::td";
        private const string PRESENT_USE_CELL = "//td[text()='Present Use']/following-sibling::td";

        private const string SITE_CITY_CELL = "//td[text()='Jurisdiction']/following-sibling::td";


        private const string NUMBER_OF_UNITS = "//td[text()='# of Units']//following-sibling::td";

        private const string APPRAISED_VALUE_TOTAL = "//table[@id='kingcounty_gov_cphContent_GridViewTaxRoll']/tr[2]/td[8]";
        private const string APPRAISED_VALUE_IMPROVEMENT = "//table[@id='kingcounty_gov_cphContent_GridViewTaxRoll']/tr[2]/td[7]";
        private const string APPRAISED_VALUE_LAND = "//table[@id='kingcounty_gov_cphContent_GridViewTaxRoll']/tr[2]/td[6]";

        private const string LAST_SALES_DATE_CELL = "//table[@id='kingcounty_gov_cphContent_GridViewSales']/tr[2]/td[3]";
        private const string LAST_SALES_PRICE_CELL = "//table[@id='kingcounty_gov_cphContent_GridViewSales']/tr[2]/td[4]";

        private const string BUILDING_SQ_FOOT_CELL = "//td[text()='Building Gross Sq Ft']/following-sibling::td";
        private const string LOT_SQ_FOOT_CELL = "//td[text()='Land SqFt']/following-sibling::td";
        private const string EFFECTIVE_YEAR_CELL = "//td[text()='Eff Year']/following-sibling::td";
        private const string BUILT_YEAR_CELL = "//td[text()='Year Built']/following-sibling::td";
        private const string SITE_ADDRESS_CELL = "//td[text()='Site Address']/following-sibling::td";

        private RemoteWebDriver _driver;

        private XPathElement _zoneingCodeCell;
        private XPathElement _parcelNumberCell;
        private XPathElement _presentUseCell;

        private XPathElement _appraisedTotalValueCell;
        private XPathElement _appraisedTotalImprovmentCell;
        private XPathElement _appriaseLandValueCell;

        private XPathElement _numberOfUnitsCell;

        private XPathElement _lastSalesDateCell;
        private XPathElement _lastSalesPriceCell;

        private XPathElement _buildingSqrFootCell;
        private XPathElement _lotSqrFootCell;
        private XPathElement _effectiveYearCell;
        private XPathElement _buildYearCell;
        private XPathElement _siteAddressCell;

        private XPathElement _siteCity;

        private Anchor _propertyDetailLink;

        public ERealPropertyDetailsFramework(RemoteWebDriver driver)
        {
            _driver = driver;

            _zoneingCodeCell = new XPathElement(_driver, ZONEING_CODE_CELL);
            _parcelNumberCell = new XPathElement(_driver, PARCEL_NUMBER_CELL);
            _presentUseCell = new XPathElement(_driver, PRESENT_USE_CELL);

            _propertyDetailLink = new Anchor(_driver, PROPERTY_DETAIL_LINK);

            _appraisedTotalValueCell = new XPathElement(_driver, APPRAISED_VALUE_TOTAL);
            _appraisedTotalImprovmentCell = new XPathElement(_driver, APPRAISED_VALUE_IMPROVEMENT);
            _appriaseLandValueCell = new XPathElement(_driver, APPRAISED_VALUE_LAND);

            _numberOfUnitsCell = new XPathElement(_driver, NUMBER_OF_UNITS);

            _lastSalesDateCell = new XPathElement(_driver, LAST_SALES_DATE_CELL);
            _lastSalesPriceCell = new XPathElement(_driver, LAST_SALES_PRICE_CELL);

            _buildingSqrFootCell = new XPathElement(_driver,BUILDING_SQ_FOOT_CELL);
            _lotSqrFootCell = new XPathElement(_driver, LOT_SQ_FOOT_CELL);
            _effectiveYearCell = new XPathElement(_driver, EFFECTIVE_YEAR_CELL);
            _buildYearCell = new XPathElement(_driver, BUILT_YEAR_CELL);
            _siteAddressCell = new XPathElement(_driver, SITE_ADDRESS_CELL);

            _siteCity = new XPathElement(_driver, SITE_CITY_CELL);
        }

        public XPathElement ZoneingCodeCell()
        {
            return _zoneingCodeCell;
        }

        public XPathElement SiteCity()
        {
            return _siteCity;
        }

        public XPathElement ParcelNumberCell()
        {
            return _parcelNumberCell;
        }

        public Anchor PropertyDetailLink()
        {
            return _propertyDetailLink;
        }

        public XPathElement PresentUseCell()
        {
            return _presentUseCell;
        }

        public XPathElement AppraisedTotalValueCell()
        {
            return _appraisedTotalValueCell;
        }

        public XPathElement AppraisedTotalImporvementCell()
        {
            return _appraisedTotalImprovmentCell;
        }

        public XPathElement AppraisedLandValueCell()
        {
            return _appriaseLandValueCell;
        }

        public XPathElement NumberOfUnitsCell()
        {
            return _numberOfUnitsCell;
        }

        public XPathElement LastSalesDateCell()
        {
            return _lastSalesDateCell;
        }

        public XPathElement LastSalesPriceCell()
        {
            return _lastSalesPriceCell;
        }

        public XPathElement BuildingSqrFootCell()
        {
            return _buildingSqrFootCell;
        }

        public XPathElement LotSqrFootCell()
        {
            return _lotSqrFootCell;
        }

        public XPathElement EffectiveYearCell()
        {
            return _effectiveYearCell;
        }

        public XPathElement BuildYearCell()
        {
            return _buildYearCell;
        }

        public XPathElement SiteAddressCell()
        {
            return _siteAddressCell;
        }


    }
}
