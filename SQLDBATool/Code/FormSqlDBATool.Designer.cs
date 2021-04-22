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
            this.splitContainerLayout = new System.Windows.Forms.SplitContainer();
            this.ucConnectionTree1 = new SQLDBATool.Code.ucConnectionTree();
            this.ucServerMonitor1 = new SQLDBATool.Code.ucServerMonitor();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayout)).BeginInit();
            this.splitContainerLayout.Panel1.SuspendLayout();
            this.splitContainerLayout.Panel2.SuspendLayout();
            this.splitContainerLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerLayout
            // 
            this.splitContainerLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLayout.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerLayout.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLayout.Name = "splitContainerLayout";
            // 
            // splitContainerLayout.Panel1
            // 
            this.splitContainerLayout.Panel1.Controls.Add(this.ucConnectionTree1);
            // 
            // splitContainerLayout.Panel2
            // 
            this.splitContainerLayout.Panel2.Controls.Add(this.ucServerMonitor1);
            this.splitContainerLayout.Size = new System.Drawing.Size(1443, 773);
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
            this.ucConnectionTree1.Size = new System.Drawing.Size(302, 769);
            this.ucConnectionTree1.TabIndex = 0;
            // 
            // ucServerMonitor1
            // 
            this.ucServerMonitor1.BackColor = System.Drawing.Color.Silver;
            this.ucServerMonitor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucServerMonitor1.Location = new System.Drawing.Point(0, 0);
            this.ucServerMonitor1.Name = "ucServerMonitor1";
            this.ucServerMonitor1.ServerID = new System.Guid("545bf3f1-33ad-4061-9fde-ff9628966183");
            this.ucServerMonitor1.SessionServerID = new System.Guid("545bf3f1-33ad-4061-9fde-ff9628966183");
            this.ucServerMonitor1.Size = new System.Drawing.Size(1129, 769);
            this.ucServerMonitor1.TabIndex = 0;
            this.ucServerMonitor1.Visible = false;
            // 
            // FormSqlDBATool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 773);
            this.Controls.Add(this.splitContainerLayout);
            this.DoubleBuffered = true;
            this.Name = "FormSqlDBATool";
            this.Text = "FormSqlDBATool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainerLayout.Panel1.ResumeLayout(false);
            this.splitContainerLayout.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLayout)).EndInit();
            this.splitContainerLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerLayout;
        private Code.ucConnectionTree ucConnectionTree1;
        private Code.ucServerMonitor ucServerMonitor1;
    }
}