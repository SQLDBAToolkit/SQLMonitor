
namespace SQLDBATool.Code
{
    partial class FormRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistration));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLicenses = new System.Windows.Forms.TextBox();
            this.textBoxLicenseKey = new System.Windows.Forms.TextBox();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelUnregistered = new System.Windows.Forms.Panel();
            this.panelRegistered = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxRegSerialNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxRegLicenseKey = new System.Windows.Forms.TextBox();
            this.textBoxRegLiceses = new System.Windows.Forms.TextBox();
            this.panelUnregistered.SuspendLayout();
            this.panelRegistered.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thank you for your interest in purchasing the SQL Monitor toolkit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please enter the following information exactly as shown in the email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number Licenses:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "License Key:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Serial Number:";
            // 
            // textBoxLicenses
            // 
            this.textBoxLicenses.Location = new System.Drawing.Point(184, 28);
            this.textBoxLicenses.Name = "textBoxLicenses";
            this.textBoxLicenses.Size = new System.Drawing.Size(115, 20);
            this.textBoxLicenses.TabIndex = 5;
            // 
            // textBoxLicenseKey
            // 
            this.textBoxLicenseKey.Location = new System.Drawing.Point(184, 50);
            this.textBoxLicenseKey.Name = "textBoxLicenseKey";
            this.textBoxLicenseKey.Size = new System.Drawing.Size(115, 20);
            this.textBoxLicenseKey.TabIndex = 6;
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.Location = new System.Drawing.Point(184, 73);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.Size = new System.Drawing.Size(115, 20);
            this.textBoxSerialNumber.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(265, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(103, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Purchase";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panelUnregistered
            // 
            this.panelUnregistered.Controls.Add(this.button3);
            this.panelUnregistered.Controls.Add(this.label2);
            this.panelUnregistered.Controls.Add(this.button2);
            this.panelUnregistered.Controls.Add(this.label3);
            this.panelUnregistered.Controls.Add(this.button1);
            this.panelUnregistered.Controls.Add(this.label4);
            this.panelUnregistered.Controls.Add(this.textBoxSerialNumber);
            this.panelUnregistered.Controls.Add(this.label5);
            this.panelUnregistered.Controls.Add(this.textBoxLicenseKey);
            this.panelUnregistered.Controls.Add(this.textBoxLicenses);
            this.panelUnregistered.Location = new System.Drawing.Point(16, 36);
            this.panelUnregistered.Name = "panelUnregistered";
            this.panelUnregistered.Size = new System.Drawing.Size(368, 133);
            this.panelUnregistered.TabIndex = 11;
            // 
            // panelRegistered
            // 
            this.panelRegistered.Controls.Add(this.button4);
            this.panelRegistered.Controls.Add(this.label6);
            this.panelRegistered.Controls.Add(this.label7);
            this.panelRegistered.Controls.Add(this.label8);
            this.panelRegistered.Controls.Add(this.textBoxRegSerialNumber);
            this.panelRegistered.Controls.Add(this.label9);
            this.panelRegistered.Controls.Add(this.textBoxRegLicenseKey);
            this.panelRegistered.Controls.Add(this.textBoxRegLiceses);
            this.panelRegistered.Location = new System.Drawing.Point(16, 36);
            this.panelRegistered.Name = "panelRegistered";
            this.panelRegistered.Size = new System.Drawing.Size(365, 133);
            this.panelRegistered.TabIndex = 12;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(265, 107);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(298, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "SQL Monitor Toolkit is registered with the following information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Number Licenses:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(86, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "License Key:";
            // 
            // textBoxRegSerialNumber
            // 
            this.textBoxRegSerialNumber.Location = new System.Drawing.Point(184, 76);
            this.textBoxRegSerialNumber.Name = "textBoxRegSerialNumber";
            this.textBoxRegSerialNumber.ReadOnly = true;
            this.textBoxRegSerialNumber.Size = new System.Drawing.Size(115, 20);
            this.textBoxRegSerialNumber.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(86, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Serial Number:";
            // 
            // textBoxRegLicenseKey
            // 
            this.textBoxRegLicenseKey.Location = new System.Drawing.Point(184, 53);
            this.textBoxRegLicenseKey.Name = "textBoxRegLicenseKey";
            this.textBoxRegLicenseKey.ReadOnly = true;
            this.textBoxRegLicenseKey.Size = new System.Drawing.Size(115, 20);
            this.textBoxRegLicenseKey.TabIndex = 13;
            // 
            // textBoxRegLiceses
            // 
            this.textBoxRegLiceses.Location = new System.Drawing.Point(184, 31);
            this.textBoxRegLiceses.Name = "textBoxRegLiceses";
            this.textBoxRegLiceses.ReadOnly = true;
            this.textBoxRegLiceses.Size = new System.Drawing.Size(115, 20);
            this.textBoxRegLiceses.TabIndex = 12;
            // 
            // FormRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 179);
            this.Controls.Add(this.panelUnregistered);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelRegistered);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQL Monitor Registration";
            this.panelUnregistered.ResumeLayout(false);
            this.panelUnregistered.PerformLayout();
            this.panelRegistered.ResumeLayout(false);
            this.panelRegistered.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLicenses;
        private System.Windows.Forms.TextBox textBoxLicenseKey;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panelUnregistered;
        private System.Windows.Forms.Panel panelRegistered;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxRegSerialNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxRegLicenseKey;
        private System.Windows.Forms.TextBox textBoxRegLiceses;
    }
}