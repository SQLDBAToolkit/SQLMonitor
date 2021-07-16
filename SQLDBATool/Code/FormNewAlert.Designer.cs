
namespace SQLDBATool.Code
{
    partial class FormNewAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewAlert));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAlertName = new System.Windows.Forms.TextBox();
            this.comboBoxAlertType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxAlertEnabled = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownDelaysBeforeNotification = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAlertNotifications = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDelayBetweenNotification = new System.Windows.Forms.NumericUpDown();
            this.checkBoxNotifyWhenResolved = new System.Windows.Forms.CheckBox();
            this.panelCPUUsage = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownCPUUsage = new System.Windows.Forms.NumericUpDown();
            this.panelRapidDatabaseGrowth = new System.Windows.Forms.Panel();
            this.numericUpDownGrowthPercentage = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.panelSuspectDatabaseDetection = new System.Windows.Forms.Panel();
            this.checkBoxIncludeRecoveryPending = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panelLocking = new System.Windows.Forms.Panel();
            this.numericUpDownLockingCount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxAlertMethod = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelaysBeforeNotification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlertNotifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayBetweenNotification)).BeginInit();
            this.panelCPUUsage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCPUUsage)).BeginInit();
            this.panelRapidDatabaseGrowth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrowthPercentage)).BeginInit();
            this.panelSuspectDatabaseDetection.SuspendLayout();
            this.panelLocking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLockingCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alert Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alert Type:";
            // 
            // textBoxAlertName
            // 
            this.textBoxAlertName.Location = new System.Drawing.Point(140, 15);
            this.textBoxAlertName.Name = "textBoxAlertName";
            this.textBoxAlertName.Size = new System.Drawing.Size(147, 20);
            this.textBoxAlertName.TabIndex = 2;
            // 
            // comboBoxAlertType
            // 
            this.comboBoxAlertType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlertType.FormattingEnabled = true;
            this.comboBoxAlertType.Items.AddRange(new object[] {
            "CPU Usage",
            "Server Down",
            "Rapid Database Growth",
            "Suspect Databases",
            "High Locking Detection"});
            this.comboBoxAlertType.Location = new System.Drawing.Point(140, 40);
            this.comboBoxAlertType.Name = "comboBoxAlertType";
            this.comboBoxAlertType.Size = new System.Drawing.Size(147, 21);
            this.comboBoxAlertType.TabIndex = 3;
            this.comboBoxAlertType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Alert Method:";
            // 
            // checkBoxAlertEnabled
            // 
            this.checkBoxAlertEnabled.AutoSize = true;
            this.checkBoxAlertEnabled.Location = new System.Drawing.Point(140, 93);
            this.checkBoxAlertEnabled.Name = "checkBoxAlertEnabled";
            this.checkBoxAlertEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkBoxAlertEnabled.TabIndex = 6;
            this.checkBoxAlertEnabled.Text = "Enabled";
            this.checkBoxAlertEnabled.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Delay Before Notification:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(305, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Alert Notifications:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Delay Between Notifications:";
            // 
            // numericUpDownDelaysBeforeNotification
            // 
            this.numericUpDownDelaysBeforeNotification.Location = new System.Drawing.Point(452, 16);
            this.numericUpDownDelaysBeforeNotification.Name = "numericUpDownDelaysBeforeNotification";
            this.numericUpDownDelaysBeforeNotification.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownDelaysBeforeNotification.TabIndex = 11;
            // 
            // numericUpDownAlertNotifications
            // 
            this.numericUpDownAlertNotifications.Location = new System.Drawing.Point(452, 41);
            this.numericUpDownAlertNotifications.Name = "numericUpDownAlertNotifications";
            this.numericUpDownAlertNotifications.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownAlertNotifications.TabIndex = 12;
            this.numericUpDownAlertNotifications.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownDelayBetweenNotification
            // 
            this.numericUpDownDelayBetweenNotification.Location = new System.Drawing.Point(452, 67);
            this.numericUpDownDelayBetweenNotification.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownDelayBetweenNotification.Name = "numericUpDownDelayBetweenNotification";
            this.numericUpDownDelayBetweenNotification.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownDelayBetweenNotification.TabIndex = 13;
            this.numericUpDownDelayBetweenNotification.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // checkBoxNotifyWhenResolved
            // 
            this.checkBoxNotifyWhenResolved.AutoSize = true;
            this.checkBoxNotifyWhenResolved.Location = new System.Drawing.Point(452, 93);
            this.checkBoxNotifyWhenResolved.Name = "checkBoxNotifyWhenResolved";
            this.checkBoxNotifyWhenResolved.Size = new System.Drawing.Size(133, 17);
            this.checkBoxNotifyWhenResolved.TabIndex = 14;
            this.checkBoxNotifyWhenResolved.Text = "Notify When Resolved";
            this.checkBoxNotifyWhenResolved.UseVisualStyleBackColor = true;
            // 
            // panelCPUUsage
            // 
            this.panelCPUUsage.Controls.Add(this.numericUpDownCPUUsage);
            this.panelCPUUsage.Controls.Add(this.label7);
            this.panelCPUUsage.Location = new System.Drawing.Point(21, 116);
            this.panelCPUUsage.Name = "panelCPUUsage";
            this.panelCPUUsage.Size = new System.Drawing.Size(564, 29);
            this.panelCPUUsage.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "CPU Usage Trigger:";
            // 
            // numericUpDownCPUUsage
            // 
            this.numericUpDownCPUUsage.Location = new System.Drawing.Point(119, 0);
            this.numericUpDownCPUUsage.Name = "numericUpDownCPUUsage";
            this.numericUpDownCPUUsage.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownCPUUsage.TabIndex = 13;
            // 
            // panelRapidDatabaseGrowth
            // 
            this.panelRapidDatabaseGrowth.Controls.Add(this.numericUpDownGrowthPercentage);
            this.panelRapidDatabaseGrowth.Controls.Add(this.label8);
            this.panelRapidDatabaseGrowth.Location = new System.Drawing.Point(21, 116);
            this.panelRapidDatabaseGrowth.Name = "panelRapidDatabaseGrowth";
            this.panelRapidDatabaseGrowth.Size = new System.Drawing.Size(564, 29);
            this.panelRapidDatabaseGrowth.TabIndex = 16;
            // 
            // numericUpDownGrowthPercentage
            // 
            this.numericUpDownGrowthPercentage.Location = new System.Drawing.Point(119, 0);
            this.numericUpDownGrowthPercentage.Name = "numericUpDownGrowthPercentage";
            this.numericUpDownGrowthPercentage.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownGrowthPercentage.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Growth Percentage:";
            // 
            // panelSuspectDatabaseDetection
            // 
            this.panelSuspectDatabaseDetection.Controls.Add(this.label9);
            this.panelSuspectDatabaseDetection.Controls.Add(this.checkBoxIncludeRecoveryPending);
            this.panelSuspectDatabaseDetection.Location = new System.Drawing.Point(21, 116);
            this.panelSuspectDatabaseDetection.Name = "panelSuspectDatabaseDetection";
            this.panelSuspectDatabaseDetection.Size = new System.Drawing.Size(564, 38);
            this.panelSuspectDatabaseDetection.TabIndex = 17;
            // 
            // checkBoxIncludeRecoveryPending
            // 
            this.checkBoxIncludeRecoveryPending.AutoSize = true;
            this.checkBoxIncludeRecoveryPending.Location = new System.Drawing.Point(119, 3);
            this.checkBoxIncludeRecoveryPending.Name = "checkBoxIncludeRecoveryPending";
            this.checkBoxIncludeRecoveryPending.Size = new System.Drawing.Size(178, 17);
            this.checkBoxIncludeRecoveryPending.TabIndex = 0;
            this.checkBoxIncludeRecoveryPending.Text = "Include RECOVERY_PENDING";
            this.checkBoxIncludeRecoveryPending.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(303, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(258, 26);
            this.label9.TabIndex = 1;
            this.label9.Text = "Note: Monitor attempts to ignore H/A secondary databases";
            // 
            // panelLocking
            // 
            this.panelLocking.Controls.Add(this.numericUpDownLockingCount);
            this.panelLocking.Controls.Add(this.label10);
            this.panelLocking.Location = new System.Drawing.Point(21, 116);
            this.panelLocking.Name = "panelLocking";
            this.panelLocking.Size = new System.Drawing.Size(564, 29);
            this.panelLocking.TabIndex = 18;
            // 
            // numericUpDownLockingCount
            // 
            this.numericUpDownLockingCount.Location = new System.Drawing.Point(119, 0);
            this.numericUpDownLockingCount.Name = "numericUpDownLockingCount";
            this.numericUpDownLockingCount.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownLockingCount.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Locking Count:";
            // 
            // comboBoxAlertMethod
            // 
            this.comboBoxAlertMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlertMethod.FormattingEnabled = true;
            this.comboBoxAlertMethod.Items.AddRange(new object[] {
            "SMTP",
            "PagerDuty"});
            this.comboBoxAlertMethod.Location = new System.Drawing.Point(140, 66);
            this.comboBoxAlertMethod.Name = "comboBoxAlertMethod";
            this.comboBoxAlertMethod.Size = new System.Drawing.Size(147, 21);
            this.comboBoxAlertMethod.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(505, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Secs";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(505, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Secs";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormNewAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 188);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxAlertMethod);
            this.Controls.Add(this.panelCPUUsage);
            this.Controls.Add(this.checkBoxNotifyWhenResolved);
            this.Controls.Add(this.numericUpDownDelayBetweenNotification);
            this.Controls.Add(this.numericUpDownAlertNotifications);
            this.Controls.Add(this.numericUpDownDelaysBeforeNotification);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxAlertEnabled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxAlertType);
            this.Controls.Add(this.textBoxAlertName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelLocking);
            this.Controls.Add(this.panelSuspectDatabaseDetection);
            this.Controls.Add(this.panelRapidDatabaseGrowth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNewAlert";
            this.Text = "Alert Configuration";
            this.Load += new System.EventHandler(this.FormNewAlert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelaysBeforeNotification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlertNotifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelayBetweenNotification)).EndInit();
            this.panelCPUUsage.ResumeLayout(false);
            this.panelCPUUsage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCPUUsage)).EndInit();
            this.panelRapidDatabaseGrowth.ResumeLayout(false);
            this.panelRapidDatabaseGrowth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrowthPercentage)).EndInit();
            this.panelSuspectDatabaseDetection.ResumeLayout(false);
            this.panelSuspectDatabaseDetection.PerformLayout();
            this.panelLocking.ResumeLayout(false);
            this.panelLocking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLockingCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAlertName;
        private System.Windows.Forms.ComboBox comboBoxAlertType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxAlertEnabled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownDelaysBeforeNotification;
        private System.Windows.Forms.NumericUpDown numericUpDownAlertNotifications;
        private System.Windows.Forms.NumericUpDown numericUpDownDelayBetweenNotification;
        private System.Windows.Forms.CheckBox checkBoxNotifyWhenResolved;
        private System.Windows.Forms.Panel panelCPUUsage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownCPUUsage;
        private System.Windows.Forms.Panel panelRapidDatabaseGrowth;
        private System.Windows.Forms.NumericUpDown numericUpDownGrowthPercentage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelSuspectDatabaseDetection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxIncludeRecoveryPending;
        private System.Windows.Forms.Panel panelLocking;
        private System.Windows.Forms.NumericUpDown numericUpDownLockingCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxAlertMethod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
    }
}