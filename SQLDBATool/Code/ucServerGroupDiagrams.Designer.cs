
namespace SQLDBATool.Code
{
    partial class ucServerGroupDiagrams
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
            this.ucTitleBarGroupName = new SQLDBATool.Code.ucTitleBar();
            this.flowLayoutPanelServerIcons = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // ucTitleBarGroupName
            // 
            this.ucTitleBarGroupName.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleBarGroupName.Location = new System.Drawing.Point(0, 0);
            this.ucTitleBarGroupName.Name = "ucTitleBarGroupName";
            this.ucTitleBarGroupName.Size = new System.Drawing.Size(913, 20);
            this.ucTitleBarGroupName.TabIndex = 0;
            this.ucTitleBarGroupName.TitleBold = false;
            this.ucTitleBarGroupName.TitleText = null;
            // 
            // flowLayoutPanelServerIcons
            // 
            this.flowLayoutPanelServerIcons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelServerIcons.Location = new System.Drawing.Point(0, 20);
            this.flowLayoutPanelServerIcons.Name = "flowLayoutPanelServerIcons";
            this.flowLayoutPanelServerIcons.Size = new System.Drawing.Size(913, 314);
            this.flowLayoutPanelServerIcons.TabIndex = 1;
            // 
            // ucServerGroupDiagrams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelServerIcons);
            this.Controls.Add(this.ucTitleBarGroupName);
            this.Name = "ucServerGroupDiagrams";
            this.Size = new System.Drawing.Size(913, 334);
            this.ResumeLayout(false);

        }

        #endregion

        private ucTitleBar ucTitleBarGroupName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelServerIcons;
    }
}
