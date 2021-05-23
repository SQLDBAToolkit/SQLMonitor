
namespace SQLDBATool.Code
{
    partial class ucServerDiagram
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
            this.flowLayoutPanelServerIcons = new System.Windows.Forms.FlowLayoutPanel();
            this.ucTitleBarServerDiagraph = new SQLDBATool.Code.ucTitleBar();
            this.SuspendLayout();
            // 
            // flowLayoutPanelServerIcons
            // 
            this.flowLayoutPanelServerIcons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelServerIcons.Location = new System.Drawing.Point(0, 20);
            this.flowLayoutPanelServerIcons.Name = "flowLayoutPanelServerIcons";
            this.flowLayoutPanelServerIcons.Size = new System.Drawing.Size(1633, 788);
            this.flowLayoutPanelServerIcons.TabIndex = 0;
            // 
            // ucTitleBarServerDiagraph
            // 
            this.ucTitleBarServerDiagraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleBarServerDiagraph.Location = new System.Drawing.Point(0, 0);
            this.ucTitleBarServerDiagraph.Name = "ucTitleBarServerDiagraph";
            this.ucTitleBarServerDiagraph.Size = new System.Drawing.Size(1633, 20);
            this.ucTitleBarServerDiagraph.TabIndex = 1;
            this.ucTitleBarServerDiagraph.TitleBold = false;
            this.ucTitleBarServerDiagraph.TitleText = null;
            // 
            // ucServerDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelServerIcons);
            this.Controls.Add(this.ucTitleBarServerDiagraph);
            this.Name = "ucServerDiagram";
            this.Size = new System.Drawing.Size(1633, 808);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelServerIcons;
        private ucTitleBar ucTitleBarServerDiagraph;
    }
}
