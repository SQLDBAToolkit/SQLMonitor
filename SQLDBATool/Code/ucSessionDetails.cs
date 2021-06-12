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
    public partial class ucSessionDetails : UserControl
    {
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWind, uint wMsg, UIntPtr wParam, IntPtr LParam);
        private Code.CLSTreeInformation FTreeInformation;
        private string FSqlCode = "";
        public ucSessionDetails()
        {
            InitializeComponent();
            this.DoubleBuffered = true;


        }

        public void ResetSessionInformation()
        {
            dataTableSessionInformation.Clear();
            dataTableSessionRequests.Clear();
            dataTableSessionConnections.Clear();
            dataTableSessionCommands.Clear();
            dataTableSessionStats.Clear();

        }
        public void RefreshSessionInformation(int session_id, Code.CLSTreeInformation treeInformation)
        {
            FTreeInformation = treeInformation;
            string sessionSearchString = "session_id = " + session_id.ToString();
            labelTitle.Text = "Session: " + session_id.ToString();
            dataTableSessionInformation.Clear();
            foreach (DataRow r in treeInformation.ConnectionInformation.ServerStats.DTSessions.Select(sessionSearchString))
            {
                dataTableSessionInformation.Rows.Add(r.ItemArray);
            }
            dataTableSessionRequests.Clear();
            foreach (DataRow r in treeInformation.ConnectionInformation.ServerStats.DTSessionRequests.Select(sessionSearchString))
            {
                dataTableSessionRequests.Rows.Add(r.ItemArray);
            }
            dataTableSessionConnections.Clear();
            foreach (DataRow r in treeInformation.ConnectionInformation.ServerStats.DTSessionConnections.Select(sessionSearchString))
            {
                dataTableSessionConnections.Rows.Add(r.ItemArray);
            }
            dataTableSessionCommands.Clear();
            foreach (DataRow r in treeInformation.ConnectionInformation.ServerStats.DTSessionCommands.Select(sessionSearchString))
            {
                dataTableSessionCommands.Rows.Add(r.ItemArray);
            }
            ShowCurrentSqlText();

            string waitState = "";
            if (dataTableSessionWaitStates.Rows.Count > 0)
            {
                if ((Int16)(dataTableSessionWaitStates.Rows[0]["session_id"]) != session_id)
                {
                    dataTableSessionWaitStates.Rows.Clear();
                }
                else
                {
                    waitState = dataTableSessionWaitStates.Rows[0]["wait_type"].ToString();
                }
            }
            DataTable dtTemp = new DataTable();
            dtTemp = treeInformation.ConnectionInformation.ServerStats.DTSessionWaitStates.Clone();
            dtTemp.PrimaryKey = new DataColumn[] { dtTemp.Columns["session_id"], dtTemp.Columns["wait_type"] };
            foreach (DataColumn col in dtTemp.Columns)
            {
                col.ReadOnly = false;
            }

            foreach (DataRow r in treeInformation.ConnectionInformation.ServerStats.DTSessionWaitStates.Select(sessionSearchString))
            {

                dtTemp.Rows.Add(r.ItemArray);
            }

            dataTableSessionWaitStates.Merge(dtTemp, false, MissingSchemaAction.Add);
            dataTableSessionStats.Clear();
            int rowCnt = treeInformation.ConnectionInformation.ServerStats.DTSessionStats.Select(sessionSearchString).Length - 300;
            foreach (DataRow r in treeInformation.ConnectionInformation.ServerStats.DTSessionStats.Select(sessionSearchString))
            {
                if (rowCnt > 0)
                    rowCnt--;
                else
                    dataTableSessionStats.Rows.Add(r.ItemArray);
            }
            panelTitle.Refresh();
            int maxCPU = 20;
            int maxIO = 20;
            int maxNet = 20;
            int maxMemory = 20;
            foreach (DataRow reqR in dataTableSessionStats.Rows)
            {
                if ((int)reqR["cpu_time_delta"] > maxCPU)
                    maxCPU = (int)reqR["cpu_time_delta"];
                if ((int)reqR["reads_delta"] > maxIO)
                    maxIO = (int)reqR["reads_delta"];
                if ((int)reqR["writes_delta"] > maxIO)
                    maxIO = (int)reqR["writes_delta"];
                if ((int)reqR["net_reads_delta"] > maxNet)
                    maxNet = (int)reqR["net_reads_delta"];
                if ((int)reqR["net_writes_delta"] > maxNet)
                    maxNet = (int)reqR["net_writes_delta"];
                if ((int)reqR["memory_usage"] > maxMemory)
                    maxMemory = (int)reqR["memory_usage"];

            }
            ucChartCPUUsage.MaxValue = maxCPU;
            ucChartCPUUsage.Refresh();
            ucChartSessionPhysicalIO.MaxValue = maxIO;
            ucChartSessionPhysicalIO.Refresh();
            ucChartSessionMemory.MaxValue = maxMemory;
            ucChartSessionMemory.Refresh();
            ucChartSessionNetwork.MaxValue = maxNet;
            ucChartSessionNetwork.Refresh();
        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
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
                    using (SolidBrush myBrushShadow = new SolidBrush(Color.Black))
                    using (SolidBrush myBrush = new SolidBrush(Color.White))
                    {
                        grGraph.DrawString(labelTitle.Text, labelTitle.Font, myBrushShadow, ClientRectangle.X + 4, ClientRectangle.Y + 2);
                        grGraph.DrawString(labelTitle.Text, labelTitle.Font, myBrush, ClientRectangle.X + 3, ClientRectangle.Y + 2);
                        //grGraph.DrawString((string)dataTableServerInformation.Rows[0]["ServerName"], labelServerHeaderName.Font, myBrushShadow, ClientRectangle.X + 4, ClientRectangle.Y + 4);
                        //grGraph.DrawString((string)dataTableServerInformation.Rows[0]["ServerName"], labelServerHeaderName.Font, myBrush, ClientRectangle.X + 3, ClientRectangle.Y + 3);
                    }

                    #endregion

                    e.Graphics.DrawImage(bmGraph, e.ClipRectangle.X, e.ClipRectangle.Y);
                }
            }

        }

        private void tabPagePerformance_Click(object sender, EventArgs e)
        {

        }

        private void tabPagePerformance_SizeChanged(object sender, EventArgs e)
        {

        }

        private void panelPerformanceGraphs_Resize(object sender, EventArgs e)
        {
            ucChartCPUUsage.Top = 0;
            ucChartCPUUsage.Left = 0;
            ucChartCPUUsage.Width = panelPerformanceGraphs.Width / 2;
            ucChartCPUUsage.Height = panelPerformanceGraphs.Height / 2;

            ucChartSessionPhysicalIO.Top = 0;
            ucChartSessionPhysicalIO.Left = ucChartCPUUsage.Width + 1;
            ucChartSessionPhysicalIO.Width = panelPerformanceGraphs.Width / 2;
            ucChartSessionPhysicalIO.Height = panelPerformanceGraphs.Height / 2;

            ucChartSessionMemory.Top = ucChartCPUUsage.Height + 1;
            ucChartSessionMemory.Left = 0;
            ucChartSessionMemory.Width = panelPerformanceGraphs.Width / 2;
            ucChartSessionMemory.Height = panelPerformanceGraphs.Height / 2;

            ucChartSessionNetwork.Top = ucChartCPUUsage.Height + 1;
            ucChartSessionNetwork.Left = ucChartCPUUsage.Width + 1;
            ucChartSessionNetwork.Width = panelPerformanceGraphs.Width / 2;
            ucChartSessionNetwork.Height = panelPerformanceGraphs.Height / 2;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            ShowCurrentSqlText();
        }
        public void ClearCurrentSqlText()
        {
            labelObjectTitle.Text = "<Idle>";
            richTextBoxSqlText.Text = "";
            labelObjectOffset.Text = "";
            FSqlCode = "";
        }
        private void ShowCurrentSqlText()
        {
            if (dataTableSessionCommands.Rows.Count == 0)
            {
                labelObjectTitle.Text = "<Idle>";
                richTextBoxSqlText.Text = "";
                labelObjectOffset.Text = "";
                FSqlCode = "";
            }
            else
            {
                if (dataTableSessionCommands.Rows[0]["statement_start_offset"] != null)
                {
                    int offset = (int)dataTableSessionCommands.Rows[0]["statement_start_offset"];
                    int len = (int)dataTableSessionCommands.Rows[0]["statement_length"];
                    string objTitle = dataTableSessionCommands.Rows[0]["object_title"].ToString();
                    if (labelObjectTitle.Text != objTitle)
                        labelObjectTitle.Text = objTitle;
                    if (offset >= 0)
                    {
                        labelObjectOffset.Text = "Statement Offset: " + offset.ToString() + " Length: " + len.ToString();
                        if (dataTableSessionCommands.Rows[0]["text"] != null)
                        {
                            string sqlText = dataTableSessionCommands.Rows[0]["text"].ToString();
                            if (checkBox1.Checked || sqlText == "<Encrpyted>")
                            {
                                if (FSqlCode != sqlText)
                                {
                                    richTextBoxSqlText.Text = sqlText;
                                    FSqlCode = sqlText;
                                }

                                if (sqlText != "<Encrypted>")
                                {
                                    int lfCount = Globals.CountStringOccurances(sqlText.Substring(0, offset - 1), "\r");
                                    int lfLenCount = Globals.CountStringOccurances(sqlText.Substring((offset - 1), len), "\r");
                                    if ((richTextBoxSqlText.SelectionStart != offset - 1 - lfCount) || richTextBoxSqlText.SelectionLength != len - lfLenCount)
                                    {
                                        Font fontBold = new Font(richTextBoxSqlText.Font.OriginalFontName, richTextBoxSqlText.Font.Size, FontStyle.Bold, GraphicsUnit.Point, 178, false);
                                        Font fontRegular = new Font(richTextBoxSqlText.Font.OriginalFontName, richTextBoxSqlText.Font.Size, FontStyle.Regular, GraphicsUnit.Point, 178, false);
                                        richTextBoxSqlText.SelectAll();
                                        richTextBoxSqlText.SelectionFont = fontRegular;
                                        richTextBoxSqlText.SelectionColor = Color.Black;
                                        richTextBoxSqlText.SelectionBackColor = Color.White;

                                        richTextBoxSqlText.Select(offset - 1 - lfCount, len - lfLenCount);
                                        richTextBoxSqlText.SelectionFont = fontBold;
                                        richTextBoxSqlText.SelectionColor = Color.WhiteSmoke;
                                        richTextBoxSqlText.SelectionBackColor = Color.Blue;

                                        richTextBoxSqlText.ScrollToCaret();
                                        SendMessage(richTextBoxSqlText.Handle, (uint)0x00B6, (UIntPtr)0, (IntPtr)(-5));

                                    }
                                }
                            }
                            else
                            {
                                if (FSqlCode != sqlText.Substring((offset - 1), len))
                                {
                                    FSqlCode = sqlText.Substring((offset - 1), len);
                                    richTextBoxSqlText.Text = sqlText.Substring((offset - 1), len);
                                }
                            }
                        }
                    }
                    else
                    {
                        labelObjectTitle.Text = "<Idle>";
                        richTextBoxSqlText.Text = "";
                        labelObjectOffset.Text = "";
                        FSqlCode = "";
                    }
                }
                else
                {
                    labelObjectTitle.Text = "<Idle>";
                    richTextBoxSqlText.Text = "";
                    labelObjectOffset.Text = "";
                    FSqlCode = "";
                }
            }

        }

        private void dbDataGridView3_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string waitType = dbDataGridView3.Rows[e.RowIndex].Cells["wait_type"].Value.ToString();

                clsWaitTypeInformationController waitTypeInfoController = new clsWaitTypeInformationController();
                WaitTypeInformation waitTypeInfo = waitTypeInfoController.GetWaitTypeInformation(waitType);
                textBoxWaitTypeInformation.Text = waitTypeInfo.WaitTypeDescription;
            }
            else
                textBoxWaitTypeInformation.Text = "";
        }
    }
}
