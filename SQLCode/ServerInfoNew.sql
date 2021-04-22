--drop procedure #GetServerInfo
--go
CREATE procedure #GetServerInfo
     @inPrevCPUIdle bigint
    ,@inPrevCPUBusy bigint
    ,@inPrevNetworkPacketsSent bigint
    ,@inPrevNetworkPacketsReceived bigint
    ,@inPrevPhysicalIOReads bigint
    ,@inPrevPhysicalIOWrites bigint
as
begin
;with OSInfo as
(
select 
    *
   ,CPUCount = case when cpu_count <= hyperthread_ratio then hyperthread_ratio else cpu_count end
   ,CPUIdle  = (
                  (
                    (
                      (CAST(datediff(DAY, sqlserver_start_time, getdate()) as bigint)  * 24 * 60 * 60 * 1000) 
                       + DATEDIFF(MS, DATEADD(day, datediff(DAY, sqlserver_start_time, getdate()), sqlserver_start_time), getdate())
             
                    ) * (case when cpu_count <= hyperthread_ratio then hyperthread_ratio else cpu_count end)
                  ) - process_user_time_ms
              )
    ,MAXDOP    = (select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = 'maximum degree of parallelism')
    ,(select top 1 cast(value_in_use as varchar(100))  from sys.configurations where description = 'cost threshold for parallelism') as CTFP
from master.sys.dm_os_sys_info
)
select
    cast(serverproperty('ServerName') as varchar(100))    as [ServerName]
   ,isnull(cast(connectionproperty('local_net_address') as varchar(100)),'')           as [LocalNetAddress]
   ,isnull(cast(serverproperty('ComputerNamePhysicalNetBIOS') as varchar(100)),'')    as [ComputerNamePhysicalNetBIOS]
   ,isnull(cast(serverproperty('Edition') as varchar(100)),'')    as [Edition]  
   ,isnull(cast(substring(@@version, patindex('% on %', @@version) + 4, 200) as varchar(200)),'') [OSVersion]
   ,isnull(cast(('InstanceName') as varchar(100)),'')   as [InstanceName]
   ,isnull(cast(serverproperty('MachineName') as varchar(100)),'')    as [MachineName]
   ,isnull(cast(serverproperty('ProductVersion') as varchar(100)),'') as [ProductVersion]
   ,isnull(cast(serverproperty('ProductLevel') as varchar(100)),'') as [ProductLevel] 
   ,isnull(cast(serverproperty('NumLicenses') as varchar(100)),'') as [NumLicenses] 
   ,isnull(cast(serverproperty('LicenseType') as varchar(100)),'') as [LicenseType]
   ,isnull(cast(serverproperty('BuildClrVersion') as varchar(100)),'') as [BuildClrVersion]
   ,isnull(cast(serverproperty('Collation') as varchar(100)),'') as [Collation]
   ,serverproperty('ResourceLastUpdateDateTime')    as [ResourceLastUpdateDateTime]
   ,isnull(cast(serverproperty('ResourceVersion') as varchar(255)),'')          as [ResourceVersion]
   ,isnull(cast(serverproperty('HadrManagerStatus') as varchar(255)),'')             as [HadrManagerStatus]
   ,isnull(cast(serverproperty('InstanceDefaultDataPath') as varchar(255)),'')       as [InstanceDefaultDataPath]
   ,isnull(cast(serverproperty('InstanceDefaultLogPath') as varchar(255)),'')        as [InstanceDefaultLogPath]
   ,isnull(cast(serverproperty('IsClustered') as varchar(255)),'')                   as [IsClustered]
   ,isnull(cast(serverproperty('IsHadrEnabled') as varchar(255)),'')                 as [IsHadrEnabled]
   ,isnull(dm_os_sys_info.CPUCount,0)                 as [CPUCount]
   ,isnull(dm_os_sys_info.hyperthread_ratio,0)        as [HyperThreadRatio]
   ,isnull(dm_os_sys_info.affinity_type_desc, 'UNKNOWN') as [AffinityType]
   ,isnull(dm_os_sys_info.scheduler_count, 0)         as [SchedulerCount]
   ,isnull(dm_os_sys_info.[MAXDOP],'0')             as [MaxDegreeOfParallelism]
   ,isnull(dm_os_sys_info.[CTFP],'0')               as [CostThresholdOfParallelism]
   ,dm_os_sys_info.sqlserver_start_time               as [StartTime]

from OSInfo dm_os_sys_info

;with perfcntr as
(
select
    sum(case when counter_name = 'Total Server Memory (KB)' then cntr_value else 0 end) TotalServerMemory
   ,sum(case when counter_name = 'Target Server Memory (KB)' then cntr_value else 0 end) TargetServerMemory
   ,sum(case when counter_name = 'Database Cache Memory (KB)' then cntr_value else 0 end) DatabaseCacheMemory
   ,sum(case when counter_name = 'Free Memory (KB)' then cntr_value else 0 end) FreeMemory
   ,sum(case when counter_name = 'Reserved Server Memory (KB)' then cntr_value else 0 end) ReservedServerMemory
   ,sum(case when counter_name = 'Stolen Server Memory (KB)' then cntr_value else 0 end) StolenServerMemory
   ,sum(case when counter_name = 'Memory Grants Outstanding' then cntr_value else 0 end) MemoryGrantsOutstanding
   ,sum(case when counter_name = 'Memory Grants Pending' then cntr_value else 0 end) MemoryGrantsPending
   ,sum(case when counter_name = 'Batch Requests/sec' then cntr_value else 0 end) BatchRequestsSec
   ,sum(case when counter_name = 'SQL Compilations/sec' then cntr_value else 0 end) SQLCompliationsSec
   ,sum(case when counter_name = 'SQL Re-Compilations/sec' then cntr_value else 0 end) SQLReCompliationsSec
   ,sum(case when counter_name = 'Checkpoint pages/sec' then cntr_value else 0 end) CheckpointPagesSec
   ,sum(case when counter_name = 'Lock Waits/sec' then cntr_value else 0 end) LockWaitsSec
   ,sum(case when counter_name = 'Buffer cache hit ratio' then cntr_value else 0 end)  BufferCacheHitRatio
   ,sum(case when counter_name = 'Buffer cache hit ratio base' then cntr_value else 0 end) BufferCacheHitRatioBase
   ,sum(case when counter_name = 'Page life expectancy' then cntr_value else 0 end) PageLifeExpectancy
    ,sum(case when counter_name like 'Lock waits%' then cntr_value else 0 end) [LockWaits]
    ,sum(case when counter_name like 'Memory grant queue waits%' then cntr_value else 0 end) [MemoryGrantQueueWaits]
    ,sum(case when counter_name like 'Thread-safe memory objects waits%' then cntr_value else 0 end) [ThreadSafeMemoryObjectsWaits]
    ,sum(case when counter_name like 'Log write waits%' then cntr_value else 0 end) [LogWriteWaits]
    ,sum(case when counter_name like 'Log buffer waits%' then cntr_value else 0 end) [LogBufferWaits]
    ,sum(case when counter_name like 'Network IO waits%' then cntr_value else 0 end) [NetworkIOWaits]
    ,sum(case when counter_name like 'Page IO latch waits%' then cntr_value else 0 end) [PageIOLatchWaits]
    ,sum(case when counter_name like 'Page latch waits%' then cntr_value else 0 end) [PageLatchWaits]
    ,sum(case when counter_name like 'Non-Page latch waits%' then cntr_value else 0 end) [NonPageLatchWaits]
    ,sum(case when counter_name like 'Wait for the worker%' then cntr_value else 0 end) [WaitForTheWorker]
    ,sum(case when counter_name like 'Workspace synchronization waits%' then cntr_value else 0 end) [WorkspaceSynchronizationWaits]
    ,sum(case when counter_name like 'Transaction ownership waits%' then cntr_value else 0 end) [TransactionOwnershipWaits]
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
    getdate()                                         as [CurrentServerTime]
   ,isnull(dm_os_sys_info.physical_memory_kb,0)       as [physical_memory_kb]
   ,isnull(dm_os_sys_info.virtual_memory_kb,0)        as [virtual_memory_kb]
   ,perfcntr.TotalServerMemory                        as [total_memory_used_kb]
   ,perfcntr.TargetServerMemory                       as [target_memory_kb]
   ,perfcntr.DatabaseCacheMemory                      as [database_cache_memory_kb]
   ,perfcntr.FreeMemory                               as [free_memory_kb]
   ,perfcntr.ReservedServerMemory                     as [reserved_server_memory_kb]
   ,perfcntr.StolenServerMemory                       as [stolen_server_memory_kb]
   ,perfcntr.MemoryGrantsOutstanding                  as [MemoryGrantsOutstanding]
   ,perfcntr.MemoryGrantsPending                      as [MemoryGrantsPending]
   ,perfcntr.BatchRequestsSec                         as [batch_requests_sec]
   ,perfcntr.SQLCompliationsSec                       as [sql_compilations_sec]
   ,perfcntr.SQLReCompliationsSec                     as [sql_recompilations_sec]
   ,perfcntr.CheckpointPagesSec                       as [checkpoint_pages_sec]
   ,perfcntr.LockWaitsSec                             as [lock_waits_sec]
   ,cast((cast(perfcntr.BufferCacheHitRatio as float) / perfcntr.BufferCacheHitRatioBase) * 100 as numeric(5,2))  as [BufferCacheHitRatio]
   ,perfcntr.PageLifeExpectancy                       as [PageLifeExpectancy]
   ,process_user_time_ms                              as [CPU_Busy]
   ,CPUIdle                                           as [CPU_Idle]
   ,((1.0 * process_user_time_ms - @inPrevCPUBusy) /
   ((1.0 * CPUIdle +  process_user_time_ms) - (@inPrevCPUBusy + @inPrevCPUIdle))) * 100 as [CPUPercentage]
   ,@@pack_received                                                                           as [pack_received]
   ,@@pack_sent                                                                               as [pack_sent]
   ,@@packet_errors                                                                           as [packet_errors]
   ,@@total_read                                                                              as [total_read]
   ,@@total_write                                                                             as [total_write]
   ,@@total_errors                                                                            as [total_errors]
   ,@@pack_received - case when @inPrevNetworkPacketsReceived = 0 then @@PACK_RECEIVED else @inPrevNetworkPacketsReceived end  as [NetworkPacketsRecievedDelta]
   ,@@PACK_sent - case when @inPrevNetworkPacketsSent = 0 then @@PACK_SENT else @inPrevNetworkPacketsSent end                  as [NetworkPacketsSentDelta]
   ,@@TOTAL_READ - case when @inPrevPhysicalIOReads = 0 then @@TOTAL_READ else @inPrevPhysicalIOReads end                      as [PhysicalIOTotalReadsDelta]
   ,@@TOTAL_WRITE - case when @inPrevPhysicalIOWrites = 0 then @@TOTAL_WRITE else @inPrevPhysicalIOWrites end                  as [PhysicalIOTotalWritesDelta]
   ,@@io_busy                                                                                 as [io_busy]
   ,(select count(*) from sys.dm_exec_sessions)                                               as [TotalSessions]
   ,(select count(distinct login_name) from sys.dm_exec_sessions)                                              as [TotalUsers]
   ,isnull(perfcntr.[LockWaits],'0')                              as [LockWaits]
   ,isnull(perfcntr.[MemoryGrantQueueWaits],'0')                  as [MemoryGrantQueueWaits]
   ,isnull(perfcntr.[ThreadSafeMemoryObjectsWaits],'0')           as [ThreadSafeMemoryObjectsWaits]
   ,isnull(perfcntr.[LogWriteWaits],'0')                          as [LogWriteWaits]
   ,isnull(perfcntr.[LogBufferWaits],'0')                         as [LogBufferWaits]
   ,isnull(perfcntr.[NetworkIOWaits],'0')                         as [NetworkIOWaits]
   ,isnull(perfcntr.[PageIOLatchWaits],'0')                       as [PageIOLatchWaits]
   ,isnull(perfcntr.[PageLatchWaits],'0')                         as [PageLatchWaits]
   ,isnull(perfcntr.[NonPageLatchWaits],'0')                      as [NonPageLatchWaits]
   ,isnull(perfcntr.[WaitForTheWorker],'0')                       as [WaitForTheWorker]
   ,isnull(perfcntr.[WorkspaceSynchronizationWaits],'0')          as [WorkspaceSynchronizationWaits]
   ,isnull(perfcntr.[TransactionOwnershipWaits],'0')              as [TransactionOwnershipWaits]
from OSInfo dm_os_sys_info, perfcntr

end
