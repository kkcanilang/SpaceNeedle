using SeleniumAutomation.Automation.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tax.Automation.UI.Logging;

namespace Tax.Automation.UI
{
    public partial class DisplayTaxParcelInformation : Form
    {
        private string _batchNumber;
        private PropertyTaxReader _propertyTaxReader;
        private string _intialCellValue = string.Empty;
        private Logger _log;
        public DisplayTaxParcelInformation(Logger log,string batchNumber,string serverName)
        {
            _log = log;
            _batchNumber = batchNumber;
            _propertyTaxReader = new PropertyTaxReader(serverName);
            InitializeComponent();
            this.BatchTaxParcelInformationGridView.DataSource = _propertyTaxReader.GetParcelNumbersByBatch(_batchNumber);
            this.BatchTaxParcelInformationGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            this.BatchTaxParcelInformationGridView.Refresh();
        }
        private string BatchNumber
        {
            set { _batchNumber = value; }
            get { return _batchNumber; }
        }

        private void ClosePopUpButton_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void Edit_Begin_TaxParcelInfor_Cell(object sender, EventArgs e)
        {
            var currentCell = ((System.Windows.Forms.DataGridView)sender).CurrentCell;
            _intialCellValue = currentCell.FormattedValue.ToString(); 

        }

        private void Edit_TaxParcelInfor_Cell(object sender, EventArgs e)
        {
           
            var currentRow = ((System.Windows.Forms.DataGridView)sender).CurrentRow;
            var currentCell = ((System.Windows.Forms.DataGridView)sender).CurrentCell;
            var columnName = currentCell.DataGridView.CurrentCell.OwningColumn.DataPropertyName;
            var Id = currentRow.Cells["TaxParcelInformationId"].Value.ToString();
            var value = currentCell.FormattedValue.ToString();

            bool success = false;

            if (!_intialCellValue.Equals(value))
            {

                string updateQuery = "update [TaxParcelInformation] " +
                                     "set" + "[" + columnName + "] = " + "'" + value + "'," +
                                     " LastModified = CURRENT_TIMESTAMP" +
                                     " where [TaxParcelInformationId] = " + Id;



                try
                {
                    _log.LogInfo("Executing the folling Query : " + updateQuery);
                    success = _propertyTaxReader.ExecuteQuery(updateQuery);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _log.LogError(ex.ToString());
                }

                if (success)
                {
                    MessageBox.Show("Data has been Successfully Updated!", "Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void OpenTaxIdWebSite_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            else
            {
                var obj = dgv.CurrentRow;
                string taxIdWebsite = obj.Cells[37].Value.ToString();
                Process.Start(taxIdWebsite);
            }
            }
            catch (Exception ex)
            {
                _log.LogError(ex.StackTrace);
            }
        }

        private void TaxInformationCell_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (dgv == null)
                    return;
                else
                {
                    var obj = dgv.CurrentRow;

                    string taxId = obj.Cells[0].Value.ToString();

                    this.BatchRecieptGridView.DataSource = _propertyTaxReader.GetReciptsByTaxParcelInformationId(taxId);
                    this.BatchRecieptGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                    this.BatchRecieptGridView.Refresh();
                }

            }
            catch (Exception ex)
            {
                _log.LogError(ex.StackTrace);
            }
        }
    }
}
