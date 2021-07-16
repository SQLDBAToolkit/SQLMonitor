using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class FormNewAlert : Form
    {
        public FormNewAlert()
        {
            InitializeComponent();
            comboBoxAlertType.SelectedIndex = 0;
            comboBoxAlertMethod.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.panelCPUUsage.Visible = (comboBoxAlertType.Text == "CPU Usage");
            this.panelRapidDatabaseGrowth.Visible = (comboBoxAlertType.Text == "Rapid Database Growth");
            this.panelSuspectDatabaseDetection.Visible = (comboBoxAlertType.Text == "Suspect Databases");
            this.panelLocking.Visible = (comboBoxAlertType.Text == "High Locking Detection");
        }

        private void FormNewAlert_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string alertRuleName;
            string ruleType;
            string notificationType;
            bool isEnabled;
            int notificationDelay;
            int notificationTries;
            int notificationDelayBetweenTries;
            bool alertWhenFixed;
            int cpuUsageTriggerPercent;
            int rapidDBGrowthPercentage;
            bool suspectRecoveryPending;
            int highLockingTrigger;

            if (textBoxAlertName.Text.Length == 0)
                MessageBox.Show("Please enter a rule name");
            else
            {
                alertRuleName = textBoxAlertName.Text;
                ruleType = comboBoxAlertType.Text;
                notificationType = comboBoxAlertMethod.Text;
                isEnabled = checkBoxAlertEnabled.Checked;
                notificationDelay = (int)numericUpDownDelaysBeforeNotification.Value;
                notificationTries = (int)numericUpDownAlertNotifications.Value;
                notificationDelayBetweenTries = (int)numericUpDownDelayBetweenNotification.Value;
                alertWhenFixed = checkBoxNotifyWhenResolved.Checked;
                cpuUsageTriggerPercent = (int)numericUpDownCPUUsage.Value;
                rapidDBGrowthPercentage = (int)numericUpDownGrowthPercentage.Value;
                suspectRecoveryPending = checkBoxIncludeRecoveryPending.Checked;
                highLockingTrigger = (int)numericUpDownLockingCount.Value;
                using (clsAlertRuleController alertController = new clsAlertRuleController())
                {
                    alertController.AddAlertRule(alertRuleName, ruleType, notificationType, isEnabled, notificationDelay, notificationTries, notificationDelayBetweenTries, alertWhenFixed, cpuUsageTriggerPercent, rapidDBGrowthPercentage, suspectRecoveryPending, highLockingTrigger);
                }
                this.Close();
            }


        }
    }
}
