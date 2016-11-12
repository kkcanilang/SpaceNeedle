using OpenQA.Selenium.Remote;
using SeleniumAutomation.Selenium.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Frameworks
{
    public class PKITAOnlineSplashPageFramework
    {

        private const string SEARCH_REQUESTS_TILE_ID = "//a[@href='/PKITAWeb/Search/Requests']";
        private const string SEARCH_CERTIFICATE_TILE_ID = "//a[@href='/PKITAWeb/Search/Requests']";
        private const string SUBMISSION_ERRORS_TILE_ID = "//a[@href='/PKITAWeb/Diagnostic/ValidationErrors']";
        private const string USER_ROLES_TILE_ID = "//a[@href='/PKITAWeb/UsersManagement']";
        private const string CERTIFICATE_AUTHORITY_GROUPS_ID = "//a[@href='/PKITAWeb/CertAuthorityGroup']";
        private const string PENDING_APPROVALS_TILE = "//a[@href='/PKITAWeb/Role/PendingSubmitterApproval']";
        private const string CERTIFICATE_TEMPLATES_TILE = "//a[@href='/PKITAWeb/CertTemplate']";

        private XPathElement _searchRequestTile;
        private XPathElement _searchCertificateTile;
        private XPathElement _submissionErrorsTile;
        private XPathElement _usersRolesTile;
        private XPathElement _certificateAuthorityGroupsTile;
        private XPathElement _pendingApprovalsTile;
        private XPathElement _certificateTemplatesTile;

        private RemoteWebDriver _driver;

        
        public PKITAOnlineSplashPageFramework(RemoteWebDriver driver)
        {
            _driver = driver;

            _searchRequestTile = new XPathElement(_driver,SEARCH_REQUESTS_TILE_ID);
            _searchCertificateTile = new XPathElement(_driver, SEARCH_CERTIFICATE_TILE_ID);
            _submissionErrorsTile = new XPathElement(_driver, SUBMISSION_ERRORS_TILE_ID);
            _usersRolesTile = new XPathElement(_driver, USER_ROLES_TILE_ID);
            _certificateAuthorityGroupsTile = new XPathElement(_driver, CERTIFICATE_AUTHORITY_GROUPS_ID);
            _pendingApprovalsTile = new XPathElement(_driver, PENDING_APPROVALS_TILE);
            _certificateTemplatesTile = new XPathElement(_driver, CERTIFICATE_TEMPLATES_TILE);
        }

        public XPathElement SearchRequestTile
        {
            get { return _searchRequestTile; }
            private set { }
        }

        public XPathElement SearchCertificateTile
        {
            get { return _searchCertificateTile; }
            private set { }
        }

        public XPathElement SubmissionErrorsTile
        {
            get { return _submissionErrorsTile; }
            private set { }
        }

        public XPathElement UserRolesTile
        {
            get { return _usersRolesTile; }
            private set {}
        }

        public XPathElement CertificateAuthorityGroupsTile
        {
            get { return _certificateAuthorityGroupsTile; }
            private set { }
        }

        public XPathElement PendingApprovalTile
        {
            get { return _pendingApprovalsTile; }
            private set { }
        }

        public XPathElement CertificateTemplatesTile
        {
            get { return _certificateTemplatesTile; }
            private set { }
        }
    }
}
