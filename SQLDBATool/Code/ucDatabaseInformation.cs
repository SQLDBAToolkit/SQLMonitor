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
        private bool FRefreshing = false;
        public ucDatabaseInformation()
        {
            InitializeComponent();
            ucDatabaseDetails1.SetDataTable(this.dataSetServerInformation);
        }

        public bool ErrorOn { get => FErrorOn; set => FErrorOn = value; }
        public ucServerMonitor ParentMonitor { get => FParentMonitor; set => FParentMonitor = value; }

        public void ShowDatabaseDetails(Code.CLSTreeInformation treeInformation)
        {
            FRefreshing = true;
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
                        r.ClearErrors();
                    }

                    dataTableDatabaseInformation.AcceptChanges();
                    ucDataStorageMasterGraphs.PopulateMainGraph(treeInformation.ConnectionInformation.ServerStats.DTDatabaseSpaceInformation, treeInformation.ConnectionInformation.ServerStats.DTDatabaseInformation);
                    ucDataStorageMasterGraphs.PopulateDriveGraphs(treeInformation.ConnectionInformation.ServerStats.DTDatabaseSpaceInformation, treeInformation.ConnectionInformation.ServerStats.DTDatabaseSpaceByDrive);
                    PopulateDataFileTabPage(true);
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
            FRefreshing = false;
        }

        private void dbDataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void PopulateDataFileTabPage(bool overrideRefreshing)
        {
            if (!FRefreshing || overrideRefreshing)
            {
                if (dbDataGridView1.SelectedRows.Count > 0)
                {

                    int database_id = (int)dbDataGridView1.SelectedRows[0].Cells[0].Value;
                    ucDatabaseFiles1.PopulateDatabaseFileInformation(database_id, FParentMonitor.TreeInformation.ConnectionInformation.ServerStats.DTDatabaseFileInformation);
                }
            }
        }

        private void dbDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            PopulateDataFileTabPage(false);
        }
    }
}
