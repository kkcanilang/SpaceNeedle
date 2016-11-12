using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using SeleniumAutomation.Selenium.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Frameworks
{
    public class AccountParcelSummaryFramework
    {
        private const string TAX_ACCOUNT_NUMBER_SPAN = "cphContent_TaxAccountNumber";
        private const string ACCOUNT_STATUS_SPAN = "cphContent_AccountStatus";
        private const string MAIL_ADDRESS_SPAN = "cphContent_MailingAddress";
        private const string PAYMENT_STATUS_SPAN = "cphContent_WebMessage";
        private const string TAX_PAYER_NAME_SPAN = "cphContent_TaxPayerName";
        private const string DELINQUENT_AMOUNTS_YEAR_SPAN_ID = "cphContent_DelinquentAmounts_Year_0";

        private const string RECEIPTS_TAB_XPATH = "//span[text()='Receipts']";
        private const string RECEIPTS_TABLE_BODY_XPATH = "//table[@id='cphContent_ReceiptGrid']/tbody/";

        private Span _taxAccountNumberSpan;
        private Span _accountStatusSpan;
        private Span _mailAddressSpan;
        private Span _paymentStatusSpan;
        private Span _taxPayerName;
        private Span _dilinquentAmountYears;

        private XPathElement _receiptsTab;

        private RemoteWebDriver _driver;
        public AccountParcelSummaryFramework(RemoteWebDriver driver)
        {
            _driver = driver;

            _taxAccountNumberSpan = new Span(_driver, TAX_ACCOUNT_NUMBER_SPAN);
            _accountStatusSpan = new Span(_driver,ACCOUNT_STATUS_SPAN);
            _mailAddressSpan = new Span(_driver, MAIL_ADDRESS_SPAN);
            _paymentStatusSpan = new Span(_driver, PAYMENT_STATUS_SPAN);
            _taxPayerName = new Span(_driver, TAX_PAYER_NAME_SPAN);
            _dilinquentAmountYears = new Span(_driver,DELINQUENT_AMOUNTS_YEAR_SPAN_ID);

            _receiptsTab = new XPathElement(_driver, RECEIPTS_TAB_XPATH);
        }

        public Span TaxAccountNumberSpan()
        {
            return _taxAccountNumberSpan;
        }

        public Span AccountStatusSpan()
        {
            return _accountStatusSpan;
        }

        public Span MailAddressSpan()
        {
            return _mailAddressSpan;
        }

        public Span PaymentStatusSpan()
        {
            return _paymentStatusSpan;
        }

        public Span TaxPayerName()
        {
            return _taxPayerName;
        }

        public Span DlinquentAmountYears()
        {
            return _dilinquentAmountYears;
        }
        public XPathElement ReceiptsTab()
        {
            return _receiptsTab;
        }

        public XPathElement RecieptsTable(int row, int column)
        {
            return new XPathElement(_driver,RECEIPTS_TABLE_BODY_XPATH + "/tr["+ row +"]/td[" + column + "]");
        }


    }
}
