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
    public partial class ucDatabaseStorage : UserControl
    {
        private string FHeaderTitle = "Header Text";
        private int FTotalSizeData = 0;
        private int FTotalSizeLog = 0;
        private int FTotalSizeFileStream = 0;
        private int FLeftData = 0;
        private int FLeftLogs = 0;
        private int FLeftFileStream = 0;
        private List<clsDBGraphs> FDBGraphs;
        public ucDatabaseStorage()
        {
            InitializeComponent();
            FDBGraphs = new List<clsDBGraphs>();
            if (dataTableSizes.Rows.Count == 0)
                dataTableSizes.Rows.Add();
        }

        public string HeaderTitle { get => FHeaderTitle; set => FHeaderTitle = value; }
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

        private void DrawHeaderBackground(PaintEventArgs e)
        {
            // Is there something to draw
            if (e.ClipRectangle.Width + e.ClipRectangle.Height > 0)
            {
                // We should draw the whole graph and clip what we want
                using (Bitmap bmGraph = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
                {
                    Graphics grGraph = Graphics.FromImage(bmGraph);

                    #region Draw the graph background
                    using (LinearGradientBrush lgBrush = new LinearGradientBrush(e.ClipRectangle, Color.LightCyan, Color.LightSkyBlue, LinearGradientMode.Vertical))
                    {
                        grGraph.FillRectangle(lgBrush, this.ClientRectangle);
                    }
                    using (SolidBrush myBrush = new SolidBrush(Color.Black))
                    using (SolidBrush myBrushShadow = new SolidBrush(Color.White))
                    {
                        grGraph.DrawString(FHeaderTitle, labelHeaderText.Font, myBrushShadow, ClientRectangle.X + 4, ClientRectangle.Y + 4);
                        grGraph.DrawString(FHeaderTitle, labelHeaderText.Font, myBrush, ClientRectangle.X + 3, ClientRectangle.Y + 3);
                    }

                    #endregion

                    e.Graphics.DrawImage(bmGraph, e.ClipRectangle.X, e.ClipRectangle.Y);
                }
            }
        }
        public void PreRefresh()
        {
            foreach (clsDBGraphs grph in FDBGraphs)
            {
                grph.Refreshed = false;
            }
            FLeftData = 0;
            FLeftLogs = 0;
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
        }
        public void AddDatabase(int databaseID, string databaseName, int totalSizeData, int usedSizeData, int totalSizeLogs, int usedSizeLogs, int totalSizeFileStream, int usedSizeFileStream, string scanningMsg)
        {

            try
            {
                clsDBGraphs dbGraphs = GetDBGraph(databaseID, databaseName);

                SetUpGraph(panelDataGraph, dbGraphs.DataGraph, "Data", databaseID, databaseName, totalSizeData, usedSizeData, scanningMsg);
                SetUpGraph(panelLogGraph, dbGraphs.LogGraph, "Logs", databaseID, databaseName, totalSizeLogs, usedSizeLogs, scanningMsg);
                SetUpGraph(panelFileStreamGraph, dbGraphs.FileStreamGraph, "FileStream", databaseID, databaseName, totalSizeFileStream, usedSizeFileStream, scanningMsg);
                FLeftData += dbGraphs.DataGraph.Width;
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
        private int GetMaxSize()
        {
            int ret = TotalSizeData;
            if (ret < TotalSizeLog)
                ret = TotalSizeLog;
            if (ret < TotalSizeFileStream)
                ret = TotalSizeFileStream;
            return ret;

        }
        public void SpaceGraphs()
        {
            int leftData = 0;
            int leftLog = 0;
            int leftFileStream = 0;
            int maxSize = GetMaxSize();
            foreach (clsDBGraphs grph in FDBGraphs)
            {
                grph.DataGraph.Left = leftData;
                grph.DataGraph.Width = (int)Math.Round(((float)(panelDataGraph.Width - 1) * ((float)grph.DataGraph.TotalSize / maxSize)),0);
                leftData += grph.DataGraph.Width;
                grph.DataGraph.DrawUsed();

                grph.LogGraph.Left = leftLog;
                grph.LogGraph.Width = (int)Math.Round(((float)(panelLogGraph.Width - 1) * ((float)grph.LogGraph.TotalSize / maxSize)),0);
                leftLog += grph.LogGraph.Width;
                grph.LogGraph.DrawUsed();

                grph.FileStreamGraph.Left = leftFileStream;
                grph.FileStreamGraph.Width = (int)Math.Round(((float)(panelFileStreamGraph.Width - 1) * ((float)grph.FileStreamGraph.TotalSize / maxSize)),0);
                leftFileStream += grph.FileStreamGraph.Width;
                grph.FileStreamGraph.DrawUsed();
            }

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
            DrawHeaderBackground(e);
        }

        public void ShowPopup(string text)
        {
            labelPopup.Text = text;
            //labelPopup.Left 

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
        private IntPtr handle;
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
