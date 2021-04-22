using LiteDB;
using System.Windows.Forms;
namespace SQLDBATool.Code
{
    class Globals
    {
        private static ConnectionString FConnectionString;
        private static FormSqlDBATool FMasterForm;
        //        #region ServerStatSQLCode
        //        private static string FServerStatRefresh = @"
        //--drop procedure #GetServerInfo
        //--go
        //CREATE procedure #GetServerInfo
        //as
        //begin
        //if object_id('tempdb..#PreviousFigures') is null
        //begin
        //    create table #PreviousFigures
        //    (
        //        PrevCPUIdle bigint
        //       ,PrevCPUBusy bigint
        //       ,PrevNetworkPacketsSent bigint
        //       ,PrevNetworkPacketsReceived bigint
        //       ,PrevPhysicalIOReads bigint
        //       ,PrevPhysicalIOWrites bigint
        //    )
        //    insert into #PreviousFigures values (0,0,0,0,0,0)
        //end
        //declare @PerfResults table
        //(
        //    [CurrentServerTime] [datetime] NOT NULL,
        //    [physical_memory_kb] [bigint] NOT NULL,
        //    [virtual_memory_kb] [bigint] NOT NULL,
        //    [total_memory_used_kb] [bigint] NULL,
        //    [target_memory_kb] [bigint] NULL,
        //    [database_cache_memory_kb] [bigint] NULL,
        //    [free_memory_kb] [bigint] NULL,
        //    [reserved_server_memory_kb] [bigint] NULL,
        //    [stolen_server_memory_kb] [bigint] NULL,
        //    [MemoryGrantsOutstanding] [bigint] NULL,
        //    [MemoryGrantsPending] [bigint] NULL,
        //    [batch_requests_sec] [bigint] NULL,
        //    [sql_compilations_sec] [bigint] NULL,
        //    [sql_recompilations_sec] [bigint] NULL,
        //    [checkpoint_pages_sec] [bigint] NULL,
        //    [lock_waits_sec] [bigint] NULL,
        //    [BufferCacheHitRatio] [numeric](5, 2) NULL,
        //    [PageLifeExpectancy] [bigint] NULL,
        //    [CPU_Busy] [bigint] NOT NULL,
        //    [CPU_Idle] [bigint] NULL,
        //    [CPUPercentage] [numeric](38, 11) NULL,
        //    [pack_received] [int] NOT NULL,
        //    [pack_sent] [int] NOT NULL,
        //    [packet_errors] [int] NOT NULL,
        //    [total_read] [int] NOT NULL,
        //    [total_write] [int] NOT NULL,
        //    [total_errors] [int] NOT NULL,
        //    [NetworkPacketsRecievedDelta] [bigint] NULL,
        //    [NetworkPacketsSentDelta] [bigint] NULL,
        //    [PhysicalIOTotalReadsDelta] [bigint] NULL,
        //    [PhysicalIOTotalWritesDelta] [bigint] NULL,
        //    [io_busy] [int] NOT NULL,
        //    [TotalSessions] [int] NULL,
        //    [TotalUsers] [int] NULL,
        //    [LockWaits] [bigint] NOT NULL,
        //    [MemoryGrantQueueWaits] [bigint] NOT NULL,
        //    [ThreadSafeMemoryObjectsWaits] [bigint] NOT NULL,
        //    [LogWriteWaits] [bigint] NOT NULL,
        //    [LogBufferWaits] [bigint] NOT NULL,
        //    [NetworkIOWaits] [bigint] NOT NULL,
        //    [PageIOLatchWaits] [bigint] NOT NULL,
        //    [PageLatchWaits] [bigint] NOT NULL,
        //    [NonPageLatchWaits] [bigint] NOT NULL,
        //    [WaitForTheWorker] [bigint] NOT NULL,
        //    [WorkspaceSynchronizationWaits] [bigint] NOT NULL,
        //    [TransactionOwnershipWaits] [bigint] NOT NULL
        //)
        //;with OSInfo as
        //(
        //select 
        //    [hyperthread_ratio]    = hyperthread_ratio
        //   ,[affinity_type_desc]   = affinity_type_desc
        //   ,[scheduler_count]      = scheduler_count
        //   ,[sqlserver_start_time] = sqlserver_start_time
        //   ,[CPUCount]             = case when cpu_count <= hyperthread_ratio then hyperthread_ratio else cpu_count end
        //   ,[CPUIdle]              = (
        //                              (
        //                                (
        //                                  (CAST(datediff(DAY, sqlserver_start_time, getdate()) as bigint)  * 24 * 60 * 60 * 1000) 
        //                                   + DATEDIFF(MS, DATEADD(day, datediff(DAY, sqlserver_start_time, getdate()), sqlserver_start_time), getdate())

        //                                ) * (case when cpu_count <= hyperthread_ratio then hyperthread_ratio else cpu_count end)
        //                              ) - process_user_time_ms)
        //    ,[MAXDOP]              = (select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = 'maximum degree of parallelism')
        //    ,[CTFP]                = (select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = 'cost threshold for parallelism')
        //from master.sys.dm_os_sys_info
        //)
        //select
        //    [ServerName]                  = cast(serverproperty('ServerName') as varchar(100)) 
        //   ,[LocalNetAddress]             = isnull(cast(connectionproperty('local_net_address') as varchar(100)),'')
        //   ,[ComputerNamePhysicalNetBIOS] = isnull(cast(serverproperty('ComputerNamePhysicalNetBIOS') as varchar(100)),'')
        //   ,[Edition]                     = isnull(cast(serverproperty('Edition') as varchar(100)),'')  
        //   ,[OSVersion]                   = isnull(cast(substring(@@version, patindex('% on %', @@version) + 4, 200) as varchar(200)),'')
        //   ,[InstanceName]                = isnull(cast(('InstanceName') as varchar(100)),'')
        //   ,[MachineName]                 = isnull(cast(serverproperty('MachineName') as varchar(100)),'')
        //   ,[ProductVersion]              = isnull(cast(serverproperty('ProductVersion') as varchar(100)),'')
        //   ,[ProductLevel]                = isnull(cast(serverproperty('ProductLevel') as varchar(100)),'')
        //   ,[NumLicenses]                 = isnull(cast(serverproperty('NumLicenses') as varchar(100)),'')
        //   ,[LicenseType]                 = isnull(cast(serverproperty('LicenseType') as varchar(100)),'')
        //   ,[BuildClrVersion]             = isnull(cast(serverproperty('BuildClrVersion') as varchar(100)),'')
        //   ,[Collation]                   = isnull(cast(serverproperty('Collation') as varchar(100)),'')
        //   ,[ResourceLastUpdateDateTime]  = serverproperty('ResourceLastUpdateDateTime')
        //   ,[ResourceVersion]             = isnull(cast(serverproperty('ResourceVersion') as varchar(255)),'')
        //   ,[HadrManagerStatus]           = isnull(cast(serverproperty('HadrManagerStatus') as varchar(255)),'')
        //   ,[InstanceDefaultDataPath]     = isnull(cast(serverproperty('InstanceDefaultDataPath') as varchar(255)),'')
        //   ,[InstanceDefaultLogPath]      = isnull(cast(serverproperty('InstanceDefaultLogPath') as varchar(255)),'')
        //   ,[IsClustered]                 = isnull(cast(serverproperty('IsClustered') as varchar(255)),'')
        //   ,[IsHadrEnabled]               = isnull(cast(serverproperty('IsHadrEnabled') as varchar(255)),'')
        //   ,[CPUCount]                    = isnull(dm_os_sys_info.CPUCount,0)
        //   ,[HyperThreadRatio]            = isnull(dm_os_sys_info.hyperthread_ratio,0)
        //   ,[AffinityType]                = isnull(dm_os_sys_info.affinity_type_desc, 'UNKNOWN')
        //   ,[SchedulerCount]              = isnull(dm_os_sys_info.scheduler_count, 0)
        //   ,[MaxDegreeOfParallelism]      = isnull(dm_os_sys_info.[MAXDOP],'0')
        //   ,[CostThresholdOfParallelism]  = isnull(dm_os_sys_info.[CTFP],'0')
        //   ,[StartTime]                   = dm_os_sys_info.sqlserver_start_time
        //from OSInfo dm_os_sys_info

        //;with perfcntr as
        //(
        //select
        //    [TotalServerMemory]             = sum(case when counter_name = 'Total Server Memory (KB)' then cntr_value else 0 end) 
        //   ,[TargetServerMemory]            = sum(case when counter_name = 'Target Server Memory (KB)' then cntr_value else 0 end) 
        //   ,[DatabaseCacheMemory]           = sum(case when counter_name = 'Database Cache Memory (KB)' then cntr_value else 0 end) 
        //   ,[FreeMemory]                    = sum(case when counter_name = 'Free Memory (KB)' then cntr_value else 0 end) 
        //   ,[ReservedServerMemory]          = sum(case when counter_name = 'Reserved Server Memory (KB)' then cntr_value else 0 end) 
        //   ,[StolenServerMemory]            = sum(case when counter_name = 'Stolen Server Memory (KB)' then cntr_value else 0 end) 
        //   ,[MemoryGrantsOutstanding]       = sum(case when counter_name = 'Memory Grants Outstanding' then cntr_value else 0 end) 
        //   ,[MemoryGrantsPending]           = sum(case when counter_name = 'Memory Grants Pending' then cntr_value else 0 end) 
        //   ,[BatchRequestsSec]              = sum(case when counter_name = 'Batch Requests/sec' then cntr_value else 0 end) 
        //   ,[SQLCompliationsSec]            = sum(case when counter_name = 'SQL Compilations/sec' then cntr_value else 0 end) 
        //   ,[SQLReCompliationsSec]          = sum(case when counter_name = 'SQL Re-Compilations/sec' then cntr_value else 0 end) 
        //   ,[CheckpointPagesSec]            = sum(case when counter_name = 'Checkpoint pages/sec' then cntr_value else 0 end) 
        //   ,[LockWaitsSec]                  = sum(case when counter_name = 'Lock Waits/sec' then cntr_value else 0 end) 
        //   ,[BufferCacheHitRatio]           = sum(case when counter_name = 'Buffer cache hit ratio' then cntr_value else 0 end)  
        //   ,[BufferCacheHitRatioBase]       = sum(case when counter_name = 'Buffer cache hit ratio base' then cntr_value else 0 end) 
        //   ,[PageLifeExpectancy]            = sum(case when counter_name = 'Page life expectancy' then cntr_value else 0 end) 
        //   ,[LockWaits]                     = sum(case when counter_name like 'Lock waits%' then cntr_value else 0 end) 
        //   ,[MemoryGrantQueueWaits]         = sum(case when counter_name like 'Memory grant queue waits%' then cntr_value else 0 end) 
        //   ,[ThreadSafeMemoryObjectsWaits]  = sum(case when counter_name like 'Thread-safe memory objects waits%' then cntr_value else 0 end) 
        //   ,[LogWriteWaits]                 = sum(case when counter_name like 'Log write waits%' then cntr_value else 0 end) 
        //   ,[LogBufferWaits]                = sum(case when counter_name like 'Log buffer waits%' then cntr_value else 0 end) 
        //   ,[NetworkIOWaits]                = sum(case when counter_name like 'Network IO waits%' then cntr_value else 0 end) 
        //   ,[PageIOLatchWaits]              = sum(case when counter_name like 'Page IO latch waits%' then cntr_value else 0 end) 
        //   ,[PageLatchWaits]                = sum(case when counter_name like 'Page latch waits%' then cntr_value else 0 end) 
        //   ,[NonPageLatchWaits]             = sum(case when counter_name like 'Non-Page latch waits%' then cntr_value else 0 end) 
        //   ,[WaitForTheWorker]              = sum(case when counter_name like 'Wait for the worker%' then cntr_value else 0 end) 
        //   ,[WorkspaceSynchronizationWaits] = sum(case when counter_name like 'Workspace synchronization waits%' then cntr_value else 0 end) 
        //   ,[TransactionOwnershipWaits]     = sum(case when counter_name like 'Transaction ownership waits%' then cntr_value else 0 end) 
        //from  sys.dm_os_performance_counters
        //WHERE 
        //    (
        //            object_name like '%:Memory Manager%' 
        //        and counter_name in ('Database Cache Memory (KB)'
        //                            ,'Free Memory (KB)'
        //                            ,'Reserved Server Memory (KB)'
        //                            ,'Stolen Server Memory (KB)'
        //                            ,'Target Server Memory (KB)'
        //                            ,'Total Server Memory (KB)')
        //     )
        //or   (
        //            object_name like '%:Buffer Manager%' 
        //        and counter_name in ('Buffer cache hit ratio'
        //                            ,'Buffer cache hit ratio base'
        //                            ,'Page life expectancy'
        //                            ,'Checkpoint pages/sec')
        //     )
        //or   (
        //            object_name like '%:SQL Statistics%' 
        //        and counter_name in ('Batch Requests/sec'
        //                            ,'SQL Compilations/sec'
        //                            ,'SQL Re-Compilations/sec')
        //     )
        //or   (
        //            object_name like '%:Memory Manager%' 
        //        and counter_name in ('Memory Grants Outstanding'
        //                            ,'Memory Grants Pending')
        //     )
        //or   (
        //            object_name like '%:Locks%' 
        //        and counter_name in ('Lock Waits/sec')
        //        and instance_name = '_Total'
        //     )
        //or   (
        //            object_name like '%Wait Statistics%'
        //        and instance_name like 'Waits started per second%'
        //     )
        //),
        //OSInfo as
        //(
        //select 
        //    [physical_memory_kb]       = [physical_memory_kb]
        //   ,[virtual_memory_kb]        = [virtual_memory_kb]
        //   ,[process_user_time_ms]     = [process_user_time_ms]
        //   ,[CPUCount]                 = case when cpu_count <= hyperthread_ratio then hyperthread_ratio else cpu_count end
        //   ,[CPUIdle]                  = (
        //								  (
        //									(
        //									  (CAST(datediff(DAY, sqlserver_start_time, getdate()) as bigint)  * 24 * 60 * 60 * 1000) 
        //									   + DATEDIFF(MS, DATEADD(day, datediff(DAY, sqlserver_start_time, getdate()), sqlserver_start_time), getdate())

        //									) * (case when cpu_count <= hyperthread_ratio then hyperthread_ratio else cpu_count end)) - process_user_time_ms)
        //    ,[MAXDOP]                  = (select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = 'maximum degree of parallelism')
        //    ,[CTFP]                    = (select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = 'cost threshold for parallelism')
        //from master.sys.dm_os_sys_info
        //)
        //insert into @PerfResults
        //select
        //    [CurrentServerTime]              = getdate()
        //   ,[physical_memory_kb]             = isnull(dm_os_sys_info.physical_memory_kb,0)
        //   ,[virtual_memory_kb]              = isnull(dm_os_sys_info.virtual_memory_kb,0)
        //   ,[total_memory_used_kb]           = isnull(perfcntr.TotalServerMemory,0)
        //   ,[target_memory_kb]               = isnull(perfcntr.TargetServerMemory,0)
        //   ,[database_cache_memory_kb]       = isnull(perfcntr.DatabaseCacheMemory,0)
        //   ,[free_memory_kb]                 = isnull(perfcntr.FreeMemory,0)
        //   ,[reserved_server_memory_kb]      = isnull(perfcntr.ReservedServerMemory,0)
        //   ,[stolen_server_memory_kb]        = isnull(perfcntr.StolenServerMemory,0)
        //   ,[MemoryGrantsOutstanding]        = isnull(perfcntr.MemoryGrantsOutstanding,0)
        //   ,[MemoryGrantsPending]            = isnull(perfcntr.MemoryGrantsPending,0)
        //   ,[batch_requests_sec]             = isnull(perfcntr.BatchRequestsSec,0)
        //   ,[sql_compilations_sec]           = isnull(perfcntr.SQLCompliationsSec,0)
        //   ,[sql_recompilations_sec]         = isnull(perfcntr.SQLReCompliationsSec,0)
        //   ,[checkpoint_pages_sec]           = isnull(perfcntr.CheckpointPagesSec,0)
        //   ,[lock_waits_sec]                 = isnull(perfcntr.LockWaitsSec,0)
        //   ,[BufferCacheHitRatio]            = isnull(cast((cast(perfcntr.BufferCacheHitRatio as float) / perfcntr.BufferCacheHitRatioBase) * 100 as numeric(5,2)),0)
        //   ,[PageLifeExpectancy]             = isnull(perfcntr.PageLifeExpectancy,0)
        //   ,[CPU_Busy]                       = isnull(process_user_time_ms,0)
        //   ,[CPU_Idle]                       = isnull(CPUIdle,0)
        //   ,[CPUPercentage]                  = ((1.0 * process_user_time_ms - prevFigures.PrevCPUBusy) /
        //                                      ((1.0 * CPUIdle +  process_user_time_ms) - (prevFigures.PrevCPUBusy + prevFigures.PrevCPUIdle))) * 100
        //   ,[pack_received]                  = @@pack_received
        //   ,[pack_sent]                      = @@pack_sent
        //   ,[packet_errors]                  = @@packet_errors
        //   ,[total_read]                     = @@total_read
        //   ,[total_write]                    = @@total_write
        //   ,[total_errors]                   = @@total_errors
        //   ,[NetworkPacketsRecievedDelta]    = @@pack_received - case when prevFigures.PrevNetworkPacketsReceived = 0 then @@PACK_RECEIVED else prevFigures.PrevNetworkPacketsReceived end
        //   ,[NetworkPacketsSentDelta]        = @@PACK_sent - case when prevFigures.PrevNetworkPacketsSent = 0 then @@PACK_SENT else prevFigures.PrevNetworkPacketsSent end
        //   ,[PhysicalIOTotalReadsDelta]      = @@TOTAL_READ - case when prevFigures.PrevPhysicalIOReads = 0 then @@TOTAL_READ else prevFigures.PrevPhysicalIOReads end
        //   ,[PhysicalIOTotalWritesDelta]     = @@TOTAL_WRITE - case when prevFigures.PrevPhysicalIOWrites = 0 then @@TOTAL_WRITE else prevFigures.PrevPhysicalIOWrites end
        //   ,[io_busy]                        = @@io_busy
        //   ,[TotalSessions]                  = (select count(*) from sys.dm_exec_sessions)
        //   ,[TotalUsers]                     = (select count(distinct login_name) from sys.dm_exec_sessions)
        //   ,[LockWaits]                      = isnull(perfcntr.[LockWaits],'0')
        //   ,[MemoryGrantQueueWaits]          = isnull(perfcntr.[MemoryGrantQueueWaits],'0')
        //   ,[ThreadSafeMemoryObjectsWaits]   = isnull(perfcntr.[ThreadSafeMemoryObjectsWaits],'0')
        //   ,[LogWriteWaits]                  = isnull(perfcntr.[LogWriteWaits],'0')
        //   ,[LogBufferWaits]                 = isnull(perfcntr.[LogBufferWaits],'0')
        //   ,[NetworkIOWaits]                 = isnull(perfcntr.[NetworkIOWaits],'0')
        //   ,[PageIOLatchWaits]               = isnull(perfcntr.[PageIOLatchWaits],'0')
        //   ,[PageLatchWaits]                 = isnull(perfcntr.[PageLatchWaits],'0')
        //   ,[NonPageLatchWaits]              = isnull(perfcntr.[NonPageLatchWaits],'0')
        //   ,[WaitForTheWorker]               = isnull(perfcntr.[WaitForTheWorker],'0')
        //   ,[WorkspaceSynchronizationWaits]  = isnull(perfcntr.[WorkspaceSynchronizationWaits],'0')
        //   ,[TransactionOwnershipWaits]      = isnull(perfcntr.[TransactionOwnershipWaits],'0')
        //from OSInfo dm_os_sys_info, perfcntr
        //    ,#PreviousFigures prevFigures

        //update pf
        //    set PrevCPUIdle = pr.CPU_Idle
        //       ,PrevCPUBusy = pr.CPU_Busy
        //       ,PrevNetworkPacketsSent = pr.pack_sent
        //       ,PrevNetworkPacketsReceived = pr.pack_received
        //       ,PrevPhysicalIOReads = pr.total_read
        //       ,PrevPhysicalIOWrites = pr.total_write
        //from #PreviousFigures pf
        //    ,@PerfResults pr

        //select * from @PerfResults
        //end
        //";
        //        #endregion
        //
        public static ConnectionString ConnectionString { get => FConnectionString; set => FConnectionString = value; }
        public static FormSqlDBATool MasterForm { get => FMasterForm; set => FMasterForm = value; }
        //public static string ServerStatRefresh { get => FServerStatRefresh; set => FServerStatRefresh = value; }\
        public static int CountStringOccurances(string text, string pattern)
        {
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }

            return count;
        }
    }

    class DBDataGridView : DataGridView
    {
        public DBDataGridView() { DoubleBuffered = true; }
    }
}
