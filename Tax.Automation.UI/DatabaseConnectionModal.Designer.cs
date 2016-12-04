namespace Tax.Automation.UI
{
    partial class DatabaseConnectionModal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConnectionErrorLabel = new System.Windows.Forms.Label();
            this.PasswordTextField = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UserNameTextField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DriverFolderTextfield = new System.Windows.Forms.TextBox();
            this.DatabaseNameTextfield = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DatabaseLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ConnectionErrorLabel);
            this.panel1.Controls.Add(this.PasswordTextField);
            this.panel1.Controls.Add(this.PasswordLabel);
            this.panel1.Controls.Add(this.UserNameTextField);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ConnectButton);
            this.panel1.Controls.Add(this.DriverFolderTextfield);
            this.panel1.Controls.Add(this.DatabaseNameTextfield);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DatabaseLabel);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 354);
            this.panel1.TabIndex = 0;
            // 
            // ConnectionErrorLabel
            // 
            this.ConnectionErrorLabel.AutoSize = true;
            this.ConnectionErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ConnectionErrorLabel.Location = new System.Drawing.Point(78, 290);
            this.ConnectionErrorLabel.Name = "ConnectionErrorLabel";
            this.ConnectionErrorLabel.Size = new System.Drawing.Size(420, 16);
            this.ConnectionErrorLabel.TabIndex = 9;
            this.ConnectionErrorLabel.Text = "Database Connection Error. Please Check Database Name.";
            this.ConnectionErrorLabel.Visible = false;
            // 
            // PasswordTextField
            // 
            this.PasswordTextField.Location = new System.Drawing.Point(194, 158);
            this.PasswordTextField.Name = "PasswordTextField";
            this.PasswordTextField.Size = new System.Drawing.Size(357, 20);
            this.PasswordTextField.TabIndex = 8;
            this.PasswordTextField.UseSystemPasswordChar = true;
            this.PasswordTextField.TextChanged += new System.EventHandler(this.RequiredFieldsChanged);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(3, 151);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(178, 25);
            this.PasswordLabel.TabIndex = 7;
            this.PasswordLabel.Text = "Password           :";
            // 
            // UserNameTextField
            // 
            this.UserNameTextField.Location = new System.Drawing.Point(194, 132);
            this.UserNameTextField.Name = "UserNameTextField";
            this.UserNameTextField.Size = new System.Drawing.Size(357, 20);
            this.UserNameTextField.TabIndex = 6;
            this.UserNameTextField.TextChanged += new System.EventHandler(this.RequiredFieldsChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "User Name         :";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(194, 239);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(161, 36);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DriverFolderTextfield
            // 
            this.DriverFolderTextfield.Location = new System.Drawing.Point(194, 106);
            this.DriverFolderTextfield.Name = "DriverFolderTextfield";
            this.DriverFolderTextfield.Size = new System.Drawing.Size(357, 20);
            this.DriverFolderTextfield.TabIndex = 3;
            this.DriverFolderTextfield.TextChanged += new System.EventHandler(this.RequiredFieldsChanged);
            // 
            // DatabaseNameTextfield
            // 
            this.DatabaseNameTextfield.Location = new System.Drawing.Point(194, 80);
            this.DatabaseNameTextfield.Name = "DatabaseNameTextfield";
            this.DatabaseNameTextfield.Size = new System.Drawing.Size(357, 20);
            this.DatabaseNameTextfield.TabIndex = 2;
            this.DatabaseNameTextfield.TextChanged += new System.EventHandler(this.RequiredFieldsChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Driver Folder      : ";
            // 
            // DatabaseLabel
            // 
            this.DatabaseLabel.AutoSize = true;
            this.DatabaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseLabel.Location = new System.Drawing.Point(3, 76);
            this.DatabaseLabel.Name = "DatabaseLabel";
            this.DatabaseLabel.Size = new System.Drawing.Size(184, 25);
            this.DatabaseLabel.TabIndex = 0;
            this.DatabaseLabel.Text = "Database Name : ";
            // 
            // DatabaseConnectionModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 378);
            this.Controls.Add(this.panel1);
            this.Name = "DatabaseConnectionModal";
            this.Text = "DatabaseConnectionModal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DatabaseLabel;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox DriverFolderTextfield;
        private System.Windows.Forms.TextBox DatabaseNameTextfield;
        private System.Windows.Forms.TextBox PasswordTextField;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox UserNameTextField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ConnectionErrorLabel;
    }
}