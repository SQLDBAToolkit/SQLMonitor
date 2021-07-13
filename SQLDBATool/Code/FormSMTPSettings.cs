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
    public partial class FormSMTPSettings : Form
    {
        private bool FSettingsExist = false;
        private SMTPInformation FSMTPInformation;
        public FormSMTPSettings()
        {
            InitializeComponent();
            clsSMTPInformationController smtpConnectionController = new clsSMTPInformationController();
            FSettingsExist = smtpConnectionController.DoesSMTPSettingsExist();

            if (FSettingsExist)
            {
                FSMTPInformation = smtpConnectionController.GetSMTPInformation();
                textBoxSenderAddress.Text = FSMTPInformation.FromAddress;
                textBoxSendTo.Text = FSMTPInformation.ToAddress;
                comboBoxDeliveryMethod.Text = FSMTPInformation.SMTPDeliveryMethod;
                textBoxHost.Text = FSMTPInformation.SMTPHost;
                textBoxPort.Text = FSMTPInformation.SMTPPort.ToString();
                checkBoxEnableSSL.Checked = FSMTPInformation.EnableSSL;
                checkBoxUseDefaultCredentials.Checked = FSMTPInformation.UseDefaultCredentiais;
                textBoxUserID.Text = FSMTPInformation.SMTPUserID;
                textBoxPassword.Text = FSMTPInformation.SMTPPassword;
                textBoxFolder.Text = FSMTPInformation.SMTPPickupDirectoryLocation;
            }
            else
            {
                comboBoxDeliveryMethod.Text = "Network";
                checkBoxUseDefaultCredentials.Checked = true;
                checkBoxEnableSSL.Checked = false;
                FSMTPInformation = new SMTPInformation();

            }
        }


        private void buttonTestSMTP_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int port;

            if (int.TryParse(textBoxPort.Text, out port))
            {
                MailMessage testMsg = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                testMsg.From = new MailAddress(textBoxSenderAddress.Text);
                testMsg.To.Add(new MailAddress(textBoxSendTo.Text));
                testMsg.Subject = "Test Alert";
                testMsg.IsBodyHtml = false;
                testMsg.Body = "This is a test message";
                if (comboBoxDeliveryMethod.Text == "Network")
                {
                    smtp.Port = port;
                    smtp.Host = textBoxHost.Text;
                    smtp.EnableSsl = checkBoxEnableSSL.Checked;
                    smtp.UseDefaultCredentials = checkBoxUseDefaultCredentials.Checked;
                    if (!checkBoxUseDefaultCredentials.Checked)
                    {
                        smtp.Credentials = new NetworkCredential(textBoxUserID.Text, textBoxPassword.Text);
                    }
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                }
                else if (comboBoxDeliveryMethod.Text == "Pickup Directory From IIS")
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                    smtp.PickupDirectoryLocation = textBoxFolder.Text;
                }
                else
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtp.PickupDirectoryLocation = textBoxFolder.Text;
                }
                try
                {
                    smtp.Send(testMsg);
                    labelTestSuccessful.Show();
                    labelTestFailed.Hide();
                }
                catch (Exception smtpException)
                {
                    MessageBox.Show(smtpException.Message, "SMTP Send Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    labelTestSuccessful.Hide();
                    labelTestFailed.Show();
                }
            }
            else
                MessageBox.Show("Port is not numeric", "Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Cursor = Cursors.Default;

        }

        private void comboBoxDeliveryMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxHost.Enabled =
                textBoxPort.Enabled =
                checkBoxEnableSSL.Enabled =
                checkBoxUseDefaultCredentials.Enabled =
                (comboBoxDeliveryMethod.Text == "Network");

            textBoxFolder.Enabled = (comboBoxDeliveryMethod.Text != "Network");
            textBoxUserID.Enabled = textBoxPassword.Enabled = (comboBoxDeliveryMethod.Text == "Network" && !checkBoxUseDefaultCredentials.Checked);
        }

        private void checkBoxUseDefaultCredentials_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUserID.Enabled = textBoxPassword.Enabled = (comboBoxDeliveryMethod.Text == "Network" && !checkBoxUseDefaultCredentials.Checked);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int port;

            if (int.TryParse(textBoxPort.Text, out port))
            {
                FSMTPInformation.FromAddress = textBoxSenderAddress.Text;
                FSMTPInformation.ToAddress = textBoxSendTo.Text;
                FSMTPInformation.SMTPDeliveryMethod = comboBoxDeliveryMethod.Text;
                FSMTPInformation.SMTPHost = textBoxHost.Text;
                FSMTPInformation.SMTPPort = port;
                FSMTPInformation.EnableSSL = checkBoxEnableSSL.Checked;
                FSMTPInformation.UseDefaultCredentiais = checkBoxUseDefaultCredentials.Checked;
                FSMTPInformation.SMTPUserID = textBoxUserID.Text;
                FSMTPInformation.SMTPPassword = textBoxPassword.Text;
                FSMTPInformation.SMTPPickupDirectoryLocation = textBoxFolder.Text;
                if (FSettingsExist)
                {
                    clsSMTPInformationController smtpConnectionController = new clsSMTPInformationController();
                    smtpConnectionController.UpdateSMTPInformation(FSMTPInformation);
                }
                else
                {
                    clsSMTPInformationController smtpConnectionController = new clsSMTPInformationController();
                    smtpConnectionController.AddSMTPInformation(FSMTPInformation);

                }
                this.Close();
            }
            else
                MessageBox.Show("Port is not numeric", "Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
