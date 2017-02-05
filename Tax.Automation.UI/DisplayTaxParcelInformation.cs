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

namespace Tax.Automation.UI
{
    public partial class DisplayTaxParcelInformation : Form
    {
        private string _batchNumber;
        private PropertyTaxReader _propertyTaxReader;
        public DisplayTaxParcelInformation(string batchNumber,string serverName)
        {

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
           _propertyTaxReader = null;
           GC.Collect();
           this.Close();

        }

        private void OpenTaxIdWebSite_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

        private void TaxInformationCell_Click(object sender, DataGridViewCellEventArgs e)
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
    }
}
