using System.Collections.Generic;

namespace SQLDBATool
{
    class clsConnectionInformation
    {
        // Private Properties
        private clsServerInfoXML FServerInfoXML;
        private string FServerName;
        private string FServerDisplayName;
        private bool FIntegratedSecurity;
        private string FUserID;
        private string FPassword;
        private List<Code.ucServerIcon> FServerIcon;
        // Public Properies
        public string ServerName { get => FServerName; set => FServerName = value; }
        public string ServerDisplayName { get => FServerDisplayName; set => FServerDisplayName = value; }
        public bool IntegratedSecurity { get => FIntegratedSecurity; set => FIntegratedSecurity = value; }
        public string UserID { get => FUserID; set => FUserID = value; }
        public string Password { get => FPassword; set => FPassword = value; }
        internal clsServerInfoXML ServerInfoXML { get => FServerInfoXML; set => FServerInfoXML = value; }
        // Constructors
        public clsConnectionInformation(string serverName, string serverDisplayName, bool integratedSecurity, string userID, string password)
        {
            ServerName = serverName;
            ServerDisplayName = serverDisplayName;
            IntegratedSecurity = integratedSecurity;
            UserID = userID;
            Password = password;
        }

        // Disposal
        public void Dispose()
        {

        }

    }
}
