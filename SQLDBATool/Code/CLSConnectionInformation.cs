﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;


namespace SQLDBATool.Code
{
    class CLSConnectionInformation : IDisposable
    {
        private readonly SynchronizationContext _syncContext;
        private MonitoredServer FMonitoredServer;
        private ServerTree FServerTree;
        private clsServerStats FServerStats;
        private List<Code.ucServerIcon> FServerIcons;
        private CLSRefreshServerStats FRefreshBackgroundProcess;
        private CLSTreeInformation FParentTreeInformation;

        public List<Code.ucServerIcon> ServerIcon { get => FServerIcons; set => FServerIcons = value; }
        public ServerTree ServerTree { get => FServerTree; set => FServerTree = value; }
        public MonitoredServer MonitoredServer { get => FMonitoredServer; set => FMonitoredServer = value; }
        public clsServerStats ServerStats { get => FServerStats; set => FServerStats = value; }
        public CLSTreeInformation ParentTreeInformation { get => FParentTreeInformation; set => FParentTreeInformation = value; }

        public CLSConnectionInformation()
        {
            //FServerIcons = new List<ucServerIcon>();
            _syncContext = SynchronizationContext.Current;
            FServerStats = new clsServerStats();
        }

        public void Dispose()
        {

        }

        public void StartRefreshProcess()
        {
            FRefreshBackgroundProcess = new CLSRefreshServerStats();
            FRefreshBackgroundProcess.MonitoredServer = FMonitoredServer;
            FRefreshBackgroundProcess.ProcessRefreshed += ProcessRefreshed;
            FRefreshBackgroundProcess.ProcessDBSizesRefreshed += ProcessDBSizesRefreshed;

            FRefreshBackgroundProcess.StartRefreshBW();
        }

        public void ProcessRefreshed(object sender, ServerStatsRefreshArgs e)
        {
            _syncContext.Post(o => UpdateIcons(e), null);
        }
        public void ProcessDBSizesRefreshed(object sender, ServerStatsDBSizesArgs e)
        {
            _syncContext.Post(o => UpdateDatabaseInformation(e), null);
        }

        public void UpdateIcons(ServerStatsRefreshArgs e)
        {
            string performanceStats;
            string cpuUsage;
            string bhr;
            string upTime;
            FServerStats.UpdatePerformanceStatistics(e.PerformanceStatistics);
            FServerStats.UpdateServerInformation(e.ServerInformation);
            FServerStats.UpdateResponseTime(e.RefreshMS);
            FServerStats.UpdateSessionInformation(e.SessionInformation);
            FServerStats.UpdateSessionRequests(e.RequestInformation);
            FServerStats.UpdateSessionConnections(e.ConnectionInformation);
            FServerStats.UpdateSessionWaitStates(e.WaitStateInformation);
            FServerStats.UpdateSessionStats(e.SessionStatistics);
            FServerStats.UpdateSessionCommands(e.SessionCommands);

            performanceStats = FServerStats.ServerIconStats();
            cpuUsage = FServerStats.ServerIconCPUUsage();
            bhr = FServerStats.ServerIconBufferCacheHitRatio();
            upTime = FServerStats.ServerIconUpTime();
            foreach (Code.ucServerIcon icon in FServerIcons)
            {
                //icon.setText(performanceStats);
                icon.setText(cpuUsage, bhr, upTime);
            }

            Code.Globals.MasterForm.ShowServerMonitor(FParentTreeInformation, false);

        }
        public void UpdateDatabaseInformation(ServerStatsDBSizesArgs e)
        {
            FServerStats.UpdateDatabaseInformation(e.DatabaseInformation);
            FServerStats.UpdateDatabaseSize(e.DatabaseSpaceOverview);
            FServerStats.UpdateDatabaseSizeByDrive(e.DatabaseSpaceByDrive);
            Code.Globals.MasterForm.ShowDatabaseMonitor(FParentTreeInformation, false);
            
        }
    }
    public class clsServerStats : IDisposable
    {
        public struct stSessionGraphMaximums
        {
            public int cpuTime;
        }
        private DataTable FDTServerInformation;
        private DataTable FDTPerformanceStatistics;
        private DataTable FDTResponseTime;
        private DataTable FDTSessions;
        private DataTable FDTSessionRequests;
        private DataTable FDTSessionConnections;
        private DataTable FDTSessionWaitStates;
        private DataTable FDTSessionStats;
        private DataTable FDTSessionCommands;

        private DataTable FDTDatabaseInformation;
        private DataTable FDTDatabaseFileInformation;
        private DataTable FDTDatabaseSpaceInformation;
        private DataTable FDTDatabaseSpaceByDrive;

        private stSessionGraphMaximums FSessionGraphMaximums;
        public DataTable DTPerformanceStatistics { get => FDTPerformanceStatistics; set => FDTPerformanceStatistics = value; }
        public DataTable DTServerInformation { get => FDTServerInformation; set => FDTServerInformation = value; }
        public DataTable DTResponseTime { get => FDTResponseTime; set => FDTResponseTime = value; }
        public DataTable DTSessions { get => FDTSessions; set => FDTSessions = value; }
        public DataTable DTSessionRequests { get => FDTSessionRequests; set => FDTSessionRequests = value; }
        public DataTable DTSessionConnections { get => FDTSessionConnections; set => FDTSessionConnections = value; }
        public DataTable DTSessionWaitStates { get => FDTSessionWaitStates; set => FDTSessionWaitStates = value; }
        public DataTable DTSessionStats { get => FDTSessionStats; set => FDTSessionStats = value; }
        public DataTable DTSessionCommands { get => FDTSessionCommands; set => FDTSessionCommands = value; }
        public DataTable DTDatabaseInformation { get => FDTDatabaseInformation; set => FDTDatabaseInformation = value; }
        public DataTable DTDatabaseFileInformation { get => FDTDatabaseFileInformation; set => FDTDatabaseFileInformation = value; }
        public DataTable DTDatabaseSpaceByDrive { get => FDTDatabaseSpaceByDrive; set => FDTDatabaseSpaceByDrive = value; }
        public stSessionGraphMaximums SessionGraphMaximums { get => FSessionGraphMaximums; set => FSessionGraphMaximums = value; }

        public clsServerStats()
        {
            FDTPerformanceStatistics = new DataTable();
            FDTServerInformation = new DataTable();
            FDTResponseTime = new DataTable();
            FDTSessions = new DataTable();
            FDTSessionRequests = new DataTable();
            FDTSessionConnections = new DataTable();
            FDTSessionWaitStates = new DataTable();
            FDTSessionStats = new DataTable();
            FDTSessionCommands = new DataTable();
            FDTDatabaseInformation = new DataTable();
            FDTDatabaseFileInformation = new DataTable();
            FDTDatabaseSpaceInformation = new DataTable();
            FSessionGraphMaximums = new stSessionGraphMaximums();
            FSessionGraphMaximums.cpuTime = 0;
            FDTResponseTime.Columns.Add("ResponseTimeMS", typeof(long));
        }

        public void Dispose()
        {
        }

        public void UpdateServerInformation(DataTable dtServerInformation)
        {
            if (FDTServerInformation.Columns.Count == 0)
                FDTServerInformation = dtServerInformation.Clone();
            FDTServerInformation.Rows.Clear();
            FDTServerInformation.Rows.Add(dtServerInformation.Rows[0].ItemArray);
        }
        public void UpdatePerformanceStatistics(DataTable dtPerformanceStatistics)
        {
            if (FDTPerformanceStatistics.Columns.Count == 0)
                FDTPerformanceStatistics = dtPerformanceStatistics.Clone();
            if (FDTPerformanceStatistics.Rows.Count == 300)
                FDTPerformanceStatistics.Rows[0].Delete();
            FDTPerformanceStatistics.Rows.Add(dtPerformanceStatistics.Rows[0].ItemArray);
        }
        public void UpdateSessionInformation(DataTable dtSessionInformation)
        {
            DateTime latestRefresh;
            if (FDTSessions.Columns.Count == 0)
            {
                FDTSessions = dtSessionInformation.Clone();
                FDTSessions.PrimaryKey = new DataColumn[] { FDTSessions.Columns["session_id"] };
                foreach (DataColumn col in FDTSessions.Columns)
                {
                    col.ReadOnly = false;
                }
            }

            latestRefresh = (DateTime)dtSessionInformation.Rows[0]["RefreshedLast"];
            dtSessionInformation.PrimaryKey = new DataColumn[] { dtSessionInformation.Columns["session_id"] };
            FDTSessions.Merge(dtSessionInformation, false, MissingSchemaAction.Add);
            foreach (DataRow row in FDTSessions.Rows)
            {
                if ((DateTime)row["RefreshedLast"] < latestRefresh)
                {

                    row["IsConnected"] = 0;
                    row["status"] = "disconnected";
                    row["SessionBackColor"] = "DISCONNECTED";
                }

                row.ClearErrors();
            }
            FDTSessions.AcceptChanges();

        }
        public void UpdateSessionRequests(DataTable dtSessionRequestInformation)
        {
            if (FDTSessionRequests.Columns.Count == 0)
            {
                FDTSessionRequests = dtSessionRequestInformation.Clone();
                FDTSessionRequests.PrimaryKey = new DataColumn[] { FDTSessionRequests.Columns["session_id"], FDTSessionRequests.Columns["request_id"] };
                foreach (DataColumn col in FDTSessionRequests.Columns)
                {
                    col.ReadOnly = false;
                }
            }

            foreach (DataRow r in DTSessions.Select("IsConnected = 1"))
            {
                int sessionID = (Int16)r["session_id"];

                string SessionSearchString = "session_id = " + sessionID.ToString();
                foreach (DataRow reqR in DTSessionRequests.Select(SessionSearchString))
                {
                    reqR.Delete();
                }
            }

            dtSessionRequestInformation.PrimaryKey = new DataColumn[] { dtSessionRequestInformation.Columns["session_id"], dtSessionRequestInformation.Columns["request_id"] };
            FDTSessionRequests.Merge(dtSessionRequestInformation, false, MissingSchemaAction.Add);
            FDTSessionRequests.AcceptChanges();

        }
        public void UpdateSessionConnections(DataTable dtSessionConnectionsInformation)
        {
            if (FDTSessionConnections.Columns.Count == 0)
            {
                FDTSessionConnections = dtSessionConnectionsInformation.Clone();
                FDTSessionConnections.PrimaryKey = new DataColumn[] { FDTSessionConnections.Columns["session_id"], FDTSessionConnections.Columns["Connections_id"] };
                foreach (DataColumn col in FDTSessionConnections.Columns)
                {
                    col.ReadOnly = false;
                }
            }

            foreach (DataRow r in DTSessions.Select("IsConnected = 1"))
            {
                int sessionID = (Int16)r["session_id"];

                string SessionSearchString = "session_id = " + sessionID.ToString();
                foreach (DataRow reqR in DTSessionConnections.Select(SessionSearchString))
                {
                    reqR.Delete();
                }
            }

            dtSessionConnectionsInformation.PrimaryKey = new DataColumn[] { dtSessionConnectionsInformation.Columns["session_id"], dtSessionConnectionsInformation.Columns["Connections_id"] };
            FDTSessionConnections.Merge(dtSessionConnectionsInformation, false, MissingSchemaAction.Add);
            FDTSessionConnections.AcceptChanges();

        }
        public void UpdateSessionWaitStates(DataTable dtSessionWaitStatesInformation)
        {
            if (FDTSessionWaitStates.Columns.Count == 0)
            {
                FDTSessionWaitStates = dtSessionWaitStatesInformation.Clone();
                FDTSessionWaitStates.PrimaryKey = new DataColumn[] { FDTSessionWaitStates.Columns["session_id"], FDTSessionWaitStates.Columns["wait_type"] };
                foreach (DataColumn col in FDTSessionWaitStates.Columns)
                {
                    col.ReadOnly = false;
                }
            }

            DTSessionWaitStates.Rows.Clear();
            //foreach (DataRow r in DTSessions.Select("IsConnected = 1"))
            //{
            //    int sessionID = (Int16)r["session_id"];

            //    string SessionSearchString = "session_id = " + sessionID.ToString();
            //    foreach (DataRow reqR in DTSessionWaitStates.Select(SessionSearchString))
            //    {
            //        reqR.Delete();
            //    }
            //}

            dtSessionWaitStatesInformation.PrimaryKey = new DataColumn[] { dtSessionWaitStatesInformation.Columns["session_id"], dtSessionWaitStatesInformation.Columns["wait_type"] };
            FDTSessionWaitStates.Merge(dtSessionWaitStatesInformation, false, MissingSchemaAction.Add);
            FDTSessionWaitStates.AcceptChanges();

        }
        public void UpdateSessionStats(DataTable dtSessionStatsInformation)
        {
            if (FDTSessionStats.Columns.Count == 0)
            {
                FDTSessionStats = dtSessionStatsInformation.Clone();
                FDTSessionStats.PrimaryKey = new DataColumn[] { FDTSessionStats.Columns["session_id"], FDTSessionStats.Columns["currentDateStamp"] };
                foreach (DataColumn col in FDTSessionStats.Columns)
                {
                    col.ReadOnly = false;
                }
            }

            foreach (DataRow r in DTSessions.Select("IsConnected = 1"))
            {
                int sessionID = (Int16)r["session_id"];
                DateTime sessionLoginTime = (DateTime)r["login_time"];
                string SessionSearchString = "session_id = " + sessionID.ToString();
                //int rowCnt = 0;
                FSessionGraphMaximums.cpuTime = 100;
                foreach (DataRow reqR in DTSessionStats.Select(SessionSearchString))
                {
                    if ((DateTime)reqR["login_time"] != sessionLoginTime)
                        reqR.Delete();
                    //else
                    //    rowCnt++;
                }
                while (DTSessionStats.Select(SessionSearchString).Length > 300)
                {
                    DTSessionStats.Select(SessionSearchString)[0].Delete();
                }
            }
            dtSessionStatsInformation.PrimaryKey = new DataColumn[] { dtSessionStatsInformation.Columns["session_id"], dtSessionStatsInformation.Columns["currentDateStamp"] };
            FDTSessionStats.Merge(dtSessionStatsInformation, false, MissingSchemaAction.Add);
            FDTSessionStats.AcceptChanges();

        }
        public void UpdateSessionCommands(DataTable dtSessionCommands)
        {
            if (FDTSessionCommands.Columns.Count == 0)
            {
                FDTSessionCommands = dtSessionCommands.Clone();
                FDTSessionCommands.PrimaryKey = new DataColumn[] { FDTSessionCommands.Columns["session_id"] };
                foreach (DataColumn col in FDTSessionCommands.Columns)
                {
                    col.ReadOnly = false;
                }
            }

            dtSessionCommands.PrimaryKey = new DataColumn[] { dtSessionCommands.Columns["session_id"] };
            FDTSessionCommands.Merge(dtSessionCommands, false, MissingSchemaAction.Add);
            FDTSessionCommands.AcceptChanges();

        }
        public void UpdateResponseTime(long responseTimeMS)
        {
            if (FDTResponseTime.Rows.Count == 300)
                FDTResponseTime.Rows[0].Delete();
            FDTResponseTime.Rows.Add(new object[] { responseTimeMS });

        }
        public void UpdateDatabaseInformation(DataTable dtDatabaseInformation)
        {
            if (FDTDatabaseInformation.Columns.Count == 0)
            {
                FDTDatabaseInformation = dtDatabaseInformation.Clone();
                FDTDatabaseInformation.PrimaryKey = new DataColumn[] { FDTDatabaseInformation.Columns["database_id"] };
                foreach (DataColumn col in FDTDatabaseInformation.Columns)
                {
                    col.ReadOnly = false;
                }
            }

            dtDatabaseInformation.PrimaryKey = new DataColumn[] { dtDatabaseInformation.Columns["database_id"] };
            FDTDatabaseInformation.Rows.Clear();
            FDTDatabaseInformation.Merge(dtDatabaseInformation, false, MissingSchemaAction.Add);
            FDTDatabaseInformation.AcceptChanges();

        }
        public void UpdateDatabaseSize(DataTable dtDatabaseSize)
        {
            if (FDTDatabaseSpaceInformation.Columns.Count == 0)
            {
                FDTDatabaseSpaceInformation = dtDatabaseSize.Clone();
                FDTDatabaseSpaceInformation.PrimaryKey = new DataColumn[] { FDTDatabaseSpaceInformation.Columns["DriveType"], FDTDatabaseSpaceInformation.Columns["Drive"] };
                foreach (DataColumn col in FDTDatabaseSpaceInformation.Columns)
                {
                    col.ReadOnly = false;
                }
            }

            dtDatabaseSize.PrimaryKey = new DataColumn[] { dtDatabaseSize.Columns["DriveType"], dtDatabaseSize.Columns["Drive"] };
            FDTDatabaseSpaceInformation.Rows.Clear();
            FDTDatabaseSpaceInformation.Merge(dtDatabaseSize, false, MissingSchemaAction.Add);
            FDTDatabaseSpaceInformation.AcceptChanges();

        }
        public void UpdateDatabaseSizeByDrive(DataTable dtDatabaseSizeByDrive)
        {
            if (FDTDatabaseSpaceByDrive.Columns.Count == 0)
            {
                FDTDatabaseSpaceByDrive = dtDatabaseSizeByDrive.Clone();
                FDTDatabaseSpaceByDrive.PrimaryKey = new DataColumn[] { FDTDatabaseSpaceByDrive.Columns["DriveType"], FDTDatabaseSpaceByDrive.Columns["Drive"] };
                foreach (DataColumn col in FDTDatabaseSpaceByDrive.Columns)
                {
                    col.ReadOnly = false;
                }
            }

            dtDatabaseSizeByDrive.PrimaryKey = new DataColumn[] { dtDatabaseSizeByDrive.Columns["DriveType"], dtDatabaseSizeByDrive.Columns["Drive"] };
            FDTDatabaseSpaceByDrive.Rows.Clear();
            FDTDatabaseSpaceByDrive.Merge(dtDatabaseSizeByDrive, false, MissingSchemaAction.Add);
            FDTDatabaseSpaceByDrive.AcceptChanges();

        }

        public string ServerIconStats()
        {
            string ret = "";

            decimal cpuPercentage;
            decimal bufferHitRatio;
            string serverUpTime;
            int totalSessions;
            int row = FDTPerformanceStatistics.Rows.Count;
            cpuPercentage = (decimal)FDTPerformanceStatistics.Rows[row - 1]["CPUPercentage"];
            bufferHitRatio = (decimal)FDTPerformanceStatistics.Rows[row - 1]["BufferCacheHitRatio"];
            totalSessions = (int)FDTPerformanceStatistics.Rows[row - 1]["TotalSessions"];
            serverUpTime = (string)FDTServerInformation.Rows[0]["RunningDurationSmall"];
            ret = "CPU: " + cpuPercentage.ToString("0.00%") + "\r\n" + "BHR: " + bufferHitRatio.ToString() + "\r\n" + serverUpTime;


            return ret;
        }
        public string ServerIconCPUUsage()
        {
            string ret = "";
            decimal cpuPercentage;
            int row = FDTPerformanceStatistics.Rows.Count;
            cpuPercentage = (decimal)FDTPerformanceStatistics.Rows[row - 1]["CPUPercentage"];
            ret = cpuPercentage.ToString("0.00") + "%";

            return ret;
        }
        public string ServerIconBufferCacheHitRatio()
        {
            string ret = "";
            decimal bufferHitRatio;
            int row = FDTPerformanceStatistics.Rows.Count;
            bufferHitRatio = (decimal)FDTPerformanceStatistics.Rows[row - 1]["BufferCacheHitRatio"];
            ret = bufferHitRatio.ToString();

            return ret;
        }
        public string ServerIconUpTime()
        {
            string ret = "";
            string serverUpTime;
            int row = FDTPerformanceStatistics.Rows.Count;
            serverUpTime = (string)FDTServerInformation.Rows[0]["RunningDurationSmall"];
            ret = serverUpTime;

            return ret;
        }

    }

}
