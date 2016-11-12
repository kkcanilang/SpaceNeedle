using OpenQA.Selenium.Remote;
using SeleniumAutomation.Selenium.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Frameworks
{
    public class ERealPropertySearchFramework
    {
        private const string PARCEL_NUMBER_TEXTFIELD_ID = "kingcounty_gov_cphContent_txtParcelNbr";
        private const string SEARCH_BUTTON_ID = "kingcounty_gov_cphContent_btn_Search";

       

        private RemoteWebDriver _driver;

        private TextField _parcelNumberTextField;
        private Button _searchButton;

        public ERealPropertySearchFramework(RemoteWebDriver driver)
        {
            _driver = driver;
            _parcelNumberTextField = new TextField(_driver,PARCEL_NUMBER_TEXTFIELD_ID);
            _searchButton = new Button(_driver, SEARCH_BUTTON_ID);
        }

        public TextField ParcelNumberTextField()
        {
            return _parcelNumberTextField;
        }

        public Button SearchButton()
        {
            return _searchButton;
        }

    }
}
