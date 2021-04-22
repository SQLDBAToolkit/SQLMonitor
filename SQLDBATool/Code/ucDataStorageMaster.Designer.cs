
namespace SQLDBATool.Code
{
    partial class ucDataStorageMaster
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
            this.ucDatabaseStorageMain = new SQLDBATool.Code.ucDatabaseStorage();
            this.SuspendLayout();
            // 
            // ucDatabaseStorageMain
            // 
            this.ucDatabaseStorageMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucDatabaseStorageMain.HeaderTitle = "Database Storage";
            this.ucDatabaseStorageMain.Location = new System.Drawing.Point(0, 0);
            this.ucDatabaseStorageMain.Name = "ucDatabaseStorageMain";
            this.ucDatabaseStorageMain.Size = new System.Drawing.Size(931, 95);
            this.ucDatabaseStorageMain.TabIndex = 0;
            this.ucDatabaseStorageMain.TotalSizeData = 0;
            this.ucDatabaseStorageMain.TotalSizeFileStream = 0;
            this.ucDatabaseStorageMain.TotalSizeLog = 0;
            // 
            // ucDataStorageMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucDatabaseStorageMain);
            this.Name = "ucDataStorageMaster";
            this.Size = new System.Drawing.Size(931, 390);
            this.Resize += new System.EventHandler(this.ucDataStorageMaster_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private ucDatabaseStorage ucDatabaseStorageMain;
    }
}
