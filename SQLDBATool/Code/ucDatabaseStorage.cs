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
using System.Runtime.InteropServices;

namespace SQLDBATool.Code
{
    public partial class ucDatabaseStorage : UserControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        private int FTotalSizeData = 0;
        private int FTotalSizeLog = 0;
        private int FTotalSizeFileStream = 0;
        private int FDisplaySize = 0;
        private bool FRefreshingData = false;
        private List<clsDBGraphs> FDBGraphs;
        private ucDatabaseStorageDBGraph FPopupGraph;
        public ucDatabaseStorage()
        {
            InitializeComponent();
            FPopupGraph = null;
            FDBGraphs = new List<clsDBGraphs>();
            if (dataTableSizes.Rows.Count == 0)
                dataTableSizes.Rows.Add();
        }
        public string HeaderTitle
        {
            get => ucTitleBarText.TitleText;
            set => ucTitleBarText.TitleText = value;
        }
        public int TotalSizeData
        {
            get => FTotalSizeData;
            set
            {
                FTotalSizeData = value;
                dataTableSizes.Rows[0]["data_size_mb"] = value;
            }
        }
        public int TotalSizeLog
        {
            get => FTotalSizeLog;
            set
            {
                FTotalSizeLog = value;
                dataTableSizes.Rows[0]["log_size_mb"] = value;
            }
        }
        public int TotalSizeFileStream
        {
            get => FTotalSizeFileStream;
            set
            {
                FTotalSizeFileStream = value;
                dataTableSizes.Rows[0]["filestream_size_mb"] = value;
            }
        }

        public int DisplaySize { get => FDisplaySize; set => FDisplaySize = value; }


        public void PreRefresh()
        {
            DrawingControl.SuspendDrawing(this);
            FRefreshingData = true;
            foreach (clsDBGraphs grph in FDBGraphs)
            {
                grph.Refreshed = false;
            }
        }
        public void PostRefresh()
        {
            try
            {
                int i = FDBGraphs.Count;
                if (i > 0)
                {
                    while (i > 0)
                    {
                        if (!FDBGraphs[i-1].Refreshed)
                        {
                            clsDBGraphs grph = FDBGraphs[i - 1];
                            panelDataGraph.Controls.Remove(grph.DataGraph);
                            panelLogGraph.Controls.Remove(grph.LogGraph);
                            panelFileStreamGraph.Controls.Remove(grph.FileStreamGraph);
                            FDBGraphs.Remove(grph);
                            grph.Dispose();
                        }
                        i--;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DrawingControl.ResumeDrawing(this);
            FRefreshingData = false;
        }
        public void AddDatabase(int databaseID, string databaseName, int totalSizeData, int usedSizeData, int totalSizeLogs, int usedSizeLogs, int totalSizeFileStream, int usedSizeFileStream, string scanningMsg)
        {

            try
            {
                clsDBGraphs dbGraphs = GetDBGraph(databaseID, databaseName);

                SetUpGraph(panelDataGraph, dbGraphs.DataGraph, "Data", databaseID, databaseName, totalSizeData, usedSizeData, scanningMsg);
                SetUpGraph(panelLogGraph, dbGraphs.LogGraph, "Logs", databaseID, databaseName, totalSizeLogs, usedSizeLogs, scanningMsg);
                SetUpGraph(panelFileStreamGraph, dbGraphs.FileStreamGraph, "FileStream", databaseID, databaseName, totalSizeFileStream, usedSizeFileStream, scanningMsg);
                dbGraphs.Refreshed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //panelDataGraph.Refresh();

        }

        private void SetUpGraph(Panel targetPanel, ucDatabaseStorageDBGraph graph, string sourceType, int databaseID, string databaseName, int totalSizeData, int usedSizeData, string scanningMsg)
        {
            graph.TotalSize = totalSizeData;
            graph.UsedSize = usedSizeData;
            graph.ScanningMsg = scanningMsg;
            graph.DatabaseName = databaseName;
            graph.DatabaseID = databaseID;
            graph.SourceType = sourceType;
            graph.Top = 0;
            if (!graph.AddedToMaster)
            {
                targetPanel.Controls.Add(graph);
                graph.AddedToMaster = true;
                graph.ParentGraph = this;
                graph.Show();
            }


        }
        public  int GetMaxSize()
        {
            int ret = TotalSizeData;
            if (ret < TotalSizeLog)
                ret = TotalSizeLog;
            if (ret < TotalSizeFileStream)
                ret = TotalSizeFileStream;
            if (ret < FDisplaySize)
                ret = FDisplaySize;
            return ret;

        }
        public void SpaceGraphs()
        {
            string popupText = "";
            if (!FRefreshingData)
                DrawingControl.SuspendDrawing(this);
            if (FDBGraphs.Count > 0)
            {
                int leftData = 0;
                int leftLog = 0;
                int leftFileStream = 0;
                int maxSize = GetMaxSize();
                int leftDataCheck = 0;
                int leftLogCheck = 0;
                int leftFileStreamCheck = 0;
                foreach (clsDBGraphs grph in FDBGraphs)
                {
                    int newLeft;
                    int newWidth;
                    newLeft = (int)Math.Round(((float)(panelDataGraph.ClientRectangle.Width) * ((float)leftData / maxSize)), 0);
                    newWidth = (int)Math.Round(((float)(panelDataGraph.ClientRectangle.Width) * ((float)grph.DataGraph.TotalSize / maxSize)), 0);
                    if (newLeft > leftDataCheck)
                    {
                        newLeft = leftDataCheck;
                        newWidth++;
                    }
                    grph.DataGraph.Left = newLeft;
                    grph.DataGraph.Width = newWidth;
                    grph.DataGraph.Height = panelDataGraph.ClientRectangle.Height;
                    leftData += grph.DataGraph.TotalSize;
                    leftDataCheck = newLeft + newWidth;
                    grph.DataGraph.DrawUsed();

                    newLeft = (int)Math.Round(((float)(panelLogGraph.ClientRectangle.Width) * ((float)leftLog / maxSize)), 0);
                    newWidth = (int)Math.Round(((float)(panelLogGraph.ClientRectangle.Width) * ((float)grph.LogGraph.TotalSize / maxSize)), 0);
                    if (newLeft > leftLogCheck)
                    {
                        newLeft = leftLogCheck;
                        newWidth++;
                    }
                    grph.LogGraph.Left = newLeft;
                    grph.LogGraph.Width = newWidth;
                    grph.LogGraph.Height = panelLogGraph.ClientRectangle.Height;
                    leftLog += grph.LogGraph.TotalSize;
                    leftLogCheck = newLeft + newWidth;
                    grph.LogGraph.DrawUsed();

                    newLeft = (int)Math.Round(((float)(panelFileStreamGraph.ClientRectangle.Width) * ((float)leftFileStream / maxSize)), 0);
                    newWidth = (int)Math.Round(((float)(panelFileStreamGraph.ClientRectangle.Width) * ((float)grph.FileStreamGraph.TotalSize / maxSize)), 0);
                    if (newLeft > leftFileStreamCheck)
                    {
                        newLeft = leftFileStreamCheck;
                        newWidth++;
                    }
                    grph.FileStreamGraph.Left = newLeft;
                    grph.FileStreamGraph.Width = newWidth;
                    grph.FileStreamGraph.Height = panelFileStreamGraph.ClientRectangle.Height;
                    leftLog += grph.FileStreamGraph.TotalSize;
                    leftFileStreamCheck = newLeft + newWidth;
                    grph.FileStreamGraph.DrawUsed();

                    if (FPopupGraph != null)
                        if (FPopupGraph == grph.DataGraph || FPopupGraph == grph.LogGraph || FPopupGraph == grph.FileStreamGraph)
                            popupText = FPopupGraph.PopupText;
                }
            }
            if (popupText.Length == 0)
                FPopupGraph = null;
            else
                labelPopup.Text = popupText;
            if (!FRefreshingData)
                DrawingControl.ResumeDrawing(this);
        }
        private clsDBGraphs GetDBGraph(int databaseID, string databaseName)
        {
            clsDBGraphs ret = new clsDBGraphs();
            bool found = false;

            foreach (clsDBGraphs grph in FDBGraphs)
            {
                if (grph.DatabaseID == databaseID && grph.DatabaseName == databaseName)
                {
                    ret = grph;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                ret.DatabaseID = databaseID;
                ret.DatabaseName = databaseName;
 
                FDBGraphs.Add(ret);
            }

            return ret;
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void ShowPopup(ucDatabaseStorageDBGraph graph)
        {
            string text = graph.PopupText;
            labelPopup.Text = text;
            FPopupGraph = graph;

        }
        public void HidePopup()
        {
            labelPopup.Hide();
        }
        private void ucDataLabel3_Resize(object sender, EventArgs e)
        {

        }
    }
    public class clsDBGraphs : IDisposable
    {
        private bool disposed = false;

        private string FDatabaseName;
        private int FDatabaseID;
        private bool FRefreshed;
        private ucDatabaseStorageDBGraph FDataGraph;
        private ucDatabaseStorageDBGraph FLogGraph;
        private ucDatabaseStorageDBGraph FFileStreamGraph;

        public string DatabaseName { get => FDatabaseName; set => FDatabaseName = value; }
        public int DatabaseID { get => FDatabaseID; set => FDatabaseID = value; }
        public bool Refreshed { get => FRefreshed; set => FRefreshed = value; }
        public ucDatabaseStorageDBGraph DataGraph { get => FDataGraph; set => FDataGraph = value; }
        public ucDatabaseStorageDBGraph LogGraph { get => FLogGraph; set => FLogGraph = value; }
        public ucDatabaseStorageDBGraph FileStreamGraph { get => FFileStreamGraph; set => FFileStreamGraph = value; }
        public clsDBGraphs()
        {
            FDataGraph = new ucDatabaseStorageDBGraph();
            FLogGraph = new ucDatabaseStorageDBGraph();
            FFileStreamGraph = new ucDatabaseStorageDBGraph();
        }

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
                    if (FDataGraph != null)
                        FDataGraph.Dispose();
                    if (FLogGraph != null)
                        FLogGraph.Dispose();
                    if (FileStreamGraph != null)
                        FileStreamGraph.Dispose();
                }
                disposed = true;
            }
        }
    }
}
