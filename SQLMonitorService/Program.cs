using System.ServiceProcess;

namespace SQLMonitorService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SQLMonitorService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
