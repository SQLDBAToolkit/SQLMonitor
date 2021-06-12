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
    public partial class ucDataStorageMaster : UserControl
    {
        private Guid FServerID;
        private List<clsDriveGraph> FDriveGraphs;
        public ucDataStorageMaster()
        {
            InitializeComponent();
            FDriveGraphs = new List<clsDriveGraph>();
        }
        public void HideGraphs()
        {
            ucDatabaseStorageMain.PreRefresh();
            ucDatabaseStorageMain.PostRefresh();
            PreRefreshDrives();
            PostRefreshDrives();
        }
        public void PopulateMainGraph(DataTable dataSizeInformation, DataTable databaseInformation)
        {
            try
            {
                if (dataSizeInformation.Rows.Count > 0)
                {
                    DataRow row = dataSizeInformation.Select("DriveType=0")[0];
                    ucDatabaseStorageMain.TotalSizeData = (int)row["data_size_mb"];
                    ucDatabaseStorageMain.TotalSizeLog = (int)row["log_size_mb"];
                    ucDatabaseStorageMain.TotalSizeFileStream = (int)row["filestream_size_mb"];
                }
                ucDatabaseStorageMain.PreRefresh();
                foreach (DataRow row in databaseInformation.Rows)
                {
                    int databaseID;
                    string databaseName;
                    int totalSizeData;
                    int usedSizeData;
                    int totalSizeLog;
                    int usedSizeLog;
                    int totalSizeFileStream;
                    string scanningMsg = "";
                    if (row["Data_Used_Mb"].ToString() == "Scanning..." || row["Data_Used_Mb"].ToString() == "No Access")
                    {
                        scanningMsg = row["Data_Used_Mb"].ToString();
                    }
                    databaseID = (int)row["database_id"];
                    databaseName = row["Database_Name"].ToString();
                    totalSizeData = (int)row["Sort_Data_Size_Mb"];
                    usedSizeData = (int)row["Sort_Data_Used_Mb"];
                    totalSizeLog = (int)row["Sort_Log_Size_Mb"];
                    usedSizeLog = (int)row["Sort_Log_Used_Mb"];
                    if (row["Sort_FileStream_Mb"] != DBNull.Value)
                        totalSizeFileStream = (int)row["Sort_FileStream_Mb"];
                    else
                        totalSizeFileStream = 0;

                    ucDatabaseStorageMain.AddDatabase(databaseID, databaseName, totalSizeData, usedSizeData, totalSizeLog, usedSizeLog, totalSizeFileStream, totalSizeFileStream, scanningMsg);
                }
                ucDatabaseStorageMain.PostRefresh();
                ucDatabaseStorageMain.SpaceGraphs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void PopulateDriveGraphs(DataTable dataSizeInformation, DataTable databaseSizeByDrive)
        {
            try
            {
                clsDriveGraph currentGraph = null;
                PreRefreshDrives();
                int masterSize = ucDatabaseStorageMain.GetMaxSize();
                foreach (DataRow row in dataSizeInformation.Rows)
                {
                    string drive = row["Drive"].ToString();
                    if (drive != "MASTER")
                    {
                        if (currentGraph == null)
                        {
                            currentGraph = FindDriveGraph(drive);
                            currentGraph.DBStorage.TotalSizeData = (int)row["data_size_mb"];
                            currentGraph.DBStorage.TotalSizeLog = (int)row["log_size_mb"];
                            currentGraph.DBStorage.TotalSizeFileStream = (int)row["filestream_size_mb"];
                            currentGraph.DBStorage.DisplaySize = masterSize;
                        }
                        else if (currentGraph.Drive != drive)
                        {
                            currentGraph = FindDriveGraph(drive);
                            currentGraph.DBStorage.TotalSizeData = (int)row["data_size_mb"];
                            currentGraph.DBStorage.TotalSizeLog = (int)row["log_size_mb"];
                            currentGraph.DBStorage.TotalSizeFileStream = (int)row["filestream_size_mb"];
                            currentGraph.DBStorage.DisplaySize = masterSize;
                            currentGraph.DBStorage.Show();
                        }
                        currentGraph.DBStorage.PreRefresh();
                        foreach (DataRow dbRow in databaseSizeByDrive.Rows)
                        {
                            if (dbRow["Drive"].ToString() == drive)
                            {
                                int databaseID;
                                string databaseName;
                                int totalSizeData;
                                int usedSizeData;
                                int totalSizeLog;
                                int usedSizeLog;
                                int totalSizeFileStream;
                                string scanningMsg = "";
                                //if (row["Data_Used_Mb"].ToString() == "Scanning..." || row["Data_Used_Mb"].ToString() == "No Access")
                                //{
                                //scanningMsg = row["Data_Used_Mb"].ToString();
                                //}
                                databaseID = (int)dbRow["database_id"];
                                databaseName = dbRow["Database_Name"].ToString();
                                totalSizeData = (int)dbRow["db_Size_Mb"];
                                usedSizeData = (int)dbRow["Data_Used_Mb"];
                                totalSizeLog = (int)dbRow["Log_Size_Mb"];
                                usedSizeLog = (int)dbRow["Log_Used_Mb"];
                                if (dbRow["FileStream_Size_Mb"] != DBNull.Value)
                                    totalSizeFileStream = (int)dbRow["FileStream_Size_Mb"];
                                else
                                    totalSizeFileStream = 0;

                                currentGraph.DBStorage.AddDatabase(databaseID, databaseName, totalSizeData, usedSizeData, totalSizeLog, usedSizeLog, totalSizeFileStream, totalSizeFileStream, scanningMsg);
                            }
                        }
                        currentGraph.DBStorage.PostRefresh();
                        currentGraph.DBStorage.SpaceGraphs();
                    }
                }
                PostRefreshDrives();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public clsDriveGraph FindDriveGraph(string drive)
        {
            clsDriveGraph ret = null;
            if (FDriveGraphs.Count > 0)
            {
                foreach (clsDriveGraph grp in FDriveGraphs)
                {
                    if (grp.Drive == drive)
                    {
                        ret = grp;
                        break;
                    }
                }
            }

            if (ret == null)
            {
                ret = new clsDriveGraph();
                ret.Drive = drive;
                ret.DBStorage.HeaderTitle = "Drive " + drive;
                this.Controls.Add(ret.DBStorage);
                ret.AddedToControl = true;
                ret.DBStorage.Dock = DockStyle.Top;
                ret.DBStorage.Show();
                ret.DBStorage.BringToFront();
                FDriveGraphs.Add(ret);
            }
            else
            {
                ret.DBStorage.Show();
                ret.DBStorage.BringToFront();
            }

            ret.Refreshed = true;
            return ret;

        }
        public void PreRefreshDrives()
        {
            if (FDriveGraphs.Count > 0)
            {
                foreach (clsDriveGraph grp in FDriveGraphs)
                    grp.Refreshed = false;
            }    
        }

        public void PostRefreshDrives()
        {
            if (FDriveGraphs.Count > 0)
            {
                foreach (clsDriveGraph grp in FDriveGraphs)
                {
                    if (!grp.Refreshed)
                    {
                        grp.DBStorage.Hide();
                    }
                }
            }
        }
        private void ucDataStorageMaster_Resize(object sender, EventArgs e)
        {
            ucDatabaseStorageMain.SpaceGraphs();
        }
    }

    public class clsDriveGraph : IDisposable
    {
        private bool disposed = false;
        private ucDatabaseStorage FDBStorage;
        private string FDrive;
        private bool FRefreshed;
        private bool FAddedToControl = false;
        public clsDriveGraph()
        {
            DBStorage = new ucDatabaseStorage();
        }

        public ucDatabaseStorage DBStorage { get => FDBStorage; set => FDBStorage = value; }
        public string Drive { get => FDrive; set => FDrive = value; }
        public bool Refreshed { get => FRefreshed; set => FRefreshed = value; }
        public bool AddedToControl { get => FAddedToControl; set => FAddedToControl = value; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {

                if (disposing)
                {
                    if (FDBStorage != null)
                        FDBStorage.Dispose();
                }
                disposed = true;
            }
        }

    }
}
