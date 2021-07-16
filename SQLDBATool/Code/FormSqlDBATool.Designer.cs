namespace SQLDBATool
{
    partial class FormSqlDBATool
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SQLDBATool.Code.SQLDBAToolSerialNumber sqldbaToolSerialNumber1 = new SQLDBATool.Code.SQLDBAToolSerialNumber();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSqlDBATool));
            this.splitContainerLayout = new System.Windows.Forms.SplitContainer();
            this.ucConnectionTree1 = new SQLDBATool.Code.ucConnectionTree();
            this.ucServerMonitor1 = new SQLDBATool.Code.ucServerMonitor();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alertingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.registrationInformaionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayout)).BeginInit();
            this.splitContainerLayout.Panel1.SuspendLayout();
            this.splitContainerLayout.Panel2.SuspendLayout();
            this.splitContainerLayout.SuspendLayout();
            this.statusStripBottom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerLayout
            // 
            this.splitContainerLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLayout.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerLayout.Location = new System.Drawing.Point(0, 24);
            this.splitContainerLayout.Name = "splitContainerLayout";
            // 
            // splitContainerLayout.Panel1
            // 
            this.splitContainerLayout.Panel1.Controls.Add(this.ucConnectionTree1);
            // 
            // splitContainerLayout.Panel2
            // 
            this.splitContainerLayout.Panel2.Controls.Add(this.ucServerMonitor1);
            this.splitContainerLayout.Size = new System.Drawing.Size(2164, 1113);
            this.splitContainerLayout.SplitterDistance = 306;
            this.splitContainerLayout.TabIndex = 0;
            // 
            // ucConnectionTree1
            // 
            this.ucConnectionTree1.BackColor = System.Drawing.Color.White;
            this.ucConnectionTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConnectionTree1.Location = new System.Drawing.Point(0, 0);
            this.ucConnectionTree1.Name = "ucConnectionTree1";
            this.ucConnectionTree1.ParentSqlToolsForm = null;
            this.ucConnectionTree1.ServerMonitor = null;
            this.ucConnectionTree1.Size = new System.Drawing.Size(302, 1109);
            this.ucConnectionTree1.TabIndex = 0;
            this.ucConnectionTree1.ThisTreeInformation = null;
            // 
            // ucServerMonitor1
            // 
            this.ucServerMonitor1.BackColor = System.Drawing.Color.Silver;
            this.ucServerMonitor1.ConnectionTree = null;
            this.ucServerMonitor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucServerMonitor1.Location = new System.Drawing.Point(0, 0);
            this.ucServerMonitor1.Name = "ucServerMonitor1";
            this.ucServerMonitor1.RegistrationInformation = sqldbaToolSerialNumber1;
            this.ucServerMonitor1.ServerID = new System.Guid("545bf3f1-33ad-4061-9fde-ff9628966183");
            this.ucServerMonitor1.SessionServerID = new System.Guid("545bf3f1-33ad-4061-9fde-ff9628966183");
            this.ucServerMonitor1.Size = new System.Drawing.Size(1850, 1109);
            this.ucServerMonitor1.TabIndex = 0;
            this.ucServerMonitor1.TreeInformation = null;
            this.ucServerMonitor1.Visible = false;
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripBottom.Location = new System.Drawing.Point(0, 1137);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(2164, 22);
            this.statusStripBottom.TabIndex = 1;
            this.statusStripBottom.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.backgroundTasksToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2164, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // backgroundTasksToolStripMenuItem
            // 
            this.backgroundTasksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alertingToolStripMenuItem});
            this.backgroundTasksToolStripMenuItem.Name = "backgroundTasksToolStripMenuItem";
            this.backgroundTasksToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.backgroundTasksToolStripMenuItem.Text = "Background Tasks";
            // 
            // alertingToolStripMenuItem
            // 
            this.alertingToolStripMenuItem.Name = "alertingToolStripMenuItem";
            this.alertingToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.alertingToolStripMenuItem.Text = "Alerting";
            this.alertingToolStripMenuItem.Click += new System.EventHandler(this.alertingToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.registrationInformaionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(200, 6);
            // 
            // registrationInformaionToolStripMenuItem
            // 
            this.registrationInformaionToolStripMenuItem.Name = "registrationInformaionToolStripMenuItem";
            this.registrationInformaionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.registrationInformaionToolStripMenuItem.Text = "Registration Information";
            this.registrationInformaionToolStripMenuItem.Click += new System.EventHandler(this.registrationInformaionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(200, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormSqlDBATool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2164, 1159);
            this.Controls.Add(this.splitContainerLayout);
            this.Controls.Add(this.statusStripBottom);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormSqlDBATool";
            this.Text = "FormSqlDBATool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainerLayout.Panel1.ResumeLayout(false);
            this.splitContainerLayout.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayout)).EndInit();
            this.splitContainerLayout.ResumeLayout(false);
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerLayout;
        private Code.ucConnectionTree ucConnectionTree1;
        private Code.ucServerMonitor ucServerMonitor1;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alertingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrationInformaionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}