namespace SQLDBATool.Code
{
    partial class ucConnectionTree
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucConnectionTree));
            this.treeViewConnections = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.removeServerGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripRootMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newServerGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newServerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripServerConnection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripServerDisabledConnection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemEnableServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemoveServerDisabled = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemServerPropertiesDisabled = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDisconnectedConnection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemConnectToServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripFolder.SuspendLayout();
            this.contextMenuStripRootMenu.SuspendLayout();
            this.contextMenuStripServerConnection.SuspendLayout();
            this.contextMenuStripServerDisabledConnection.SuspendLayout();
            this.contextMenuStripDisconnectedConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewConnections
            // 
            this.treeViewConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewConnections.ImageIndex = 0;
            this.treeViewConnections.ImageList = this.imageList1;
            this.treeViewConnections.Location = new System.Drawing.Point(0, 0);
            this.treeViewConnections.Name = "treeViewConnections";
            this.treeViewConnections.SelectedImageIndex = 0;
            this.treeViewConnections.Size = new System.Drawing.Size(410, 660);
            this.treeViewConnections.TabIndex = 0;
            this.treeViewConnections.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewConnections_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "tvFolder.png");
            this.imageList1.Images.SetKeyName(1, "tvDatabase.png");
            this.imageList1.Images.SetKeyName(2, "tvDatabaseDisabled.png");
            // 
            // contextMenuStripFolder
            // 
            this.contextMenuStripFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFolderToolStripMenuItem,
            this.newServerToolStripMenuItem,
            this.toolStripSeparator3,
            this.removeServerGroupToolStripMenuItem,
            this.toolStripSeparator4,
            this.propertiesToolStripMenuItem});
            this.contextMenuStripFolder.Name = "contextMenuStripFolder";
            this.contextMenuStripFolder.Size = new System.Drawing.Size(189, 104);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.newFolderToolStripMenuItem.Text = "New Server Group";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newServerGroupToolStripMenuItem_Click);
            // 
            // newServerToolStripMenuItem
            // 
            this.newServerToolStripMenuItem.Name = "newServerToolStripMenuItem";
            this.newServerToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.newServerToolStripMenuItem.Text = "New Server";
            this.newServerToolStripMenuItem.Click += new System.EventHandler(this.newServerToolStripMenuItemNewConnection_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(185, 6);
            // 
            // removeServerGroupToolStripMenuItem
            // 
            this.removeServerGroupToolStripMenuItem.Name = "removeServerGroupToolStripMenuItem";
            this.removeServerGroupToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.removeServerGroupToolStripMenuItem.Text = "Remove Server Group";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(185, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // contextMenuStripRootMenu
            // 
            this.contextMenuStripRootMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newServerGroupToolStripMenuItem,
            this.newServerToolStripMenuItem1});
            this.contextMenuStripRootMenu.Name = "contextMenuStripRootMenu";
            this.contextMenuStripRootMenu.Size = new System.Drawing.Size(170, 48);
            // 
            // newServerGroupToolStripMenuItem
            // 
            this.newServerGroupToolStripMenuItem.Name = "newServerGroupToolStripMenuItem";
            this.newServerGroupToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.newServerGroupToolStripMenuItem.Text = "New Server Group";
            this.newServerGroupToolStripMenuItem.Click += new System.EventHandler(this.newServerGroupToolStripMenuItem_Click);
            // 
            // newServerToolStripMenuItem1
            // 
            this.newServerToolStripMenuItem1.Name = "newServerToolStripMenuItem1";
            this.newServerToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.newServerToolStripMenuItem1.Text = "New Server";
            this.newServerToolStripMenuItem1.Click += new System.EventHandler(this.newServerToolStripMenuItemNewConnection_Click);
            // 
            // contextMenuStripServerConnection
            // 
            this.contextMenuStripServerConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemConnect,
            this.toolStripMenuItemDisconnect,
            this.toolStripSeparator1,
            this.toolStripMenuItemDisable,
            this.toolStripMenuItemDeleteServer,
            this.toolStripSeparator2,
            this.toolStripMenuItemProperties});
            this.contextMenuStripServerConnection.Name = "contextMenuStrip1";
            this.contextMenuStripServerConnection.Size = new System.Drawing.Size(198, 126);
            this.contextMenuStripServerConnection.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripServerConnection_Opening);
            // 
            // toolStripMenuItemConnect
            // 
            this.toolStripMenuItemConnect.Enabled = false;
            this.toolStripMenuItemConnect.Name = "toolStripMenuItemConnect";
            this.toolStripMenuItemConnect.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItemConnect.Text = "Connect to Server";
            // 
            // toolStripMenuItemDisconnect
            // 
            this.toolStripMenuItemDisconnect.Name = "toolStripMenuItemDisconnect";
            this.toolStripMenuItemDisconnect.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItemDisconnect.Text = "Disconnect from Server";
            this.toolStripMenuItemDisconnect.Click += new System.EventHandler(this.toolStripMenuItemDisconnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // toolStripMenuItemDisable
            // 
            this.toolStripMenuItemDisable.Name = "toolStripMenuItemDisable";
            this.toolStripMenuItemDisable.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItemDisable.Text = "Disable Server";
            this.toolStripMenuItemDisable.Click += new System.EventHandler(this.toolStripMenuItemDisable_Click);
            // 
            // toolStripMenuItemDeleteServer
            // 
            this.toolStripMenuItemDeleteServer.Name = "toolStripMenuItemDeleteServer";
            this.toolStripMenuItemDeleteServer.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItemDeleteServer.Text = "Remove Server";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(194, 6);
            // 
            // toolStripMenuItemProperties
            // 
            this.toolStripMenuItemProperties.Name = "toolStripMenuItemProperties";
            this.toolStripMenuItemProperties.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItemProperties.Text = "Properties";
            this.toolStripMenuItemProperties.Click += new System.EventHandler(this.toolStripMenuItemProperties_Click);
            // 
            // contextMenuStripServerDisabledConnection
            // 
            this.contextMenuStripServerDisabledConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator5,
            this.toolStripMenuItemEnableServer,
            this.toolStripMenuItemRemoveServerDisabled,
            this.toolStripSeparator6,
            this.toolStripMenuItemServerPropertiesDisabled});
            this.contextMenuStripServerDisabledConnection.Name = "contextMenuStrip1";
            this.contextMenuStripServerDisabledConnection.Size = new System.Drawing.Size(198, 126);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem1.Text = "Connect to Server";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem2.Text = "Disconnect from Server";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(194, 6);
            // 
            // toolStripMenuItemEnableServer
            // 
            this.toolStripMenuItemEnableServer.Name = "toolStripMenuItemEnableServer";
            this.toolStripMenuItemEnableServer.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItemEnableServer.Text = "Enable Server";
            this.toolStripMenuItemEnableServer.Click += new System.EventHandler(this.toolStripMenuItemEnableServer_Click);
            // 
            // toolStripMenuItemRemoveServerDisabled
            // 
            this.toolStripMenuItemRemoveServerDisabled.Name = "toolStripMenuItemRemoveServerDisabled";
            this.toolStripMenuItemRemoveServerDisabled.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItemRemoveServerDisabled.Text = "Remove Server";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(194, 6);
            // 
            // toolStripMenuItemServerPropertiesDisabled
            // 
            this.toolStripMenuItemServerPropertiesDisabled.Name = "toolStripMenuItemServerPropertiesDisabled";
            this.toolStripMenuItemServerPropertiesDisabled.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItemServerPropertiesDisabled.Text = "Properties";
            this.toolStripMenuItemServerPropertiesDisabled.Click += new System.EventHandler(this.toolStripMenuItemProperties_Click);
            // 
            // contextMenuStripDisconnectedConnection
            // 
            this.contextMenuStripDisconnectedConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemConnectToServer,
            this.toolStripMenuItem4,
            this.toolStripSeparator7,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripSeparator8,
            this.toolStripMenuItem7});
            this.contextMenuStripDisconnectedConnection.Name = "contextMenuStrip1";
            this.contextMenuStripDisconnectedConnection.Size = new System.Drawing.Size(198, 126);
            this.contextMenuStripDisconnectedConnection.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItemConnectToServer
            // 
            this.toolStripMenuItemConnectToServer.Name = "toolStripMenuItemConnectToServer";
            this.toolStripMenuItemConnectToServer.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItemConnectToServer.Text = "Connect to Server";
            this.toolStripMenuItemConnectToServer.Click += new System.EventHandler(this.toolStripMenuItemConnect_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem4.Text = "Disconnect from Server";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(194, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem5.Text = "Disable Server";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItemDisable_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem6.Text = "Remove Server";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(194, 6);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem7.Text = "Properties";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItemProperties_Click);
            // 
            // ucConnectionTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.treeViewConnections);
            this.Name = "ucConnectionTree";
            this.Size = new System.Drawing.Size(410, 660);
            this.contextMenuStripFolder.ResumeLayout(false);
            this.contextMenuStripRootMenu.ResumeLayout(false);
            this.contextMenuStripServerConnection.ResumeLayout(false);
            this.contextMenuStripServerDisabledConnection.ResumeLayout(false);
            this.contextMenuStripDisconnectedConnection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewConnections;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFolder;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeServerGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRootMenu;
        private System.Windows.Forms.ToolStripMenuItem newServerGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newServerToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripServerConnection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConnect;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisable;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProperties;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripServerDisabledConnection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnableServer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveServerDisabled;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemServerPropertiesDisabled;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDisconnectedConnection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemConnectToServer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
    }
}
