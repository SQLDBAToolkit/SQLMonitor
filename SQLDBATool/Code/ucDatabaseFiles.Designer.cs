
namespace SQLDBATool.Code
{
    partial class ucDatabaseFiles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ucTitleBar1 = new SQLDBATool.Code.ucTitleBar();
            this.dbDataGridView1 = new SQLDBATool.Code.DBDataGridView();
            this.dataSetDatabaseInformation = new System.Data.DataSet();
            this.dataTableDatabaseFiles = new System.Data.DataTable();
            this.dataColumnFIDatabaseId = new System.Data.DataColumn();
            this.dataColumnFIDatabaseName = new System.Data.DataColumn();
            this.dataColumnFIFileId = new System.Data.DataColumn();
            this.dataColumnFIFileName = new System.Data.DataColumn();
            this.dataColumnFIPhysicalName = new System.Data.DataColumn();
            this.dataColumnFIFileType = new System.Data.DataColumn();
            this.dataColumnFIFileSizeMb = new System.Data.DataColumn();
            this.dataColumnFIFileUsedMb = new System.Data.DataColumn();
            this.dataColumnFIFileFreeBb = new System.Data.DataColumn();
            this.dataColumnFIFileFreePct = new System.Data.DataColumn();
            this.dataColumnFIGrowthUnits = new System.Data.DataColumn();
            this.dataColumnFIMaxSizeMb = new System.Data.DataColumn();
            this.dataColumnFISortFileSizeMb = new System.Data.DataColumn();
            this.dataColumnFISortFileFreeMb = new System.Data.DataColumn();
            this.dataColumnFISortFileUsedMb = new System.Data.DataColumn();
            this.dataColumnFISortFileFreePct = new System.Data.DataColumn();
            this.databaseidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.physicalnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filetypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filesizembDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileusedmbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filefreebbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filefreepctDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.growthunitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxsizembDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortfilesizembDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortfilefreembDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortfileusedmbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortfilefreepctDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDatabaseInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDatabaseFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // ucTitleBar1
            // 
            this.ucTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ucTitleBar1.Name = "ucTitleBar1";
            this.ucTitleBar1.Size = new System.Drawing.Size(988, 20);
            this.ucTitleBar1.TabIndex = 0;
            this.ucTitleBar1.TitleText = "Database Files";
            // 
            // dbDataGridView1
            // 
            this.dbDataGridView1.AllowUserToAddRows = false;
            this.dbDataGridView1.AllowUserToDeleteRows = false;
            this.dbDataGridView1.AllowUserToResizeRows = false;
            this.dbDataGridView1.AutoGenerateColumns = false;
            this.dbDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dbDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dbDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.databaseidDataGridViewTextBoxColumn,
            this.databaseNameDataGridViewTextBoxColumn,
            this.fileidDataGridViewTextBoxColumn,
            this.filenameDataGridViewTextBoxColumn,
            this.physicalnameDataGridViewTextBoxColumn,
            this.filetypeDataGridViewTextBoxColumn,
            this.filesizembDataGridViewTextBoxColumn,
            this.fileusedmbDataGridViewTextBoxColumn,
            this.filefreebbDataGridViewTextBoxColumn,
            this.filefreepctDataGridViewTextBoxColumn,
            this.growthunitsDataGridViewTextBoxColumn,
            this.maxsizembDataGridViewTextBoxColumn,
            this.sortfilesizembDataGridViewTextBoxColumn,
            this.sortfilefreembDataGridViewTextBoxColumn,
            this.sortfileusedmbDataGridViewTextBoxColumn,
            this.sortfilefreepctDataGridViewTextBoxColumn,
            this.Filler});
            this.dbDataGridView1.DataMember = "DTDatebaseFiles";
            this.dbDataGridView1.DataSource = this.dataSetDatabaseInformation;
            this.dbDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbDataGridView1.Location = new System.Drawing.Point(0, 20);
            this.dbDataGridView1.MultiSelect = false;
            this.dbDataGridView1.Name = "dbDataGridView1";
            this.dbDataGridView1.RowHeadersVisible = false;
            this.dbDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbDataGridView1.Size = new System.Drawing.Size(988, 244);
            this.dbDataGridView1.TabIndex = 1;
            // 
            // dataSetDatabaseInformation
            // 
            this.dataSetDatabaseInformation.DataSetName = "dataSetFileInformation";
            this.dataSetDatabaseInformation.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableDatabaseFiles});
            // 
            // dataTableDatabaseFiles
            // 
            this.dataTableDatabaseFiles.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnFIDatabaseId,
            this.dataColumnFIDatabaseName,
            this.dataColumnFIFileId,
            this.dataColumnFIFileName,
            this.dataColumnFIPhysicalName,
            this.dataColumnFIFileType,
            this.dataColumnFIFileSizeMb,
            this.dataColumnFIFileUsedMb,
            this.dataColumnFIFileFreeBb,
            this.dataColumnFIFileFreePct,
            this.dataColumnFIGrowthUnits,
            this.dataColumnFIMaxSizeMb,
            this.dataColumnFISortFileSizeMb,
            this.dataColumnFISortFileFreeMb,
            this.dataColumnFISortFileUsedMb,
            this.dataColumnFISortFileFreePct});
            this.dataTableDatabaseFiles.TableName = "DTDatebaseFiles";
            // 
            // dataColumnFIDatabaseId
            // 
            this.dataColumnFIDatabaseId.ColumnName = "database_id";
            this.dataColumnFIDatabaseId.DataType = typeof(int);
            // 
            // dataColumnFIDatabaseName
            // 
            this.dataColumnFIDatabaseName.ColumnName = "Database_Name";
            // 
            // dataColumnFIFileId
            // 
            this.dataColumnFIFileId.ColumnName = "file_id";
            this.dataColumnFIFileId.DataType = typeof(int);
            // 
            // dataColumnFIFileName
            // 
            this.dataColumnFIFileName.ColumnName = "file_name";
            // 
            // dataColumnFIPhysicalName
            // 
            this.dataColumnFIPhysicalName.ColumnName = "physical_name";
            // 
            // dataColumnFIFileType
            // 
            this.dataColumnFIFileType.ColumnName = "file_type";
            // 
            // dataColumnFIFileSizeMb
            // 
            this.dataColumnFIFileSizeMb.ColumnName = "file_size_mb";
            // 
            // dataColumnFIFileUsedMb
            // 
            this.dataColumnFIFileUsedMb.ColumnName = "file_used_mb";
            // 
            // dataColumnFIFileFreeBb
            // 
            this.dataColumnFIFileFreeBb.ColumnName = "file_free_mb";
            // 
            // dataColumnFIFileFreePct
            // 
            this.dataColumnFIFileFreePct.ColumnName = "file_free_pct";
            // 
            // dataColumnFIGrowthUnits
            // 
            this.dataColumnFIGrowthUnits.ColumnName = "growth_units";
            // 
            // dataColumnFIMaxSizeMb
            // 
            this.dataColumnFIMaxSizeMb.ColumnName = "max_size_mb";
            // 
            // dataColumnFISortFileSizeMb
            // 
            this.dataColumnFISortFileSizeMb.ColumnName = "sort_file_size_mb";
            this.dataColumnFISortFileSizeMb.DataType = typeof(int);
            // 
            // dataColumnFISortFileFreeMb
            // 
            this.dataColumnFISortFileFreeMb.ColumnName = "sort_file_free_mb";
            this.dataColumnFISortFileFreeMb.DataType = typeof(int);
            // 
            // dataColumnFISortFileUsedMb
            // 
            this.dataColumnFISortFileUsedMb.ColumnName = "sort_file_used_mb";
            this.dataColumnFISortFileUsedMb.DataType = typeof(int);
            // 
            // dataColumnFISortFileFreePct
            // 
            this.dataColumnFISortFileFreePct.ColumnName = "sort_file_free_pct";
            this.dataColumnFISortFileFreePct.DataType = typeof(decimal);
            // 
            // databaseidDataGridViewTextBoxColumn
            // 
            this.databaseidDataGridViewTextBoxColumn.DataPropertyName = "database_id";
            this.databaseidDataGridViewTextBoxColumn.HeaderText = "Database ID";
            this.databaseidDataGridViewTextBoxColumn.Name = "databaseidDataGridViewTextBoxColumn";
            this.databaseidDataGridViewTextBoxColumn.Width = 92;
            // 
            // databaseNameDataGridViewTextBoxColumn
            // 
            this.databaseNameDataGridViewTextBoxColumn.DataPropertyName = "Database_Name";
            this.databaseNameDataGridViewTextBoxColumn.HeaderText = "Database Name";
            this.databaseNameDataGridViewTextBoxColumn.Name = "databaseNameDataGridViewTextBoxColumn";
            this.databaseNameDataGridViewTextBoxColumn.Width = 109;
            // 
            // fileidDataGridViewTextBoxColumn
            // 
            this.fileidDataGridViewTextBoxColumn.DataPropertyName = "file_id";
            this.fileidDataGridViewTextBoxColumn.HeaderText = "File ID";
            this.fileidDataGridViewTextBoxColumn.Name = "fileidDataGridViewTextBoxColumn";
            this.fileidDataGridViewTextBoxColumn.Width = 62;
            // 
            // filenameDataGridViewTextBoxColumn
            // 
            this.filenameDataGridViewTextBoxColumn.DataPropertyName = "file_name";
            this.filenameDataGridViewTextBoxColumn.HeaderText = "File Name";
            this.filenameDataGridViewTextBoxColumn.Name = "filenameDataGridViewTextBoxColumn";
            this.filenameDataGridViewTextBoxColumn.Width = 79;
            // 
            // physicalnameDataGridViewTextBoxColumn
            // 
            this.physicalnameDataGridViewTextBoxColumn.DataPropertyName = "physical_name";
            this.physicalnameDataGridViewTextBoxColumn.HeaderText = "Physical Name";
            this.physicalnameDataGridViewTextBoxColumn.Name = "physicalnameDataGridViewTextBoxColumn";
            this.physicalnameDataGridViewTextBoxColumn.Width = 102;
            // 
            // filetypeDataGridViewTextBoxColumn
            // 
            this.filetypeDataGridViewTextBoxColumn.DataPropertyName = "file_type";
            this.filetypeDataGridViewTextBoxColumn.HeaderText = "File Type";
            this.filetypeDataGridViewTextBoxColumn.Name = "filetypeDataGridViewTextBoxColumn";
            this.filetypeDataGridViewTextBoxColumn.Width = 75;
            // 
            // filesizembDataGridViewTextBoxColumn
            // 
            this.filesizembDataGridViewTextBoxColumn.DataPropertyName = "file_size_mb";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.filesizembDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.filesizembDataGridViewTextBoxColumn.HeaderText = "Size (Mb)";
            this.filesizembDataGridViewTextBoxColumn.Name = "filesizembDataGridViewTextBoxColumn";
            this.filesizembDataGridViewTextBoxColumn.Width = 76;
            // 
            // fileusedmbDataGridViewTextBoxColumn
            // 
            this.fileusedmbDataGridViewTextBoxColumn.DataPropertyName = "file_used_mb";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.fileusedmbDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.fileusedmbDataGridViewTextBoxColumn.HeaderText = "Used (Mb)";
            this.fileusedmbDataGridViewTextBoxColumn.Name = "fileusedmbDataGridViewTextBoxColumn";
            this.fileusedmbDataGridViewTextBoxColumn.Width = 81;
            // 
            // filefreebbDataGridViewTextBoxColumn
            // 
            this.filefreebbDataGridViewTextBoxColumn.DataPropertyName = "file_free_mb";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.filefreebbDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.filefreebbDataGridViewTextBoxColumn.HeaderText = "Free (Mb)";
            this.filefreebbDataGridViewTextBoxColumn.Name = "filefreebbDataGridViewTextBoxColumn";
            this.filefreebbDataGridViewTextBoxColumn.Width = 77;
            // 
            // filefreepctDataGridViewTextBoxColumn
            // 
            this.filefreepctDataGridViewTextBoxColumn.DataPropertyName = "file_free_pct";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.filefreepctDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.filefreepctDataGridViewTextBoxColumn.HeaderText = "Free (%)";
            this.filefreepctDataGridViewTextBoxColumn.Name = "filefreepctDataGridViewTextBoxColumn";
            this.filefreepctDataGridViewTextBoxColumn.Width = 70;
            // 
            // growthunitsDataGridViewTextBoxColumn
            // 
            this.growthunitsDataGridViewTextBoxColumn.DataPropertyName = "growth_units";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.growthunitsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.growthunitsDataGridViewTextBoxColumn.HeaderText = "File Growth";
            this.growthunitsDataGridViewTextBoxColumn.Name = "growthunitsDataGridViewTextBoxColumn";
            this.growthunitsDataGridViewTextBoxColumn.Width = 85;
            // 
            // maxsizembDataGridViewTextBoxColumn
            // 
            this.maxsizembDataGridViewTextBoxColumn.DataPropertyName = "max_size_mb";
            this.maxsizembDataGridViewTextBoxColumn.HeaderText = "max_size_mb";
            this.maxsizembDataGridViewTextBoxColumn.Name = "maxsizembDataGridViewTextBoxColumn";
            this.maxsizembDataGridViewTextBoxColumn.Visible = false;
            this.maxsizembDataGridViewTextBoxColumn.Width = 95;
            // 
            // sortfilesizembDataGridViewTextBoxColumn
            // 
            this.sortfilesizembDataGridViewTextBoxColumn.DataPropertyName = "sort_file_size_mb";
            this.sortfilesizembDataGridViewTextBoxColumn.HeaderText = "sort_file_size_mb";
            this.sortfilesizembDataGridViewTextBoxColumn.Name = "sortfilesizembDataGridViewTextBoxColumn";
            this.sortfilesizembDataGridViewTextBoxColumn.Visible = false;
            this.sortfilesizembDataGridViewTextBoxColumn.Width = 112;
            // 
            // sortfilefreembDataGridViewTextBoxColumn
            // 
            this.sortfilefreembDataGridViewTextBoxColumn.DataPropertyName = "sort_file_free_mb";
            this.sortfilefreembDataGridViewTextBoxColumn.HeaderText = "sort_file_free_mb";
            this.sortfilefreembDataGridViewTextBoxColumn.Name = "sortfilefreembDataGridViewTextBoxColumn";
            this.sortfilefreembDataGridViewTextBoxColumn.Visible = false;
            this.sortfilefreembDataGridViewTextBoxColumn.Width = 112;
            // 
            // sortfileusedmbDataGridViewTextBoxColumn
            // 
            this.sortfileusedmbDataGridViewTextBoxColumn.DataPropertyName = "sort_file_used_mb";
            this.sortfileusedmbDataGridViewTextBoxColumn.HeaderText = "sort_file_used_mb";
            this.sortfileusedmbDataGridViewTextBoxColumn.Name = "sortfileusedmbDataGridViewTextBoxColumn";
            this.sortfileusedmbDataGridViewTextBoxColumn.Visible = false;
            this.sortfileusedmbDataGridViewTextBoxColumn.Width = 117;
            // 
            // sortfilefreepctDataGridViewTextBoxColumn
            // 
            this.sortfilefreepctDataGridViewTextBoxColumn.DataPropertyName = "sort_file_free_pct";
            this.sortfilefreepctDataGridViewTextBoxColumn.HeaderText = "sort_file_free_pct";
            this.sortfilefreepctDataGridViewTextBoxColumn.Name = "sortfilefreepctDataGridViewTextBoxColumn";
            this.sortfilefreepctDataGridViewTextBoxColumn.Visible = false;
            this.sortfilefreepctDataGridViewTextBoxColumn.Width = 113;
            // 
            // Filler
            // 
            this.Filler.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Filler.HeaderText = "";
            this.Filler.Name = "Filler";
            // 
            // ucDatabaseFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dbDataGridView1);
            this.Controls.Add(this.ucTitleBar1);
            this.Name = "ucDatabaseFiles";
            this.Size = new System.Drawing.Size(988, 264);
            ((System.ComponentModel.ISupportInitialize)(this.dbDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDatabaseInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDatabaseFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ucTitleBar ucTitleBar1;
        private DBDataGridView dbDataGridView1;
        private System.Data.DataSet dataSetDatabaseInformation;
        private System.Data.DataTable dataTableDatabaseFiles;
        private System.Data.DataColumn dataColumnFIDatabaseId;
        private System.Data.DataColumn dataColumnFIDatabaseName;
        private System.Data.DataColumn dataColumnFIFileId;
        private System.Data.DataColumn dataColumnFIFileName;
        private System.Data.DataColumn dataColumnFIPhysicalName;
        private System.Data.DataColumn dataColumnFIFileType;
        private System.Data.DataColumn dataColumnFIFileSizeMb;
        private System.Data.DataColumn dataColumnFIFileUsedMb;
        private System.Data.DataColumn dataColumnFIFileFreeBb;
        private System.Data.DataColumn dataColumnFIFileFreePct;
        private System.Data.DataColumn dataColumnFIGrowthUnits;
        private System.Data.DataColumn dataColumnFIMaxSizeMb;
        private System.Data.DataColumn dataColumnFISortFileSizeMb;
        private System.Data.DataColumn dataColumnFISortFileFreeMb;
        private System.Data.DataColumn dataColumnFISortFileUsedMb;
        private System.Data.DataColumn dataColumnFISortFileFreePct;
        private System.Windows.Forms.DataGridViewTextBoxColumn databaseidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn databaseNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn physicalnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filetypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filesizembDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileusedmbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filefreebbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filefreepctDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn growthunitsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxsizembDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortfilesizembDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortfilefreembDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortfileusedmbDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortfilefreepctDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filler;
    }
}
