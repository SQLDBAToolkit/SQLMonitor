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
    public partial class FormRegistration : Form
    {
        public SQLDBAToolSerialNumber RegistrationInformation { get; set; }
        public FormRegistration()
        {
            InitializeComponent();
            RegistrationInformation = new SQLDBAToolSerialNumber();

            if (RegistrationInformation.IsLicensed)
            {
                textBoxRegLiceses.Text = RegistrationInformation.NumberLicenses;
                textBoxRegLicenseKey.Text = RegistrationInformation.LicenseKeyString;
                textBoxRegSerialNumber.Text = RegistrationInformation.LicenseKey;
                panelRegistered.Show();
                panelUnregistered.Hide();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxLicenses.Text.Length == 0)
            {
                MessageBox.Show("Please enter the number of licenses field");
            }
            else if (textBoxLicenseKey.Text.Length == 0)
            {
                MessageBox.Show("Please enter the license key field");
            }
            else if (textBoxSerialNumber.Text.Length == 0)
            {
                MessageBox.Show("Please enter the Serial Number");
            }
            else if (!RegistrationInformation.CheckSerialNumber(textBoxSerialNumber.Text, textBoxLicenses.Text, textBoxLicenseKey.Text))
            {
                MessageBox.Show("Registration Serial Number is Invalid.  Please ensure all fields are exact");
            }
            else
            {
                RegistrationInformation.UpdateRegistrationInformation(true, textBoxLicenses.Text, textBoxLicenseKey.Text, textBoxSerialNumber.Text, DateTime.Now.AddYears(99));
                MessageBox.Show("SQL Monitor Toolkit is now licensed.  Please restart the application.");
                textBoxRegLiceses.Text = RegistrationInformation.NumberLicenses;
                textBoxRegLicenseKey.Text = RegistrationInformation.LicenseKeyString;
                textBoxRegSerialNumber.Text = RegistrationInformation.LicenseKey;
                panelRegistered.Show();
                panelUnregistered.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
