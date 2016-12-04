namespace Tax.Automation.UI
{
    partial class ConnectingModal
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
            this.ConnectionText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConnectionText
            // 
            this.ConnectionText.AutoSize = true;
            this.ConnectionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionText.Location = new System.Drawing.Point(130, 74);
            this.ConnectionText.Name = "ConnectionText";
            this.ConnectionText.Size = new System.Drawing.Size(206, 37);
            this.ConnectionText.TabIndex = 0;
            this.ConnectionText.Text = "Connecting...";
            // 
            // ConnectingModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 196);
            this.Controls.Add(this.ConnectionText);
            this.Name = "ConnectingModal";
            this.Text = "ConnectingModal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ConnectionText;
    }
}