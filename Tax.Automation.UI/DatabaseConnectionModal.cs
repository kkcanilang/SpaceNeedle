using SeleniumAutomation.Automation.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tax.Automation.UI
{
    public partial class DatabaseConnectionModal : Form
    {

        private PropertyTaxLocalReader _localDataReader;
        private ConnectingModal modal;
        public DatabaseConnectionModal()
        {
            _localDataReader = new PropertyTaxLocalReader();
            InitializeComponent();
            LoadSavedValues();
            EnabaleConnectionButton();
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
                    DatabaseNameTextfield.Text = value;
                }

                if (data.TryGetValue(PropertyTaxLocalReader.DRIVER_KEY, out value))
                {
                    DriverFolderTextfield.Text = value;
                }

                if (data.TryGetValue(PropertyTaxLocalReader.USERNAME_KEY, out value))
                {
                    UserNameTextField.Text = value;
                }

                if (data.TryGetValue(PropertyTaxLocalReader.PASSWORD_KEY, out value))
                {
                    PasswordTextField.Text = value;
                }

            }


        }

        private void RequiredFieldsChanged(object sender, EventArgs e)
        {

            EnabaleConnectionButton();

        }

        private void EnabaleConnectionButton()
        {
            bool allowStart = (!String.IsNullOrEmpty(this.DatabaseNameTextfield.Text.Trim()))
           && (!String.IsNullOrEmpty(this.DriverFolderTextfield.Text.Trim()))
           && (!String.IsNullOrEmpty(this.UserNameTextField.Text.Trim()))
           && (!String.IsNullOrEmpty(this.PasswordTextField.Text.Trim()));

            ConnectButton.Enabled = allowStart;

            if (ConnectionErrorLabel.Visible)
            {
                ConnectionErrorLabel.Visible = false;
            }

        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            bool succeedeed = false;

            string databaseName = DatabaseNameTextfield.Text;
            string driverFolder = DriverFolderTextfield.Text;
            string userName = UserNameTextField.Text;
            string password = PasswordTextField.Text;



            if (!string.IsNullOrEmpty(databaseName))
            {
                ConnectingModal modal = new ConnectingModal();
                modal.Show();

                ActivateControls(false);
                var task = await PropertyTaxReader.TestConnection(databaseName);
                
                ActivateControls(true);
                modal.Dispose();

                succeedeed = task;

            }

            if (succeedeed)
            {
                _localDataReader.SaveData(databaseName,
                          driverFolder,
                          userName,
                          password);
                this.Close();
            }
            else
            {
                this.ConnectionErrorLabel.Visible = true;

            }

        }

        private void ActivateControls(bool isEnabled)
        {
            DatabaseNameTextfield.Enabled = isEnabled;
            DriverFolderTextfield.Enabled = isEnabled;
            UserNameTextField.Enabled = isEnabled;
            PasswordTextField.Enabled = isEnabled;
            ConnectButton.Enabled = isEnabled;
        }

    }

}
