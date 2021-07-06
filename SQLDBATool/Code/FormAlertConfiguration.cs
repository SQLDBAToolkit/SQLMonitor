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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage testMsg = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            testMsg.From = new MailAddress("daverowland1@live.com");
            testMsg.To.Add(new MailAddress("user-database-email.kf9pduj6@sqldbatool.pagerduty.com"));
            testMsg.Subject = "Test Alert";
            testMsg.IsBodyHtml = false;
            testMsg.Body = "This is a test message";
            testMsg.From = new MailAddress("daverowland1@live.com");
            smtp.Port = 587;
            smtp.Host = "smtp.live.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("daverowland1@live.com", "9assWord!@2020");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(testMsg);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSMTPSettings formSmtp = new FormSMTPSettings();
            formSmtp.ShowDialog();

        }
    }
}
