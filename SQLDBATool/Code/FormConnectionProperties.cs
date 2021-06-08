using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace SQLDBATool.Code
{
    public partial class FormConnectionProperties : Form
    {
        private CLSTreeInformation FTreeInformation;
        private readonly SynchronizationContext _syncContext;

        public FormConnectionProperties(CLSTreeInformation treeInformation)
        {
            _syncContext = SynchronizationContext.Current;
            InitializeComponent();
            FTreeInformation = treeInformation;
            SetConnectionObjects();
            if (FTreeInformation.ConnectionInformation.IsConnectionOpen)
                FTreeInformation.ConnectionInformation.RefreshBackgroundProcess.ProcessRefreshStopped += ProcessRefreshStopped;
            
        }
        public void ProcessRefreshStopped(object sender, ServerStatsRefreshStoppedArgs e)
        {
            _syncContext.Post(o => SetOpenConnectionToClose(e), null);
        }

        public void SetOpenConnectionToClose(ServerStatsRefreshStoppedArgs e)
        {
            EnableeObjects();

        }

        void SetConnectionObjects()
        {
            textBoxConnectionName.Text = FTreeInformation.ConnectionInformation.MonitoredServer.ServerDisplayName;
            textBoxServerName.Text = FTreeInformation.ConnectionInformation.MonitoredServer.ServerName;
            checkBoxWinAuth.Checked = FTreeInformation.ConnectionInformation.MonitoredServer.UseIntegratedSecurity;

            textBoxUserID.Text = FTreeInformation.ConnectionInformation.MonitoredServer.UserID;
            textBoxPassword.Text = FTreeInformation.ConnectionInformation.MonitoredServer.Password;

            comboBoxNetworkProtocol.Text = FTreeInformation.ConnectionInformation.MonitoredServer.NetworkProtocol;
            numericUpDownNetworkPacketSize.Value = FTreeInformation.ConnectionInformation.MonitoredServer.NetworkPacketSize;
            numericUpDownConnectionTimeOut.Value = FTreeInformation.ConnectionInformation.MonitoredServer.ConnectionTimeOut;
            numericUpDownExecutionTimeOut.Value = FTreeInformation.ConnectionInformation.MonitoredServer.ExecutionTimeOut;
            checkBoxEncryptConnection.Checked = FTreeInformation.ConnectionInformation.MonitoredServer.EncryptConnection;
            checkBoxTrustServerCertificate.Checked = FTreeInformation.ConnectionInformation.MonitoredServer.TrustServerCertificate;

            if (FTreeInformation.ConnectionInformation.IsConnectionOpen)
            {
                DisableObjects();
            }
            else
            {
                EnableeObjects();
            }

        }

        public void DisableObjects()
        {
            buttonAccept.Enabled = false;
            buttonTestConnection.Hide();
            buttonDisconnect.Show();
            textBoxConnectionName.Enabled = false;
            textBoxServerName.Enabled = false;
            checkBoxWinAuth.Enabled = false;
            textBoxUserID.Enabled = false;
            textBoxPassword.Enabled = false;
            comboBoxNetworkProtocol.Enabled = false;
            numericUpDownConnectionTimeOut.Enabled = false;
            numericUpDownExecutionTimeOut.Enabled = false;
            numericUpDownNetworkPacketSize.Enabled = false;
            checkBoxEncryptConnection.Enabled = false;
            checkBoxTrustServerCertificate.Enabled = false;

        }
        public void EnableeObjects()
        {
            buttonAccept.Enabled = true;
            buttonTestConnection.Show();
            buttonDisconnect.Hide();
            textBoxConnectionName.Enabled = true;
            textBoxServerName.Enabled = true;
            checkBoxWinAuth.Enabled = true;
            if (checkBoxWinAuth.Checked)
            {
                textBoxUserID.Enabled = true;
                textBoxPassword.Enabled = true;
            }
            comboBoxNetworkProtocol.Enabled = true;
            numericUpDownConnectionTimeOut.Enabled = true;
            numericUpDownExecutionTimeOut.Enabled = true;
            numericUpDownNetworkPacketSize.Enabled = true;
            checkBoxEncryptConnection.Enabled = true;
            checkBoxTrustServerCertificate.Enabled = true;

        }
        private void checkBoxWinAuth_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUserID.ReadOnly = checkBoxWinAuth.Checked;
            textBoxUserID.Enabled = !checkBoxWinAuth.Checked;
            textBoxPassword.ReadOnly = checkBoxWinAuth.Checked;
            textBoxPassword.Enabled = !checkBoxWinAuth.Checked;
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            FTreeInformation.ConnectionInformation.StopRefreshProcess();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxConnectionName.Text.Trim().Length > 0)
            {
                clsMonitoredServerController monitoredServerController = new clsMonitoredServerController();
                clsServerTreeController serverTreeController = new clsServerTreeController();

                FTreeInformation.ConnectionInformation.MonitoredServer.ServerName = textBoxServerName.Text;
                FTreeInformation.ConnectionInformation.MonitoredServer.ServerDisplayName = textBoxConnectionName.Text;
                FTreeInformation.ConnectionInformation.MonitoredServer.UseIntegratedSecurity = checkBoxWinAuth.Checked;
                FTreeInformation.ConnectionInformation.MonitoredServer.UserID = textBoxUserID.Text;
                FTreeInformation.ConnectionInformation.MonitoredServer.Password = textBoxPassword.Text;

                FTreeInformation.ConnectionInformation.MonitoredServer.NetworkProtocol = comboBoxNetworkProtocol.Text;
                FTreeInformation.ConnectionInformation.MonitoredServer.NetworkPacketSize = (int)numericUpDownNetworkPacketSize.Value;
                FTreeInformation.ConnectionInformation.MonitoredServer.ConnectionTimeOut = (int)numericUpDownConnectionTimeOut.Value;
                FTreeInformation.ConnectionInformation.MonitoredServer.ExecutionTimeOut = (int)numericUpDownExecutionTimeOut.Value;
                FTreeInformation.ConnectionInformation.MonitoredServer.EncryptConnection = checkBoxEncryptConnection.Checked;
                FTreeInformation.ConnectionInformation.MonitoredServer.TrustServerCertificate = checkBoxTrustServerCertificate.Checked;

                monitoredServerController.UpdateMonitoredServer(FTreeInformation.ConnectionInformation.MonitoredServer);
                
                FTreeInformation.ConnectionInformation.ServerTree.TreeName = textBoxConnectionName.Text;
                serverTreeController.UpdateServerTree(FTreeInformation.ConnectionInformation.ServerTree);

                FTreeInformation.ConnectionInformation.UpdateIconTitle(textBoxConnectionName.Text);
                FTreeInformation.ConnectionTreeNode.Text = textBoxConnectionName.Text;
            }
            this.Close();
        }
        public string BuildConnectionString()
        {
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();

            connString.DataSource = textBoxServerName.Text;
            connString.IntegratedSecurity = checkBoxWinAuth.Checked;
            if (!checkBoxWinAuth.Checked)
            {
                connString.UserID = textBoxUserID.Text;
                connString.Password = textBoxPassword.Text;
            }
            if (comboBoxNetworkProtocol.Text != @"<default>")
            {
                string networkLibrary = comboBoxNetworkProtocol.Text.Substring(comboBoxNetworkProtocol.Text.IndexOf("(") + 1);
                networkLibrary = networkLibrary.Substring(0, networkLibrary.Length - 1);
                connString.NetworkLibrary = networkLibrary;
            }
            if (numericUpDownNetworkPacketSize.Value != 4096)
            {
                connString.PacketSize = (int)numericUpDownNetworkPacketSize.Value;
            }
            if (numericUpDownConnectionTimeOut.Value != 4096)
            {
                connString.ConnectTimeout = (int)numericUpDownConnectionTimeOut.Value;
            }
            connString.Encrypt = checkBoxEncryptConnection.Checked;
            connString.TrustServerCertificate = checkBoxTrustServerCertificate.Checked;
            connString.ApplicationName = "SQL Server Assistance Connection Test";
            return connString.ConnectionString;
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            string connString = BuildConnectionString();
            labelConnectionSuccessful.Hide();
            labelConnectionFailed.Hide();
            Cursor = Cursors.WaitCursor;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {

                    conn.Open();
                    conn.Close();
                    labelConnectionSuccessful.Show();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    labelConnectionFailed.Show();
                }
            }
            Cursor = Cursors.Default;

        }
    }
}
