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
    public partial class ucRegistrationInformation : UserControl
    {
        private SQLDBAToolSerialNumber FRegistrationInformation;
        public SQLDBAToolSerialNumber RegistrationInformation
        {
            get => FRegistrationInformation;
            set
            {
                FRegistrationInformation = value;
             }
        }
 
        public ucRegistrationInformation()
        {
            InitializeComponent();
        }

        public void DisplayRegistrationInformation()
        {
            label1.Text = FRegistrationInformation.RegistrationStatus();
            if (!FRegistrationInformation.IsLicensed && !timerCountdown.Enabled)
            {
                timerCountdown.Start();
            }

        }

        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            label1.Text = FRegistrationInformation.RegistrationStatus();
            if (FRegistrationInformation.IsLicensed)
            {
                timerCountdown.Stop();
            }
        }
    }
}
