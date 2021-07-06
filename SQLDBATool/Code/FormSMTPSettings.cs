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
        public FormSMTPSettings()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonTestSMTP_Click(object sender, EventArgs e)
        {
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
                smtp.Port = port;
                smtp.Host = textBoxHost.Text;
                smtp.EnableSsl = checkBoxEnableSSL.Checked;
                smtp.UseDefaultCredentials = checkBoxUseDefaultCredentials.Checked;
                if (!checkBoxUseDefaultCredentials.Checked)
                {
                    smtp.Credentials = new NetworkCredential(textBoxUserID.Text, textBoxPassword.Text);
                }
                if (comboBoxDeliveryMethod.Text == "Network")
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
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
                smtp.Send(testMsg);
            }
            else
                MessageBox.Show("Port is not numeric", "Invalid Port", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
