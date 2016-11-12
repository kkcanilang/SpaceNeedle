using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using SeleniumAutomation.Selenium.Elements;
using OpenQA.Selenium.Remote;

namespace SeleniumAutomation.Frameworks
{
    public class SearchFramework
    {
        private const string PARCEL_NUMBER_TEXT_FIELD = "cphContent_RealAccountNumber";
        private const string SEARCH_BUTTON = "cphContent_RealSearch";
        private const string CAPTCHA_TEXT_FIELD = "recaptcha_response_field";

        private TextField _parcelNumberTextField;
        private TextField _captchaTextfield;
        private Button _searchButton;

        private RemoteWebDriver _driver;
        public SearchFramework(RemoteWebDriver driver)
        {
            _driver = driver;

            _parcelNumberTextField = new TextField(_driver, PARCEL_NUMBER_TEXT_FIELD);
            _captchaTextfield = new TextField(_driver, CAPTCHA_TEXT_FIELD);
            _searchButton = new Button(_driver, SEARCH_BUTTON);
        }

        public TextField ParcelNumberTextField()
        {
            return _parcelNumberTextField;
        }
        public TextField CapatchaTextField()
        {
            return _captchaTextfield;
        }
        public Button SearchButton()
        {
            return _searchButton;
        }






    }
}
