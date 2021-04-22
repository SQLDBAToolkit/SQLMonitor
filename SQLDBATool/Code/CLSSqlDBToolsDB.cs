using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SQLDBATool.Code
{
    class CLSSqlDBToolsDB : IDisposable
    {
        public CLSSqlDBToolsDB()
        {

        }

        public void Dispose()
        {

        }


    }

    #region ServerTreeController
    public class clsServerTreeController : IDisposable
    {
        public clsServerTreeController()
        {

        }

        public void Dispose()
        {

        }
        public void CheckIndexes()
        {
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {
                var col = db.GetCollection<ServerTree>("ServerTree");
                col.DropIndex("ServerTreeID");
                col.EnsureIndex("ServerTreeID", true);
                col.EnsureIndex("ParentTreeID", false);
            }

        }
        public ServerTree AddServerTree(ServerTree serverTree)
        {
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {
                var col = db.GetCollection<ServerTree>("ServerTree");
                col.Insert(serverTree);
                col.EnsureIndex("ServerTreeID", true);
                col.EnsureIndex("ParentTreeID", false);
            }

            return serverTree;
        }
        public ServerTree AddServerTree(string treeName, int treeOrdinalPosition, Guid parentTreeID, bool isSubFolder, Guid serverID, bool masterTreeItem)
        {
            ServerTree serverTree = new ServerTree
            {
                ServerTreeID = Guid.NewGuid(),
                TreeName = treeName,
                TreeOrdinalPosition = treeOrdinalPosition,
                ParentTreeID = parentTreeID,
                IsSubFolder = isSubFolder,
                MasterTreeItem = masterTreeItem,
                ServerID = serverID
            };

            return AddServerTree(serverTree);
        }
        public bool UpdateServerTree(ServerTree serverTree)
        {
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {
                var col = db.GetCollection<ServerTree>("ServerTree");
                col.Update(serverTree);
                col.DropIndex("ServerTreeID");
                col.EnsureIndex("ServerTreeID", true);
                col.EnsureIndex("ParentTreeID", false);
            }

            return true;
        }

        public bool DeleteServerTree(ServerTree serverTree)
        {
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {
                var col = db.GetCollection<ServerTree>("ServerTree");
                col.Delete(serverTree.ID);
                col.DropIndex("ServerTreeID");
                col.EnsureIndex("ServerTreeID", true);
                col.EnsureIndex("ParentTreeID", false);
            }

            return true;
        }
        public ServerTree GetServerTree(int id)
        {
            ServerTree ret = new ServerTree();
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {

                LiteCollection<ServerTree> col = (LiteCollection<ServerTree>)db.GetCollection<ServerTree>("ServerTree");
                ServerTree serverTree = col
                    .FindById(id);
                ret = serverTree;
                if (ret.IsSubFolder)
                    ret.ChildTreeNodes = GetChildServerTrees(ret.ServerTreeID);
            }
            return ret;
        }
        public ServerTree GetServerTree(Guid serverTreeID)
        {
            ServerTree ret = new ServerTree();
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {

                LiteCollection<ServerTree> col = (LiteCollection<ServerTree>)db.GetCollection<ServerTree>("ServerTree");
                List<ServerTree> serverTree = col.Find(Query.EQ("ParentTypeID", serverTreeID)).ToList();
                ret = serverTree[0];
                if (ret.IsSubFolder)
                    ret.ChildTreeNodes = GetChildServerTrees(ret.ServerTreeID);
            }
            return ret;
        }
        public ServerTree GetMasterServerTree()
        {
            ServerTree ret = new ServerTree();
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {

                LiteCollection<ServerTree> col = (LiteCollection<ServerTree>)db.GetCollection<ServerTree>("ServerTree");
                List<ServerTree> serverTree = col.Find(Query.EQ("MasterTreeItem", true)).ToList();
                ret = serverTree[0];

                if (ret.IsSubFolder)
                {
                    ret.ChildTreeNodes = GetChildServerTrees(ret.ServerTreeID);
                }
            }

            return ret;
        }

        public List<ServerTree> GetChildServerTrees(Guid parentTreeID)
        {
            List<ServerTree> ret = new List<ServerTree>();
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {

                LiteCollection<ServerTree> col = (LiteCollection<ServerTree>)db.GetCollection<ServerTree>("ServerTree");
                ret = col.Find(Query.EQ("ParentTreeID", parentTreeID)).ToList();

                foreach (ServerTree serverTree in ret)
                {
                    if (serverTree.IsSubFolder)
                    {
                        serverTree.ChildTreeNodes = GetChildServerTrees(serverTree.ServerTreeID);
                        serverTree.ChildTreeNodes.Sort(
                            delegate (ServerTree p1, ServerTree p2)
                            {
                                int compareIsFolder = p2.IsSubFolder.CompareTo(p1.IsSubFolder);
                                if (compareIsFolder == 0)
                                {
                                    return p1.TreeName.CompareTo(p2.TreeName);
                                }
                                return compareIsFolder;
                            }
                        );
                    }
                }
            }
            return ret;
        }
    }
    #endregion
    #region MonitoredServerController
    public class clsMonitoredServerController : IDisposable
    {
        public clsMonitoredServerController()
        {

        }

        public void Dispose()
        {

        }
        public void CheckIndexes()
        {
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {
                var col = db.GetCollection<MonitoredServer>("MonitoredServer");
                col.DropIndex("ServerID");
                col.EnsureIndex("ServerID", true);
            }

        }
        public MonitoredServer AddMonitoredServer(MonitoredServer monitoredServer)
        {
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {
                var col = db.GetCollection<MonitoredServer>("MonitoredServer");
                col.Insert(monitoredServer);
                col.EnsureIndex("ServerID", true);

                if (monitoredServer.TreeDiagrams.Count() > 0)
                    AddServerDiagrams(monitoredServer);
            }

            return monitoredServer;
        }
        public MonitoredServer AddServerDiagrams(MonitoredServer monitoredServer)
        {
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {
                var col = db.GetCollection<ServerTreeDiagram>("ServerTreeDiagrams");
                foreach (ServerTreeDiagram treeDiagram in monitoredServer.TreeDiagrams)
                {
                    if (treeDiagram.ID > 0)
                    {
                        col.Update(treeDiagram);
                    }
                    else
                    {
                        col.Insert(treeDiagram);
                    }
                }
                col.EnsureIndex("ServerID", false);
                col.EnsureIndex("ParentTreeID", false);
            }
            return monitoredServer;
        }
        public ServerTreeDiagram AddServerDiagram(ServerTreeDiagram serverTreeDiagram)
        {
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {
                var col = db.GetCollection<ServerTreeDiagram>("ServerTreeDiagrams");
                col.Insert(serverTreeDiagram);
                col.EnsureIndex("ServerID", false);
                col.EnsureIndex("ParentTreeID", false);
            }
            return serverTreeDiagram;
        }
        public ServerTreeDiagram AddServerDiagram(Guid serverID, Guid parentTreeID, int topLocation, int leftLocation, bool showOnDiagram)
        {
            ServerTreeDiagram serverTreeDiagram = new ServerTreeDiagram
            {
                ServerID = serverID,
                ParentTreeID = parentTreeID,
                TopLocation = topLocation,
                LeftLocation = leftLocation,
                ShowOnDiagram = showOnDiagram
            };

            return AddServerDiagram(serverTreeDiagram);
        }
        public MonitoredServer AddMonitoredServer(String serverName, String serverDisplayName, bool useIntegratedSecurity, String userID, String password)
        {
            MonitoredServer monitoredServer = new MonitoredServer
            {
                ServerID = Guid.NewGuid(),
                ServerName = serverName,
                ServerDisplayName = serverDisplayName,
                UseIntegratedSecurity = useIntegratedSecurity,
                UserID = userID,
                Password = password,
                TreeDiagrams = new List<ServerTreeDiagram>()
            };
            return AddMonitoredServer(monitoredServer);
        }

        public bool UpdateMonitoredServer(MonitoredServer monitoredServer)
        {
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {
                var col = db.GetCollection<MonitoredServer>("MonitoredServer");
                col.Update(monitoredServer);
                monitoredServer = AddServerDiagrams(monitoredServer);
                col.EnsureIndex("ServerID", true);
            }

            return true;
        }

        public bool DeleteMonitoredServer(MonitoredServer monitoredServer)
        {
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {
                var col = db.GetCollection<MonitoredServer>("MonitoredServer");
                col.Delete(monitoredServer.ID);
                col.EnsureIndex("ServerID", true);
            }

            return true;
        }
        public MonitoredServer GetMonitoredServer(int id)
        {
            MonitoredServer ret = new MonitoredServer();
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {

                LiteCollection<MonitoredServer> col = (LiteCollection<MonitoredServer>)db.GetCollection<MonitoredServer>("MonitoredServer");
                MonitoredServer monitoredServer = col
                    .FindById(id);
                ret = monitoredServer;
            }
            return ret;
        }
        public MonitoredServer GetMonitoredServer(Guid serverID)
        {
            MonitoredServer ret = new MonitoredServer();
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {

                LiteCollection<MonitoredServer> col = (LiteCollection<MonitoredServer>)db.GetCollection<MonitoredServer>("MonitoredServer");
                List<MonitoredServer> monitoredServer = col.Find(Query.EQ("ServerID", serverID)).ToList();
                ret = monitoredServer[0];
                ret.TreeDiagrams = AppendTreeDiagrams(ret);
            }
            return ret;
        }
        public List<ServerTreeDiagram> AppendTreeDiagrams(MonitoredServer monitoredServer)
        {

            List<ServerTreeDiagram> ret = new List<ServerTreeDiagram>();

            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {

                var col = db.GetCollection<ServerTreeDiagram>("ServerTreeDiagrams");
                List<ServerTreeDiagram> treeDiagrams = col.Find(Query.EQ("ServerID", monitoredServer.ServerID)).ToList();
                foreach (ServerTreeDiagram treeDiagram in treeDiagrams)
                {
                    ret.Add(treeDiagram);
                }
            }
            return ret;
        }
        public List<ServerTreeDiagram> AppendTreeDiagrams(ServerTree monitoredServer)
        {
            List<ServerTreeDiagram> ret = new List<ServerTreeDiagram>();

            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {

                var col = db.GetCollection<ServerTreeDiagram>("ServerTreeDiagrams");
                List<ServerTreeDiagram> treeDiagrams = col.Find(Query.EQ("ParentTreeID", monitoredServer.ServerTreeID)).ToList();
                foreach (ServerTreeDiagram treeDiagram in treeDiagrams)
                {
                    ret.Add(treeDiagram);
                }
            }
            return ret;
        }

    }
    #endregion
    #region WaitTypeInformationController
    public class clsWaitTypeInformationController : IDisposable
    {
        public clsWaitTypeInformationController()
        {

        }

        public void Dispose()
        {

        }
        public void CheckIndexes()
        {
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {
                var col = db.GetCollection<WaitTypeInformation>("WaitTypeInformation");
                col.EnsureIndex("WaitType", false);
            }

        }

        public WaitTypeInformation GetWaitTypeInformation(string waitType)
        {
            WaitTypeInformation ret = new WaitTypeInformation();
            using (LiteDatabase db = new LiteDatabase(Globals.ConnectionString))
            {

                LiteCollection<WaitTypeInformation> col = (LiteCollection<WaitTypeInformation>)db.GetCollection<WaitTypeInformation>("WaitTypeInformation");
                List<WaitTypeInformation> waitTypeInformation = col.Find(Query.EQ("WaitType", waitType)).ToList();
                if (waitTypeInformation.Count > 0)
                {
                    ret = waitTypeInformation[0];
                }
                else
                {
                    ret.WaitTypeDescription = "Undefined Wait Type";
                }
            }
            return ret;
        }

    }
    #endregion



    #region Database Class Objects
    public class ServerTree
    {
        public int ID { get; set; }
        public Guid ServerTreeID { get; set; }
        public string TreeName { get; set; }
        public int TreeOrdinalPosition { get; set; }
        public Guid ParentTreeID { get; set; }
        public bool IsSubFolder { get; set; }
        public Guid ServerID { get; set; }
        public bool MasterTreeItem { get; set; }
        public List<ServerTree> ChildTreeNodes;
    }
    public class MonitoredServer
    {
        public int ID { get; set; }
        public Guid ServerID { get; set; }
        public String ServerName { get; set; }
        public String ServerDisplayName { get; set; }
        public bool UseIntegratedSecurity { get; set; }
        public String UserID { get; set; }
        public String Password { get; set; }
        public String NetworkProtocol { get; set; }
        public int NetworkPacketSize { get; set; }
        public int ConnectionTimeOut { get; set; }
        public int ExecutionTimeOut { get; set; }
        public bool EncryptConnection { get; set; }
        public bool TrustServerCertificate { get; set; }
        public bool IsDisabled { get; set; }
        public List<ServerTreeDiagram> TreeDiagrams;
    }

    public class ServerTreeDiagram
    {
        public int ID { get; set; }
        public Guid ServerID { get; set; }
        public Guid ParentTreeID { get; set; }
        public int TopLocation { get; set; }
        public int LeftLocation { get; set; }
        public bool ShowOnDiagram { get; set; }

    }
    public class WaitTypeInformation
    {
        public int ID { get; set; }
        public string WaitType { get; set; }
        public string WaitTypeDescription { get; set; }

    }
    #endregion
}
