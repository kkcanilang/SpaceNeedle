using SeleniumAutomation.Automation.Data;
using SeleniumAutomation.Automation.Record.Utilities;
using SeleniumAutomation.Automation.Run;
using SeleniumAutomation.Frameworks.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Tax.Automation.UI.Logging;

namespace Tax.Automation.UI
{
    public partial class CrawlerMain : Form
    {
        private SeattleLeadsCrawl _crawler;
        private System.Timers.Timer _timer;

        private PropertyTaxLocalReader _localDataReader;
        private Logger _log;

        private static readonly object LockObjCommonFunction2 = new object();

        public CrawlerMain()
        {
            _localDataReader = new PropertyTaxLocalReader();
            _crawler = new SeattleLeadsCrawl();
            _timer = new System.Timers.Timer(10000);
            _log = new Logger();

            ShowModalDialog();

            InitializeComponent();

            LoadSavedValues();
            ChangeConnectionForTable();

            _timer.Elapsed += OnTimedEvent;
            _timer.Elapsed += CrawlerMain_Load_1;


          

            //this.StopButton.Visible = false;
        }

        private void ShowModalDialog()
        {
            DatabaseConnectionModal modal = new DatabaseConnectionModal()
            {
                Text = "DatabaseInfo",
            };
            modal.ShowDialog();
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


            try
            {
                _crawler.DataReader.DatabaseServer = this.DatabaseServerNameTextfield.Text.Trim();
                SeattleTaxIdsCrawlerTotals totals = _crawler.DataReader.TaxTotals();

                this.TotalCrawledText.Text = totals.TotalCrawled;
                this.TotalNotCrawledText.Text = totals.TotalUncrawled;
                this.TotalCrawledErrorText.Text = totals.TotalErrorCrawled;

                if ((!string.IsNullOrEmpty(PasswordTextField.Text) && (!string.IsNullOrEmpty(UserNameTextfield.Text))))
                {
                    this.TotalCaptchaCreditText.Text = CaptchaSolver.GetBalance(UserNameTextfield.Text, PasswordTextField.Text);

                }
            }
            catch (Exception e)
            {
                _log.LogError(e.Message);
            }





        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _crawler.DataReader.DatabaseServer = this.DatabaseServerNameTextfield.Text.Trim();
            SeattleTaxIdsCrawlerTotals totals = _crawler.DataReader.TaxTotals();

            ThreadHelperClass.SetText(this, TotalCrawledText, totals.TotalCrawled);
            ThreadHelperClass.SetText(this, TotalNotCrawledText, totals.TotalUncrawled);
            ThreadHelperClass.SetText(this, TotalCrawledErrorText, totals.TotalErrorCrawled);

            CrawlerHistoryGridView.Invoke(new Action(() =>
            {
                try
                {
                    CrawlerHistoryGridView.Update();
                    CrawlerHistoryGridView.Refresh();
                }
                catch (Exception ex)
                {
                    _log.LogError(ex.ToString());
                }
            }));

        }

        private void StartCrawlerButton_Click(object sender, EventArgs e)
        {
            StartCrawlerButton.Enabled = false;
            this.StopButton.Enabled = true;
            Thread newThread = new Thread(DoWork);

            _timer.Start();
            newThread.Start();





        }

        private void DoWork()
        {
            _crawler.DatabaseServer = this.DatabaseServerNameTextfield.Text.Trim();

            _crawler.SeleniumWebDriverFolder = this.DriverFolderNameTextField.Text.Trim();
            _crawler.UserName = this.UserNameTextfield.Text.Trim();
            _crawler.Password = this.PasswordTextField.Text.Trim();


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
                this.taxParcelInformationTableAdapter.Connection.ConnectionString = "Data Source=" + currentDataSource + ";Initial Catalog=" + PropertyTaxReader.DADABASE_NAME + "Integrated Security=True";
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
            _crawler.DataReader.DatabaseServer = this.DatabaseServerNameTextfield.Text.Trim();
            List<List<String>> results = _crawler.DataReader.DilinquentTaxIds();

            string content = OutputFile.DelinquientCSVContent(results);
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "CSV|*.csv";
            dialog.Title = "Save CSV File";
            dialog.ShowDialog();

            if (dialog.FileName != string.Empty)
            {
                System.IO.File.WriteAllText(dialog.FileName, content);
            }


        }

        private void StopButton_Click(object sender, EventArgs e)
        {

            _crawler.Stop();
            this.StopButton.Enabled = false;
            this.StartCrawlerButton.Enabled = true;
            CrawlerHistoryGridView.Update();
            CrawlerHistoryGridView.Refresh();
        }

        private void CrawlerMain_Load_1(object sender, EventArgs e)
        {

            this.dilinquentTaxIdsTableAdapter1.Connection.ConnectionString = ChangeConnectionForTable();
            this.dilinquentTaxIdsTableAdapter.Connection.ConnectionString = ChangeConnectionForTable();
            this.crawlHistoryListTableAdapter.Connection.ConnectionString = ChangeConnectionForTable();

            // TODO: This line of code loads data into the 'propertyTax_2DataSet2.DilinquentTaxIds' table. You can move, or remove it, as needed.
            this.dilinquentTaxIdsTableAdapter1.Fill(this.propertyTax_2DataSet2.DilinquentTaxIds);
            // TODO: This line of code loads data into the 'delinquentTaxIds.DilinquentTaxIds' table. You can move, or remove it, as needed.
            this.dilinquentTaxIdsTableAdapter.Fill(this.delinquentTaxIds.DilinquentTaxIds);
            // TODO: This line of code loads data into the 'propertyTax_2DataSet1.CrawlHistoryList' table. You can move, or remove it, as needed.
            this.crawlHistoryListTableAdapter.Fill(this.propertyTax_2DataSet1.CrawlHistoryList);
        }

      

        private void CrawlerHistoryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            else {
                var obj = dgv.CurrentRow;

                string batchId = obj.Cells[0].Value.ToString();
                
                DisplayTaxParcelInformation dialog = new DisplayTaxParcelInformation(batchId, this.DatabaseServerNameTextfield.Text);

                dialog.ShowDialog();



            }
           
        }

        private string ChangeConnectionForTable()
        {
            string currentDataSource = this.DatabaseServerNameTextfield.Text.Trim();
            return "Data Source=" + currentDataSource + ";Initial Catalog=" + PropertyTaxReader.DADABASE_NAME + "Integrated Security=True";
        }

    }

    public static class ThreadHelperClass
    {
        delegate void SetTextCallback(Form f, Control ctrl, string text);
        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="form">The calling form</param>
        /// <param name="ctrl"></param>
        /// <param name="text"></param>
        public static void SetText(Form form, Control ctrl, string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }

 
   


    }


}
