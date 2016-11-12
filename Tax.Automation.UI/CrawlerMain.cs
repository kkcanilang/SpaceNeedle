using SeleniumAutomation.Automation.Data;
using SeleniumAutomation.Automation.Record.Utilities;
using SeleniumAutomation.Automation.Run;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tax.Automation.UI
{
    public partial class CrawlerMain : Form
    {
        private SeattleLeadsCrawl _crawler;

        private PropertyTaxLocalReader _localDataReader;

        public CrawlerMain()
        {
            _localDataReader = new PropertyTaxLocalReader();
            _crawler = new SeattleLeadsCrawl();

            InitializeComponent();
            LoadSavedValues();
        }

        private void LoadSavedValues()
        {
            Dictionary<string, string> data = _localDataReader.ReadData();
            bool dataExisits = (data.ContainsKey(PropertyTaxLocalReader.SERVER_NAME_KEY) &&
                               data.ContainsKey(PropertyTaxLocalReader.DRIVER_KEY) &&
                               data.ContainsKey(PropertyTaxLocalReader.USERNAME_KEY) &&
                               data.ContainsKey(PropertyTaxLocalReader.PASSWORD_KEY));

            string value = string.Empty;

            if (dataExisits)
            {
                if (data.TryGetValue(PropertyTaxLocalReader.SERVER_NAME_KEY, out value))
                {
                    DatabaseServerNameTextfield.Text = value;
                }

                if (data.TryGetValue(PropertyTaxLocalReader.DRIVER_KEY, out value))
                {
                    DriverFolderNameTextField.Text = value;
                }

                if (data.TryGetValue(PropertyTaxLocalReader.USERNAME_KEY, out value))
                {
                    UserNameTextfield.Text = value;
                }

                if (data.TryGetValue(PropertyTaxLocalReader.PASSWORD_KEY, out value))
                {
                    PasswordTextField.Text = value;
                }
            }
        }

        private void StartCrawlerButton_Click(object sender, EventArgs e)
        {
            _crawler.DatabaseServer = this.DatabaseServerNameTextfield.Text.Trim();
            
            _crawler.SeleniumWebDriverFolder = this.DriverFolderNameTextField.Text.Trim();
            _crawler.Run();
           
        }

        private void RequiredFieldsChanged(object sender, EventArgs e)
        {
            bool allowStart = (!String.IsNullOrEmpty(this.DatabaseServerNameTextfield.Text.Trim()))
             && (!String.IsNullOrEmpty(this.DriverFolderNameTextField.Text.Trim()))
             && (!String.IsNullOrEmpty(this.UserNameTextfield.Text.Trim()))
             && (!String.IsNullOrEmpty(this.PasswordTextField.Text.Trim()));

            StartCrawlerButton.Enabled = allowStart;


        }

        private void DatabaseName_Change(object sender, EventArgs e)
        {
            string currentDataSource = this.DatabaseServerNameTextfield.Text.Trim();

            if (!this.taxParcelInformationTableAdapter.Connection.DataSource.Equals(currentDataSource))
            {
                this.taxParcelInformationTableAdapter.Connection.ConnectionString = "Data Source=" + currentDataSource + ";Initial Catalog=PropertyTax;Integrated Security=True";
            }
            this.richTextBox1.Text = this.taxParcelInformationTableAdapter.Connection.ConnectionString;
            this.richTextBox1.Update();
        }


        private void ParcelIdTab_Selected(object sender, EventArgs e)
        {

            this.taxParcelInformationTableAdapter.Fill(this.propertyTaxDataSet.TaxParcelInformation);
        }

        private void CrawlerMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'propertyTaxDataSet.TaxParcelInformation' table. You can move, or remove it, as needed.
            //this.taxParcelInformationTableAdapter.Fill(this.propertyTaxDataSet.TaxParcelInformation);

        }

        private void SaveConfigCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DatabaseServerNameTextfield.Enabled = !SaveConfigCheckBox.Checked;
            DriverFolderNameTextField.Enabled = !SaveConfigCheckBox.Checked;
            UserNameTextfield.Enabled = !SaveConfigCheckBox.Checked;
            PasswordTextField.Enabled = !SaveConfigCheckBox.Checked;

            if (SaveConfigCheckBox.Checked)
            {
                _localDataReader.SaveData(DatabaseServerNameTextfield.Text,
                                          DriverFolderNameTextField.Text,
                                          UserNameTextfield.Text,
                                          PasswordTextField.Text);
            }
        }

        private void ExportCSVButton_Click(object sender, EventArgs e)
        {
            List<List<String>> results = _crawler.DataReader.DilinquentTaxIds();

            string content =  OutputFile.DelinquientCSVContent(results);
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV|*.csv";
            dialog.Title = "Save CSV File";
            dialog.ShowDialog();

            if (dialog.FileName != string.Empty)
            {
                System.IO.File.WriteAllText(dialog.FileName, content);
            }


        }
    }
}
