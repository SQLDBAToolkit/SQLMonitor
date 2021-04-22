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
    public partial class ucDatabaseStorageDBGraph : UserControl
    {
        private string FDatabaseName;
        private int FTotalSize;
        private int FUsedSize;
        private int FDatabaseID;
        private string FScanningMsg;
        private string FSourceType;
        private bool FAddedToMaster = false;
        private ucDatabaseStorage FParentGraph;
        public ucDatabaseStorageDBGraph()
        {
            InitializeComponent();
        }

        public string DatabaseName { get => FDatabaseName; set => FDatabaseName = value; }
        public int TotalSize { get => FTotalSize; set => FTotalSize = value; }
        public int UsedSize { get => FUsedSize; set => FUsedSize = value; }
        public int DatabaseID { get => FDatabaseID; set => FDatabaseID = value; }
        public string PopupText
        {
            get
            {
                string ret = SourceType + "\r\n" + DatabaseName + " (" + DatabaseID.ToString() + ")\r\n" 
                    + "   Total Size: " + TotalSize.ToString("#,##0Mb") + "\r\n"
                    + "   Used: " + (FScanningMsg.Length > 0 ? FScanningMsg : UsedSize.ToString("#,##0Mb")) + "\r\n" 
                    + "   Free: " + (FScanningMsg.Length > 0 ? FScanningMsg : (TotalSize - UsedSize).ToString("#,##0Mb")) + "\r\n";
                return ret;
            }
        }

        public void ShowGraph()
        {
            if (FScanningMsg.Length > 0)
            {
                FUsedSize = FTotalSize;
            }


        }
        public void DrawUsed()
        {
            panelUsedSpace.Width = (int)((float)this.Width * ((float)UsedSize / TotalSize));
        }
        public string ScanningMsg { get => FScanningMsg; set => FScanningMsg = value; }
        public bool AddedToMaster { get => FAddedToMaster; set => FAddedToMaster = value; }
        public ucDatabaseStorage ParentGraph { get => FParentGraph; set => FParentGraph = value; }
        public string SourceType { get => FSourceType; set => FSourceType = value; }

        private void ucDatabaseStorageDBGraph_MouseEnter(object sender, EventArgs e)
        {
            ParentGraph.ShowPopup(this.PopupText);
        }
    }
}
