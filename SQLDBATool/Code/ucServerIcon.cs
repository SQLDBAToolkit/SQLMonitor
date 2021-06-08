using System.Windows.Forms;
using System.Drawing;

namespace SQLDBATool.Code
{
    public partial class ucServerIcon : UserControl
    {
        private CLSTreeInformation FTreeInformation;
        private ucServerDiagram FServerDiagram;

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

    }
}
