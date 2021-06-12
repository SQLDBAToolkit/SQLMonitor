using System.Windows.Forms;
using System.Drawing;

namespace SQLDBATool.Code
{
    public partial class ucServerIcon : UserControl
    {
        private CLSTreeInformation FTreeInformation;
        private ucServerDiagram FServerDiagram;
        //private ucConnectionTree FParentTree;

        public ucServerDiagram ServerDiagram { get => FServerDiagram; set => FServerDiagram = value; }
        internal CLSTreeInformation TreeInformation
        {
            get => FTreeInformation;
            set
            {
                FTreeInformation = value;
                ServerInfoRefreshed();
            }
        }

        //public ucConnectionTree ParentTree { get => FParentTree; set => FParentTree = value; }

        public ucServerIcon()
        {
            InitializeComponent();
        }

        public void ServerInfoRefreshed()
        {
            labelServerName.Text = FTreeInformation.ConnectionInformation.MonitoredServer.ServerDisplayName;
        }

        public void SetTitleColor(Color fg, Color bg)
        {
            labelServerName.BackColor = bg;
            labelServerName.ForeColor = fg;
        }
        public void SetTitleText(string newTitle)
        {
            labelServerName.Text = newTitle;
        }
        public void setText(string cpuUsage, string bhr, string upTime)
        {
            labelCPUUsage.Text = cpuUsage;
            labelBHR.Text = bhr;
            labelUpTime.Text = upTime;
        }

        private void labelServerName_Click(object sender, System.EventArgs e)
        {
            FTreeInformation.ParentTree.SelectTreeNode(FTreeInformation.ConnectionTreeNode);
        }
    }
}
