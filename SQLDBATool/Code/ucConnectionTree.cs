using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class ucConnectionTree : UserControl
    {
        private List<CLSTreeInformation> FTreeInformation = new List<CLSTreeInformation>();
        private CLSTreeInformation TestTreeInformation;
        private FormSqlDBATool FParentSqlToolsForm;

        public FormSqlDBATool ParentSqlToolsForm { get => FParentSqlToolsForm; set => FParentSqlToolsForm = value; }

        public ucConnectionTree()
        {
            InitializeComponent();
            string dbPath = Application.StartupPath;

            if (dbPath.StartsWith(@"F:\Projects\SQLDBATool\SQLDBATool") ||
                dbPath.Contains(@"Visual Studio"))
            {
                dbPath = @"F:\Projects\SQLDBATool\SQLDBATool";
            }
            if (!dbPath.EndsWith(@"\"))
                dbPath += @"\";
            dbPath += @"Data\SqlDBTool.litedb";
            ConnectionString connString = new ConnectionString();
            connString.Filename = dbPath;
            connString.Connection = ConnectionType.Shared;
            connString.ReadOnly = false;

            Globals.ConnectionString = connString;
            //PopulateTreeViewItems();
        }

        public void PopulateTreeViewItems()
        {
            clsServerTreeController serverTreeController = new clsServerTreeController();
            clsMonitoredServerController serverController = new clsMonitoredServerController();
            ServerTree serverTree = serverTreeController.GetMasterServerTree();
            PopulateTreeItem(serverTree);
            treeViewConnections.ExpandAll();

        }
        public void PopulateTreeItem(ServerTree serverTree)
        {
            TreeNode treeNode = new TreeNode();
            CLSTreeInformation treeInformation = new CLSTreeInformation();

            treeInformation.ServerTree = serverTree;
            treeInformation.ConnectionTreeNode = treeViewConnections.Nodes.Add(serverTree.TreeName);
            treeInformation.ConnectionTreeNode.Tag = treeInformation;
            treeInformation.ConnectionTreeNode.ImageIndex = (serverTree.IsSubFolder ? 0 : 1);
            treeInformation.ConnectionTreeNode.ContextMenuStrip = contextMenuStripRootMenu;

            treeInformation.ServerDiagram = new ucServerDiagram(treeInformation);
            if (serverTree.ChildTreeNodes.Count > 0)
            {
                PopulateSubTreeItem(treeInformation);
            }
            ParentSqlToolsForm.AddServerDiagram(treeInformation.ServerDiagram);

        }
        public void PopulateSubTreeItem(CLSTreeInformation parentNode)
        {
            if (parentNode.ServerTree != null)
            {
                foreach (ServerTree serverTree in parentNode.ServerTree.ChildTreeNodes)
                {
                    if (serverTree != null)
                    {
                        TreeNode treeNode = new TreeNode();
                        CLSTreeInformation treeInformation = new CLSTreeInformation();
                        treeInformation.ServerTree = serverTree;
                        treeInformation.ConnectionTreeNode = parentNode.ConnectionTreeNode.Nodes.Add(serverTree.TreeName);
                        treeInformation.ConnectionTreeNode.Tag = treeInformation;
                        treeInformation.ConnectionTreeNode.ImageIndex = (serverTree.IsSubFolder ? 0 : 1);
                        treeInformation.ConnectionTreeNode.SelectedImageIndex = treeInformation.ConnectionTreeNode.ImageIndex;
                        parentNode.ChildConnections.Add(treeInformation);
                        treeInformation.ParentTreeInformation = parentNode;
                        if (serverTree.IsSubFolder)
                        {
                            treeInformation.ConnectionTreeNode.ContextMenuStrip = contextMenuStripFolder;
                            treeInformation.ServerDiagram = new ucServerDiagram(treeInformation);
                            if (serverTree.ChildTreeNodes.Count > 0)
                            {
                                PopulateSubTreeItem(treeInformation);
                            }
                            ParentSqlToolsForm.AddServerDiagram(treeInformation.ServerDiagram);
                        }
                        else
                        {
                            CLSConnectionInformation connectionInformation = new CLSConnectionInformation();
                            connectionInformation.ParentTreeInformation = treeInformation;
                            clsMonitoredServerController monitoredServerController = new clsMonitoredServerController();
                            connectionInformation.ServerTree = serverTree;
                            connectionInformation.MonitoredServer = monitoredServerController.GetMonitoredServer(serverTree.ServerID);
                            if (connectionInformation.MonitoredServer.IsDisabled)
                            {
                                treeInformation.ConnectionTreeNode.ContextMenuStrip = contextMenuStripServerDisabledConnection;
                                treeInformation.ConnectionTreeNode.ImageIndex = 2;
                            }
                            else
                            {
                                treeInformation.ConnectionTreeNode.ContextMenuStrip = contextMenuStripServerConnection;
                                treeInformation.ConnectionTreeNode.ImageIndex = 1;
                            }
                            connectionInformation.ServerStats = new clsServerStats();
                            connectionInformation.ServerIcon = new List<ucServerIcon>();
                            treeInformation.ConnectionInformation = connectionInformation;
                            TestTreeInformation = treeInformation;
                            treeInformation.ParentTreeInformation = parentNode;
                            CLSTreeInformation treeLoop = parentNode;
                            bool masterFound = false;
                            while (!masterFound)
                            {
                                treeLoop.ServerDiagram.AddServer(treeInformation);
                                if (treeLoop.ServerTree.MasterTreeItem)
                                    masterFound = true;
                                else
                                    treeLoop = treeLoop.ParentTreeInformation;
                            }
                            connectionInformation.StartRefreshProcess();

                        }
                    }
                }
            }
        }
        public void AppendNewTreeItem(ServerTree serverTree, CLSTreeInformation parentNode)
        {
            TreeNode treeNode = new TreeNode();
            CLSTreeInformation treeInformation = new CLSTreeInformation();

            treeInformation.ServerTree = serverTree;
            treeInformation.ConnectionTreeNode = parentNode.ConnectionTreeNode.Nodes.Add(serverTree.TreeName);
            treeInformation.ConnectionTreeNode.Tag = treeInformation;
            treeInformation.ConnectionTreeNode.ImageIndex = (serverTree.IsSubFolder ? 0 : 1);
            treeInformation.ConnectionTreeNode.ContextMenuStrip = contextMenuStripRootMenu;
            treeInformation.ParentTreeInformation = parentNode;
            if (serverTree.IsSubFolder)
            {
                treeInformation.ConnectionTreeNode.ContextMenuStrip = contextMenuStripFolder;
                treeInformation.ServerDiagram = new ucServerDiagram(treeInformation);
                if (serverTree.ChildTreeNodes.Count > 0)
                {
                    PopulateSubTreeItem(treeInformation);
                }
                ParentSqlToolsForm.AddServerDiagram(treeInformation.ServerDiagram);
            }
            else
            {
                CLSConnectionInformation connectionInformation = new CLSConnectionInformation();
                clsMonitoredServerController monitoredServerController = new clsMonitoredServerController();
                connectionInformation.ServerTree = serverTree;
                connectionInformation.MonitoredServer = monitoredServerController.GetMonitoredServer(serverTree.ServerID);
                if (connectionInformation.MonitoredServer.IsDisabled)
                {
                    treeInformation.ConnectionTreeNode.ContextMenuStrip = contextMenuStripServerDisabledConnection;
                    treeInformation.ConnectionTreeNode.ImageIndex = 2;
                }
                else
                {
                    treeInformation.ConnectionTreeNode.ContextMenuStrip = contextMenuStripServerConnection;
                    treeInformation.ConnectionTreeNode.ImageIndex = 1;
                }
                connectionInformation.ServerStats = new clsServerStats();
                connectionInformation.ServerIcon = new List<ucServerIcon>();
                treeInformation.ConnectionInformation = connectionInformation;
                TestTreeInformation = treeInformation;
                treeInformation.ParentTreeInformation = parentNode;
                CLSTreeInformation treeLoop = parentNode;
                bool masterFound = false;
                while (!masterFound)
                {
                    treeLoop.ServerDiagram.AddServer(treeInformation);
                    if (treeLoop.ServerTree.MasterTreeItem)
                        masterFound = true;
                    else
                        treeLoop = treeLoop.ParentTreeInformation;
                }
                connectionInformation.StartRefreshProcess();

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void newServerGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // use SourceControl property.. ContextMenuStrip must be associated with TreeView

            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;

            TreeView treeView = (TreeView)cms.SourceControl;

            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));
            CLSTreeInformation currentNode = (CLSTreeInformation)node.Tag;
            FormNewFolder newFolder = new FormNewFolder(currentNode, this);
            newFolder.ShowDialog();
        }
        private void newServerToolStripMenuItemNewConnection_Click(object sender, EventArgs e)
        {
            // use SourceControl property.. ContextMenuStrip must be associated with TreeView

            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;

            TreeView treeView = (TreeView)cms.SourceControl;

            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));
            CLSTreeInformation currentNode = (CLSTreeInformation)node.Tag;
            FormNewConnection newConnection = new FormNewConnection(currentNode, this);
            newConnection.ShowDialog();

        }

        private void treeViewConnections_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CLSTreeInformation currentNode = (CLSTreeInformation)e.Node.Tag;
            if (currentNode.ServerDiagram != null)
            {
                if (currentNode.ServerTree.IsSubFolder)
                {
                    ParentSqlToolsForm.ShowServerDiagram(currentNode.ServerDiagram);
                }
            }
            else if (!currentNode.ServerTree.IsSubFolder)
            {

                ParentSqlToolsForm.ShowServerMonitor(currentNode, true);
                
            }

        }

        private void contextMenuStripServerConnection_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItemDisable_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            TreeView treeView = (TreeView)cms.SourceControl;

            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));
            CLSTreeInformation currentNode = (CLSTreeInformation)node.Tag;
            currentNode.ConnectionInformation.MonitoredServer.IsDisabled = true;
            currentNode.ConnectionTreeNode.ContextMenuStrip = contextMenuStripServerDisabledConnection;
            currentNode.ConnectionTreeNode.ImageIndex = 2;
            using (clsMonitoredServerController monitoredServerController = new clsMonitoredServerController())
            {
                monitoredServerController.UpdateMonitoredServer(currentNode.ConnectionInformation.MonitoredServer);
            }



        }

        private void toolStripMenuItemEnableServer_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;

            TreeView treeView = (TreeView)cms.SourceControl;

            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));
            CLSTreeInformation currentNode = (CLSTreeInformation)node.Tag;
            currentNode.ConnectionInformation.MonitoredServer.IsDisabled = false;
            currentNode.ConnectionTreeNode.ContextMenuStrip = contextMenuStripServerConnection;
            currentNode.ConnectionTreeNode.ImageIndex = 1;
            using (clsMonitoredServerController monitoredServerController = new clsMonitoredServerController())
            {
                monitoredServerController.UpdateMonitoredServer(currentNode.ConnectionInformation.MonitoredServer);
            }

        }
    }
    public class CLSTreeInformation : IDisposable
    {

        private ServerTree FServerTree;
        private TreeNode FConnectionTreeNode;
        private List<CLSTreeInformation> FChildConnections;
        private CLSConnectionInformation FConnectionInformation;
        private ucServerDiagram FServerDiagram;
        private CLSTreeInformation FParentTreeInformation;
        public ServerTree ServerTree { get => FServerTree; set => FServerTree = value; }
        public TreeNode ConnectionTreeNode { get => FConnectionTreeNode; set => FConnectionTreeNode = value; }
        public List<CLSTreeInformation> ChildConnections { get => FChildConnections; set => FChildConnections = value; }
        internal CLSConnectionInformation ConnectionInformation { get => FConnectionInformation; set => FConnectionInformation = value; }
        public CLSTreeInformation ParentTreeInformation { get => FParentTreeInformation; set => FParentTreeInformation = value; }
        public ucServerDiagram ServerDiagram { get => FServerDiagram; set => FServerDiagram = value; }

        public CLSTreeInformation()
        {
            ChildConnections = new List<CLSTreeInformation>();

        }
        public void Dispose()
        {

        }
        public int GetMaxChildOrdinal()
        {
            int maxOrdinal = -1;
            if (FChildConnections.Count > 0)
            {
                foreach (CLSTreeInformation child in FChildConnections)
                {
                    if (child.ServerTree.TreeOrdinalPosition > maxOrdinal)
                        maxOrdinal = child.ServerTree.TreeOrdinalPosition;
                }
            }

            return maxOrdinal;
        }
    }


}
