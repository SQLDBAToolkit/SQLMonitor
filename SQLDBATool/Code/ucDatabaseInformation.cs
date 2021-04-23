using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class ucDatabaseInformation : UserControl
    {
        private bool FErrorOn = false;
        private ucServerMonitor FParentMonitor;
        public ucDatabaseInformation()
        {
            InitializeComponent();
            ucDatabaseDetails1.SetDataTable(this.dataSetServerInformation);
        }

        public bool ErrorOn { get => FErrorOn; set => FErrorOn = value; }
        public ucServerMonitor ParentMonitor { get => FParentMonitor; set => FParentMonitor = value; }

        public void ShowDatabaseDetails(Code.CLSTreeInformation treeInformation)
        {
            try
            {
                if (treeInformation.ConnectionInformation.MonitoredServer.ServerID == ParentMonitor.ServerID)
                {
                    dataTableDatabaseInformation.Merge(treeInformation.ConnectionInformation.ServerStats.DTDatabaseInformation);

                    foreach (DataRow r in dataTableDatabaseInformation.Rows)
                    {
                        int databaseID = (int)(r["database_id"]);
                        string searchString = "database_id=" + databaseID.ToString();
                        if (treeInformation.ConnectionInformation.ServerStats.DTDatabaseInformation.Select(searchString).Length == 0)
                            r.Delete();
                    }

                    ucDataStorageMasterGraphs.PopulateMainGraph(treeInformation.ConnectionInformation.ServerStats.DTDatabaseSpaceInformation, treeInformation.ConnectionInformation.ServerStats.DTDatabaseInformation);
                    ucDataStorageMasterGraphs.PopulateDriveGraphs(treeInformation.ConnectionInformation.ServerStats.DTDatabaseSpaceInformation, treeInformation.ConnectionInformation.ServerStats.DTDatabaseSpaceByDrive);
                }
            }
            catch (Exception ex)
            {
                if (!ErrorOn)
                {
                    ErrorOn = true;
                    //MessageBox.Show(ex.Message);
                    ErrorOn = false;
                }
            }
        }

    }
}
