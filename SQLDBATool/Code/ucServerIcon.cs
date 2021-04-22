using System.Windows.Forms;

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
            //labelServerStats.Text = String.Format("CPU: {0}\r\nIO: {1}\r\nBHR: {2}", FTreeInformation.ConnectionInformation.ServerStats.CPU, FTreeInformation.ConnectionInformation.ServerStats.IO, FTreeInformation.ConnectionInformation.ServerStats.BHR);
        }

        public void setText(string cpuUsage, string bhr, string upTime)
        {
            labelCPUUsage.Text = cpuUsage;
            labelBHR.Text = bhr;
            labelUpTime.Text = upTime;
        }

    }
}
