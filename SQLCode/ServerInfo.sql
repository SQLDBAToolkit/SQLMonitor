declare @sql varchar(max)
if object_id('tempdb..#GetServerInfo') is not null
begin
	set @sql = 'drop procedure tempdb..#GetServerInfo'
	exec (@sql)
end

if object_id('tempdb..#GetServerInfo') is null
begin
    set @sql = '
CREATE procedure #GetServerInfo
    @inPrevCPUIdle bigint = 0
   ,@inPrevCPUBusy bigint = 0
   ,@inPrevNetworkPacketsSent bigint = 0
   ,@inPrevNetworkPacketsReceived bigint = 0
   ,@inPrevPhysicalIOReads bigint = 0
   ,@inPrevPhysicalIOWrites bigint = 0
as
begin
--drop table  dbo.ServerInfoTable
;with perfcntr as
(
select
    sum(case when counter_name = ''Total Server Memory (KB)'' then cntr_value else 0 end) TotalServerMemory
   ,sum(case when counter_name = ''Target Server Memory (KB)'' then cntr_value else 0 end) TargetServerMemory
   ,sum(case when counter_name = ''Database Cache Memory (KB)'' then cntr_value else 0 end) DatabaseCacheMemory
   ,sum(case when counter_name = ''Free Memory (KB)'' then cntr_value else 0 end) FreeMemory
   ,sum(case when counter_name = ''Reserved Server Memory (KB)'' then cntr_value else 0 end) ReservedServerMemory
   ,sum(case when counter_name = ''Stolen Server Memory (KB)'' then cntr_value else 0 end) StolenServerMemory
   ,sum(case when counter_name = ''Memory Grants Outstanding'' then cntr_value else 0 end) MemoryGrantsOutstanding
   ,sum(case when counter_name = ''Memory Grants Pending'' then cntr_value else 0 end) MemoryGrantsPending
   ,sum(case when counter_name = ''Batch Requests/sec'' then cntr_value else 0 end) BatchRequestsSec
   ,sum(case when counter_name = ''SQL Compilations/sec'' then cntr_value else 0 end) SQLCompliationsSec
   ,sum(case when counter_name = ''SQL Re-Compilations/sec'' then cntr_value else 0 end) SQLReCompliationsSec
   ,sum(case when counter_name = ''Checkpoint pages/sec'' then cntr_value else 0 end) CheckpointPagesSec
   ,sum(case when counter_name = ''Lock Waits/sec'' then cntr_value else 0 end) LockWaitsSec
   ,sum(case when counter_name = ''Buffer cache hit ratio'' then cntr_value else 0 end)  BufferCacheHitRatio
   ,sum(case when counter_name = ''Buffer cache hit ratio base'' then cntr_value else 0 end) BufferCacheHitRatioBase
   ,sum(case when counter_name = ''Page life expectancy'' then cntr_value else 0 end) PageLifeExpectancy
'
set @sql = @sql + '       ,sum(case when counter_name like ''Lock waits%'' then cntr_value else 0 end) [LockWaits]
       ,sum(case when counter_name like ''Memory grant queue waits%'' then cntr_value else 0 end) [MemoryGrantQueueWaits]
       ,sum(case when counter_name like ''Thread-safe memory objects waits%'' then cntr_value else 0 end) [ThreadSafeMemoryObjectsWaits]
       ,sum(case when counter_name like ''Log write waits%'' then cntr_value else 0 end) [LogWriteWaits]
       ,sum(case when counter_name like ''Log buffer waits%'' then cntr_value else 0 end) [LogBufferWaits]
       ,sum(case when counter_name like ''Network IO waits%'' then cntr_value else 0 end) [NetworkIOWaits]
       ,sum(case when counter_name like ''Page IO latch waits%'' then cntr_value else 0 end) [PageIOLatchWaits]
       ,sum(case when counter_name like ''Page latch waits%'' then cntr_value else 0 end) [PageLatchWaits]
       ,sum(case when counter_name like ''Non-Page latch waits%'' then cntr_value else 0 end) [NonPageLatchWaits]
       ,sum(case when counter_name like ''Wait for the worker%'' then cntr_value else 0 end) [WaitForTheWorker]
       ,sum(case when counter_name like ''Workspace synchronization waits%'' then cntr_value else 0 end) [WorkspaceSynchronizationWaits]
       ,sum(case when counter_name like ''Transaction ownership waits%'' then cntr_value else 0 end) [TransactionOwnershipWaits]
from  sys.dm_os_performance_counters
WHERE 
    (
            object_name like ''%:Memory Manager%'' 
        and counter_name in (''Database Cache Memory (KB)''
                            ,''Free Memory (KB)''
                            ,''Reserved Server Memory (KB)''
                            ,''Stolen Server Memory (KB)''
                            ,''Target Server Memory (KB)''
                            ,''Total Server Memory (KB)'')
     )
or   (
            object_name like ''%:Buffer Manager%'' 
        and counter_name in (''Buffer cache hit ratio''
                            ,''Buffer cache hit ratio base''
                            ,''Page life expectancy''
                            ,''Checkpoint pages/sec'')
     )
or   (
            object_name like ''%:SQL Statistics%'' 
        and counter_name in (''Batch Requests/sec''
                            ,''SQL Compilations/sec''
                            ,''SQL Re-Compilations/sec'')
     )
or   (
            object_name like ''%:Memory Manager%'' 
'
set @sql = @sql + '        and counter_name in (''Memory Grants Outstanding''
                            ,''Memory Grants Pending'')
     )
or   (
            object_name like ''%:Locks%'' 
        and counter_name in (''Lock Waits/sec'')
        and instance_name = ''_Total''
     )
or   (
            object_name like ''%Wait Statistics%''
        and instance_name like ''Waits started per second%''
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
    ,(select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = ''maximum degree of parallelism'') as MAXDOP
    ,(select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = ''cost threshold for parallelism'') as CTFP
from master.sys.dm_os_sys_info
)
select
    1                                                 as Tag
   ,NULL                                              as Parent
   ,cast(serverproperty(''ServerName'') as varchar(100))    as [SQLDBToolServerXML!1!ServerName]
   ,cast(connectionproperty(''local_net_address'') as varchar(100))           as [SQLDBToolServerXML!1!LocalNetAddress]
   ,cast(serverproperty(''ComputerNamePhysicalNetBIOS'') as varchar(100))    as [SQLDBToolServerXML!1!ComputerNamePhysicalNetBIOS]
   ,cast(serverproperty(''Edition'') as varchar(100))    as [SQLDBToolServerXML!1!Edition]  
'
set @sql = @sql + '   ,substring(@@version, patindex(''% on %'', @@version) + 4, 200) [SQLDBToolServerXML!1!OSVersion]
   ,cast((''InstanceName'') as varchar(100))   as [SQLDBToolServerXML!1!InstanceName]
   ,cast(serverproperty(''MachineName'') as varchar(100))    as [SQLDBToolServerXML!1!MachineName]
   ,cast(serverproperty(''ProductVersion'') as varchar(100)) as [SQLDBToolServerXML!1!ProductVersion]
   ,cast(serverproperty(''ProductLevel'') as varchar(100)) as [SQLDBToolServerXML!1!ProductLevel] 
   ,cast(serverproperty(''NumLicenses'') as varchar(100)) as [SQLDBToolServerXML!1!NumLicenses] 
   ,cast(serverproperty(''LicenseType'') as varchar(100)) as [SQLDBToolServerXML!1!LicenseType]
   ,cast(serverproperty(''BuildClrVersion'') as varchar(100)) as [SQLDBToolServerXML!1!BuildClrVersion]
   ,cast(serverproperty(''Collation'') as varchar(100)) as [SQLDBToolServerXML!1!Collation]
   ,serverproperty(''ResourceLastUpdateDateTime'')    as [SQLDBToolServerXML!1!ResourceLastUpdateDateTime]
   ,cast(serverproperty(''ResourceVersion'')          as varchar(100)) as [SQLDBToolServerXML!1!ResourceVersion]
   ,serverproperty(''HadrManagerStatus'')             as [SQLDBToolServerXML!1!HadrManagerStatus]
   ,serverproperty(''InstanceDefaultDataPath'')       as [SQLDBToolServerXML!1!InstanceDefaultDataPath]
   ,serverproperty(''InstanceDefaultLogPath'')        as [SQLDBToolServerXML!1!InstanceDefaultLogPath]
   ,serverproperty(''IsClustered'')                   as [SQLDBToolServerXML!1!IsClustered]
   ,serverproperty(''IsHadrEnabled'')                 as [SQLDBToolServerXML!1!IsHadrEnabled]
'
set @sql = @sql + '


   ,isnull(dm_os_sys_info.CPUCount,0)                 as [SQLDBToolServerXML!1!CPUCount]
   ,isnull(dm_os_sys_info.hyperthread_ratio,0)        as [SQLDBToolServerXML!1!HyperThreadRatio]
   ,isnull(dm_os_sys_info.affinity_type_desc, ''UNKNOWN'') as [SQLDBToolServerXML!1!AffinityType]
   ,isnull(dm_os_sys_info.scheduler_count, 0)         as [SQLDBToolServerXML!1!SchedulerCount]
   ,isnull(dm_os_sys_info.[MAXDOP],''0'')             as [SQLDBToolServerXML!1!MaxDegreeOfParallelism]
   ,isnull(dm_os_sys_info.[CTFP],''0'')               as [SQLDBToolServerXML!1!CostThresholdOfParallelism]
   ,dm_os_sys_info.sqlserver_start_time               as [SQLDBToolServerXML!1!StartTime]
   ,NULL                                              as [PerformanceStats!2!PerformanceStats]
   ,NULL                                              as [StatCounter!3!CurrentServerTime]
   ,NULL                                              as [StatCounter!3!PhysicalMemoryKB]
   ,NULL                                              as [StatCounter!3!VirtualMemoryKB]
   ,NULL                                              as [StatCounter!3!TotalMemoryUsedKB]
   ,NULL                                              as [StatCounter!3!TargetMemoryKB]
   ,NULL                                              as [StatCounter!3!DatabaseCacheMemoryKB]
   ,NULL                                              as [StatCounter!3!FreeMemoryKB]
   ,NULL                                              as [StatCounter!3!ReservedServerMemoryKB]
'
set @sql = @sql + '   ,NULL                                              as [StatCounter!3!StolenServerMemoryKB]
   ,NULL                                              as [StatCounter!3!MemoryGrantsOutstanding]
   ,NULL                                              as [StatCounter!3!MemoryGrantsPending]
   ,NULL                                              as [StatCounter!3!BatchRequestsSec]
   ,NULL                                              as [StatCounter!3!SqlCompilationsSec]
   ,NULL                                              as [StatCounter!3!SqlReCompilationsSec]
   ,NULL                                              as [StatCounter!3!CheckPointPagesSec]
   ,NULL                                              as [StatCounter!3!LockWaitsSec]
   ,NULL                                              as [StatCounter!3!BufferCacheHitRatio]
   ,NULL                                              as [StatCounter!3!PageLifeExpectancy]
   ,NULL                                              as [StatCounter!3!CPUBusy]
   ,NULL                                              as [StatCounter!3!CPUIdle]
   ,NULL                                              as [StatCounter!3!CPUPercentage]
   ,NULL                                              as [StatCounter!3!NetworkPacketsRecieved]
   ,NULL                                              as [StatCounter!3!NetworkPacketsSent]
   ,NULL                                              as [StatCounter!3!NetworkPacketErrors]
   ,NULL                                              as [StatCounter!3!PhysicalIOTotalReads]
   ,NULL                                              as [StatCounter!3!PhysicalIOTotalWrites]
   ,NULL                                              as [StatCounter!3!NetworkPacketsRecievedDelta]
   ,NULL                                              as [StatCounter!3!NetworkPacketsSentDelta]
   ,NULL                                              as [StatCounter!3!PhysicalIOTotalReadsDelta]
   ,NULL                                              as [StatCounter!3!PhysicalIOTotalWritesDelta]
   ,NULL                                              as [StatCounter!3!PhysicalIOTotalErrors]
   ,NULL                                              as [StatCounter!3!PhysicalIOBusy]
   ,NULL                                              as [StatCounter!3!TotalSessions]
   ,NULL                                              as [StatCounter!3!TotalUsers]
   ,NULL                                                  as [StatCounter!3!LockWaits]
   ,NULL                                                  as [StatCounter!3!MemoryGrantQueueWaits]
   ,NULL                                                  as [StatCounter!3!ThreadSafeMemoryObjectsWaits]
'
set @sql = @sql + '   ,NULL                                                  as [StatCounter!3!LogWriteWaits]
   ,NULL                                                  as [StatCounter!3!LogBufferWaits]
   ,NULL                                                  as [StatCounter!3!NetworkIOWaits]
   ,NULL                                                  as [StatCounter!3!PageIOLatchWaits]
   ,NULL                                                  as [StatCounter!3!PageLatchWaits]
   ,NULL                                                  as [StatCounter!3!NonPageLatchWaits]
   ,NULL                                                  as [StatCounter!3!WaitForTheWorker]
   ,NULL                                                  as [StatCounter!3!WorkspaceSynchronizationWaits]
   ,NULL                                                  as [StatCounter!3!TransactionOwnershipWaits]
from OSInfo dm_os_sys_info
union all
select
    2                                                 as Tag
   ,1                                                 as Parent
   ,NULL                                              as [SQLDBToolServerXML!1!ServerName]
   ,NULL                                              as [SQLDBToolServerXML!1!LocalNetAddress]
   ,NULL                                              as [SQLDBToolServerXML!1!ComputerNamePhysicalNetBIOS]
   ,NULL                                              as [SQLDBToolServerXML!1!Edition]  
   ,NULL                                              as [SQLDBToolServerXML!1!OSVersion]
   ,NULL                                              as [SQLDBToolServerXML!1!InstanceName]
   ,NULL                                              as [SQLDBToolServerXML!1!MachineName]
   ,NULL                                              as [SQLDBToolServerXML!1!ProductVersion]
   ,NULL                                              as [SQLDBToolServerXML!1!ProductLevel] 
   ,NULL                                              as [SQLDBToolServerXML!1!NumLicenses] 
   ,NULL                                              as [SQLDBToolServerXML!1!LicenseType]
   ,NULL                                              as [SQLDBToolServerXML!1!BuildClrVersion]
   ,NULL                                              as [SQLDBToolServerXML!1!Collation]
   ,NULL                                              as [SQLDBToolServerXML!1!ResourceLastUpdateDateTime]
   ,NULL                                              as [SQLDBToolServerXML!1!ResourceVersion]
   ,NULL                                              as [SQLDBToolServerXML!1!HadrManagerStatus]
   ,NULL                                              as [SQLDBToolServerXML!1!InstanceDefaultDataPath]
   ,NULL                                              as [SQLDBToolServerXML!1!InstanceDefaultLogPath]
   ,NULL                                              as [SQLDBToolServerXML!1!IsClustered]
   ,NULL                                              as [SQLDBToolServerXML!1!IsHadrEnabled]
   ,NULL                                              as [SQLDBToolServerXML!1!CPUCount]
   ,NULL                                              as [SQLDBToolServerXML!1!HyperThreadRatio]
   ,NULL                                              as [SQLDBToolServerXML!1!AffinityType]
   ,NULL                                              as [SQLDBToolServerXML!1!SchedulerCount]
   ,NULL                                              as [SQLDBToolServerXML!1!MaxDegreeOfParallelism]
   ,NULL                                              as [SQLDBToolServerXML!1!CostThresholdOfParallelism]
   ,NULL                                              as [SQLDBToolServerXML!1!StartTime]
   ,NULL                                              as [PerformanceStats!2!PerformanceStats]
   ,NULL                                              as [StatCounter!3!CurrentServerTime]
'
set @sql = @sql + '   ,NULL                                              as [StatCounter!3!physical_memory_kb]
   ,NULL                                              as [StatCounter!3!virtual_memory_kb]
   ,NULL                                              as [StatCounter!3!total_memory_used_kb]
   ,NULL                                              as [StatCounter!3!target_memory_kb]
   ,NULL                                              as [StatCounter!3!database_cache_memory_kb]
   ,NULL                                              as [StatCounter!3!free_memory_kb]
   ,NULL                                              as [StatCounter!3!reserved_server_memory_kb]
   ,NULL                                              as [StatCounter!3!stolen_server_memory_kb]
   ,NULL                                              as [StatCounter!3!MemoryGrantsOutstanding]
   ,NULL                                              as [StatCounter!3!MemoryGrantsPending]
   ,NULL                                              as [StatCounter!3!batch_requests_sec]
   ,NULL                                              as [StatCounter!3!sql_compilations_sec]
   ,NULL                                              as [StatCounter!3!sql_recompilations_sec]
   ,NULL                                              as [StatCounter!3!checkpoint_pages_sec]
   ,NULL                                              as [StatCounter!3!LockWaitsSec]
   ,NULL                                              as [StatCounter!3!BufferCacheHitRatio]
   ,NULL                                              as [StatCounter!3!PageLifeExpectancy]
   ,NULL                                              as [StatCounter!3!CPU_Busy]
   ,NULL                                              as [StatCounter!3!CPU_Idle]
   ,NULL                                              as [StatCounter!3!CPUPercentage]
   ,NULL                                              as [StatCounter!3!pack_received]
   ,NULL                                              as [StatCounter!3!pack_sent]
   ,NULL                                              as [StatCounter!3!packet_errors]
   ,NULL                                              as [StatCounter!3!total_read]
   ,NULL                                              as [StatCounter!3!total_write]
   ,NULL                                              as [StatCounter!3!total_errors]
   ,NULL                                              as [StatCounter!3!NetworkPacketsRecievedDelta]
   ,NULL                                              as [StatCounter!3!NetworkPacketsSentDelta]
   ,NULL                                              as [StatCounter!3!PhysicalIOTotalReadsDelta]
   ,NULL                                              as [StatCounter!3!PhysicalIOTotalWritesDelta]
   ,NULL                                              as [StatCounter!3!io_busy]
   ,NULL                                              as [StatCounter!3!TotalSessions]
   ,NULL                                              as [StatCounter!3!TotalUsers]
   ,NULL                                                  as [StatCounter!3!LockWaits]
   ,NULL                                                  as [StatCounter!3!MemoryGrantQueueWaits]
'
set @sql = @sql + '   ,NULL                                                  as [StatCounter!3!ThreadSafeMemoryObjectsWaits]
   ,NULL                                                  as [StatCounter!3!LogWriteWaits]
   ,NULL                                                  as [StatCounter!3!LogBufferWaits]
   ,NULL                                                  as [StatCounter!3!NetworkIOWaits]
   ,NULL                                                  as [StatCounter!3!PageIOLatchWaits]
   ,NULL                                                  as [StatCounter!3!PageLatchWaits]
   ,NULL                                                  as [StatCounter!3!NonPageLatchWaits]
   ,NULL                                                  as [StatCounter!3!WaitForTheWorker]
   ,NULL                                                  as [StatCounter!3!WorkspaceSynchronizationWaits]
   ,NULL                                                  as [StatCounter!3!TransactionOwnershipWaits]
union all
select
    3                                                 as Tag
   ,2                                                 as Parent
   ,NULL                                              as [SQLDBToolServerXML!1!ServerName]
   ,NULL                                              as [SQLDBToolServerXML!1!LocalNetAddress]
   ,NULL                                              as [SQLDBToolServerXML!1!ComputerNamePhysicalNetBIOS]
   ,NULL                                              as [SQLDBToolServerXML!1!Edition]  
   ,NULL                                              as [SQLDBToolServerXML!1!OSVersion]
   ,NULL                                              as [SQLDBToolServerXML!1!InstanceName]
   ,NULL                                              as [SQLDBToolServerXML!1!MachineName]
   ,NULL                                              as [SQLDBToolServerXML!1!ProductVersion]
   ,NULL                                              as [SQLDBToolServerXML!1!ProductLevel] 
   ,NULL                                              as [SQLDBToolServerXML!1!NumLicenses] 
   ,NULL                                              as [SQLDBToolServerXML!1!LicenseType]
   ,NULL                                              as [SQLDBToolServerXML!1!BuildClrVersion]
   ,NULL                                              as [SQLDBToolServerXML!1!Collation]
   ,NULL                                              as [SQLDBToolServerXML!1!ResourceLastUpdateDateTime]
   ,NULL                                              as [SQLDBToolServerXML!1!ResourceVersion]
   ,NULL                                              as [SQLDBToolServerXML!1!HadrManagerStatus]
   ,NULL                                              as [SQLDBToolServerXML!1!InstanceDefaultDataPath]
   ,NULL                                              as [SQLDBToolServerXML!1!InstanceDefaultLogPath]
   ,NULL                                              as [SQLDBToolServerXML!1!IsClustered]
   ,NULL                                              as [SQLDBToolServerXML!1!IsHadrEnabled]

   ,NULL                                              as [SQLDBToolServerXML!1!CPUCount]
   ,NULL                                              as [SQLDBToolServerXML!1!HyperThreadRatio]
   ,NULL                                              as [SQLDBToolServerXML!1!AffinityType]
   ,NULL                                              as [SQLDBToolServerXML!1!SchedulerCount]
   ,NULL                                              as [SQLDBToolServerXML!1!MaxDegreeOfParallelism]
   ,NULL                                              as [SQLDBToolServerXML!1!CostThresholdOfParallelism]
   ,NULL                                              as [SQLDBToolServerXML!1!StartTime]
   ,NULL                                              as [PerformanceStats!2!PerformanceStats]
   ,getdate()                                         as [StatCounter!3!CurrentServerTime]
   ,isnull(dm_os_sys_info.physical_memory_kb,0)       as [StatCounter!3!physical_memory_kb]
'
set @sql = @sql + '   ,isnull(dm_os_sys_info.virtual_memory_kb,0)        as [StatCounter!3!virtual_memory_kb]
   ,perfcntr.TotalServerMemory                        as [StatCounter!3!total_memory_used_kb]
   ,perfcntr.TargetServerMemory                       as [StatCounter!3!target_memory_kb]
   ,perfcntr.DatabaseCacheMemory                      as [StatCounter!3!database_cache_memory_kb]
   ,perfcntr.FreeMemory                               as [StatCounter!3!free_memory_kb]
   ,perfcntr.ReservedServerMemory                     as [StatCounter!3!reserved_server_memory_kb]
   ,perfcntr.StolenServerMemory                       as [StatCounter!3!stolen_server_memory_kb]
   ,perfcntr.MemoryGrantsOutstanding                  as [StatCounter!3!MemoryGrantsOutstanding]
   ,perfcntr.MemoryGrantsPending                      as [StatCounter!3!MemoryGrantsPending]
   ,perfcntr.BatchRequestsSec                         as [StatCounter!3!batch_requests_sec]
   ,perfcntr.SQLCompliationsSec                       as [StatCounter!3!sql_compilations_sec]
   ,perfcntr.SQLReCompliationsSec                     as [StatCounter!3!sql_recompilations_sec]
   ,perfcntr.CheckpointPagesSec                       as [StatCounter!3!checkpoint_pages_sec]
   ,perfcntr.LockWaitsSec                             as [StatCounter!3!lock_waits_sec]
   ,cast((cast(perfcntr.BufferCacheHitRatio as float) / perfcntr.BufferCacheHitRatioBase) * 100 as numeric(5,2))  as [StatCounter!3!BufferCacheHitRatio]
   ,perfcntr.PageLifeExpectancy                       as [StatCounter!3!PageLifeExpectancy]
   ,process_user_time_ms                                                                      as [StatCounter!3!CPU_Busy]
   ,CPUIdle                                                                    as [StatCounter!3!CPU_Idle]
   
   ,((1.0 * process_user_time_ms - @inPrevCPUBusy) /
   ((1.0 * CPUIdle +  process_user_time_ms) - (@inPrevCPUBusy + @inPrevCPUIdle))) * 100                                         as [StatCounter!3!CPUPercentage]

   ,@@pack_received                                                                           as [StatCounter!3!pack_received]
   ,@@pack_sent                                                                               as [StatCounter!3!pack_sent]
   ,@@packet_errors                                                                           as [StatCounter!3!packet_errors]
   ,@@total_read                                                                              as [StatCounter!3!total_read]
   ,@@total_write                                                                             as [StatCounter!3!total_write]
   ,@@total_errors                                                                            as [StatCounter!3!total_errors]
   ,@@pack_received - case when @inPrevNetworkPacketsReceived = 0 then @@PACK_RECEIVED else @inPrevNetworkPacketsReceived end  as [StatCounter!3!NetworkPacketsRecievedDelta]
   ,@@PACK_sent - case when @inPrevNetworkPacketsSent = 0 then @@PACK_SENT else @inPrevNetworkPacketsSent end                  as [StatCounter!3!NetworkPacketsSentDelta]
   ,@@TOTAL_READ - case when @inPrevPhysicalIOReads = 0 then @@TOTAL_READ else @inPrevPhysicalIOReads end                      as [StatCounter!3!PhysicalIOTotalReadsDelta]
   ,@@TOTAL_WRITE - case when @inPrevPhysicalIOWrites = 0 then @@TOTAL_WRITE else @inPrevPhysicalIOWrites end                  as [StatCounter!3!PhysicalIOTotalWritesDelta]
   ,@@io_busy                                                                                 as [StatCounter!3!io_busy]
   ,(select count(*) from sys.dm_exec_sessions)                                               as [StatCounter!3!TotalSessions]
   ,(select count(distinct login_name) from sys.dm_exec_sessions)                                              as [StatCounter!3!TotalUsers]
   ,isnull(perfcntr.[LockWaits],''0'')                              as [StatCounter!3!LockWaits]
   ,isnull(perfcntr.[MemoryGrantQueueWaits],''0'')                  as [StatCounter!3!MemoryGrantQueueWaits]
   ,isnull(perfcntr.[ThreadSafeMemoryObjectsWaits],''0'')           as [StatCounter!3!ThreadSafeMemoryObjectsWaits]
   ,isnull(perfcntr.[LogWriteWaits],''0'')                          as [StatCounter!3!LogWriteWaits]
   ,isnull(perfcntr.[LogBufferWaits],''0'')                         as [StatCounter!3!LogBufferWaits]
   ,isnull(perfcntr.[NetworkIOWaits],''0'')                         as [StatCounter!3!NetworkIOWaits]
   ,isnull(perfcntr.[PageIOLatchWaits],''0'')                       as [StatCounter!3!PageIOLatchWaits]
   ,isnull(perfcntr.[PageLatchWaits],''0'')                         as [StatCounter!3!PageLatchWaits]
   ,isnull(perfcntr.[NonPageLatchWaits],''0'')                      as [StatCounter!3!NonPageLatchWaits]
   ,isnull(perfcntr.[WaitForTheWorker],''0'')                       as [StatCounter!3!WaitForTheWorker]
   ,isnull(perfcntr.[WorkspaceSynchronizationWaits],''0'')          as [StatCounter!3!WorkspaceSynchronizationWaits]
'
set @sql = @sql + '   ,isnull(perfcntr.[TransactionOwnershipWaits],''0'')              as [StatCounter!3!TransactionOwnershipWaits]
from OSInfo dm_os_sys_info, perfcntr
order by tag
for xml EXPLICIT
end
'
    exec (@sql)
end

exec #GetServerInfo
