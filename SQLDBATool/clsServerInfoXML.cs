namespace SQLDBATool
{
    class clsServerInfoXML
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class SQLMonitorServerInfoXML
        {
            #region Fields
            private SQLMonitorServerInfoXMLStatCounter[] performanceStatsField;
            private string serverNameField;
            private string computerNamePhysicalNetBIOSField;
            private string editionField;
            private string oSVersionField;
            private string instanceNameField;
            private string machineNameField;
            private string productVersionField;
            private string productLevelField;
            private string licenseTypeField;
            private string buildClrVersionField;
            private string collationField;
            private string resourceLastUpdateDateTimeField;
            private string resourceVersionField;
            private byte cPUCountField;
            private byte hyperThreadRatioField;
            private string affinityTypeField;
            private byte schedulerCountField;
            private byte maxDegreeOfParallelismField;
            private byte costThresholdOfParallelismField;
            private System.DateTime startTimeField;
            #endregion
            #region Properies
            [System.Xml.Serialization.XmlArrayItemAttribute("StatCounter", IsNullable = false)]
            public SQLMonitorServerInfoXMLStatCounter[] PerformanceStats
            {
                get
                {
                    return this.performanceStatsField;
                }
                set
                {
                    this.performanceStatsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ServerName
            {
                get
                {
                    return this.serverNameField;
                }
                set
                {
                    this.serverNameField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ComputerNamePhysicalNetBIOS
            {
                get
                {
                    return this.computerNamePhysicalNetBIOSField;
                }
                set
                {
                    this.computerNamePhysicalNetBIOSField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Edition
            {
                get
                {
                    return this.editionField;
                }
                set
                {
                    this.editionField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string OSVersion
            {
                get
                {
                    return this.oSVersionField;
                }
                set
                {
                    this.oSVersionField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string InstanceName
            {
                get
                {
                    return this.instanceNameField;
                }
                set
                {
                    this.instanceNameField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string MachineName
            {
                get
                {
                    return this.machineNameField;
                }
                set
                {
                    this.machineNameField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ProductVersion
            {
                get
                {
                    return this.productVersionField;
                }
                set
                {
                    this.productVersionField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ProductLevel
            {
                get
                {
                    return this.productLevelField;
                }
                set
                {
                    this.productLevelField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string LicenseType
            {
                get
                {
                    return this.licenseTypeField;
                }
                set
                {
                    this.licenseTypeField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string BuildClrVersion
            {
                get
                {
                    return this.buildClrVersionField;
                }
                set
                {
                    this.buildClrVersionField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Collation
            {
                get
                {
                    return this.collationField;
                }
                set
                {
                    this.collationField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ResourceLastUpdateDateTime
            {
                get
                {
                    return this.resourceLastUpdateDateTimeField;
                }
                set
                {
                    this.resourceLastUpdateDateTimeField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ResourceVersion
            {
                get
                {
                    return this.resourceVersionField;
                }
                set
                {
                    this.resourceVersionField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte CPUCount
            {
                get
                {
                    return this.cPUCountField;
                }
                set
                {
                    this.cPUCountField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte HyperThreadRatio
            {
                get
                {
                    return this.hyperThreadRatioField;
                }
                set
                {
                    this.hyperThreadRatioField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string AffinityType
            {
                get
                {
                    return this.affinityTypeField;
                }
                set
                {
                    this.affinityTypeField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte SchedulerCount
            {
                get
                {
                    return this.schedulerCountField;
                }
                set
                {
                    this.schedulerCountField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte MaxDegreeOfParallelism
            {
                get
                {
                    return this.maxDegreeOfParallelismField;
                }
                set
                {
                    this.maxDegreeOfParallelismField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte CostThresholdOfParallelism
            {
                get
                {
                    return this.costThresholdOfParallelismField;
                }
                set
                {
                    this.costThresholdOfParallelismField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public System.DateTime StartTime
            {
                get
                {
                    return this.startTimeField;
                }
                set
                {
                    this.startTimeField = value;
                }
            }
        }
        #endregion

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class SQLMonitorServerInfoXMLStatCounter
        {
            #region Fields
            private System.DateTime currentServerTimeField;
            private uint physicalMemoryKBField;
            private ulong virtualMemoryKBField;
            private uint totalMemoryUsedKBField;
            private uint targetMemoryKBField;
            private ushort databaseCacheMemoryKBField;
            private ushort freeMemoryKBField;
            private byte reservedServerMemoryKBField;
            private uint stolenServerMemoryKBField;
            private byte memoryGrantsOutstandingField;
            private byte memoryGrantsPendingField;
            private ushort batchRequestsSecField;
            private ushort sqlCompilationsSecField;
            private byte sqlReCompilationsSecField;
            private byte checkPointPagesSecField;
            private byte lockWaitsSecField;
            private decimal bufferCacheHitRatioField;
            private ushort pageLifeExpectancyField;
            private uint cPUBusyField;
            private uint cPUIdleField;
            private decimal cPUPercentageField;
            private ushort networkPacketsRecievedField;
            private ushort networkPacketsSentField;
            private byte networkPacketErrorsField;
            private ushort physicalIOTotalReadsField;
            private byte physicalIOTotalWritesField;
            private byte networkPacketsRecievedDeltaField;
            private byte networkPacketsSentDeltaField;
            private byte physicalIOTotalReadsDeltaField;
            private byte physicalIOTotalWritesDeltaField;
            private byte physicalIOTotalErrorsField;
            private ushort physicalIOBusyField;
            private byte totalSessionsField;
            private byte totalUsersField;
            private byte lockWaitsField;
            private byte memoryGrantQueueWaitsField;
            private byte threadSafeMemoryObjectsWaitsField;
            private byte logWriteWaitsField;
            private byte logBufferWaitsField;
            private byte networkIOWaitsField;
            private byte pageIOLatchWaitsField;
            private byte pageLatchWaitsField;
            private byte nonPageLatchWaitsField;
            private byte waitForTheWorkerField;
            private byte workspaceSynchronizationWaitsField;
            private byte transactionOwnershipWaitsField;
            #endregion
            #region Properties
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public System.DateTime CurrentServerTime
            {
                get
                {
                    return this.currentServerTimeField;
                }
                set
                {
                    this.currentServerTimeField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint PhysicalMemoryKB
            {
                get
                {
                    return this.physicalMemoryKBField;
                }
                set
                {
                    this.physicalMemoryKBField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ulong VirtualMemoryKB
            {
                get
                {
                    return this.virtualMemoryKBField;
                }
                set
                {
                    this.virtualMemoryKBField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint TotalMemoryUsedKB
            {
                get
                {
                    return this.totalMemoryUsedKBField;
                }
                set
                {
                    this.totalMemoryUsedKBField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint TargetMemoryKB
            {
                get
                {
                    return this.targetMemoryKBField;
                }
                set
                {
                    this.targetMemoryKBField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort DatabaseCacheMemoryKB
            {
                get
                {
                    return this.databaseCacheMemoryKBField;
                }
                set
                {
                    this.databaseCacheMemoryKBField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort FreeMemoryKB
            {
                get
                {
                    return this.freeMemoryKBField;
                }
                set
                {
                    this.freeMemoryKBField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ReservedServerMemoryKB
            {
                get
                {
                    return this.reservedServerMemoryKBField;
                }
                set
                {
                    this.reservedServerMemoryKBField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint StolenServerMemoryKB
            {
                get
                {
                    return this.stolenServerMemoryKBField;
                }
                set
                {
                    this.stolenServerMemoryKBField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte MemoryGrantsOutstanding
            {
                get
                {
                    return this.memoryGrantsOutstandingField;
                }
                set
                {
                    this.memoryGrantsOutstandingField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte MemoryGrantsPending
            {
                get
                {
                    return this.memoryGrantsPendingField;
                }
                set
                {
                    this.memoryGrantsPendingField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort BatchRequestsSec
            {
                get
                {
                    return this.batchRequestsSecField;
                }
                set
                {
                    this.batchRequestsSecField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort SqlCompilationsSec
            {
                get
                {
                    return this.sqlCompilationsSecField;
                }
                set
                {
                    this.sqlCompilationsSecField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte SqlReCompilationsSec
            {
                get
                {
                    return this.sqlReCompilationsSecField;
                }
                set
                {
                    this.sqlReCompilationsSecField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte CheckPointPagesSec
            {
                get
                {
                    return this.checkPointPagesSecField;
                }
                set
                {
                    this.checkPointPagesSecField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte LockWaitsSec
            {
                get
                {
                    return this.lockWaitsSecField;
                }
                set
                {
                    this.lockWaitsSecField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal BufferCacheHitRatio
            {
                get
                {
                    return this.bufferCacheHitRatioField;
                }
                set
                {
                    this.bufferCacheHitRatioField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort PageLifeExpectancy
            {
                get
                {
                    return this.pageLifeExpectancyField;
                }
                set
                {
                    this.pageLifeExpectancyField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint CPUBusy
            {
                get
                {
                    return this.cPUBusyField;
                }
                set
                {
                    this.cPUBusyField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public uint CPUIdle
            {
                get
                {
                    return this.cPUIdleField;
                }
                set
                {
                    this.cPUIdleField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal CPUPercentage
            {
                get
                {
                    return this.cPUPercentageField;
                }
                set
                {
                    this.cPUPercentageField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort NetworkPacketsRecieved
            {
                get
                {
                    return this.networkPacketsRecievedField;
                }
                set
                {
                    this.networkPacketsRecievedField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort NetworkPacketsSent
            {
                get
                {
                    return this.networkPacketsSentField;
                }
                set
                {
                    this.networkPacketsSentField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte NetworkPacketErrors
            {
                get
                {
                    return this.networkPacketErrorsField;
                }
                set
                {
                    this.networkPacketErrorsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort PhysicalIOTotalReads
            {
                get
                {
                    return this.physicalIOTotalReadsField;
                }
                set
                {
                    this.physicalIOTotalReadsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte PhysicalIOTotalWrites
            {
                get
                {
                    return this.physicalIOTotalWritesField;
                }
                set
                {
                    this.physicalIOTotalWritesField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte NetworkPacketsRecievedDelta
            {
                get
                {
                    return this.networkPacketsRecievedDeltaField;
                }
                set
                {
                    this.networkPacketsRecievedDeltaField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte NetworkPacketsSentDelta
            {
                get
                {
                    return this.networkPacketsSentDeltaField;
                }
                set
                {
                    this.networkPacketsSentDeltaField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte PhysicalIOTotalReadsDelta
            {
                get
                {
                    return this.physicalIOTotalReadsDeltaField;
                }
                set
                {
                    this.physicalIOTotalReadsDeltaField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte PhysicalIOTotalWritesDelta
            {
                get
                {
                    return this.physicalIOTotalWritesDeltaField;
                }
                set
                {
                    this.physicalIOTotalWritesDeltaField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte PhysicalIOTotalErrors
            {
                get
                {
                    return this.physicalIOTotalErrorsField;
                }
                set
                {
                    this.physicalIOTotalErrorsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort PhysicalIOBusy
            {
                get
                {
                    return this.physicalIOBusyField;
                }
                set
                {
                    this.physicalIOBusyField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte TotalSessions
            {
                get
                {
                    return this.totalSessionsField;
                }
                set
                {
                    this.totalSessionsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte TotalUsers
            {
                get
                {
                    return this.totalUsersField;
                }
                set
                {
                    this.totalUsersField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte LockWaits
            {
                get
                {
                    return this.lockWaitsField;
                }
                set
                {
                    this.lockWaitsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte MemoryGrantQueueWaits
            {
                get
                {
                    return this.memoryGrantQueueWaitsField;
                }
                set
                {
                    this.memoryGrantQueueWaitsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte ThreadSafeMemoryObjectsWaits
            {
                get
                {
                    return this.threadSafeMemoryObjectsWaitsField;
                }
                set
                {
                    this.threadSafeMemoryObjectsWaitsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte LogWriteWaits
            {
                get
                {
                    return this.logWriteWaitsField;
                }
                set
                {
                    this.logWriteWaitsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte LogBufferWaits
            {
                get
                {
                    return this.logBufferWaitsField;
                }
                set
                {
                    this.logBufferWaitsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte NetworkIOWaits
            {
                get
                {
                    return this.networkIOWaitsField;
                }
                set
                {
                    this.networkIOWaitsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte PageIOLatchWaits
            {
                get
                {
                    return this.pageIOLatchWaitsField;
                }
                set
                {
                    this.pageIOLatchWaitsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte PageLatchWaits
            {
                get
                {
                    return this.pageLatchWaitsField;
                }
                set
                {
                    this.pageLatchWaitsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte NonPageLatchWaits
            {
                get
                {
                    return this.nonPageLatchWaitsField;
                }
                set
                {
                    this.nonPageLatchWaitsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte WaitForTheWorker
            {
                get
                {
                    return this.waitForTheWorkerField;
                }
                set
                {
                    this.waitForTheWorkerField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte WorkspaceSynchronizationWaits
            {
                get
                {
                    return this.workspaceSynchronizationWaitsField;
                }
                set
                {
                    this.workspaceSynchronizationWaitsField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte TransactionOwnershipWaits
            {
                get
                {
                    return this.transactionOwnershipWaitsField;
                }
                set
                {
                    this.transactionOwnershipWaitsField = value;
                }
            }
            #endregion
        }

    }
}
