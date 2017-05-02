namespace Tax.Automation.UI
{
    partial class DisplayTaxParcelInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ClosePopUpButton = new System.Windows.Forms.Button();
            this.BatchRecieptGridView = new System.Windows.Forms.DataGridView();
            this.BatchTaxParcelInformationGridView = new System.Windows.Forms.DataGridView();
            this.ParcelListLabel = new System.Windows.Forms.Label();
            this.RecieptsLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BatchRecieptGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatchTaxParcelInformationGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ClosePopUpButton);
            this.MainPanel.Controls.Add(this.ExportButton);
            this.MainPanel.Controls.Add(this.panel2);
            this.MainPanel.Controls.Add(this.panel1);
            this.MainPanel.Location = new System.Drawing.Point(12, 13);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(864, 391);
            this.MainPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RecieptsLabel);
            this.panel1.Controls.Add(this.BatchRecieptGridView);
            this.panel1.Location = new System.Drawing.Point(542, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 328);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ParcelListLabel);
            this.panel2.Controls.Add(this.BatchTaxParcelInformationGridView);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(532, 328);
            this.panel2.TabIndex = 1;
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(346, 350);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(123, 23);
            this.ExportButton.TabIndex = 2;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            // 
            // ClosePopUpButton
            // 
            this.ClosePopUpButton.Location = new System.Drawing.Point(475, 350);
            this.ClosePopUpButton.Name = "ClosePopUpButton";
            this.ClosePopUpButton.Size = new System.Drawing.Size(123, 23);
            this.ClosePopUpButton.TabIndex = 3;
            this.ClosePopUpButton.Text = "Close";
            this.ClosePopUpButton.UseVisualStyleBackColor = true;
            this.ClosePopUpButton.Click += new System.EventHandler(this.ClosePopUpButton_Click);
            // 
            // BatchRecieptGridView
            // 
            this.BatchRecieptGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BatchRecieptGridView.Location = new System.Drawing.Point(3, 36);
            this.BatchRecieptGridView.Name = "BatchRecieptGridView";
            this.BatchRecieptGridView.Size = new System.Drawing.Size(303, 289);
            this.BatchRecieptGridView.TabIndex = 0;
            // 
            // BatchTaxParcelInformationGridView
            // 
            this.BatchTaxParcelInformationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BatchTaxParcelInformationGridView.Location = new System.Drawing.Point(4, 36);
            this.BatchTaxParcelInformationGridView.Name = "BatchTaxParcelInformationGridView";
            this.BatchTaxParcelInformationGridView.Size = new System.Drawing.Size(528, 289);
            this.BatchTaxParcelInformationGridView.TabIndex = 0;
            this.BatchTaxParcelInformationGridView.CellClick += TaxInformationCell_Click;
            this.BatchTaxParcelInformationGridView.CellDoubleClick += OpenTaxIdWebSite_CellClick;
            this.BatchTaxParcelInformationGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Edit_TaxParcelInfor_Cell);
            this.BatchTaxParcelInformationGridView.CellBeginEdit += null;
            // 
            // ParcelListLabel
            // 
            this.ParcelListLabel.AutoSize = true;
            this.ParcelListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParcelListLabel.Location = new System.Drawing.Point(2, 2);
            this.ParcelListLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ParcelListLabel.Name = "ParcelListLabel";
            this.ParcelListLabel.Size = new System.Drawing.Size(240, 31);
            this.ParcelListLabel.TabIndex = 1;
            this.ParcelListLabel.Text = "[Parcel Text Label]";
            // 
            // RecieptsLabel
            // 
            this.RecieptsLabel.AutoSize = true;
            this.RecieptsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecieptsLabel.Location = new System.Drawing.Point(2, 2);
            this.RecieptsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RecieptsLabel.Name = "RecieptsLabel";
            this.RecieptsLabel.Size = new System.Drawing.Size(299, 31);
            this.RecieptsLabel.TabIndex = 2;
            this.RecieptsLabel.Text = "[Reciept Number Label]";
            // 
            // DisplayTaxParcelInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 416);
            this.Controls.Add(this.MainPanel);
            this.Name = "DisplayTaxParcelInformation";
            this.Text = "[Pracel Batch Number]";
            this.MainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BatchRecieptGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatchTaxParcelInformationGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button ClosePopUpButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView BatchRecieptGridView;
        private System.Windows.Forms.DataGridView BatchTaxParcelInformationGridView;
        private System.Windows.Forms.Label ParcelListLabel;
        private System.Windows.Forms.Label RecieptsLabel;
    }
}