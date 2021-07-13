using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SQLDBATool.Code
{
    public partial class FormAlertConfiguration : Form
    {
        public FormAlertConfiguration()
        {
            InitializeComponent();
            LoadAllAlerts();
            
        }

        private void LoadAllAlerts()
        {
            using (clsAlertRuleController alertRuleController = new clsAlertRuleController())
            {
                foreach (AlertRule rule in alertRuleController.GetAllAlertRules())
                {
                    object[] newRow = new object[9];
                    newRow[0] = rule.ID;
                    newRow[1] = rule.RuleType;
                    newRow[2] = rule.NotificationType;
                    newRow[3] = rule.IsEnabled;
                    newRow[4] = rule.NotificationDelay;
                    newRow[5] = rule.NotificationTries;
                    newRow[6] = rule.NotificationDelayBetweenTries;
                    newRow[7] = rule.AlertWhenFixed;
                    newRow[8] = rule.AlertRuleID;
                    dataTableAlerts.Rows.Add(newRow);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSMTPSettings formSmtp = new FormSMTPSettings();
            formSmtp.ShowDialog();

        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            using (clsAlertRuleController ruleController = new clsAlertRuleController())
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    AlertRule rule = new AlertRule();
                    {
                        rule.ID = (int)row.Cells[0].Value;
                        rule.AlertRuleID = (Guid)row.Cells[1].Value;
                        rule.RuleType = row.Cells[2].Value.ToString();
                        rule.NotificationType = row.Cells[3].Value.ToString();
                        rule.IsEnabled = (bool)row.Cells[4].Value;
                        rule.NotificationDelay = (int)row.Cells[5].Value;
                        rule.NotificationTries = (int)row.Cells[6].Value;
                        rule.NotificationDelayBetweenTries = (int)row.Cells[7].Value;
                        rule.AlertWhenFixed = (bool)row.Cells[8].Value;

                        ruleController.UpdateAlertRule(rule);
                    }
                }
            }

            this.Close();
        }

    }
}
