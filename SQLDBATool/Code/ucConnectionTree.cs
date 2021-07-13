﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace SQLDBATool.Code
{
    public partial class ucConnectionTree : UserControl
    {
        private List<CLSTreeInformation> FTreeInformation = new List<CLSTreeInformation>();
        private CLSTreeInformation FThisTreeInformation;
        private FormSqlDBATool FParentSqlToolsForm;
        private ucServerMonitor FServerMonitor;
        private SQLDBAToolSerialNumber FRegistrationInformation;
        public SQLDBAToolSerialNumber RegistrationInformation
        {
            get => FRegistrationInformation;
            set
            {
                FRegistrationInformation = value;
                ucRegistrationInformation1.RegistrationInformation = value;
                ucRegistrationInformation1.DisplayRegistrationInformation();
            }
        }
        public FormSqlDBATool ParentSqlToolsForm
        {
            get => FParentSqlToolsForm;
            set
            {
                FParentSqlToolsForm = value;
            }
        }
        public CLSTreeInformation ThisTreeInformation { get => FThisTreeInformation; set => FThisTreeInformation = value; }
        public ucServerMonitor ServerMonitor 
        {
            get => FServerMonitor;
            set
            {
                FServerMonitor = value;
            }
        }

        public ucConnectionTree()
        {
            InitializeComponent();
            
            string dbPath = Application.StartupPath;

            if (dbPath.StartsWith(@"E:\Projects\SQLDBATool\SQLDBATool") ||
                dbPath.Contains(@"Visual Studio"))
            {
                dbPath = @"E:\Projects\SQLDBATool\SQLDBATool";
            }
            if (!dbPath.EndsWith(@"\"))
                dbPath += @"\";
            dbPath += @"Data\SqlDBTool.litedb";
            ConnectionString connString = new ConnectionString();
            connString.Filename = dbPath;
            connString.Connection = ConnectionType.Shared;
            connString.Password = "cXWD9OKmQgwk4z95G5SI";
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
        public void SelectTreeNode(TreeNode treeNode)
        {
            treeViewConnections.SelectedNode = treeNode;
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
            treeInformation.ParentTree = this;
            treeInformation.ServerDiagram = new ucServerDiagram(treeInformation);
            if (serverTree.ChildTreeNodes.Count > 0)
            {
                PopulateSubTreeItem(treeInformation);
            }
            ParentSqlToolsForm.AddServerDiagram(treeInformation.ServerDiagram);
            FThisTreeInformation = treeInformation;
        }
        public ContextMenuStrip GetContextMenu(string menuType)
        {
            if (menuType.ToUpper() == "DISCONNECT")
                return contextMenuStripDisconnectedConnection;
            else
                return contextMenuStripServerConnection;
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
                        treeInformation.ParentTree = this;
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
                            connectionInformation.ServerIcon = new List<Code.ucServerIcon>();
                            treeInformation.ConnectionInformation = connectionInformation;
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
                            if (!connectionInformation.MonitoredServer.IsDisabled)
                                connectionInformation.StartRefreshProcess();
                            else
                                foreach (Code.ucServerIcon icon in connectionInformation.ServerIcon)
                                {
                                    icon.SetTitleColor(Color.Black, Color.LightGray);
                                }

                        }
                    }
                }
            }
        }
        public void AppendNewTreeItem(ServerTree serverTree, CLSTreeInformation parentNode)
        {
            //TreeNode treeNode = new TreeNode();
            CLSTreeInformation treeInformation = new CLSTreeInformation();

            treeInformation.ServerTree = serverTree;
            treeInformation.ConnectionTreeNode = parentNode.ConnectionTreeNode.Nodes.Add(serverTree.TreeName);
            treeInformation.ConnectionTreeNode.Tag = treeInformation;
            treeInformation.ConnectionTreeNode.ImageIndex = (serverTree.IsSubFolder ? 0 : 1);
            treeInformation.ConnectionTreeNode.ContextMenuStrip = contextMenuStripRootMenu;
            treeInformation.ParentTreeInformation = parentNode;
            treeInformation.ParentTree = this;
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
            ShowServerDiagram(currentNode);
        }

        public void ShowServerDiagram(CLSTreeInformation currentNode)
        {
            
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

            currentNode.ConnectionInformation.StopRefreshProcess();
            foreach (Code.ucServerIcon icon in currentNode.ConnectionInformation.ServerIcon)
            {
                icon.SetTitleColor(Color.Black, Color.LightGray);
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
            foreach (Code.ucServerIcon icon in currentNode.ConnectionInformation.ServerIcon)
            {
                icon.SetTitleColor(Color.Black, Color.LightSlateGray);
            }
            currentNode.ConnectionInformation.StartRefreshProcess();

        }

        private void toolStripMenuItemProperties_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;

            TreeView treeView = (TreeView)cms.SourceControl;

            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));
            CLSTreeInformation currentNode = (CLSTreeInformation)node.Tag;

            FormConnectionProperties connectionProperties = new FormConnectionProperties(currentNode);
            connectionProperties.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItemDisconnect_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            TreeView treeView = (TreeView)cms.SourceControl;

            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));
            CLSTreeInformation currentNode = (CLSTreeInformation)node.Tag;
            currentNode.ConnectionTreeNode.ContextMenuStrip = contextMenuStripDisconnectedConnection;
            currentNode.ConnectionTreeNode.ImageIndex = 2;

            currentNode.ConnectionInformation.StopRefreshProcess();
            foreach (Code.ucServerIcon icon in currentNode.ConnectionInformation.ServerIcon)
            {
                icon.SetTitleColor(Color.Black, Color.Gray);
            }

        }

        private void toolStripMenuItemConnect_Click(object sender, EventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            TreeView treeView = (TreeView)cms.SourceControl;

            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));
            CLSTreeInformation currentNode = (CLSTreeInformation)node.Tag;
            currentNode.ConnectionTreeNode.ContextMenuStrip = contextMenuStripServerConnection;
            currentNode.ConnectionTreeNode.ImageIndex = 1;

            currentNode.ConnectionInformation.StartRefreshProcess();

        }
    }
    public class CLSTreeInformation : IDisposable
    {

        private ServerTree FServerTree;
        private TreeNode FConnectionTreeNode;
        private List<CLSTreeInformation> FChildConnections;
        private CLSConnectionInformation FConnectionInformation;
        private ucServerDiagram FServerDiagram;
        private ucConnectionTree FParentTree;
        private CLSTreeInformation FParentTreeInformation;
        public ServerTree ServerTree { get => FServerTree; set => FServerTree = value; }
        public TreeNode ConnectionTreeNode { get => FConnectionTreeNode; set => FConnectionTreeNode = value; }
        public List<CLSTreeInformation> ChildConnections { get => FChildConnections; set => FChildConnections = value; }
        internal CLSConnectionInformation ConnectionInformation { get => FConnectionInformation; set => FConnectionInformation = value; }
        public CLSTreeInformation ParentTreeInformation { get => FParentTreeInformation; set => FParentTreeInformation = value; }
        public ucServerDiagram ServerDiagram { get => FServerDiagram; set => FServerDiagram = value; }
        public ucConnectionTree ParentTree { get => FParentTree; set => FParentTree = value; }

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
