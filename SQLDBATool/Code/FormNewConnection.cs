using System;
using System.Collections.Generic;
//using System.Data.SQLite;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class FormNewConnection : Form
    {
        private CLSTreeInformation FParentTreeInformation;
        private ucConnectionTree FConnTree;

        public FormNewConnection(CLSTreeInformation parentTreeInformation, ucConnectionTree connTree)
        {
            InitializeComponent();
            FParentTreeInformation = parentTreeInformation;
            FConnTree = connTree;
            comboBoxNetworkProtocol.Text = "<default>";
            textBoxConnectionName.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //            string serverTreeGuid = Guid.NewGuid().ToString();
            //            string connectionGuid = Guid.NewGuid().ToString();

            if (textBoxConnectionName.Text.Trim().Length > 0)
            {
                clsMonitoredServerController monitoredServerController = new clsMonitoredServerController();
                clsServerTreeController serverTreeController = new clsServerTreeController();

                MonitoredServer monitoredServer = monitoredServerController.AddMonitoredServer(
                    textBoxServerName.Text,
                    textBoxConnectionName.Text,
                    checkBoxWinAuth.Checked,
                    textBoxUserID.Text,
                    textBoxPassword.Text);

                monitoredServer.NetworkProtocol = comboBoxNetworkProtocol.Text;
                monitoredServer.NetworkPacketSize = (int)numericUpDownNetworkPacketSize.Value;
                monitoredServer.ConnectionTimeOut = (int)numericUpDownConnectionTimeOut.Value;
                monitoredServer.ExecutionTimeOut = (int)numericUpDownExecutionTimeOut.Value;
                monitoredServer.EncryptConnection = checkBoxEncryptConnection.Checked;
                monitoredServer.TrustServerCertificate = checkBoxTrustServerCertificate.Checked;

                monitoredServerController.UpdateMonitoredServer(monitoredServer);
                ServerTree serverTree = serverTreeController.AddServerTree(
                    textBoxConnectionName.Text,
                    1,
                    FParentTreeInformation.ServerTree.ServerTreeID,
                    false,
                    monitoredServer.ServerID,
                    false);

                CLSTreeInformation parentTree = FParentTreeInformation;
                monitoredServer.TreeDiagrams = new List<ServerTreeDiagram>();
                bool hasChildren = true;

                while (hasChildren)
                {
                    monitoredServer.TreeDiagrams.Add(monitoredServerController.AddServerDiagram(
                        monitoredServer.ServerID,
                        parentTree.ServerTree.ServerTreeID,
                        1,
                        1,
                        true));
                    if (parentTree.ParentTreeInformation == null)
                        hasChildren = false;
                    else
                        parentTree = parentTree.ParentTreeInformation;
                }
                FConnTree.AppendNewTreeItem(serverTree, FParentTreeInformation);
            }
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
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

        private void checkBoxWinAuth_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUserID.ReadOnly = checkBoxWinAuth.Checked;
            textBoxUserID.Enabled = !checkBoxWinAuth.Checked;
            textBoxPassword.ReadOnly = checkBoxWinAuth.Checked;
            textBoxPassword.Enabled = !checkBoxWinAuth.Checked;

        }

        private void textBoxConnectionName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxServerName.Text.Length == 0 || textBoxConnectionName.Text.StartsWith(textBoxServerName.Text))
                textBoxServerName.Text = textBoxConnectionName.Text;
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
    }
}
