using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
namespace SQLDBATool.Code
{
    class CLSRefreshServerStats : IDisposable
    {
        private MonitoredServer FMonitoredServer;
        private int Counter = 0;
        private BackgroundWorker FBWServerStats;
        private BackgroundWorker FBWDBSpace;
        private bool FCancelRefresh = false;
        private long FPrevCPUIdle = 0;
        private long FPrevCPUBusy = 0;
        private int FPrevNetworkPacketsSent = 0;
        private int FPrevNetworkPacketsReceived = 0;
        private int FPrevPhysicalIOReads = 0;
        private int FPrevPhysicalIOWrites = 0;
        private Decimal FPrevBatchRecSec = 0;
        private Decimal FPrevSqlCompilationSec = 0;
        private Decimal FPrevSqlReCompilationSec = 0;
        private Decimal FPrevCheckPointsSec = 0;
        private Decimal FPrevLockWaitsSec = 0;
        private bool FDBSpaceQuickScan = true;
        private DateTime FPrevTime = DateTime.Now;
        private SqlConnection FConnection;
        private SqlConnection FDBSizeConnection;
        public MonitoredServer MonitoredServer { get => FMonitoredServer; set => FMonitoredServer = value; }
        public bool CancelRefresh { get => FCancelRefresh; set => FCancelRefresh = value; }

        public CLSRefreshServerStats()
        {
        }

        public void Dispose()
        {

        }
        public event EventHandler<ServerStatsRefreshArgs> ProcessRefreshed;
        public event EventHandler<ServerStatsDBSizesArgs> ProcessDBSizesRefreshed;
        protected virtual void OnProcessRefreshed(ServerStatsRefreshArgs e)
        {
            EventHandler<ServerStatsRefreshArgs> handler = ProcessRefreshed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnProcessDBSpaceRefreshed(ServerStatsDBSizesArgs e)
        {
            EventHandler<ServerStatsDBSizesArgs> handler = ProcessDBSizesRefreshed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void StartRefreshBW()
        {
            FBWServerStats = new BackgroundWorker();
            FBWServerStats.DoWork += ProcessRefresh;
            FBWServerStats.WorkerSupportsCancellation = true;
            FBWServerStats.RunWorkerCompleted += RefreshProcessComplete_BW;
            FBWServerStats.RunWorkerAsync();

            FBWDBSpace = new BackgroundWorker();
            FBWDBSpace.DoWork += ProcessDBSpaceRefresh;
            FBWDBSpace.WorkerSupportsCancellation = true;
            FBWDBSpace.RunWorkerCompleted += RefreshProcessComplete_BW;
            FBWDBSpace.RunWorkerAsync();
       }

        public string BuildConnectionString()
        {
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();

            connString.DataSource = FMonitoredServer.ServerName;
            connString.IntegratedSecurity = FMonitoredServer.UseIntegratedSecurity;
            connString.ColumnEncryptionSetting = SqlConnectionColumnEncryptionSetting.Enabled;
            if (!FMonitoredServer.UseIntegratedSecurity)
            {
                connString.UserID = FMonitoredServer.UserID;
                connString.Password = FMonitoredServer.Password;
            }
            if (FMonitoredServer.NetworkProtocol != @"<default>")
            {
                string networkLibrary = FMonitoredServer.NetworkProtocol.Substring(FMonitoredServer.NetworkProtocol.IndexOf("(") + 1);
                networkLibrary = networkLibrary.Substring(0, networkLibrary.Length - 1);
                connString.NetworkLibrary = networkLibrary;
            }
            if (FMonitoredServer.NetworkPacketSize != 4096)
            {
                connString.PacketSize = (int)FMonitoredServer.NetworkPacketSize;
            }
            if (FMonitoredServer.ConnectionTimeOut != 4096)
            {
                connString.ConnectTimeout = (int)FMonitoredServer.ConnectionTimeOut;
            }
            connString.Encrypt = FMonitoredServer.EncryptConnection;
            connString.TrustServerCertificate = FMonitoredServer.TrustServerCertificate;
            connString.ApplicationName = "SQL Server Assistance";
            connString.Pooling = false;
            return connString.ConnectionString;
        }
        private void ProcessRefresh(object sender, DoWorkEventArgs e)
        {
            ServerStatsRefreshArgs args = new ServerStatsRefreshArgs();
            args.ConnectionID = FMonitoredServer.ServerID;
            args.ServerInformation = new DataTable();
            args.PerformanceStatistics = new DataTable();
            args.SessionInformation = new DataTable();
            args.SessionStatistics = new DataTable();
            args.RequestInformation = new DataTable();
            args.ConnectionInformation = new DataTable();
            args.WaitStateInformation = new DataTable();
            args.CursorInformaiton = new DataTable();
            args.SessionCommands = new DataTable();

            if (FConnection == null)
            {
                FConnection = new SqlConnection();
                FConnection.ConnectionString = BuildConnectionString();

            }
            while (!CancelRefresh)
            {
                if (FConnection.State != ConnectionState.Open)
                {
                    try
                    {
                        args.IsOnError = false;
                        FConnection.Open();
                        CreateRefreshProcedure(FConnection);
                    }
                    catch (SqlException ex)
                    {
                        args.IsOnError = true;
                        args.LastError = ex.Message;
                    }
                }

                if (!args.IsOnError)
                {
                    #region Get Server Information
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = FConnection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "#GetServerInfo";

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (args.ServerInformation.Rows.Count > 0)
                            args.ServerInformation.Clear();
                        args.ServerInformation.Load(dr);
                    }
                    #endregion

                    #region Get Server Statistics
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = FConnection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "#GetPerformanceStats";

                        cmd.Parameters.Add("@inPrevCPUIdle", SqlDbType.BigInt);
                        cmd.Parameters.Add("@inPrevCPUBusy", SqlDbType.BigInt);
                        cmd.Parameters.Add("@inPrevNetworkPacketsSent", SqlDbType.Int);
                        cmd.Parameters.Add("@inPrevNetworkPacketsReceived", SqlDbType.Int);
                        cmd.Parameters.Add("@inPrevPhysicalIOReads", SqlDbType.Int);
                        cmd.Parameters.Add("@inPrevBatchRecSec", SqlDbType.BigInt);
                        cmd.Parameters.Add("@inPrevSqlCompilationSec", SqlDbType.BigInt);
                        cmd.Parameters.Add("@inPrevSqlReCompilationSec", SqlDbType.BigInt);
                        cmd.Parameters.Add("@inPrevCheckPointsSec", SqlDbType.BigInt);
                        cmd.Parameters.Add("@inPrevLockWaitsSec", SqlDbType.BigInt);
                        cmd.Parameters.Add("@inPrevTime", SqlDbType.DateTime);
                        cmd.Parameters["@inPrevCPUIdle"].Value = FPrevCPUIdle;
                        cmd.Parameters["@inPrevCPUBusy"].Value = FPrevCPUBusy;
                        cmd.Parameters["@inPrevNetworkPacketsSent"].Value = FPrevNetworkPacketsSent;
                        cmd.Parameters["@inPrevNetworkPacketsReceived"].Value = FPrevNetworkPacketsReceived;
                        cmd.Parameters["@inPrevPhysicalIOReads"].Value = FPrevPhysicalIOReads;
                        cmd.Parameters["@inPrevBatchRecSec"].Value = FPrevBatchRecSec;
                        cmd.Parameters["@inPrevSqlCompilationSec"].Value = FPrevSqlCompilationSec;
                        cmd.Parameters["@inPrevSqlReCompilationSec"].Value = FPrevSqlReCompilationSec;
                        cmd.Parameters["@inPrevCheckPointsSec"].Value = FPrevCheckPointsSec;
                        cmd.Parameters["@inPrevLockWaitsSec"].Value = FPrevLockWaitsSec;
                        cmd.Parameters["@inPrevTime"].Value = FPrevTime;

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (args.PerformanceStatistics.Rows.Count > 0)
                            args.PerformanceStatistics.Clear();
                        args.PerformanceStatistics.Load(dr);

                        FPrevCPUIdle = (long)args.PerformanceStatistics.Rows[0]["CPU_Idle"];
                        FPrevCPUBusy = (long)args.PerformanceStatistics.Rows[0]["CPU_Busy"];
                        FPrevNetworkPacketsSent = (int)args.PerformanceStatistics.Rows[0]["pack_sent"];
                        FPrevNetworkPacketsReceived = (int)args.PerformanceStatistics.Rows[0]["pack_received"];
                        FPrevPhysicalIOReads = (int)args.PerformanceStatistics.Rows[0]["total_read"];
                        FPrevPhysicalIOWrites = (int)args.PerformanceStatistics.Rows[0]["total_write"];
                        FPrevBatchRecSec = (Int64)args.PerformanceStatistics.Rows[0]["batch_requests_sec"];
                        FPrevSqlCompilationSec = (Int64)args.PerformanceStatistics.Rows[0]["sql_compilations_sec"];
                        FPrevSqlReCompilationSec = (Int64)args.PerformanceStatistics.Rows[0]["sql_recompilations_sec"];
                        FPrevCheckPointsSec = (Int64)args.PerformanceStatistics.Rows[0]["checkpoint_pages_sec"];
                        FPrevLockWaitsSec = (Int64)args.PerformanceStatistics.Rows[0]["lock_waits_sec"];
                        FPrevTime = (DateTime)args.PerformanceStatistics.Rows[0]["CurrentServerTime"];
                    }
                    #endregion

                    #region Get Server Response Time
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = FConnection;
                        cmd.CommandText = "SELECT 1";
                        cmd.CommandType = CommandType.Text;
                        Stopwatch sw = Stopwatch.StartNew();
                        SqlDataReader dr = cmd.ExecuteReader();
                        sw.Stop();
                        dr.Close();
                        args.RefreshMS = sw.ElapsedMilliseconds;
                    }
                    #endregion

                    #region Get Session Information
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = FConnection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "#GetSessionInfomation";

                        #region Get Sessions
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (args.SessionInformation.Rows.Count > 0)
                            args.SessionInformation.Clear();
                        args.SessionInformation.Load(dr);
                        #endregion
                        #region Session Stats
                            args.SessionStatistics.Clear();
                        args.SessionStatistics.Load(dr);
                        #endregion
                        #region Requests
                        if (args.RequestInformation.Rows.Count > 0)
                            args.RequestInformation.Clear();
                        args.RequestInformation.Load(dr);
                        #endregion
                        #region Connections
                        if (args.ConnectionInformation.Rows.Count > 0)
                            args.ConnectionInformation.Clear();
                        args.ConnectionInformation.Load(dr);
                        #endregion
                        #region WaitStates
                        if (args.WaitStateInformation.Rows.Count > 0)
                            args.WaitStateInformation.Clear();
                        args.WaitStateInformation.Load(dr);
                        #endregion
                        //#region Cursors
                        //if (args.CursorInformaiton.Rows.Count > 0)
                        //    args.CursorInformaiton.Clear();
                        //args.CursorInformaiton.Load(dr);
                        //#endregion
                        #region Session Commands
                        if (args.SessionCommands.Rows.Count > 0)
                            args.SessionCommands.Clear();
                        args.SessionCommands.Load(dr);
                        #endregion

                    }
                    #endregion
                }
                this.OnProcessRefreshed(args);

                Thread.Sleep(5000);
            }

        }
        private void ProcessDBSpaceRefresh(object sender, DoWorkEventArgs e)
        {
            try
            {
                ServerStatsDBSizesArgs args = new ServerStatsDBSizesArgs();
                args.ConnectionID = FMonitoredServer.ServerID;
                args.DatabaseInformation = new DataTable();
                args.DatabaseFileInformation = new DataTable();
                args.DatabaseSpaceOverview = new DataTable();
                args.DatabaseSpaceByDrive = new DataTable();
                if (FDBSizeConnection == null)
                {
                    FDBSizeConnection = new SqlConnection();
                    FDBSizeConnection.ConnectionString = BuildConnectionString();

                }
                while (!CancelRefresh)
                {
                    if (FDBSizeConnection.State != ConnectionState.Open)
                    {
                        try
                        {
                            args.IsOnError = false;
                            FDBSizeConnection.Open();
                            CreateDBSpaceProcedure(FDBSizeConnection);
                        }
                        catch (SqlException ex)
                        {
                            args.IsOnError = true;
                            args.LastError = ex.Message;
                        }
                    }

                    if (!args.IsOnError)
                    {
                        #region Get DBSpace Information

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = FDBSizeConnection;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "#GetDatabaseInformation";
                            cmd.Parameters.Add("@inQuickScan", SqlDbType.Bit);
                            cmd.Parameters["@inQuickScan"].Value = FDBSpaceQuickScan;
                            #region Get Database Information
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (args.DatabaseInformation.Rows.Count > 0)
                                args.DatabaseInformation.Clear();
                            args.DatabaseInformation.Load(dr);
                            #endregion
                            #region Database File Information
                            if (args.DatabaseFileInformation.Rows.Count > 0)
                                args.DatabaseFileInformation.Clear();
                            args.DatabaseFileInformation.Load(dr);
                            #endregion
                            #region Database Space Overview
                            if (args.DatabaseSpaceOverview.Rows.Count > 0)
                                args.DatabaseSpaceOverview.Clear();
                            args.DatabaseSpaceOverview.Load(dr);
                            #endregion
                            #region Database Space Byt Drive
                            if (args.DatabaseSpaceByDrive.Rows.Count > 0)
                                args.DatabaseSpaceByDrive.Clear();
                            args.DatabaseSpaceByDrive.Load(dr);
                            #endregion

                        }
                        #endregion
                    }
                    this.OnProcessDBSpaceRefreshed(args);
                    if (FDBSpaceQuickScan)
                    {
                        Thread.Sleep(5000);
                        FDBSpaceQuickScan = false;
                    }
                    else
                    {
                        Thread.Sleep(12000);
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

        }
        private void RefreshProcessComplete_BW(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        #region CreateRefreshProcedure
        private void CreateRefreshProcedure(SqlConnection conn)
        {
            #region GetServerInfo
            string sql = @"
CREATE procedure #GetServerInfo
as
begin
;with OSInfo as
(
select 
    [hyperthread_ratio]    = hyperthread_ratio
   ,[affinity_type_desc]   = affinity_type_desc
   ,[scheduler_count]      = scheduler_count
   ,[sqlserver_start_time] = sqlserver_start_time
   ,[CPUCount]             = case when cpu_count <= hyperthread_ratio then hyperthread_ratio else cpu_count end
   ,[CPUIdle]              = (
                              (
                                (
                                  (CAST(datediff(DAY, sqlserver_start_time, getdate()) as bigint)  * 24 * 60 * 60 * 1000) 
                                   + DATEDIFF(MS, DATEADD(day, datediff(DAY, sqlserver_start_time, getdate()), sqlserver_start_time), getdate())
                                     
                                ) * (case when cpu_count <= hyperthread_ratio then hyperthread_ratio else cpu_count end)
                              ) - process_user_time_ms)
    ,[MAXDOP]              = (select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = 'maximum degree of parallelism')
    ,[CTFP]                = (select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = 'cost threshold for parallelism')
from master.sys.dm_os_sys_info
),
  PerformanceCounters as
(
select
    [TotalServerMemory]             = sum(case when counter_name = 'Total Server Memory (KB)' then cntr_value else 0 end) 
   ,[TargetServerMemory]            = sum(case when counter_name = 'Target Server Memory (KB)' then cntr_value else 0 end) 
   ,[DatabaseCacheMemory]           = sum(case when counter_name = 'Database Cache Memory (KB)' then cntr_value else 0 end) 
   ,[FreeMemory]                    = sum(case when counter_name = 'Free Memory (KB)' then cntr_value else 0 end) 
   ,[ReservedServerMemory]          = sum(case when counter_name = 'Reserved Server Memory (KB)' then cntr_value else 0 end) 
   ,[StolenServerMemory]            = sum(case when counter_name = 'Stolen Server Memory (KB)' then cntr_value else 0 end) 
   ,[MemoryGrantsOutstanding]       = sum(case when counter_name = 'Memory Grants Outstanding' then cntr_value else 0 end) 
   ,[MemoryGrantsPending]           = sum(case when counter_name = 'Memory Grants Pending' then cntr_value else 0 end) 
   ,[BufferCacheHitRatio]           = sum(case when counter_name = 'Buffer cache hit ratio' then cntr_value else 0 end)  
   ,[BufferCacheHitRatioBase]       = sum(case when counter_name = 'Buffer cache hit ratio base' then cntr_value else 0 end) 
   ,[PageLifeExpectancy]            = sum(case when counter_name = 'Page life expectancy' then cntr_value else 0 end) 
from  sys.dm_os_performance_counters
where 
	(
         object_name like '%Buffer Manager%'
	 and counter_name in ( 'Buffer cache hit ratio'
                          ,'Buffer cache hit ratio base'
                          ,'Page life expectancy')
    )
or
	(
         object_name like '%Memory Manager%'
	 and counter_name in ( 'Total Server Memory (KB)'
                          ,'Target Server Memory (KB)'
                          ,'Database Cache Memory (KB)'
                          ,'Free Memory (KB)'
                          ,'Reserved Server Memory (KB)'
                          ,'Stolen Server Memory (KB)'
                          ,'Memory Grants Outstanding'
                          ,'Memory Grants Pending')
    )
)
select
    [ServerName]                  = cast(serverproperty('ServerName') as varchar(100)) 
   ,[LocalNetAddress]             = isnull(cast(connectionproperty('local_net_address') as varchar(100)),'')
   ,[ComputerNamePhysicalNetBIOS] = isnull(cast(serverproperty('ComputerNamePhysicalNetBIOS') as varchar(100)),'')
   ,[Edition]                     = isnull(cast(serverproperty('Edition') as varchar(100)),'')  
   ,[OSVersion]                   = isnull(cast(substring(@@version, patindex('% on %', @@version) + 4, 200) as varchar(200)),'')
   ,[InstanceName]                = isnull(cast(('InstanceName') as varchar(100)),'')
   ,[MachineName]                 = isnull(cast(serverproperty('MachineName') as varchar(100)),'')
   ,[ProductVersion]              = isnull(cast(serverproperty('ProductVersion') as varchar(100)),'')
   ,[ProductLevel]                = isnull(cast(serverproperty('ProductLevel') as varchar(100)),'')
   ,[NumLicenses]                 = isnull(cast(serverproperty('NumLicenses') as varchar(100)),'')
   ,[LicenseType]                 = isnull(cast(serverproperty('LicenseType') as varchar(100)),'')
   ,[BuildClrVersion]             = isnull(cast(serverproperty('BuildClrVersion') as varchar(100)),'')
   ,[Collation]                   = isnull(cast(serverproperty('Collation') as varchar(100)),'')
   ,[ResourceLastUpdateDateTime]  = serverproperty('ResourceLastUpdateDateTime')
   ,[ResourceVersion]             = isnull(cast(serverproperty('ResourceVersion') as varchar(255)),'')
   ,[HadrManagerStatus]           = isnull(cast(serverproperty('HadrManagerStatus') as varchar(255)),'')
   ,[InstanceDefaultDataPath]     = isnull(cast(serverproperty('InstanceDefaultDataPath') as varchar(255)),'')
   ,[InstanceDefaultLogPath]      = isnull(cast(serverproperty('InstanceDefaultLogPath') as varchar(255)),'')
   ,[IsClustered]                 = isnull(cast(serverproperty('IsClustered') as varchar(255)),'')
   ,[IsHadrEnabled]               = isnull(cast(serverproperty('IsHadrEnabled') as varchar(255)),'')
   ,[CPUCount]                    = isnull(dm_os_sys_info.CPUCount,0)
   ,[HyperThreadRatio]            = isnull(dm_os_sys_info.hyperthread_ratio,0)
   ,[AffinityType]                = isnull(dm_os_sys_info.affinity_type_desc, 'UNKNOWN')
   ,[SchedulerCount]              = isnull(dm_os_sys_info.scheduler_count, 0)
   ,[MaxDegreeOfParallelism]      = isnull(dm_os_sys_info.[MAXDOP],'0')
   ,[CostThresholdOfParallelism]  = isnull(dm_os_sys_info.[CTFP],'0')
   ,[StartTime]                   = dm_os_sys_info.sqlserver_start_time
   ,[RunningDurationSmall]        = case when datediff(day, dm_os_sys_info.sqlserver_start_time, getdate()) = 0 then ''
                                         when datediff(day, dm_os_sys_info.sqlserver_start_time, getdate()) = 1 then format(datediff(day, dm_os_sys_info.sqlserver_start_time, getdate()),'#,##0') + ' day' + char(13) + char(10)
                                         else format(datediff(day, dm_os_sys_info.sqlserver_start_time, getdate()),'#,##0') + ' days' + char(13) + char(10)
                                    end + 
                                    format((datediff(hour, dm_os_sys_info.sqlserver_start_time, getdate()) % 24),'00') + ':' +
                                    format((datediff(minute, dm_os_sys_info.sqlserver_start_time, getdate()) % 60),'00') + ':' +
                                    format((datediff(second, dm_os_sys_info.sqlserver_start_time, getdate()) % 60),'00')
   ,[RunningDurationLarge]        = format(datediff(day, dm_os_sys_info.sqlserver_start_time, getdate()),'#,##0') + ' days, ' +
                                    format((datediff(hour, dm_os_sys_info.sqlserver_start_time, getdate()) % 24),'#,##0') + ' hours, ' +
                                    format((datediff(minute, dm_os_sys_info.sqlserver_start_time, getdate()) % 60),'#,##0') + ' minutes, ' +
                                    format((datediff(second, dm_os_sys_info.sqlserver_start_time, getdate()) % 60),'#,##0') + ' seconds' 
   ,[CurrentTime]                 = GetDate()
   ,[TotalServerMemory]           = PerformanceCounters.TotalServerMemory
   ,[TargetServerMemory]          = PerformanceCounters.TargetServerMemory
   ,[DatabaseCacheMemory]         = PerformanceCounters.DatabaseCacheMemory
   ,[FreeMemory]                  = PerformanceCounters.FreeMemory
   ,[ReservedServerMemory]        = PerformanceCounters.ReservedServerMemory
   ,[StolenServerMemory]          = PerformanceCounters.StolenServerMemory
   ,[MemoryGrantsOutstanding]     = PerformanceCounters.MemoryGrantsOutstanding
   ,[MemoryGrantsPending]         = PerformanceCounters.MemoryGrantsPending
   ,[BufferCacheHitRatio]         = isnull(cast((cast(PerformanceCounters.BufferCacheHitRatio as float) / PerformanceCounters.BufferCacheHitRatioBase) * 100 as numeric(5,2)),0)
   ,[PageLifeExpectancy]          = PerformanceCounters.PageLifeExpectancy
   ,[LocalTCPPort]                = isnull(cast(connectionproperty('local_tcp_port') as varchar(100)),'')
from OSInfo dm_os_sys_info, PerformanceCounters
end";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
            }
            #endregion
            #region GetPerformanceStats
            sql = @"
create procedure #GetPerformanceStats
     @inPrevCPUIdle bigint = 0
    ,@inPrevCPUBusy bigint = 0
    ,@inPrevNetworkPacketsSent int = 0
    ,@inPrevNetworkPacketsReceived int = 0
    ,@inPrevPhysicalIOReads int = 0
    ,@inPrevPhysicalIOWrites int = 0
    ,@inPrevBatchRecSec bigint = 0
    ,@inPrevSqlCompilationSec bigint = 0
    ,@inPrevSqlReCompilationSec bigint = 0
    ,@inPrevCheckPointsSec bigint = 0
    ,@inPrevLockWaitsSec bigint = 0
    ,@inPrevTime datetime = null
as
begin
if @inPrevTime is null
    set @inPrevTime = dateadd(second, -3, getdate())

;with perfcntr as
(
select
    [TotalServerMemory]             = sum(case when counter_name = 'Total Server Memory (KB)' then cntr_value else 0 end) 
   ,[TargetServerMemory]            = sum(case when counter_name = 'Target Server Memory (KB)' then cntr_value else 0 end) 
   ,[DatabaseCacheMemory]           = sum(case when counter_name = 'Database Cache Memory (KB)' then cntr_value else 0 end) 
   ,[FreeMemory]                    = sum(case when counter_name = 'Free Memory (KB)' then cntr_value else 0 end) 
   ,[ReservedServerMemory]          = sum(case when counter_name = 'Reserved Server Memory (KB)' then cntr_value else 0 end) 
   ,[StolenServerMemory]            = sum(case when counter_name = 'Stolen Server Memory (KB)' then cntr_value else 0 end) 
   ,[MemoryGrantsOutstanding]       = sum(case when counter_name = 'Memory Grants Outstanding' then cntr_value else 0 end) 
   ,[MemoryGrantsPending]           = sum(case when counter_name = 'Memory Grants Pending' then cntr_value else 0 end) 
   ,[BatchRequestsSec]              = sum(case when counter_name = 'Batch Requests/sec' then cntr_value else 0 end) 
   ,[SQLCompliationsSec]            = sum(case when counter_name = 'SQL Compilations/sec' then cntr_value else 0 end) 
   ,[SQLReCompliationsSec]          = sum(case when counter_name = 'SQL Re-Compilations/sec' then cntr_value else 0 end) 
   ,[CheckpointPagesSec]            = sum(case when counter_name = 'Checkpoint pages/sec' then cntr_value else 0 end) 
   ,[LockWaitsSec]                  = sum(case when counter_name = 'Lock Waits/sec' then cntr_value else 0 end) 
   ,[BufferCacheHitRatio]           = sum(case when counter_name = 'Buffer cache hit ratio' then cntr_value else 0 end)  
   ,[BufferCacheHitRatioBase]       = sum(case when counter_name = 'Buffer cache hit ratio base' then cntr_value else 0 end) 
   ,[PageLifeExpectancy]            = sum(case when counter_name = 'Page life expectancy' then cntr_value else 0 end) 
   ,[LockWaits]                     = sum(case when counter_name like 'Lock waits%' then cntr_value else 0 end) 
   ,[MemoryGrantQueueWaits]         = sum(case when counter_name like 'Memory grant queue waits%' then cntr_value else 0 end) 
   ,[ThreadSafeMemoryObjectsWaits]  = sum(case when counter_name like 'Thread-safe memory objects waits%' then cntr_value else 0 end) 
   ,[LogWriteWaits]                 = sum(case when counter_name like 'Log write waits%' then cntr_value else 0 end) 
   ,[LogBufferWaits]                = sum(case when counter_name like 'Log buffer waits%' then cntr_value else 0 end) 
   ,[NetworkIOWaits]                = sum(case when counter_name like 'Network IO waits%' then cntr_value else 0 end) 
   ,[PageIOLatchWaits]              = sum(case when counter_name like 'Page IO latch waits%' then cntr_value else 0 end) 
   ,[PageLatchWaits]                = sum(case when counter_name like 'Page latch waits%' then cntr_value else 0 end) 
   ,[NonPageLatchWaits]             = sum(case when counter_name like 'Non-Page latch waits%' then cntr_value else 0 end) 
   ,[WaitForTheWorker]              = sum(case when counter_name like 'Wait for the worker%' then cntr_value else 0 end) 
   ,[WorkspaceSynchronizationWaits] = sum(case when counter_name like 'Workspace synchronization waits%' then cntr_value else 0 end) 
   ,[TransactionOwnershipWaits]     = sum(case when counter_name like 'Transaction ownership waits%' then cntr_value else 0 end) 
from  sys.dm_os_performance_counters
WHERE 
    (
            object_name like '%:Memory Manager%' 
        and counter_name in ('Database Cache Memory (KB)'
                            ,'Free Memory (KB)'
                            ,'Reserved Server Memory (KB)'
                            ,'Stolen Server Memory (KB)'
                            ,'Target Server Memory (KB)'
                            ,'Total Server Memory (KB)')
     )
or   (
            object_name like '%:Buffer Manager%' 
        and counter_name in ('Buffer cache hit ratio'
                            ,'Buffer cache hit ratio base'
                            ,'Page life expectancy'
                            ,'Checkpoint pages/sec')
     )
or   (
            object_name like '%:SQL Statistics%' 
        and counter_name in ('Batch Requests/sec'
                            ,'SQL Compilations/sec'
                            ,'SQL Re-Compilations/sec')
     )
or   (
            object_name like '%:Memory Manager%' 
        and counter_name in ('Memory Grants Outstanding'
                            ,'Memory Grants Pending')
     )
or   (
            object_name like '%:Locks%' 
        and counter_name in ('Lock Waits/sec')
        and instance_name = '_Total'
     )
or   (
            object_name like '%Wait Statistics%'
        and instance_name like 'Waits started per second%'
     )
),
OSInfo as
(
select 
    *
   ,case when cpu_count <= hyperthread_ratio then hyperthread_ratio else cpu_count end as CPUCount
   ,(
      (
        (
          (CAST(datediff(DAY, sqlserver_start_time, getdate()) as bigint)  * 24 * 60 * 60 * 1000) 
           + DATEDIFF(MS, DATEADD(day, datediff(DAY, sqlserver_start_time, getdate()), sqlserver_start_time), getdate())
             
        ) * (case when cpu_count <= hyperthread_ratio then hyperthread_ratio else cpu_count end)
      )
     - process_user_time_ms) as CPUIdle
    ,(select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = 'maximum degree of parallelism') as MAXDOP
    ,(select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = 'cost threshold for parallelism') as CTFP
from master.sys.dm_os_sys_info
)
select
    [CurrentServerTime]              = getdate()
   ,[physical_memory_kb]             = isnull(dm_os_sys_info.physical_memory_kb,0)
   ,[virtual_memory_kb]              = isnull(dm_os_sys_info.virtual_memory_kb,0)
   ,[total_memory_used_kb]           = isnull(perfcntr.TotalServerMemory,0)
   ,[target_memory_kb]               = isnull(perfcntr.TargetServerMemory,0)
   ,[database_cache_memory_kb]       = isnull(perfcntr.DatabaseCacheMemory,0)
   ,[free_memory_kb]                 = isnull(perfcntr.FreeMemory,0)
   ,[reserved_server_memory_kb]      = isnull(perfcntr.ReservedServerMemory,0)
   ,[stolen_server_memory_kb]        = isnull(perfcntr.StolenServerMemory,0)
   ,[MemoryGrantsOutstanding]        = isnull(perfcntr.MemoryGrantsOutstanding,0)
   ,[MemoryGrantsPending]            = isnull(perfcntr.MemoryGrantsPending,0)
   ,[batch_requests_sec]             = isnull(perfcntr.BatchRequestsSec,0)
   ,[sql_compilations_sec]           = isnull(perfcntr.SQLCompliationsSec,0)
   ,[sql_recompilations_sec]         = isnull(perfcntr.SQLReCompliationsSec,0)
   ,[checkpoint_pages_sec]           = isnull(perfcntr.CheckpointPagesSec,0)
   ,[lock_waits_sec]                 = isnull(perfcntr.LockWaitsSec,0)
   ,[BufferCacheHitRatio]            = case when perfcntr.BufferCacheHitRatioBase = 0 then 0.00 else isnull(cast((cast(perfcntr.BufferCacheHitRatio as float) / perfcntr.BufferCacheHitRatioBase) * 100 as numeric(5,2)),0) end
   ,[PageLifeExpectancy]             = isnull(perfcntr.PageLifeExpectancy,0)
   ,[CPU_Busy]                       = isnull(process_user_time_ms,0)
   ,[CPU_Idle]                       = isnull(CPUIdle,0)
   ,[CPUPercentage]                  = case when ((1.0 * CPUIdle +  process_user_time_ms) - (@inPrevCPUBusy + @inPrevCPUIdle)) = 0 then 0.00 else cast(round(isnull(((1.0 * process_user_time_ms - @inPrevCPUBusy) / ((1.0 * CPUIdle +  process_user_time_ms) - (@inPrevCPUBusy + @inPrevCPUIdle))),0),4) * 100 as decimal(5,2)) end
   ,[pack_received]                  = @@pack_received
   ,[pack_sent]                      = @@pack_sent
   ,[packet_errors]                  = @@packet_errors
   ,[total_read]                     = @@total_read
   ,[total_write]                    = @@total_write
   ,[total_errors]                   = @@total_errors
   ,[NetworkPacketsRecievedDelta]    = @@pack_received - case when @inPrevNetworkPacketsReceived = 0 then @@PACK_RECEIVED else @inPrevNetworkPacketsReceived end
   ,[NetworkPacketsSentDelta]        = @@PACK_sent - case when @inPrevNetworkPacketsSent = 0 then @@PACK_SENT else @inPrevNetworkPacketsSent end
   ,[PhysicalIOTotalReadsDelta]      = @@TOTAL_READ - case when @inPrevPhysicalIOReads = 0 then @@TOTAL_READ else @inPrevPhysicalIOReads end
   ,[PhysicalIOTotalWritesDelta]     = @@TOTAL_WRITE - case when @inPrevPhysicalIOWrites = 0 then @@TOTAL_WRITE else @inPrevPhysicalIOWrites end
   ,[io_busy]                        = @@io_busy
   ,[TotalSessions]                  = (select count(*) from sys.dm_exec_sessions)
   ,[TotalUsers]                     = (select count(distinct login_name) from sys.dm_exec_sessions)
   ,[LockWaits]                      = isnull(perfcntr.[LockWaits],'0')
   ,[MemoryGrantQueueWaits]          = isnull(perfcntr.[MemoryGrantQueueWaits],'0')
   ,[ThreadSafeMemoryObjectsWaits]   = isnull(perfcntr.[ThreadSafeMemoryObjectsWaits],'0')
   ,[LogWriteWaits]                  = isnull(perfcntr.[LogWriteWaits],'0')
   ,[LogBufferWaits]                 = isnull(perfcntr.[LogBufferWaits],'0')
   ,[NetworkIOWaits]                 = isnull(perfcntr.[NetworkIOWaits],'0')
   ,[PageIOLatchWaits]               = isnull(perfcntr.[PageIOLatchWaits],'0')
   ,[PageLatchWaits]                 = isnull(perfcntr.[PageLatchWaits],'0')
   ,[NonPageLatchWaits]              = isnull(perfcntr.[NonPageLatchWaits],'0')
   ,[WaitForTheWorker]               = isnull(perfcntr.[WaitForTheWorker],'0')
   ,[WorkspaceSynchronizationWaits]  = isnull(perfcntr.[WorkspaceSynchronizationWaits],'0')
   ,[TransactionOwnershipWaits]      = isnull(perfcntr.[TransactionOwnershipWaits],'0')
   ,[CurrentTimeOfDay]               = format(getdate(), 'HH:mm:ss')
   ,[batch_requests_sec_delta]       = case when isnull(perfcntr.BatchRequestsSec,0) - @inPrevBatchRecSec <= 0 or @inPrevBatchRecSec = 0 then 0 else ((1.0 * (isnull(perfcntr.BatchRequestsSec,0) - @inPrevBatchRecSec)) / ((1.0 * datediff(millisecond, @inPrevTime, GetDate())))) * 1000 end
   ,[sql_compilations_sec_delta]     = case when isnull(perfcntr.SQLCompliationsSec,0) - @inPrevSqlCompilationSec <= 0 or @inPrevSqlCompilationSec = 0 then 0 else ((1.0 * (isnull(perfcntr.SQLCompliationsSec,0) - @inPrevSqlCompilationSec)) / ((1.0 * datediff(millisecond, @inPrevTime, GetDate())))) * 1000 end
   ,[sql_recompilations_sec_delta]   = case when isnull(perfcntr.SQLReCompliationsSec,0) - @inPrevSqlReCompilationSec <= 0 or @inPrevSqlReCompilationSec = 0 then 0 else ((1.0 * (isnull(perfcntr.SQLReCompliationsSec,0) - @inPrevSqlReCompilationSec)) / ((1.0 * datediff(millisecond, @inPrevTime, GetDate())))) * 1000 end
   ,[checkpoint_pages_sec_delta]     = case when isnull(perfcntr.CheckpointPagesSec,0) - @inPrevCheckPointsSec <= 0 or @inPrevCheckPointsSec = 0 then 0 else ((1.0 * (isnull(perfcntr.CheckpointPagesSec,0) - @inPrevCheckPointsSec)) / ((1.0 * datediff(millisecond, @inPrevTime, GetDate())))) * 1000 end
   ,[lock_waits_sec_delta]           = case when isnull(perfcntr.LockWaitsSec,0) - @inPrevLockWaitsSec <= 0 or @inPrevLockWaitsSec = 0 then 0 else ((1.0 * (isnull(perfcntr.LockWaitsSec,0) - @inPrevLockWaitsSec)) / ((1.0 * datediff(millisecond, @inPrevTime, GetDate())))) * 1000 end
from OSInfo dm_os_sys_info, perfcntr

end";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
            }
            #endregion
            #region Build Connection Temporary Tables
            sql = @"
if object_id('tempdb..#SessionsCurrentValues') is null
	create table #SessionsCurrentValues
	(
		session_id smallint not null
	   ,login_time datetime
	   ,cpu_time int
	   ,memory_usage int
	   ,total_scheduled_time int
	   ,total_elapsed_time int
	   ,reads int
	   ,writes int
	   ,logical_reads bigint
	   ,row_count bigint
	   ,net_reads int
	   ,net_writes int
       ,blocking_session_id int
	   ,primary key (session_id)
	)
if object_id('tempdb..#SessionsPreviousValues') is null
	create table #SessionsPreviousValues
	(
		session_id smallint not null
	   ,login_time datetime
	   ,cpu_time int
	   ,memory_usage int
	   ,total_scheduled_time int
	   ,total_elapsed_time int
	   ,reads int
	   ,writes int
	   ,logical_reads bigint
	   ,row_count bigint
	   ,net_reads int
	   ,net_writes int
       ,blocking_session_id int
	   ,primary key (session_id)
	)
if object_id('tempdb..#ConnectionsCurrentValues') is null
	create table #ConnectionsCurrentValues
	(
		session_id smallint not null
	   ,connection_id uniqueidentifier not null
       ,num_reads bigint
       ,num_writes bigint
	   ,primary key (session_id, connection_id)
	)
if object_id('tempdb..#ConnectionsPreviousValues') is null
	create table #ConnectionsPreviousValues
	(
		session_id smallint not null
	   ,connection_id uniqueidentifier not null
       ,num_reads bigint
       ,num_writes bigint
	   ,primary key (session_id, connection_id)
	)
if object_id('tempdb..#RequestsCurrentValues') is null
	create table #RequestsCurrentValues
	(
		session_id smallint not null
	   ,request_id int not null
	   ,start_time datetime
       ,wait_time int
       ,open_transaction_count int
       ,open_resultset_count int
       ,percent_complete real
       ,cpu_time int
       ,total_elapsed_time int
       ,reads bigint
       ,writes bigint
       ,logical_reads bigint
       ,granted_query_memory int
	   ,primary key (session_id, request_id)
	)
if object_id('tempdb..#RequestsPreviousValues') is null
	create table #RequestsPreviousValues
	(
		session_id smallint not null
	   ,request_id int not null
	   ,start_time datetime
       ,wait_time int
       ,open_transaction_count int
       ,open_resultset_count int
       ,percent_complete real
       ,cpu_time int
       ,total_elapsed_time int
       ,reads bigint
       ,writes bigint
       ,logical_reads bigint
       ,granted_query_memory int
	   ,primary key (session_id, request_id)
	)
";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
            }
            #endregion
            #region GetSessionStats
            sql = @"
create procedure #GetSessionInfomation
as
begin
/*
if object_id('tempdb..#SessionsCurrentValues') is null
	create table #SessionsCurrentValues
	(
		session_id smallint not null
	   ,login_time datetime
	   ,cpu_time int
	   ,memory_usage int
	   ,total_scheduled_time int
	   ,total_elapsed_time int
	   ,reads int
	   ,writes int
	   ,logical_reads bigint
	   ,row_count bigint
	   ,net_reads int
	   ,net_writes int
       ,blocking_session_id int
	   ,primary key (session_id)
	)
if object_id('tempdb..#SessionsPreviousValues') is null
	create table #SessionsPreviousValues
	(
		session_id smallint not null
	   ,login_time datetime
	   ,cpu_time int
	   ,memory_usage int
	   ,total_scheduled_time int
	   ,total_elapsed_time int
	   ,reads int
	   ,writes int
	   ,logical_reads bigint
	   ,row_count bigint
	   ,net_reads int
	   ,net_writes int
       ,blocking_session_id int
	   ,primary key (session_id)
	)
if object_id('tempdb..#ConnectionsCurrentValues') is null
	create table #ConnectionsCurrentValues
	(
		session_id smallint not null
	   ,connection_id uniqueidentifier not null
       ,num_reads bigint
       ,num_writes bigint
	   ,primary key (session_id, connection_id)
	)
if object_id('tempdb..#ConnectionsPreviousValues') is null
	create table #ConnectionsPreviousValues
	(
		session_id smallint not null
	   ,connection_id uniqueidentifier not null
       ,num_reads bigint
       ,num_writes bigint
	   ,primary key (session_id, connection_id)
	)
if object_id('tempdb..#RequestsCurrentValues') is null
	create table #RequestsCurrentValues
	(
		session_id smallint not null
	   ,request_id int not null
	   ,start_time datetime
       ,wait_time int
       ,open_transaction_count int
       ,open_resultset_count int
       ,percent_complete real
       ,cpu_time int
       ,total_elapsed_time int
       ,reads bigint
       ,writes bigint
       ,logical_reads bigint
       ,granted_query_memory int
	   ,primary key (session_id, request_id)
	)
if object_id('tempdb..#RequestsPreviousValues') is null
	create table #RequestsPreviousValues
	(
		session_id smallint not null
	   ,request_id int not null
	   ,start_time datetime
       ,wait_time int
       ,open_transaction_count int
       ,open_resultset_count int
       ,percent_complete real
       ,cpu_time int
       ,total_elapsed_time int
       ,reads bigint
       ,writes bigint
       ,logical_reads bigint
       ,granted_query_memory int
	   ,primary key (session_id, request_id)
	)
*/
truncate table #SessionsPreviousValues
insert into #SessionsPreviousValues select * from #SessionsCurrentValues
truncate table #SessionsCurrentValues
insert into #SessionsCurrentValues
select 
	 dm_exec_Sessions.session_id
	,dm_exec_Sessions.login_time
	,dm_exec_Sessions.cpu_time + IsNull(RequestStats.cpu_time,0)
	,dm_exec_Sessions.memory_usage + IsNull(RequestStats.granted_query_memory,0)
	,dm_exec_Sessions.total_scheduled_time
	,dm_exec_Sessions.total_elapsed_time + IsNull(RequestStats.total_elapsed_time, 0)
	,dm_exec_Sessions.reads + IsNull(RequestStats.reads, 0)
	,dm_exec_Sessions.writes  + IsNull(RequestStats.writes, 0)
	,dm_exec_Sessions.logical_reads + IsNull(RequestStats.logical_reads, 0)
	,dm_exec_Sessions.row_count + IsNull(RequestStats.row_count, 0)
	,ConnectionStats.num_reads net_reads
	,ConnectionStats.num_writes net_writes
    ,isnull((select max(blocking_session_id) from sys.dm_exec_requests where dm_exec_requests.session_id = dm_exec_sessions.session_id),0) blocking_session_id
FROM sys.dm_exec_Sessions
	cross apply (select 
			 	 	 session_id
				    ,sum(num_reads) as num_reads
				    ,sum(num_writes) as num_writes
					,count(*) - 1 as num_child_connections
				 from  sys.dm_exec_connections connections
				 where connections.session_id = dm_exec_sessions.session_id
				 group by session_id) as ConnectionStats
	outer apply (select 
			 	 	 session_id
				    ,sum(cpu_time) as cpu_time
					,sum(requests.reads) as reads
					,sum(requests.logical_reads) as logical_reads
					,sum(requests.writes) as writes
					,sum(requests.granted_query_memory) as granted_query_memory
					,sum(requests.row_count) as row_count
					,sum(requests.total_elapsed_time) as total_elapsed_time
				 from  sys.dm_exec_requests requests
				 where requests.session_id = dm_exec_sessions.session_id
				 group by session_id) as RequestStats
truncate table #ConnectionsPreviousValues
insert into #ConnectionsPreviousValues select * from #ConnectionsCurrentValues
truncate table #ConnectionsCurrentValues
insert into #ConnectionsCurrentValues
select 
	dm_exec_connections.session_id
   ,dm_exec_connections.connection_id
   ,dm_exec_connections.num_reads
   ,dm_exec_connections.num_writes
from sys.dm_exec_connections
where exists (select 1 
              from #SessionsCurrentValues CurrentSessions
			  where currentSessions.session_id = dm_exec_connections.session_id)
truncate table #RequestsPreviousValues
insert into #RequestsPreviousValues select * from #RequestsCurrentValues
truncate table #RequestsCurrentValues
insert into #RequestsCurrentValues
select 
	dm_exec_requests.session_id
   ,dm_exec_requests.request_id
   ,dm_exec_requests.start_time
   ,dm_exec_requests.wait_time
   ,dm_exec_requests.open_transaction_count
   ,dm_exec_requests.open_resultset_count
   ,dm_exec_requests.percent_complete
   ,dm_exec_requests.cpu_time
   ,dm_exec_requests.total_elapsed_time
   ,dm_exec_requests.reads
   ,dm_exec_requests.writes
   ,dm_exec_requests.logical_reads
   ,dm_exec_requests.granted_query_memory
from sys.dm_exec_requests
where exists (select 1 
              from #SessionsCurrentValues CurrentSessions
			  where currentSessions.session_id = dm_exec_requests.session_id)

select *
from (
SELECT 
       [dm_exec_Sessions].[session_id]
      ,GetDate() as [RefreshedLast]
      ,1 as [IsConnected]
      ,[dm_exec_Sessions].[login_time]
      ,[dm_exec_Sessions].[host_name]
      ,[dm_exec_Sessions].[program_name]
      ,[dm_exec_Sessions].[host_process_id]
      ,[dm_exec_Sessions].[client_version]
      ,[dm_exec_Sessions].[client_interface_name]
      ,[dm_exec_Sessions].[login_name]
      ,[dm_exec_Sessions].[nt_domain]
      ,[dm_exec_Sessions].[nt_user_name]
      ,case when [SessionStats].blocking_session_id > 0 then 'LOCKED (' + format([SessionStats].blocking_session_id, '0') + ')' else [dm_exec_Sessions].[status] end status
      ,isnull([SessionStats].[cpu_time],[dm_exec_Sessions].[cpu_time]) cpu_time
      ,isnull([SessionStats].[memory_usage],[dm_exec_Sessions].[memory_usage]) memory_usage
      ,isnull([SessionStats].[total_scheduled_time],[dm_exec_Sessions].[total_scheduled_time]) [total_scheduled_time]
      ,isnull([SessionStats].[total_elapsed_time],[dm_exec_Sessions].[total_elapsed_time]) [total_elapsed_time]
      ,[dm_exec_Sessions].[endpoint_id]
      ,[dm_exec_Sessions].[last_request_start_time]
      ,[dm_exec_Sessions].[last_request_end_time]
      ,isnull([SessionStats].[reads],[dm_exec_Sessions].[reads]) [reads]
      ,isnull([SessionStats].[writes],[dm_exec_Sessions].[writes]) [writes]
      ,isnull([SessionStats].[logical_reads],[dm_exec_Sessions].[logical_reads]) [logical_reads]
      ,[dm_exec_Sessions].[is_user_process]
      ,[dm_exec_Sessions].[text_size]
      ,[dm_exec_Sessions].[language]
      ,[dm_exec_Sessions].[date_format]
      ,[dm_exec_Sessions].[date_first]
      ,[dm_exec_Sessions].[quoted_identifier]
      ,[dm_exec_Sessions].[arithabort]
      ,[dm_exec_Sessions].[ansi_null_dflt_on]
      ,[dm_exec_Sessions].[ansi_defaults]
      ,[dm_exec_Sessions].[ansi_warnings]
      ,[dm_exec_Sessions].[ansi_padding]
      ,[dm_exec_Sessions].[ansi_nulls]
      ,[dm_exec_Sessions].[concat_null_yields_null]
      ,[dm_exec_Sessions].[transaction_isolation_level]
      ,[dm_exec_Sessions].[lock_timeout]
      ,[dm_exec_Sessions].[deadlock_priority]
      ,isnull([SessionStats].[row_count],[dm_exec_Sessions].[row_count]) [row_count]
      ,[dm_exec_Sessions].[prev_error]
      ,[dm_exec_Sessions].[original_login_name]
      ,[dm_exec_Sessions].[last_successful_logon]
      ,[dm_exec_Sessions].[last_unsuccessful_logon]
      ,[dm_exec_Sessions].[unsuccessful_logons]
      ,[dm_exec_Sessions].[group_id]
      ,DB_NAME([dm_exec_Sessions].[database_id]) as DatabaseName
      ,[dm_exec_Sessions].[open_transaction_count]
--      ,[dm_exec_Sessions].[page_server_reads]
	  ,[dm_exec_connections].[connect_time]
	  ,[dm_exec_connections].[net_transport]
	  ,[dm_exec_connections].[protocol_type]
	  ,convert(varchar(10), CONVERT(VARBINARY(9), protocol_version), 1) as protocol_version
	  ,CASE CONVERT(VARBINARY(9), protocol_version)
          WHEN 0x07000000 THEN 'SQL 7.0'
          WHEN 0x07010000 THEN 'SQL 2000'   
          WHEN 0x71000001 THEN 'SQL 2000 SP1'
          WHEN 0x72090002 THEN 'SQL 2005'
          WHEN 0x730A0003 THEN 'SQL 2008'
          WHEN 0x730B0003 THEN 'SQL 2008'
          WHEN 0x74000004 THEN 'SQL 2012+'
          ELSE convert(varchar(10), CONVERT(VARBINARY(9), protocol_version), 1)
       END AS [TDSVersion]
	   ,lower([dm_exec_connections].[encrypt_option]) as encrypt_option
	   ,[dm_exec_connections].[auth_scheme]
	   ,[dm_exec_connections].[node_affinity]
	   ,isnull([SessionStats].net_reads,dm_exec_connections.[num_reads]) net_reads
	   ,isnull([SessionStats].net_writes,dm_exec_connections.[num_writes]) net_writes
	   ,isnull((select count(*) from sys.dm_exec_connections where dm_exec_connections.session_id = dm_exec_sessions.session_id and dm_exec_connections.parent_connection_id is not null),0) num_MARS_child_connections
	   ,[dm_exec_connections].[last_read]
	   ,[dm_exec_connections].[last_write]
	   ,[dm_exec_connections].[net_packet_size]
	   ,[dm_exec_connections].[client_net_address]
	   ,[dm_exec_connections].[client_tcp_port]
	   ,[dm_exec_connections].[local_net_address]
	   ,[dm_exec_connections].[local_tcp_port]
       ,format(isnull([SessionStats].[cpu_time],[dm_exec_Sessions].[cpu_time]), '#,##0') + ' (' + format(isnull([SessionStats].[cpu_time_delta],[dm_exec_Sessions].[cpu_time]), '#,##0') + ')' CPUTimeDisplay
       ,format(isnull([SessionStats].[memory_usage],[dm_exec_Sessions].[memory_usage]), '#,##0') + ' (' + format(isnull([SessionStats].[memory_usage_delta],[dm_exec_Sessions].[memory_usage]), '#,##0') + ')' MemoryUsageDisplay
       ,format([dm_exec_Sessions].[total_scheduled_time], '#,##0') + ' (' + format(isnull([SessionStats].[total_scheduled_time_delta],[dm_exec_Sessions].[total_scheduled_time]), '#,##0') + ')' TotalScheduledTimeDisplay
       ,format(isnull([SessionStats].[total_elapsed_time],[dm_exec_Sessions].[total_elapsed_time]), '#,##0') + ' (' + format(isnull([SessionStats].[total_elapsed_time_delta],[dm_exec_Sessions].[total_elapsed_time]), '#,##0') + ')' TotalElapsedTimeDisplay
       ,format(isnull([SessionStats].[reads],[dm_exec_Sessions].[reads]), '#,##0') + ' (' + format(isnull([SessionStats].[reads_delta],[dm_exec_Sessions].[reads]), '#,##0') + ')' ReadsDisplay
       ,format(isnull([SessionStats].[writes],[dm_exec_Sessions].[writes]), '#,##0') + ' (' + format(isnull([SessionStats].[writes_delta],[dm_exec_Sessions].[writes]), '#,##0') + ')' WritesDisplay
       ,format([dm_exec_connections].[num_reads], '#,##0') + ' (' + format(isnull([SessionStats].[net_reads_delta],[dm_exec_connections].[num_reads]), '#,##0') + ')' NetReadsDisplay
       ,format([dm_exec_connections].[num_writes], '#,##0') + ' (' + format(isnull([SessionStats].[net_writes_delta],[dm_exec_connections].[num_writes]), '#,##0') + ')' NetWritesDisplay
       ,isnull([SessionStats].[cpu_time_delta],[dm_exec_Sessions].[cpu_time]) cpu_time_delta
       ,isnull([SessionStats].[memory_usage_delta],[dm_exec_Sessions].[memory_usage]) memory_usage_delta
       ,isnull([SessionStats].[total_scheduled_time_delta],[dm_exec_Sessions].[total_scheduled_time]) [total_scheduled_time_delta]
       ,isnull([SessionStats].[total_elapsed_time_delta],[dm_exec_Sessions].[total_elapsed_time]) [total_elapsed_time_delta]
       ,isnull([SessionStats].[reads_delta],[dm_exec_Sessions].[reads]) [reads_delta]
       ,isnull([SessionStats].[writes_delta],[dm_exec_Sessions].[writes]) [writes_delta]
       ,isnull([SessionStats].[logical_reads_delta],[dm_exec_Sessions].[logical_reads]) [logical_reads_delta]
       ,isnull([SessionStats].[row_count_delta],[dm_exec_Sessions].[row_count]) [row_count_delta]
	   ,isnull([SessionStats].net_reads_delta,dm_exec_connections.[num_reads]) net_reads_delta
	   ,isnull([SessionStats].net_writes_delta,dm_exec_connections.[num_writes]) net_writes_delta
	   ,isnull([SessionStats].blocking_session_id,0) blocking_session_id
	   ,case when isnull([SessionStats].blocking_session_id,0) > 0 then 'BLOCKED'
	         when isnull([SessionStats].[cpu_time_delta],0) > 0 and [dm_exec_Sessions].[status] = 'sleeping' then 'FINISHED'
	         when [dm_exec_Sessions].[status] != 'sleeping' then 'PROCESSING'
	         else 'SLEEPING         '
		end as SessionBackColor
FROM sys.dm_exec_Sessions
	join sys.dm_exec_connections
		on dm_exec_sessions.session_id = dm_exec_connections.session_id
		and dm_exec_connections.parent_connection_id is null
	outer apply (
				 select 
					currentValues.cpu_time
				   ,currentValues.memory_usage
				   ,currentValues.total_scheduled_time
				   ,currentValues.total_elapsed_time
				   ,currentValues.reads
				   ,currentValues.writes
				   ,currentValues.logical_reads
				   ,currentValues.row_count
				   ,currentValues.net_reads
				   ,currentValues.net_writes
                   ,currentValues.blocking_session_id
				   ,case when previousValues.cpu_time is null then 0 else currentValues.cpu_time - previousValues.cpu_time end cpu_time_delta
				   ,case when previousValues.cpu_time is null then 0 else currentValues.memory_usage - isnull(previousValues.memory_usage,0) end memory_usage_delta
				   ,case when previousValues.cpu_time is null then 0 else currentValues.total_scheduled_time - isnull(previousValues.total_scheduled_time,0) end total_scheduled_time_delta
				   ,case when previousValues.cpu_time is null then 0 else currentValues.total_elapsed_time - isnull(previousValues.total_elapsed_time,0) end total_elapsed_time_delta
				   ,case when previousValues.cpu_time is null then 0 else currentValues.reads - isnull(previousValues.reads,0) end reads_delta
				   ,case when previousValues.cpu_time is null then 0 else currentValues.writes - isnull(previousValues.writes,0) end writes_delta
				   ,case when previousValues.cpu_time is null then 0 else currentValues.logical_reads - isnull(previousValues.logical_reads,0) end logical_reads_delta
				   ,case when previousValues.cpu_time is null then 0 else currentValues.row_count - isnull(previousValues.row_count,0) end row_count_delta
				   ,case when previousValues.cpu_time is null then 0 else currentValues.net_reads - isnull(previousValues.net_reads,0) end net_reads_delta
				   ,case when previousValues.cpu_time is null then 0 else currentValues.net_writes - isnull(previousValues.net_writes,0) end net_writes_delta
				 from #SessionsCurrentValues currentValues
					left outer join #SessionsPreviousValues previousValues
						on currentValues.session_id = previousValues.session_id
				 where currentValues.session_id = dm_exec_sessions.session_id
				 and currentValues.login_time = dm_exec_sessions.login_time
				) as SessionStats
) as SessionInformation

select *
from (
select
     currentValues.session_id
	,currentValues.login_time
	,currentValues.cpu_time
	,currentValues.memory_usage
	,currentValues.total_scheduled_time
	,currentValues.total_elapsed_time
	,currentValues.reads
	,currentValues.writes
	,currentValues.logical_reads
	,currentValues.row_count
	,currentValues.net_reads
	,currentValues.net_writes
	,case when previousValues.cpu_time is null then 0 else currentValues.cpu_time - previousValues.cpu_time end cpu_time_delta
	,case when previousValues.cpu_time is null then 0 else currentValues.memory_usage - isnull(previousValues.memory_usage,0) end memory_usage_delta
	,case when previousValues.cpu_time is null then 0 else currentValues.total_scheduled_time - isnull(previousValues.total_scheduled_time,0) end total_scheduled_time_delta
	,case when previousValues.cpu_time is null then 0 else currentValues.total_elapsed_time - isnull(previousValues.total_elapsed_time,0) end total_elapsed_time_delta
	,case when previousValues.cpu_time is null then 0 else currentValues.reads - isnull(previousValues.reads,0) end reads_delta
	,case when previousValues.cpu_time is null then 0 else currentValues.writes - isnull(previousValues.writes,0) end writes_delta
	,case when previousValues.cpu_time is null then 0 else currentValues.logical_reads - isnull(previousValues.logical_reads,0) end logical_reads_delta
	,case when previousValues.cpu_time is null then 0 else currentValues.row_count - isnull(previousValues.row_count,0) end row_count_delta
	,case when previousValues.cpu_time is null then 0 else currentValues.net_reads - isnull(previousValues.net_reads,0) end net_reads_delta
	,case when previousValues.cpu_time is null then 0 else currentValues.net_writes - isnull(previousValues.net_writes,0) end net_writes_delta
    ,getDate() as currentDateStamp
from #SessionsCurrentValues currentValues
left outer join #SessionsPreviousValues previousValues
	on currentValues.session_id = previousValues.session_id
) as SessionStatistics
select 
	 [dm_exec_requests].[session_id]
	,[dm_exec_requests].[request_id]
	,[dm_exec_requests].[start_time]
	,[dm_exec_requests].[status]
	,[dm_exec_requests].[command]
	,DB_NAME([dm_exec_requests].[database_id]) as database_name
	,[dm_exec_requests].[blocking_session_id]
	,[dm_exec_requests].[wait_type]
	,isnull(requeststats.wait_time, [dm_exec_requests].[wait_time]) wait_time
	,[dm_exec_requests].[last_wait_type]
	,[dm_exec_requests].[wait_resource]
	,isnull(requeststats.open_transaction_count, [dm_exec_requests].[open_transaction_count]) [open_transaction_count]
	,isnull(requeststats.open_resultset_count, [dm_exec_requests].[open_resultset_count]) [open_resultset_count]
	,[dm_exec_requests].[transaction_id]
	,[dm_exec_requests].[percent_complete]
	,[dm_exec_requests].[estimated_completion_time]
	,isnull(requeststats.cpu_time, [dm_exec_requests].[cpu_time]) [cpu_time]
	,isnull(requeststats.total_elapsed_time, [dm_exec_requests].[total_elapsed_time]) [total_elapsed_time]
	,isnull(requeststats.reads, [dm_exec_requests].[reads]) [reads]
	,isnull(requeststats.writes, [dm_exec_requests].[writes]) [writes]
	,isnull(requeststats.logical_reads, [dm_exec_requests].[logical_reads]) [logical_reads]
	,[dm_exec_requests].[text_size]
	,[dm_exec_requests].[language]
	,[dm_exec_requests].[date_format]
	,[dm_exec_requests].[date_first]
	,[dm_exec_requests].[quoted_identifier]
	,[dm_exec_requests].[arithabort]
	,[dm_exec_requests].[ansi_null_dflt_on]
	,[dm_exec_requests].[ansi_defaults]
	,[dm_exec_requests].[ansi_warnings]
	,[dm_exec_requests].[ansi_padding]
	,[dm_exec_requests].[ansi_nulls]
	,[dm_exec_requests].[concat_null_yields_null]
	,case [dm_exec_requests].[transaction_isolation_level] 
          when 0 then '0 - Unspecified'
          when 1 then '0 - Read Uncomitted'
          when 2 then '0 - Read Comitted'
          when 3 then '0 - Repeatable'
          when 4 then '0 - Serializable'
          when 5 then '0 - Snapshot'
          else cast([dm_exec_requests].[transaction_isolation_level] as varchar) + ' - Unknown'
    end [transaction_isolation_level] 
	,[dm_exec_requests].[lock_timeout]
	,[dm_exec_requests].[deadlock_priority]
	,[dm_exec_requests].[row_count]
	,[dm_exec_requests].[prev_error]
	,[dm_exec_requests].[nest_level]
	,isnull(requeststats.granted_query_memory, [dm_exec_requests].[granted_query_memory]) granted_query_memory
	,[dm_exec_requests].[executing_managed_code]
	,[dm_exec_requests].[dop]
	,[dm_exec_requests].[parallel_worker_count]
	,[dm_exec_requests].[is_resumable]
--	,[dm_exec_requests].[page_server_reads]
	,requeststats.wait_time_delta
	,requeststats.open_transaction_count_delta
	,requeststats.percent_complete_delta
	,requeststats.cpu_time_delta
	,requeststats.total_elapsed_time_delta
	,requeststats.reads_delta
	,requeststats.writes_delta
	,requeststats.logical_reads_delta
	,requeststats.granted_query_memory_delta
from sys.dm_exec_requests
	cross apply (
				 select 
				    currentValues.wait_time
				   ,currentValues.open_transaction_count
				   ,currentValues.open_resultset_count
				   ,currentValues.percent_complete
				   ,currentValues.cpu_time
				   ,currentValues.total_elapsed_time
				   ,currentValues.reads
				   ,currentValues.writes
				   ,currentValues.logical_reads
				   ,CurrentValues.granted_query_memory
				   ,currentValues.wait_time - isnull(previousValues.wait_time,0) wait_time_delta
				   ,currentValues.open_transaction_count - isnull(previousValues.open_transaction_count,0) open_transaction_count_delta
				   ,currentValues.percent_complete - isnull(previousValues.percent_complete,0) percent_complete_delta
				   ,currentValues.cpu_time - isnull(previousValues.cpu_time,0) cpu_time_delta
				   ,currentValues.total_elapsed_time - isnull(previousValues.total_elapsed_time,0) total_elapsed_time_delta
				   ,currentValues.reads - isnull(previousValues.reads,0) reads_delta
				   ,currentValues.writes - isnull(previousValues.writes,0) writes_delta
				   ,currentValues.logical_reads - isnull(previousValues.logical_reads,0) logical_reads_delta
				   ,currentValues.granted_query_memory - isnull(previousValues.granted_query_memory,0) granted_query_memory_delta
				 from #RequestsCurrentValues CurrentValues
					left outer join #RequestsPreviousValues PreviousValues
						on CurrentValues.session_id = PreviousValues.session_id
						and CurrentValues.request_id = PreviousValues.request_id
						and CurrentValues.start_time = PreviousValues.start_time
				 where CurrentValues.session_id = dm_exec_requests.session_id
				 and CurrentValues.request_id = dm_exec_requests.request_id
				 and CurrentValues.start_time = dm_exec_requests.start_time
				) as requeststats

select 
    [dm_exec_connections].[session_id]
   ,[dm_exec_connections].[connect_time]
   ,[dm_exec_connections].[net_transport]
   ,[dm_exec_connections].[protocol_type]
   ,convert(varchar(10), CONVERT(VARBINARY(9), protocol_version), 1) as protocol_version
  ,CASE CONVERT(VARBINARY(9), protocol_version)
		WHEN 0x07000000 THEN 'SQL 7.0'
		WHEN 0x07010000 THEN 'SQL 2000'   
		WHEN 0x71000001 THEN 'SQL 2000 SP1'
		WHEN 0x72090002 THEN 'SQL 2005'
		WHEN 0x730A0003 THEN 'SQL 2008'
		WHEN 0x730B0003 THEN 'SQL 2008'
		WHEN 0x74000004 THEN 'SQL 2012+'
		ELSE convert(varchar(10), CONVERT(VARBINARY(9), protocol_version), 1)
	END AS [TDSVersion]
   ,[dm_exec_connections].[encrypt_option]
   ,[dm_exec_connections].[auth_scheme]
   ,[dm_exec_connections].[node_affinity]
   ,Connectionstats.[num_reads]
   ,Connectionstats.[num_writes]
   ,Connectionstats.[num_reads_delta]
   ,Connectionstats.[num_writes_delta]
   ,[dm_exec_connections].[last_read]
   ,[dm_exec_connections].[last_write]
   ,[dm_exec_connections].[net_packet_size]
   ,[dm_exec_connections].[client_net_address]
   ,[dm_exec_connections].[client_tcp_port]
   ,[dm_exec_connections].[local_net_address]
   ,[dm_exec_connections].[local_tcp_port]
   ,cast([dm_exec_connections].[connection_id] as varchar(100)) connection_id
   ,cast([dm_exec_connections].[parent_connection_id] as varchar(100)) parent_connection_id
from sys.dm_exec_connections
	cross apply (
				 select 
				    currentValues.num_reads
				   ,currentValues.num_writes
				   ,currentValues.num_reads - isnull(previousValues.num_reads,0) num_reads_delta
				   ,currentValues.num_writes - isnull(previousValues.num_writes,0) num_writes_delta
				 from #ConnectionsCurrentValues CurrentValues
					left outer join #ConnectionsPreviousValues PreviousValues
						on CurrentValues.session_id = PreviousValues.session_id
						and CurrentValues.connection_id = PreviousValues.connection_id
				 where CurrentValues.session_id = dm_exec_connections.session_id
				 and CurrentValues.connection_id = dm_exec_connections.connection_id
				) as Connectionstats
select 
	session_id
   ,wait_type
   ,waiting_tasks_count
   ,wait_time_ms
   ,max_wait_time_ms
   ,signal_wait_time_ms
from sys.dm_exec_session_wait_stats


select
	s.session_id
   ,st.encrypted
   ,isnull(db_name(st.dbid), '') as database_name
   ,isnull(object_schema_name(st.objectid, st.dbid), '') as [object_schema_name]
   ,isnull(object_name(st.objectid, st.dbid), '') as [object_name]
   ,case when st.encrypted = 1 then '<Encrypted>' else st.text end as text
   ,isnull((r.statement_start_offset / 2) + 1,-1) as statement_start_offset
   ,isnull(cast((case r.statement_end_offset
         when -1 then DATALENGTH(st.text)
		 else (r.statement_end_offset / 2) + 1
	 end) - (r.statement_start_offset / 2) as int),-1) as statement_length
   ,input_buffer.event_info
   ,input_buffer.event_type
   ,input_buffer.parameters
   ,case when event_type = 'No Event' then '<No Event>'
         when st.objectid is null then '<Adhoc Batch>'
         else '[' + isnull(db_name(st.dbid), '') + '].[' + isnull(object_schema_name(st.objectid, st.dbid), '') + '].[' + isnull(object_name(st.objectid, st.dbid), '') + ']'
	end as object_title
   ,'  Event Type: ' + event_type as event_title
from sys.dm_exec_sessions s
	outer apply (select top 1 r.request_id, r.plan_handle, r.sql_handle, r.statement_start_offset, r.statement_end_offset
	             from sys.dm_exec_requests r
				 where r.session_id = s.session_id
				 order by r.request_id) r
	outer  apply sys.dm_exec_sql_text(r.sql_handle) st
	outer apply sys.dm_exec_input_buffer(session_id, request_id) input_buffer
where exists (select 1 from sys.dm_exec_connections where dm_exec_connections.session_id = s.session_id)
end
";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
            }
            #endregion
        }
        private void CreateDBSpaceProcedure(SqlConnection conn)
        {
            #region GetDatabaseInformation
            string sql = @"
create procedure #GetDatabaseInformation
 	@inQuickScan bit = 0
as
/*
exec #GetDatabaseInformation @inQuickScan = 1
exec #GetDatabaseInformation @inQuickScan = 0
*/
begin
DECLARE @SQL VARCHAR(5000)   
DECLARE	@QuickScan bit = @inQuickScan

declare @backupResults table
(
	database_id int not null
   ,restore_date datetime
   ,last_full_backup datetime
   ,last_full_backup_size numeric(20,0)
   ,last_full_backup_compressed_size numeric(20,0)
   ,last_other_backup datetime
   ,last_other_backup_size numeric(20,0)
   ,last_other_backup_compressed_size numeric(20,0)
   ,last_other_backup_type char(1)
)
DROP TABLE if exists #Results
create table #Results(
[database_id] int,
[Database_Name] sysname, 
[File Name] sysname, 
[Physical Name] NVARCHAR(260),
[File Type] VARCHAR(20), 
[Total Size in Mb] int, 
[Available Space in Mb] int, 
[Growth Units] VARCHAR(15), 
[Max File Size in Mb] int)   

if @QuickScan = 0
begin
	SELECT @SQL =    
'USE [?] 
insert into #Results
([database_id], [Database_Name], [File Name], [Physical Name], [File Type], [Total Size in Mb], [Available Space in Mb], [Growth Units], [Max File Size in Mb])
SELECT 
    DB_ID() database_id
   ,DB_NAME() DatabaseName   
   ,[name] AS [FileName]    
   ,physical_name AS [PhysicalName]    
   ,type_desc AS [FileType]
   ,CASE ceiling([size]/128)    
		WHEN 0 THEN 1   
		ELSE ceiling([size]/128)   
    END as SizeMB
   ,CASE ceiling([size]/128)   
         WHEN 0 THEN (1 - CAST(FILEPROPERTY([name], ''SpaceUsed'') as int) /128)   
         ELSE (([size]/128) - CAST(FILEPROPERTY([name], ''SpaceUsed'') as int) /128)   
    END  as SpaceUsed
   ,CASE [is_percent_growth]    
         WHEN 1 THEN CAST(growth AS varchar(20)) + ''%'' 
		 ELSE CAST(growth*8/1024 AS varchar(20)) + ''Mb''
    END AS Growth
   ,CASE [max_size]   
         WHEN -1 THEN NULL   
         WHEN 268435456 THEN NULL
         ELSE [max_size]/128  
    END as MaxSize
FROM sys.database_files   
ORDER BY [Type], [file_id]'   

	EXEC sp_MSforeachdb @SQL   

	insert into #Results
	([database_id], [Database_Name], [File Name], [Physical Name], [File Type], [Total Size in Mb], [Available Space in Mb], [Growth Units], [Max File Size in Mb])
	SELECT 
	    database_id
	   ,DB_NAME(database_id) DatabaseName   
	   ,[name] AS [FileName]    
	   ,physical_name AS [PhysicalName]    
	   ,type_desc AS [FileType]
	   ,CASE ceiling([size]/128)    
			WHEN 0 THEN 1   
			ELSE ceiling([size]/128)   
		END as SizeMB
	   ,-1 SpaceUsed
	   ,CASE [is_percent_growth]    
			 WHEN 1 THEN CAST(growth AS varchar(20)) + '%' 
			 ELSE CAST(growth*8/1024 AS varchar(20)) + 'Mb'
		END AS Growth
	   ,CASE [max_size]   
			 WHEN -1 THEN NULL   
			 WHEN 268435456 THEN NULL
			 ELSE [max_size]/128  
		END as MaxSize
	FROM sys.master_files   
	where not exists (select 1 from #Results r where r.[Database_Name] = DB_NAME(master_files.database_id))
	ORDER BY [Type], [file_id]   

	;with outpt as
	(
		select distinct database_id, [Database_Name]
		from #Results
	)
	insert into @backupResults
	(
		database_id
	   ,restore_date
	   ,last_full_backup
	   ,last_full_backup_size
	   ,last_full_backup_compressed_size
	   ,last_other_backup
	   ,last_other_backup_size
	   ,last_other_backup_compressed_size
	   ,last_other_backup_type
	  )
	select
		database_id
	   ,(select 
             max(restore_date) as restore_date
         from msdb..restorehistory
	     where restorehistory.destination_database_name = results.[Database_Name]) restore_date
	   ,fullBackup.backup_finish_date LastFullBackupDate
	   ,FullBackup.backup_size / power(1024,2)     LastFullBackupSize
	   ,FullBackup.compressed_backup_size / power(1024,2) LastFullBackupCompressedSize
	   ,NonFullBackup.backup_finish_date LastNonFullBackupDate
	   ,NonFullBackup.backup_size / power(1024,2)     LastNonFullBackupSize
	   ,NonFullBackup.compressed_backup_size / power(1024,2) LastNonFullBackupCompressedSize
	   ,NonFullBackup.BackupType LastNonFullBackupType
	from outpt results
		outer apply (select top 1  
	                  backup_finish_date
	                 ,backup_size
					 ,compressed_backup_size
	             from msdb..backupset
				 where backupset.database_name = results.[Database_Name]
				 and backupset.type = 'D'
				 and isnull(is_copy_only,0) = 0
				 order by backupset.backup_finish_date desc) fullBackup
	outer apply (select top 1  
	                  backup_finish_date
	                 ,backup_size
					 ,compressed_backup_size
					 ,[type] backupType
	             from msdb..backupset
				 where backupset.database_name = results.[Database_Name]
				 and backupset.type != 'D'
				 order by backupset.backup_finish_date desc) NonFullBackup

end
else
begin
	insert into #Results
	([database_id], [Database_Name], [File Name], [Physical Name], [File Type], [Total Size in Mb], [Available Space in Mb], [Growth Units], [Max File Size in Mb])
	SELECT 
	    database_id
	   ,DB_NAME(database_id) DatabaseName   
	   ,[name] AS [FileName]    
	   ,physical_name AS [PhysicalName]    
	   ,type_desc AS [FileType]
	   ,CASE ceiling([size]/128)    
			WHEN 0 THEN 1   
			ELSE ceiling([size]/128)   
		END as SizeMB
	   ,-1 SpaceUsed
	   ,CASE [is_percent_growth]    
			 WHEN 1 THEN CAST(growth AS varchar(20)) + '%' 
			 ELSE CAST(growth*8/1024 AS varchar(20)) + 'Mb'
		END AS Growth
	   ,CASE [max_size]   
			 WHEN -1 THEN NULL   
			 WHEN 268435456 THEN NULL
			 ELSE [max_size]/128  
		END as MaxSize
	FROM sys.master_files   
	ORDER BY [Type], [file_id]   
end

--Return the Results   
;with outpt as
(
SELECT   
T.database_id,
T.[Database_Name],   
cast(Format(T.[Total Size in Mb], '#,##0') as varchar(20)) AS [db_size_mb],   
cast(case when T.[Available Space in Mb] >= 0 then Format(T.[Available Space in Mb], '#,##0') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end as varchar(20))  AS [DB_Free_Mb],   
cast(case when T.[Available Space in Mb] >= 0 then Format(T.[Consumed Space in Mb], '#,##0') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end as varchar(20))  AS [DB_Used_Mb],   
cast(Format(D.[Total Size in Mb], '#,##0') as varchar(20))  AS [Data_Size_Mb],   
cast(case when T.[Available Space in Mb] >= 0 then Format(D.[Available Space in Mb], '#,##0') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end as varchar(20))  AS [Data_Free_Mb],   
cast(case when T.[Available Space in Mb] >= 0 then Format(D.[Consumed Space in Mb], '#,##0') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end as varchar(20))  AS [Data_Used_Mb],   
cast(case when T.[Available Space in Mb] >= 0 then Format((1.0 * D.[Available Space in Mb])/D.[Total Size in Mb], '#,##0.00%') else  case when @QuickScan = 1 then 'Scanning...' else 'No Access' end  end as varchar(20))  AS [Data_Free_Pct],   
cast(Format(L.[Total Size in Mb], '#,##0') as varchar(20))  AS [Log_Size_Mb],   
cast(case when T.[Available Space in Mb] >= 0 then Format(L.[Available Space in Mb], '#,##0') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end as varchar(20))  AS [Log_Free_Mb],   
cast(case when T.[Available Space in Mb] >= 0 then Format(L.[Consumed Space in Mb], '#,##0') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end as varchar(20))  AS [Log_Used_Mb],   
cast(case when T.[Available Space in Mb] >= 0 then Format((1.0 * L.[Available Space in Mb])/L.[Total Size in Mb], '#,##0.00%') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end as varchar(20))  AS [Log_Free_Pct],   
cast(Format(FS.[Total Size in Mb], '#,##0') as varchar(20))  AS [FileStream_Mb],   
cast(case when FS.[Total Size in Mb] is null then NULL when T.[Available Space in Mb] >= 0 then Format(FS.[Available Space in Mb], '#,##0') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end as varchar(20))  AS [FileStream_Free_Mb],   
cast(case when FS.[Total Size in Mb] is null then NULL when T.[Available Space in Mb] >= 0 then Format(FS.[Consumed Space in Mb], '#,##0') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end as varchar(20))  AS [FileStream_Used_Mb],   
cast(case when FS.[Total Size in Mb] is null then NULL when T.[Available Space in Mb] >= 0 then Format((1.0 * FS.[Available Space in Mb])/FS.[Total Size in Mb], '#,##0.00%') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end as varchar(20))  AS [FileStream_Free_Pct],   
T.[Total Size in Mb] AS [Sort_DB_Size_Mb],   
case when T.[Available Space in Mb] >= 0 then T.[Available Space in Mb] else case when @QuickScan = 1 then 0 else 0 end end AS [Sort_DB_Free_Mb],   
case when T.[Available Space in Mb] >= 0 then T.[Consumed Space in Mb] else case when @QuickScan = 1 then 0 else 0 end end AS [Sort_DB_Used_Mb],   
D.[Total Size in Mb] AS [Sort_Data_Size_Mb],   
case when T.[Available Space in Mb] >= 0 then D.[Available Space in Mb] else case when @QuickScan = 1 then 0 else 0 end end AS [Sort_Data_Free_Mb],   
case when T.[Available Space in Mb] >= 0 then D.[Consumed Space in Mb] else case when @QuickScan = 1 then 0 else 0 end end AS [Sort_Data_Used_Mb],   
case when T.[Available Space in Mb] >= 0 then (1.0 * D.[Available Space in Mb])/D.[Total Size in Mb] else  case when @QuickScan = 1 then -1 else 0 end  end AS [Sort_Data_Free_Pct],   
L.[Total Size in Mb] AS [Sort_Log_Size_Mb],   
case when T.[Available Space in Mb] >= 0 then L.[Available Space in Mb] else case when @QuickScan = 1 then 0 else 0 end end AS [Sort_Log_Free_Mb],   
case when T.[Available Space in Mb] >= 0 then L.[Consumed Space in Mb] else case when @QuickScan = 1 then 0 else 0 end end AS [Sort_Log_Used_Mb],   
case when T.[Available Space in Mb] >= 0 then (1.0 * L.[Available Space in Mb])/L.[Total Size in Mb] else case when @QuickScan = 1 then 0 else 0 end end AS [Sort_Log_Free_Pct],   
FS.[Total Size in Mb] AS [Sort_FileStream_Mb],   
case when FS.[Total Size in Mb] is null then NULL when T.[Available Space in Mb] >= 0 then FS.[Available Space in Mb] else case when @QuickScan = 1 then 0 else 0 end end AS [Sort_FileStream_Free_Mb],   
case when FS.[Total Size in Mb] is null then NULL when T.[Available Space in Mb] >= 0 then FS.[Consumed Space in Mb] else case when @QuickScan = 1 then 0 else 0 end end AS [Sort_FileStream_Used_Mb],   
case when FS.[Total Size in Mb] is null then NULL when T.[Available Space in Mb] >= 0 then (1.0 * FS.[Available Space in Mb])/FS.[Total Size in Mb] else case when @QuickScan = 1 then 0 else 0 end end AS [Sort_FileStream_Free_Pct]
FROM    
	(   
	SELECT database_id, [Database_Name],   
		SUM([Total Size in Mb]) AS [Total Size in Mb],   
		SUM([Available Space in Mb]) AS [Available Space in Mb],   
		SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
	FROM #Results   
	GROUP BY database_id, [Database_Name]   
	) AS T   
	INNER JOIN    
	(   
	SELECT database_id,   
		SUM([Total Size in Mb]) AS [Total Size in Mb],   
		SUM([Available Space in Mb]) AS [Available Space in Mb],   
		SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
	FROM #Results   
	WHERE #Results.[File Type] = 'ROWS'   
	GROUP BY database_id 
	) AS D ON T.[database_id] = D.[database_id]   
	INNER JOIN   
	(   
	SELECT database_id,   
		SUM([Total Size in Mb]) AS [Total Size in Mb],   
		SUM([Available Space in Mb]) AS [Available Space in Mb],   
		SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
	FROM #Results   
	WHERE #Results.[File Type] = 'LOG'   
	GROUP BY database_id  
	) AS L ON T.[database_id] = L.[database_id]   
	LEFT OUTER JOIN   
	(   
	SELECT database_id,   
		SUM([Total Size in Mb]) AS [Total Size in Mb],   
		SUM([Available Space in Mb]) AS [Available Space in Mb],   
		SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
	FROM #Results   
	WHERE #Results.[File Type] = 'FILESTREAM'   
	GROUP BY database_id  
	) AS FS ON T.[database_id] = FS.[database_id]   
)
select 
	outpt.database_id
   ,cast(outpt.[Database_Name] as varchar(128)) as [Database_Name]
   ,cast(isnull((select top 1 name from sys.server_principals p where databases.owner_sid = p.sid), cast(databases.owner_sid as varchar(100))) as varchar(128)) as Owner
   ,databases.create_date
   ,cast(databases.compatibility_level as int) as compatibility_level
   ,cast(databases.collation_name as varchar(128)) as collation_name
   ,cast(databases.user_access_desc as varchar(60)) as user_access_desc
   ,databases.is_read_only
   ,cast(databases.state_desc as varchar(60)) as state_desc
   ,cast(databases.recovery_model_desc as varchar(60)) as recovery_model_desc
   ,backupResults.restore_date
   ,backupResults.last_full_backup
   ,backupResults.last_full_backup_size
   ,backupResults.last_full_backup_compressed_size
   ,backupResults.last_other_backup
   ,backupResults.last_other_backup_size
   ,backupResults.last_other_backup_compressed_size
   ,case when backupResults.last_other_backup_type = 'I' then 'DIfferential'
		 when backupResults.last_other_backup_type = 'L' then 'Log'
		 when backupResults.last_other_backup_type = 'F' then 'File or FileGroup'
		 when backupResults.last_other_backup_type = 'G' then 'Differential File'
		 when backupResults.last_other_backup_type = 'P' then 'Partial'
		 when backupResults.last_other_backup_type = 'Q' then 'Differential Partial'
		 else ''
	end as BackupType
   ,outpt.[db_size_mb]
   ,outpt.[DB_Used_Mb]
   ,outpt.[DB_Free_Mb]
   ,outpt.[Data_Size_Mb]
   ,outpt.[Data_Used_Mb]
   ,outpt.[Data_Free_Mb]
   ,outpt.[Data_Free_Pct]
   ,outpt.[Log_Size_Mb] 
   ,outpt.[Log_Used_Mb]
   ,outpt.[Log_Free_Mb]
   ,outpt.[Log_Free_Pct]
   ,outpt.[FileStream_Mb]
   ,outpt.[FileStream_Used_Mb]
   ,outpt.[FileStream_Free_Mb]
   ,outpt.[FileStream_Free_Pct]
   ,outpt.[Sort_DB_Size_Mb]
   ,outpt.[Sort_DB_Used_Mb]
   ,outpt.[Sort_DB_Free_Mb]
   ,outpt.[Sort_Data_Size_Mb]
   ,outpt.[Sort_Data_Used_Mb]
   ,outpt.[Sort_Data_Free_Mb]
   ,outpt.[Sort_Data_Free_Pct]
   ,outpt.[Sort_Log_Size_Mb] 
   ,outpt.[Sort_Log_Used_Mb]
   ,outpt.[Sort_Log_Free_Mb]
   ,outpt.[Sort_Log_Free_Pct]
   ,outpt.[Sort_FileStream_Mb]
   ,outpt.[Sort_FileStream_Used_Mb]
   ,outpt.[Sort_FileStream_Free_Mb]
   ,outpt.[Sort_FileStream_Free_Pct] 
from outpt
	join sys.databases
		on outpt.database_id = databases.database_id
	left outer join @backupResults backupResults
		on outpt.database_id = backupResults.database_id
ORDER BY [Database_Name]   

SELECT [Database_Name],   
    [File Name],   
    [Physical Name],   
    [File Type],   
    format([Total Size in Mb], '#,##0') AS [db_size_mb],   
    case when [Available Space in Mb] >= 0 then format([Total Size in Mb] - [Available Space in Mb], '#,##0') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end AS [DB_Used_Mb],   
    case when [Available Space in Mb] >= 0 then format([Available Space in Mb], '#,##0') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end AS [DB_Free_Mb],   
    case when [Available Space in Mb] >= 0 then format((1.0 *[Available Space in Mb]) / [Total Size in Mb], '#,##0.00%') else case when @QuickScan = 1 then 'Scanning...' else 'No Access' end end  AS [Free Space %],   
    [Growth Units],   
    isnull(format([Max File Size in Mb], '#,##0'), 'Unlimited') AS [Grow Max Size (Mb)],
    case when [Total Size in Mb] >= 0 then [Total Size in Mb] else -1 end AS [Sort Total Size in Mb],  
    case when [Available Space in Mb] >= 0 then [Available Space in Mb] else -1 end AS [Sort_DB_Free_Mb],  
    case when [Available Space in Mb] >= 0 then [Total Size in Mb] - [Available Space in Mb] else -1 end AS [Sort_DB_Used_Mb],  
    case when [Available Space in Mb] >= 0 then (1.0 *[Available Space in Mb]) / [Total Size in Mb] else case when @QuickScan = 1 then 0 else 0 end end  AS [Sort Free Space %] 
FROM #Results    

SELECT
    0 as DriveType
   ,'MASTER' as Drive
   ,sum([Total Size in Mb]) as db_size_mb
   ,sum(case when [File Type] = 'ROWS' then [Total Size in Mb] else 0 end) as data_size_mb
   ,sum(case when [File Type] = 'LOG' then [Total Size in Mb] else 0 end) as log_size_mb
   ,sum(case when [File Type] = 'FILESTREAM' then [Total Size in Mb] else 0 end) as filestream_size_mb
FROM #Results   
union all
SELECT    
    1 as DriveType
   ,left([Physical Name],1) as Drive
   ,sum([Total Size in Mb]) as db_size_mb
   ,sum(case when [File Type] = 'ROWS' then [Total Size in Mb] else 0 end) as data_size_mb
   ,sum(case when [File Type] = 'LOG' then [Total Size in Mb] else 0 end) as log_size_mb
   ,sum(case when [File Type] = 'FILESTREAM' then [Total Size in Mb] else 0 end) as filestream_size_mb
FROM #Results   
group by left([Physical Name],1)

;with outpt as
(
	select distinct database_id, database_name, left([Physical Name],1) as Drive
	from #results
)
SELECT    
    t.database_id
   ,t.database_name
   ,t.Drive
   ,isnull(sum(D.[Total Size in Mb]),0) as db_size_mb
   ,isnull(sum(case when D.[Available Space in Mb] >= 0 then D.[Consumed Space in Mb] else case when @QuickScan = 1 then 0 else 0 end end),0) AS [Data_Used_Mb]
   ,isnull(sum(L.[Total Size in Mb]),0) as log_size_mb
   ,isnull(sum(case when L.[Available Space in Mb] >= 0 then L.[Consumed Space in Mb] else case when @QuickScan = 1 then 0 else 0 end end),0) AS [log_Used_Mb]
   ,isnull(sum(FS.[Total Size in Mb]),0) as filestream_size_mb
FROM outpt  T 
	INNER JOIN    
	(   
	SELECT database_id,   
		SUM([Total Size in Mb]) AS [Total Size in Mb],   
		SUM([Available Space in Mb]) AS [Available Space in Mb],   
		SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
	FROM #Results   
	WHERE #Results.[File Type] = 'ROWS'   
	GROUP BY database_id 
	) AS D ON T.[database_id] = D.[database_id]   
	INNER JOIN   
	(   
	SELECT database_id,   
		SUM([Total Size in Mb]) AS [Total Size in Mb],   
		SUM([Available Space in Mb]) AS [Available Space in Mb],   
		SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
	FROM #Results   
	WHERE #Results.[File Type] = 'LOG'   
	GROUP BY database_id  
	) AS L ON T.[database_id] = L.[database_id]   
	LEFT OUTER JOIN   
	(   
	SELECT database_id,   
		SUM([Total Size in Mb]) AS [Total Size in Mb],   
		SUM([Available Space in Mb]) AS [Available Space in Mb],   
		SUM([Total Size in Mb]-[Available Space in Mb]) AS [Consumed Space in Mb]    
	FROM #Results   
	WHERE #Results.[File Type] = 'FILESTREAM'   
	GROUP BY database_id  
	) AS FS ON T.[database_id] = FS.[database_id]  
group by t.database_id, t.database_name, t.drive


DROP TABLE #Results   
end

";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
            }
            #endregion
        }

        #endregion
    }

    public class ServerStatsRefreshArgs : EventArgs
    {
        public Guid ConnectionID;
        public int Counter;
        public bool IsOnError;
        public string LastError;
        public DataTable ServerInformation;
        public DataTable PerformanceStatistics;
        public DataTable SessionInformation;
        public DataTable SessionStatistics;
        public DataTable RequestInformation;
        public DataTable ConnectionInformation;
        public DataTable WaitStateInformation;
        public DataTable CursorInformaiton;
        public DataTable SessionCommands;
        public long RefreshMS;
    }
    public class ServerStatsDBSizesArgs : EventArgs
    {
        public Guid ConnectionID;
        public bool IsOnError;
        public string LastError;
        public DataTable DatabaseInformation;
        public DataTable DatabaseFileInformation;
        public DataTable DatabaseSpaceOverview;
        public DataTable DatabaseSpaceByDrive;

    }
}
