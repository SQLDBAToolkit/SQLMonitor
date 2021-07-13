
namespace SQLDBATool.Code
{
    partial class FormAlertConfiguration
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataSetAlerts = new System.Data.DataSet();
            this.dataTableAlerts = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataColumn9 = new System.Data.DataColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertRuleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruleTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.notificationTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.notificationDelayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notificationTriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notificationDelayBetweenTriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alertWhenFixedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAlerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableAlerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "PagerDuty Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "SMTP Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataSetAlerts
            // 
            this.dataSetAlerts.DataSetName = "NewDataSet";
            this.dataSetAlerts.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableAlerts});
            // 
            // dataTableAlerts
            // 
            this.dataTableAlerts.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9});
            this.dataTableAlerts.TableName = "Alerts";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "ID";
            this.dataColumn1.DataType = typeof(int);
            this.dataColumn1.DefaultValue = -1;
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "Rule Type";
            this.dataColumn2.ColumnName = "RuleType";
            this.dataColumn2.DefaultValue = "Server Down";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "Notification Type";
            this.dataColumn3.ColumnName = "NotificationType";
            this.dataColumn3.DefaultValue = "SMTP";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "Rule Enabled";
            this.dataColumn4.ColumnName = "IsEnabled";
            this.dataColumn4.DataType = typeof(bool);
            this.dataColumn4.DefaultValue = true;
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "Notifiation Delay";
            this.dataColumn5.ColumnName = "NotificationDelay";
            this.dataColumn5.DataType = typeof(int);
            this.dataColumn5.DefaultValue = 300;
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "Notification Tries";
            this.dataColumn6.ColumnName = "NotificationTries";
            this.dataColumn6.DataType = typeof(int);
            this.dataColumn6.DefaultValue = 1;
            // 
            // dataColumn7
            // 
            this.dataColumn7.Caption = "Delay Between Retries";
            this.dataColumn7.ColumnName = "NotificationDelayBetweenTries";
            this.dataColumn7.DataType = typeof(int);
            this.dataColumn7.DefaultValue = 0;
            // 
            // dataColumn8
            // 
            this.dataColumn8.Caption = "Alert When Fixed";
            this.dataColumn8.ColumnName = "AlertWhenFixed";
            this.dataColumn8.DataType = typeof(bool);
            this.dataColumn8.DefaultValue = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.AlertRuleID,
            this.ruleTypeDataGridViewTextBoxColumn,
            this.notificationTypeDataGridViewTextBoxColumn,
            this.isEnabledDataGridViewCheckBoxColumn,
            this.notificationDelayDataGridViewTextBoxColumn,
            this.notificationTriesDataGridViewTextBoxColumn,
            this.notificationDelayBetweenTriesDataGridViewTextBoxColumn,
            this.alertWhenFixedDataGridViewCheckBoxColumn});
            this.dataGridView1.DataMember = "Alerts";
            this.dataGridView1.DataSource = this.dataSetAlerts;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(780, 163);
            this.dataGridView1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAccept);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 40);
            this.panel1.TabIndex = 3;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(612, 6);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 3;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(693, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "AlertRuleID";
            this.dataColumn9.DataType = typeof(System.Guid);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // AlertRuleID
            // 
            this.AlertRuleID.DataPropertyName = "AlertRuleID";
            this.AlertRuleID.HeaderText = "AlertRuleID";
            this.AlertRuleID.Name = "AlertRuleID";
            this.AlertRuleID.Visible = false;
            // 
            // ruleTypeDataGridViewTextBoxColumn
            // 
            this.ruleTypeDataGridViewTextBoxColumn.DataPropertyName = "RuleType";
            this.ruleTypeDataGridViewTextBoxColumn.HeaderText = "Rule Type";
            this.ruleTypeDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "Server Down",
            "Suspect Databases",
            "Excessive Locking",
            "Rapid Data Growth",
            "High CPU Usage"});
            this.ruleTypeDataGridViewTextBoxColumn.MinimumWidth = 150;
            this.ruleTypeDataGridViewTextBoxColumn.Name = "ruleTypeDataGridViewTextBoxColumn";
            this.ruleTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ruleTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ruleTypeDataGridViewTextBoxColumn.Width = 150;
            // 
            // notificationTypeDataGridViewTextBoxColumn
            // 
            this.notificationTypeDataGridViewTextBoxColumn.DataPropertyName = "NotificationType";
            this.notificationTypeDataGridViewTextBoxColumn.HeaderText = "Method";
            this.notificationTypeDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "SMTP",
            "PagerDuty"});
            this.notificationTypeDataGridViewTextBoxColumn.Name = "notificationTypeDataGridViewTextBoxColumn";
            this.notificationTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.notificationTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isEnabledDataGridViewCheckBoxColumn
            // 
            this.isEnabledDataGridViewCheckBoxColumn.DataPropertyName = "IsEnabled";
            this.isEnabledDataGridViewCheckBoxColumn.HeaderText = "Enabled";
            this.isEnabledDataGridViewCheckBoxColumn.Name = "isEnabledDataGridViewCheckBoxColumn";
            // 
            // notificationDelayDataGridViewTextBoxColumn
            // 
            this.notificationDelayDataGridViewTextBoxColumn.DataPropertyName = "NotificationDelay";
            this.notificationDelayDataGridViewTextBoxColumn.HeaderText = "Delay";
            this.notificationDelayDataGridViewTextBoxColumn.Name = "notificationDelayDataGridViewTextBoxColumn";
            // 
            // notificationTriesDataGridViewTextBoxColumn
            // 
            this.notificationTriesDataGridViewTextBoxColumn.DataPropertyName = "NotificationTries";
            this.notificationTriesDataGridViewTextBoxColumn.HeaderText = "Tries";
            this.notificationTriesDataGridViewTextBoxColumn.Name = "notificationTriesDataGridViewTextBoxColumn";
            // 
            // notificationDelayBetweenTriesDataGridViewTextBoxColumn
            // 
            this.notificationDelayBetweenTriesDataGridViewTextBoxColumn.DataPropertyName = "NotificationDelayBetweenTries";
            this.notificationDelayBetweenTriesDataGridViewTextBoxColumn.HeaderText = "Try Delay";
            this.notificationDelayBetweenTriesDataGridViewTextBoxColumn.Name = "notificationDelayBetweenTriesDataGridViewTextBoxColumn";
            // 
            // alertWhenFixedDataGridViewCheckBoxColumn
            // 
            this.alertWhenFixedDataGridViewCheckBoxColumn.DataPropertyName = "AlertWhenFixed";
            this.alertWhenFixedDataGridViewCheckBoxColumn.HeaderText = "Alert When Fixed";
            this.alertWhenFixedDataGridViewCheckBoxColumn.Name = "alertWhenFixedDataGridViewCheckBoxColumn";
            // 
            // FormAlertConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 203);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormAlertConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alert Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAlerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableAlerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Data.DataSet dataSetAlerts;
        private System.Data.DataTable dataTableAlerts;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button button3;
        private System.Data.DataColumn dataColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertRuleID;
        private System.Windows.Forms.DataGridViewComboBoxColumn ruleTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn notificationTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notificationDelayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notificationTriesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notificationDelayBetweenTriesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn alertWhenFixedDataGridViewCheckBoxColumn;
    }
}