using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class ucServerMonitor : UserControl
    {
        private Guid FServerID;
        private Guid FSessionServerID;
        public Guid ServerID { get => FServerID; set => FServerID = value; }
        public Guid SessionServerID { get => FSessionServerID; set => FSessionServerID = value; }
        public CLSTreeInformation TreeInformation { get => FTreeInformation; set => FTreeInformation = value; }

        private DataTable FDTSessionsTable;
        private int FFirstDisplayedRowIndex = 0;
        private Code.CLSTreeInformation FTreeInformation;
        private bool FUpdatingData = false;
        public bool ErrorOn = false;
        public ucServerMonitor()
        {
            InitializeComponent();
            ucDatabaseInformation1.ParentMonitor = this;
            
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            FServerID = Guid.NewGuid();
            SessionServerID = Guid.NewGuid();
            DoubleBuffered = true;
            dataGridView1.AutoGenerateColumns = false;
            FDTSessionsTable = new DataTable();


        }
        public void ChangeSessionDataTable(Code.CLSTreeInformation treeInformation)
        {
            #region Session Tab
            if (treeInformation.ConnectionInformation.MonitoredServer.ServerID != SessionServerID || dataGridView1.Rows.Count == 0)
            {
                FUpdatingData = true;
                FTreeInformation = treeInformation;
                SessionServerID = treeInformation.ConnectionInformation.MonitoredServer.ServerID;
                dataGridView1.AutoGenerateColumns = false;
                //dataGridView1.DataSource = treeInformation.ConnectionInformation.ServerStats.DTSessions;
                FDTSessionsTable = treeInformation.ConnectionInformation.ServerStats.DTSessions.Clone();
                FDTSessionsTable.Rows.Clear();
                dataGridView1.DataSource = FDTSessionsTable;
                MergeSessionDataTable(treeInformation);
                FUpdatingData = false;
            }
            #endregion
        }
        public void MergeSessionDataTable(Code.CLSTreeInformation treeInformation)
        {
            FUpdatingData = true;
            dataGridView1.SuspendLayout();
            FDTSessionsTable.Merge(treeInformation.ConnectionInformation.ServerStats.DTSessions, false, MissingSchemaAction.Add);
            dataGridView1.ResumeLayout();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int session_id = (Int16)dataGridView1.SelectedRows[0].Cells["session_id"].Value;
                ucCurrentSessionDetails.RefreshSessionInformation(session_id, FTreeInformation);
            }
            FUpdatingData = false;

        }
        public void ChangeDatabaseServerName(string serverName)
        {
            ucTitleBar1.TitleText = serverName;
        }
        // Change backgroup color
        public void ChangeRowBackgroundColors()
        {
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    Color bg = Color.White;
            //    //Color fg = Color.Black;
            //    if ((Int32)FDTSessionsTable.Rows[row.Index]["IsConnected"] == 0)
            //        bg = Color.Silver;
            //    else if (((String)FDTSessionsTable.Rows[row.Index]["status"]).ToUpper().StartsWith("LOCKED"))
            //    {
            //        bg = Color.Salmon;
            //        //fg = Color.White;
            //    }
            //    else if (!((String)FDTSessionsTable.Rows[row.Index]["status"]).ToUpper().StartsWith("SLEEPING"))
            //    {
            //        bg = Color.LightGreen;
            //        //fg = Color.Black;
            //    }
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        cell.Style.BackColor = bg;
            //        //cell.Style.ForeColor = fg;
            //    }

            //}
        }
        public void ShowServerDetails(Code.CLSTreeInformation treeInformation)
        {
            try
            {
                if (treeInformation.ConnectionInformation.MonitoredServer.ServerID == ServerID)
                {
                    int maxNetwork = 10;
                    int maxIO = 10;
                    Int64 maxMemory = 10;
                    Decimal maxRequests = 9;
                    int maxSessions = 10;

                    ucTitleBar1.TitleText = (string)(treeInformation.ConnectionInformation.ServerStats.DTServerInformation.Rows[0]["ServerName"]);
                    foreach (DataRow row in treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows)
                    {
                        if ((Int32)row["NetworkPacketsRecievedDelta"] > maxNetwork)
                            maxNetwork = (Int32)row["NetworkPacketsRecievedDelta"];
                        if ((Int32)row["NetworkPacketsSentDelta"] > maxNetwork)
                            maxNetwork = (Int32)row["NetworkPacketsSentDelta"];
                        if ((Int32)row["PhysicalIOTotalReadsDelta"] > maxIO)
                            maxIO = (Int32)row["PhysicalIOTotalReadsDelta"];
                        if ((Int32)row["PhysicalIOTotalWritesDelta"] > maxIO)
                            maxIO = (Int32)row["PhysicalIOTotalWritesDelta"];
                        if ((Int64)row["total_memory_used_kb"] > maxMemory)
                            maxMemory = (Int64)row["total_memory_used_kb"];
                        if ((Decimal)row["batch_requests_sec_delta"] > maxRequests)
                            maxRequests = (Decimal)row["batch_requests_sec_delta"];
                        if ((Decimal)row["sql_compilations_sec_delta"] > maxRequests)
                            maxRequests = (Decimal)row["sql_compilations_sec_delta"];
                        if ((Decimal)row["sql_recompilations_sec_delta"] > maxRequests)
                            maxRequests = (Decimal)row["sql_recompilations_sec_delta"];
                        //if ((Decimal)row["checkpoint_pages_sec_delta"] > maxRequests)
                        //    maxRequests = (Decimal)row["checkpoint_pages_sec_delta"];
                        if ((Decimal)row["lock_waits_sec_delta"] > maxRequests)
                            maxRequests = (Decimal)row["lock_waits_sec_delta"];
                        if ((Int32)row["TotalSessions"] > maxSessions)
                            maxSessions = (Int32)row["TotalSessions"];

                    }
                    #region Server Information Table
                    dataTableServerInformation.Rows.Clear();
                    dataTableServerInformation.Rows.Add(treeInformation.ConnectionInformation.ServerStats.DTServerInformation.Rows[0].ItemArray);
                    #endregion
                    #region CPU Usage Graph
                    ucChartCPUUsage.GraphTable = treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics;
                    ucChartCPUUsage.Series[0].SeriesLedgendSource = "CPU Usage: " + ((Decimal)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["CpuPercentage"]).ToString("##0.0") + "%";
                    ucChartCPUUsage.Refresh();
                    #endregion
                    #region Buffer Cache Hit Ratio
                    ucChartBufferCacheHitRatio.GraphTable = treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics;
                    ucChartBufferCacheHitRatio.Series[0].SeriesLedgendSource = "BHR: " + ((Decimal)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["BufferCacheHitRatio"]).ToString("##0.0") + "%";
                    ucChartBufferCacheHitRatio.Refresh();
                    #endregion
                    #region Response Time
                    ucChartResponseTime.GraphTable = treeInformation.ConnectionInformation.ServerStats.DTResponseTime;
                    ucChartResponseTime.Series[0].SeriesLedgendSource = "Time (ms): " + ((long)treeInformation.ConnectionInformation.ServerStats.DTResponseTime.Rows[treeInformation.ConnectionInformation.ServerStats.DTResponseTime.Rows.Count - 1]["ResponseTimeMS"]).ToString("#,##0");
                    ucChartResponseTime.Refresh();
                    #endregion
                    #region Network Traffic
                    ucChartNetworkTraffic.GraphTable = treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics;
                    ucChartNetworkTraffic.MaxValue = maxNetwork;
                    ucChartNetworkTraffic.Series[0].SeriesLedgendSource = "Received: " + ((Int32)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["NetworkPacketsRecievedDelta"]).ToString("#,##0");
                    ucChartNetworkTraffic.Series[1].SeriesLedgendSource = "Sent: " + ((Int32)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["NetworkPacketsSentDelta"]).ToString("#,##0");
                    ucChartNetworkTraffic.Refresh();
                    #endregion
                    #region Physical IO
                    ucChartPhysicalIO.GraphTable = treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics;
                    ucChartPhysicalIO.MaxValue = maxIO;
                    ucChartPhysicalIO.Series[0].SeriesLedgendSource = "Read: " + ((Int32)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["PhysicalIOTotalReadsDelta"]).ToString("#,##0");
                    ucChartPhysicalIO.Series[1].SeriesLedgendSource = "Written: " + ((Int32)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["PhysicalIOTotalWritesDelta"]).ToString("#,##0");
                    ucChartPhysicalIO.Refresh();
                    #endregion
                    #region Memory Usage

                    ucChartMemoryUsage.GraphTable = treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics;
                    ucChartMemoryUsage.MaxValue = maxMemory;
                    ucSeriesDatabaseCacheMemory.SeriesLedgendSource = "Data Cache: " + FormatKbToString((Int64)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["database_cache_memory_kb"]);
                    ucSeriesReservedServerMemory.SeriesLedgendSource = "Reserved: " + FormatKbToString((Int64)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["reserved_server_memory_kb"]);
                    ucSeriesFreeMemory.SeriesLedgendSource = "Free: " + FormatKbToString((Int64)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["free_memory_kb"]);
                    ucSeriesStolenMemory.SeriesLedgendSource = "Stolen: " + FormatKbToString((Int64)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["stolen_server_memory_kb"]);
                    ucChartMemoryUsage.Refresh();
                    #endregion
                    #region Requests and Compilations

                    ucChartRequests.GraphTable = treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics;
                    ucChartRequests.MaxValue = (Int64)maxRequests + 1;
                    ucSeriesBatchRequestsSec.SeriesLedgendSource = "Batch Req: " + ((Decimal)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["batch_requests_sec_delta"]).ToString("#,##0");
                    ucSeriesSqlCompliationsSec.SeriesLedgendSource = "Sql Compl: " + ((Decimal)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["sql_compilations_sec_delta"]).ToString("#,##0");
                    ucSeriesSqlRecompilationsSec.SeriesLedgendSource = "Sql Recompl: " + ((Decimal)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["sql_recompilations_sec_delta"]).ToString("#,##0");
                    ucSeriesCheckpointPagesSec.SeriesLedgendSource = "Checkpoint: " + ((Decimal)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["checkpoint_pages_sec_delta"]).ToString("#,##0");
                    ucSeriesLockWaitsSec.SeriesLedgendSource = "Lock Waits: " + ((Decimal)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["lock_waits_sec_delta"]).ToString("#,##0");
                    ucChartRequests.Refresh();
                    #endregion
                    #region Users and Sessions
                    ucChartUsersSessions.GraphTable = treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics;
                    ucChartUsersSessions.MaxValue = maxSessions;
                    ucSeriesTotalUsers.SeriesLedgendSource = "Users: " + ((Int32)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["TotalUsers"]).ToString("#,##0");
                    ucSeriesTotalSessions.SeriesLedgendSource = "Sessions: " + ((Int32)treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows[treeInformation.ConnectionInformation.ServerStats.DTPerformanceStatistics.Rows.Count - 1]["TotalSessions"]).ToString("#,##0");
                    ChangeRowBackgroundColors();
                    ucChartUsersSessions.Refresh();

                    #endregion
                    //                    int index = dataGridView1.FirstDisplayedScrollingRowIndex;
                    ////                    if (dataGridView1.Rows.Count == 0)

                    if (dataGridView1.Rows.Count == 0)
                        ChangeSessionDataTable(treeInformation);
                    else
                        MergeSessionDataTable(treeInformation);
                    if (dataGridView1.Rows.Count > 0)
                        dataGridView1.FirstDisplayedScrollingRowIndex = FFirstDisplayedRowIndex;
                    //#endregion
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
        public void ShowDatabaseDetails(Code.CLSTreeInformation treeInformation)
        {
            try
            {
                if (treeInformation.ConnectionInformation.MonitoredServer.ServerID == ServerID)
                {
                    ucDatabaseInformation1.ShowDatabaseDetails(treeInformation);

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
        private string FormatKbToString(Int64 kb)
        {
            int index = 0;
            string text = "Kb";
            string[] suffixs = { "Mb", "Gb", "Tb", "Pb" };

            while (kb > 1024)
            {
                kb = kb / 1024;
                text = suffixs[index];
                index++;
            }
            text = kb.ToString() + text;

            return text;
        }

        private void label3_Click(object sender6, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            ResizeChart(ucChartCPUUsage, 0, 0);
            ResizeChart(ucChartBufferCacheHitRatio, 0, 1);
            ResizeChart(ucChartResponseTime, 0, 2);
            ResizeChart(ucChartRequests, 0, 3);
            ResizeChart(ucChartPhysicalIO, 1, 0);
            ResizeChart(ucChartNetworkTraffic, 1, 1);
            ResizeChart(ucChartMemoryUsage, 1, 2);
            ResizeChart(ucChartUsersSessions, 1, 3);


        }
        private void ResizeChart(ucChart chart, int row, int col)
        {
            int width = splitContainer1.Panel2.ClientRectangle.Width / 2;
            int height = splitContainer1.Panel2.ClientRectangle.Height / 4;

            chart.Width = width - 2;
            chart.Height = height - 2;
            chart.Left = width * row;
            chart.Top = height * col;

        }

        private void ucChartNetworkTraffic_Load(object sender, EventArgs e)
        {

        }

        private void ucChartPhysicalIO_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
 
        private void panelSystemInformation_Paint(object sender, PaintEventArgs e)
        {
            Panel s = (Panel)sender;
            if (e.ClipRectangle.Width + e.ClipRectangle.Height > 0)
            {
                // We should draw the whole graph and clip what we want
                using (Bitmap bmGraph = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
                {
                    Graphics grGraph = Graphics.FromImage(bmGraph);

                    #region Draw the graph background
                    using (LinearGradientBrush lgBrush = new LinearGradientBrush(e.ClipRectangle, Color.Black, Color.DarkGray, LinearGradientMode.Vertical))
                    {
                        grGraph.FillRectangle(lgBrush, this.ClientRectangle);
                    }
                    if (dataTableServerInformation.Rows.Count > 0)
                    {
                        using (SolidBrush myBrushShadow = new SolidBrush(Color.Black))
                        using (SolidBrush myBrush = new SolidBrush(Color.White))
                        {
                            grGraph.DrawString((string)((Panel)sender).Tag, labelMemoryInformationHeader.Font, myBrushShadow, ClientRectangle.X + 4, ClientRectangle.Y + 2);
                            grGraph.DrawString((string)((Panel)sender).Tag, labelMemoryInformationHeader.Font, myBrush, ClientRectangle.X + 3, ClientRectangle.Y + 2);
                            //grGraph.DrawString((string)dataTableServerInformation.Rows[0]["ServerName"], labelServerHeaderName.Font, myBrushShadow, ClientRectangle.X + 4, ClientRectangle.Y + 4);
                            //grGraph.DrawString((string)dataTableServerInformation.Rows[0]["ServerName"], labelServerHeaderName.Font, myBrush, ClientRectangle.X + 3, ClientRectangle.Y + 3);
                        }
                    }
                    #endregion

                    e.Graphics.DrawImage(bmGraph, e.ClipRectangle.X, e.ClipRectangle.Y);
                }
            }

        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Do not automatically paint the focus rectangle.
            //e.PaintParts &= ~DataGridViewPaintParts.Focus;

            //// Determine whether the cell should be painted
            //// with the custom selection background.
            ////Color fg = Color.Black;
            //Color bg = Color.White;

            //if (dataGridView1.Rows[e.RowIndex].Cells["IsConnected"].Value.ToString() == "0")
            //    bg = Color.Silver;
            //else if (dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString().ToUpper().StartsWith("LOCKED"))
            //{
            //    bg = Color.Salmon;
            //    //fg = Color.White;
            //}
            //else if (!dataGridView1.Rows[e.RowIndex].Cells["status"].Value.ToString().ToUpper().StartsWith("SLEEPING"))
            //{
            //    bg = Color.LightGreen;
            //    //fg = Color.Black;
            //}
            //if (dataGridView1.Rows[e.RowIndex].Cells[0].Style.BackColor != bg)
            //{
            //    foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
            //    {
            //        cell.Style.BackColor = bg;
            //        //cell.Style.ForeColor = fg;
            //    }
            //}

        }

        private void tabControlServerMonitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlServerMonitor.SelectedIndex == 1)
                ChangeRowBackgroundColors();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void dataGridView1_RowMinimumHeightChanged(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            ChangeRowBackgroundColors();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.CellStyle.ForeColor = Color.Black;
                if ((int)(dataGridView1.Rows[e.RowIndex].Cells["IsConnected"].Value) == 0)
                    e.CellStyle.BackColor = Color.Silver;
                else if ((String)(dataGridView1.Rows[e.RowIndex].Cells["SessionBackColor"].Value) == "BLOCKED")
                    e.CellStyle.BackColor = Color.Salmon;
                else if ((String)(dataGridView1.Rows[e.RowIndex].Cells["SessionBackColor"].Value) == "PROCESSING")
                    e.CellStyle.BackColor = Color.LightGreen;
                else if ((String)(dataGridView1.Rows[e.RowIndex].Cells["SessionBackColor"].Value) == "FINISHED")
                    e.CellStyle.BackColor = Color.LightYellow;
                else
                    e.CellStyle.BackColor = Color.White;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!FUpdatingData)
            {
                int session_id = (Int16)dataGridView1.Rows[e.RowIndex].Cells["session_id"].Value;
                ucCurrentSessionDetails.RefreshSessionInformation(session_id, FTreeInformation);
            }
        }
    }
}
