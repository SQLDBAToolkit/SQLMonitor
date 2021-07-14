using System.Windows.Forms;

namespace SQLDBATool
{
    public partial class FormSqlDBATool : Form
    {
        private Code.ucServerDiagram FActiveDiagram;
        public FormSqlDBATool()
        {
            InitializeComponent();
            Code.Globals.MasterForm = this;
            ucConnectionTree1.ParentSqlToolsForm = this;
            ucConnectionTree1.PopulateTreeViewItems();
            ucServerMonitor1.ConnectionTree = ucConnectionTree1;
            ucConnectionTree1.ServerMonitor = ucServerMonitor1;
            ucServerMonitor1.RegistrationInformation = ucConnectionTree1.RegistrationInformation;
        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
        //        return cp;
        //    }
        //}
        public void AddServerDiagram(Code.ucServerDiagram serverDiagram)
        {
            this.splitContainerLayout.Panel2.Controls.Add(serverDiagram);
            serverDiagram.Dock = DockStyle.Fill;
            if (FActiveDiagram == null)
            {
                FActiveDiagram = serverDiagram;
            }
            else
                serverDiagram.Hide();
        }

        public void ShowServerDiagram(Code.ucServerDiagram serverDiagram)
        {
            if (FActiveDiagram != null)
            {
                if (FActiveDiagram != serverDiagram)
                {
                    FActiveDiagram.Hide();
                }
            }
            FActiveDiagram = serverDiagram;
            FActiveDiagram.Show();
            ucServerMonitor1.Hide();
        }
        public void ShowServerMonitor(Code.CLSTreeInformation serverConnection, bool forceChange)
        {

            if (serverConnection != null)
            {
                if (forceChange)
                {
                    ucServerMonitor1.ServerID = serverConnection.ConnectionInformation.MonitoredServer.ServerID;
                    if (FActiveDiagram != null)
                    {
                        FActiveDiagram.Hide();
                        FActiveDiagram = null;
                        ucServerMonitor1.Show();
                    }
                    ucServerMonitor1.ChangeSessionDataTable(serverConnection);
                    ShowDatabaseMonitor(serverConnection, false);


                }
                ucServerMonitor1.ShowServerDetails(serverConnection);
            }
        }
        public void ShowDatabaseMonitor(Code.CLSTreeInformation serverConnection, bool forceChange)
        {
            if (serverConnection != null)
            {
                if (forceChange)
                {
                    ucServerMonitor1.ServerID = serverConnection.ConnectionInformation.MonitoredServer.ServerID;
                    if (FActiveDiagram != null)
                    {
                        FActiveDiagram.Hide();
                        FActiveDiagram = null;
                        ucServerMonitor1.Show();
                    }
                }
                ucServerMonitor1.ShowDatabaseDetails(serverConnection);
            }
        }

        private void alertingToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Code.FormAlertConfiguration alert = new Code.FormAlertConfiguration();
            alert.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void registrationInformaionToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Code.FormRegistration frmReg = new Code.FormRegistration();
            frmReg.ShowDialog();
        }
    }
}
