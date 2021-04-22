using System.Diagnostics;
using System.ServiceProcess;

namespace SQLMonitorService
{
    public partial class SQLMonitorService : ServiceBase
    {
        private System.ComponentModel.IContainer components;
        //private System.Diagnostics.EventLog eventLogService;
        public SQLMonitorService()
        {
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("SQLMonitorService"))
            {
                System.Diagnostics.EventLog.CreateEventSource("SQLMonitorService", "SQLMonitorLog");
            }

            eventLogService.Source = "SQLMonitorService";
            eventLogService.Log = "SQLMonitorLog";
            //    eventLogService = new System.Diagnostics.EventLog();

        }

        protected override void OnStart(string[] args)
        {
            eventLogService.WriteEntry("In OnStart");

        }

        protected override void OnStop()
        {
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
    }
}
