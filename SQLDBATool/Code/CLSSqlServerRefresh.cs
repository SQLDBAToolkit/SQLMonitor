using System;
using System.Data.SqlClient;

namespace SQLDBATool.Code
{
    class CLSSqlServerRefresh : IDisposable
    {

        public CLSSqlServerRefresh()
        {

        }

        public void Dispose()
        {

        }

    }
    class CLSSqlServerStats : IDisposable
    {
        private CLSTreeInformation FTreeInformation;
        private string FConnectionString;

        public CLSTreeInformation TreeInformation { get => FTreeInformation; set => FTreeInformation = value; }
        public string ConnectionString { get => FConnectionString; set => FConnectionString = value; }

        public CLSSqlServerStats(CLSTreeInformation treeInformation)
        {
            FTreeInformation = treeInformation;
            SqlConnectionStringBuilder connString = new SqlConnectionStringBuilder();
            connString.DataSource = treeInformation.ConnectionInformation.MonitoredServer.ServerName;
            connString.IntegratedSecurity = treeInformation.ConnectionInformation.MonitoredServer.UseIntegratedSecurity;
            if (!treeInformation.ConnectionInformation.MonitoredServer.UseIntegratedSecurity)
            {
                connString.UserID = treeInformation.ConnectionInformation.MonitoredServer.UserID;
                connString.Password = treeInformation.ConnectionInformation.MonitoredServer.Password;
            }

            FConnectionString = connString.ConnectionString;
        }

        public void Dispose()
        {

        }
    }

}
