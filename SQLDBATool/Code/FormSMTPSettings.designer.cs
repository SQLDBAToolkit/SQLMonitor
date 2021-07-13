
namespace SQLDBATool.Code
{
    partial class FormSMTPSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxEnableSSL = new System.Windows.Forms.CheckBox();
            this.checkBoxUseDefaultCredentials = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDeliveryMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonTestSMTP = new System.Windows.Forms.Button();
            this.textBoxSenderAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSendTo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelTestSuccessful = new System.Windows.Forms.Label();
            this.labelTestFailed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // checkBoxEnableSSL
            // 
            this.checkBoxEnableSSL.Location = new System.Drawing.Point(125, 162);
            this.checkBoxEnableSSL.Name = "checkBoxEnableSSL";
            this.checkBoxEnableSSL.Size = new System.Drawing.Size(138, 24);
            this.checkBoxEnableSSL.TabIndex = 5;
            this.checkBoxEnableSSL.Text = "Enable SSL";
            this.checkBoxEnableSSL.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseDefaultCredentials
            // 
            this.checkBoxUseDefaultCredentials.Location = new System.Drawing.Point(125, 192);
            this.checkBoxUseDefaultCredentials.Name = "checkBoxUseDefaultCredentials";
            this.checkBoxUseDefaultCredentials.Size = new System.Drawing.Size(141, 24);
            this.checkBoxUseDefaultCredentials.TabIndex = 6;
            this.checkBoxUseDefaultCredentials.Text = "Use Default Credentials";
            this.checkBoxUseDefaultCredentials.UseVisualStyleBackColor = true;
            this.checkBoxUseDefaultCredentials.CheckedChanged += new System.EventHandler(this.checkBoxUseDefaultCredentials_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "UserID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password:";
            // 
            // comboBoxDeliveryMethod
            // 
            this.comboBoxDeliveryMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeliveryMethod.FormattingEnabled = true;
            this.comboBoxDeliveryMethod.Items.AddRange(new object[] {
            "Network",
            "Pickup Directory From IIS",
            "Specified Pickup Directory"});
            this.comboBoxDeliveryMethod.Location = new System.Drawing.Point(125, 83);
            this.comboBoxDeliveryMethod.Name = "comboBoxDeliveryMethod";
            this.comboBoxDeliveryMethod.Size = new System.Drawing.Size(245, 21);
            this.comboBoxDeliveryMethod.TabIndex = 2;
            this.comboBoxDeliveryMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxDeliveryMethod_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Delivery Method:";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(125, 110);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(245, 20);
            this.textBoxHost.TabIndex = 3;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(125, 136);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(48, 20);
            this.textBoxPort.TabIndex = 4;
            this.textBoxPort.Text = "587";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(125, 218);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(245, 20);
            this.textBoxUserID.TabIndex = 7;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(125, 244);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(245, 20);
            this.textBoxPassword.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(296, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonTestSMTP
            // 
            this.buttonTestSMTP.Location = new System.Drawing.Point(134, 304);
            this.buttonTestSMTP.Name = "buttonTestSMTP";
            this.buttonTestSMTP.Size = new System.Drawing.Size(75, 23);
            this.buttonTestSMTP.TabIndex = 10;
            this.buttonTestSMTP.Text = "Test";
            this.buttonTestSMTP.UseVisualStyleBackColor = true;
            this.buttonTestSMTP.Click += new System.EventHandler(this.buttonTestSMTP_Click);
            // 
            // textBoxSenderAddress
            // 
            this.textBoxSenderAddress.Location = new System.Drawing.Point(125, 19);
            this.textBoxSenderAddress.Name = "textBoxSenderAddress";
            this.textBoxSenderAddress.Size = new System.Drawing.Size(245, 20);
            this.textBoxSenderAddress.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sender Address:";
            // 
            // textBoxSendTo
            // 
            this.textBoxSendTo.Location = new System.Drawing.Point(125, 45);
            this.textBoxSendTo.Name = "textBoxSendTo";
            this.textBoxSendTo.Size = new System.Drawing.Size(245, 20);
            this.textBoxSendTo.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Alert Recipients:";
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(125, 270);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(245, 20);
            this.textBoxFolder.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Folder:";
            // 
            // labelTestSuccessful
            // 
            this.labelTestSuccessful.AutoSize = true;
            this.labelTestSuccessful.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelTestSuccessful.Location = new System.Drawing.Point(31, 309);
            this.labelTestSuccessful.Name = "labelTestSuccessful";
            this.labelTestSuccessful.Size = new System.Drawing.Size(87, 13);
            this.labelTestSuccessful.TabIndex = 20;
            this.labelTestSuccessful.Text = "Send Successful";
            this.labelTestSuccessful.Visible = false;
            // 
            // labelTestFailed
            // 
            this.labelTestFailed.AutoSize = true;
            this.labelTestFailed.ForeColor = System.Drawing.Color.Crimson;
            this.labelTestFailed.Location = new System.Drawing.Point(31, 309);
            this.labelTestFailed.Name = "labelTestFailed";
            this.labelTestFailed.Size = new System.Drawing.Size(63, 13);
            this.labelTestFailed.TabIndex = 21;
            this.labelTestFailed.Text = "Send Failed";
            this.labelTestFailed.Visible = false;
            // 
            // FormSMTPSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 335);
            this.Controls.Add(this.labelTestFailed);
            this.Controls.Add(this.labelTestSuccessful);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxSendTo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxSenderAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonTestSMTP);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserID);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxHost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxDeliveryMethod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxUseDefaultCredentials);
            this.Controls.Add(this.checkBoxEnableSSL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSMTPSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SMTP Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxEnableSSL;
        private System.Windows.Forms.CheckBox checkBoxUseDefaultCredentials;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDeliveryMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonTestSMTP;
        private System.Windows.Forms.TextBox textBoxSenderAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSendTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTestSuccessful;
        private System.Windows.Forms.Label labelTestFailed;
    }
}