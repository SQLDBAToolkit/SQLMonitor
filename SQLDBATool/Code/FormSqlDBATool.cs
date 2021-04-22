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
        public void ShowDatabaseMonitor(Code.CLSTreeInformation serverConnection, bool forceChange)
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
}
