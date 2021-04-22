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
        public ucDataStorageMaster()
        {
            InitializeComponent();
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

        private void ucDataStorageMaster_Resize(object sender, EventArgs e)
        {
            ucDatabaseStorageMain.SpaceGraphs();
        }
    }
}
