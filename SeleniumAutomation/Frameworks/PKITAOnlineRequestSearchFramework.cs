using OpenQA.Selenium.Remote;
using SeleniumAutomation.Selenium.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Frameworks
{
    public class PKITAOnlineRequestSearchFramework
    {
        private const string SR_NUMBER_TEXTFIELD_ID = "SrNumber";
        private const string LANE_SELECT_ID = "LaneInfo";
        private const string SUBMITTED_BY_TEXTFIELD_ID = "SubmittedBy";
        private const string SUBMITTED_FROM_DATE_TEXTFIELD_ID = "FromDate";
        private const string SUBMITTED_FROM_TIME_TEXTFIELD_ID = "FromTime";
        private const string DESCRIPTION_TEXTFEID_ID = "RequestDescription";
        private const string TO_DATE_TEXTFIELD_ID = "ToDate";
        private const string TO_TIME_TEXTFIELD_ID = "ToTime";

        private const string REQUEST_STATUS_SELECT_ID = "RequestStatus";
        private const string SEARCH_BUTTON_ID = "btnSearchRequests";

        private TextField _srNumberTextField;
        private TextField _submittedByTextField;
        private TextField _submittedFromDateTextField;
        private TextField _submittedFromTimeTextField;
        private TextField _descriptionTextField;
        private TextField _submittedToDateTextField;
        private TextField _submittedToTimeTextField;

        private Select _laneSelect;
        private Select _requestStatusSelect;

        private Button _searchButton;

        private RemoteWebDriver _driver;
        public PKITAOnlineRequestSearchFramework(RemoteWebDriver driver)
        {
            _driver = driver;

            _srNumberTextField = new TextField(_driver, SR_NUMBER_TEXTFIELD_ID);

            _submittedByTextField = new TextField(_driver, SUBMITTED_BY_TEXTFIELD_ID);
            _submittedFromDateTextField = new TextField(_driver, SUBMITTED_FROM_DATE_TEXTFIELD_ID);
            _submittedFromTimeTextField = new TextField(_driver, SUBMITTED_FROM_TIME_TEXTFIELD_ID);
            _submittedToDateTextField = new TextField(_driver, TO_DATE_TEXTFIELD_ID);
            _submittedToTimeTextField = new TextField(_driver, TO_TIME_TEXTFIELD_ID);


            _laneSelect = new Select(_driver, LANE_SELECT_ID);
            _requestStatusSelect = new Select(_driver, REQUEST_STATUS_SELECT_ID);

            _searchButton = new Button(_driver, SEARCH_BUTTON_ID);

          
            _descriptionTextField = new TextField(_driver, DESCRIPTION_TEXTFEID_ID);
            

        }

        public TextField SrNumberTextField
        {
            get { return _srNumberTextField; }
            private set { }
        }

        public TextField SubmittedByTextField
        {
            get { return _submittedByTextField;  }
            private set{}
        }

        public TextField SubmittedFromDateTextField
        {
            get { return _submittedFromDateTextField; }
            private set { }
        }

        public Select LaneSelect
        {
            get { return _laneSelect; }
            private set { }
        }

        public Select RequestStatusSelect
        {
            get { return _requestStatusSelect; }
            private set { }
        }

        public Button SearchButton
        {
            get { return _searchButton;  }
            private set { }
        }

        public TextField SubmittedFromTimeTextfield
        {
            get { return _submittedFromTimeTextField; }
            private set { }
        }

        public TextField DescriptionTextField
        {
            get { return _descriptionTextField; }
            private set { }
        }

        public TextField SubmittedToDateTextField
        {
            get { return _submittedToDateTextField; }
            private set { }
        }

        public TextField SubmitedToTimeTextField
        {
            get { return _submittedToTimeTextField;  }
        }


    }
}
