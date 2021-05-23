
namespace SQLDBATool.Code
{
    partial class ucDatabaseStorage
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
            this.dataSetServerInformation = new System.Data.DataSet();
            this.dataTableDatabaseInformation = new System.Data.DataTable();
            this.dataColumnDIDatabaseId = new System.Data.DataColumn();
            this.dataColumnDIDatabaseName = new System.Data.DataColumn();
            this.dataColumnDIOwner = new System.Data.DataColumn();
            this.dataColumnDICreateDate = new System.Data.DataColumn();
            this.dataColumnDICompatibilityLevel = new System.Data.DataColumn();
            this.dataColumnDICollationName = new System.Data.DataColumn();
            this.dataColumnDIUserAccessDesc = new System.Data.DataColumn();
            this.dataColumnDIIsReadOnly = new System.Data.DataColumn();
            this.dataColumnDIStateDesc = new System.Data.DataColumn();
            this.dataColumnDIRecoveryModelDesc = new System.Data.DataColumn();
            this.dataColumnDIRestoreDate = new System.Data.DataColumn();
            this.dataColumnDILastFullBackup = new System.Data.DataColumn();
            this.dataColumnDILastFullBackupSize = new System.Data.DataColumn();
            this.dataColumnDILastFullBackupCompressedSize = new System.Data.DataColumn();
            this.dataColumnDILastOtherBackup = new System.Data.DataColumn();
            this.dataColumnDILastOtherBackupSize = new System.Data.DataColumn();
            this.dataColumnDILastOtherBackupCompressedSize = new System.Data.DataColumn();
            this.dataColumnDIBackupType = new System.Data.DataColumn();
            this.dataColumnDIDBSizeMb = new System.Data.DataColumn();
            this.dataColumnDIDBUsedMb = new System.Data.DataColumn();
            this.dataColumnDIDBFreeMb = new System.Data.DataColumn();
            this.dataColumnDIDataSizeMb = new System.Data.DataColumn();
            this.dataColumnDIDataUsedMb = new System.Data.DataColumn();
            this.dataColumnDIDataFreeMb = new System.Data.DataColumn();
            this.dataColumnDIDataFreePct = new System.Data.DataColumn();
            this.dataColumnDILogSizeMb = new System.Data.DataColumn();
            this.dataColumnDILogUsedMb = new System.Data.DataColumn();
            this.dataColumnDILogFreeMb = new System.Data.DataColumn();
            this.dataColumnDILogFreePct = new System.Data.DataColumn();
            this.dataColumnDIFileStreamMb = new System.Data.DataColumn();
            this.dataColumnDIFileStreamUsedMb = new System.Data.DataColumn();
            this.dataColumnDIFileStreamFreeMb = new System.Data.DataColumn();
            this.dataColumnDIFileStreamFreePct = new System.Data.DataColumn();
            this.dataColumnDISortDBSizeMb = new System.Data.DataColumn();
            this.dataColumnDISortDBUsedMb = new System.Data.DataColumn();
            this.dataColumnDISortDBFreeMb = new System.Data.DataColumn();
            this.dataColumnDISortDataSizeMb = new System.Data.DataColumn();
            this.dataColumnDISortDataUsedMb = new System.Data.DataColumn();
            this.dataColumnDISortDataFreeMb = new System.Data.DataColumn();
            this.dataColumnDISortDataFreePct = new System.Data.DataColumn();
            this.dataColumnDISortLogSizeMb = new System.Data.DataColumn();
            this.dataColumnDISortLogUsedMb = new System.Data.DataColumn();
            this.dataColumnDISortLogFreeMb = new System.Data.DataColumn();
            this.dataColumnDISortLogFreePct = new System.Data.DataColumn();
            this.dataColumnDISortFileStreamMb = new System.Data.DataColumn();
            this.dataColumnDISortFileStreamUsedMb = new System.Data.DataColumn();
            this.dataColumnDISortFileStreamFreeMb = new System.Data.DataColumn();
            this.dataColumnDISortFileStreamFreePct = new System.Data.DataColumn();
            this.dataTableSizes = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ucDataLabel3 = new SQLDBATool.Code.UCDataLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ucDataLabel2 = new SQLDBATool.Code.UCDataLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ucDataLabel1 = new SQLDBATool.Code.UCDataLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panelFileStreamGraph = new System.Windows.Forms.Panel();
            this.panelLogGraph = new System.Windows.Forms.Panel();
            this.panelDataGraph = new System.Windows.Forms.Panel();
            this.labelPopup = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ucTitleBarText = new SQLDBATool.Code.ucTitleBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetServerInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDatabaseInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSizes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSetServerInformation
            // 
            this.dataSetServerInformation.DataSetName = "NewDataSet";
            this.dataSetServerInformation.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableDatabaseInformation,
            this.dataTableSizes});
            // 
            // dataTableDatabaseInformation
            // 
            this.dataTableDatabaseInformation.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnDIDatabaseId,
            this.dataColumnDIDatabaseName,
            this.dataColumnDIOwner,
            this.dataColumnDICreateDate,
            this.dataColumnDICompatibilityLevel,
            this.dataColumnDICollationName,
            this.dataColumnDIUserAccessDesc,
            this.dataColumnDIIsReadOnly,
            this.dataColumnDIStateDesc,
            this.dataColumnDIRecoveryModelDesc,
            this.dataColumnDIRestoreDate,
            this.dataColumnDILastFullBackup,
            this.dataColumnDILastFullBackupSize,
            this.dataColumnDILastFullBackupCompressedSize,
            this.dataColumnDILastOtherBackup,
            this.dataColumnDILastOtherBackupSize,
            this.dataColumnDILastOtherBackupCompressedSize,
            this.dataColumnDIBackupType,
            this.dataColumnDIDBSizeMb,
            this.dataColumnDIDBUsedMb,
            this.dataColumnDIDBFreeMb,
            this.dataColumnDIDataSizeMb,
            this.dataColumnDIDataUsedMb,
            this.dataColumnDIDataFreeMb,
            this.dataColumnDIDataFreePct,
            this.dataColumnDILogSizeMb,
            this.dataColumnDILogUsedMb,
            this.dataColumnDILogFreeMb,
            this.dataColumnDILogFreePct,
            this.dataColumnDIFileStreamMb,
            this.dataColumnDIFileStreamUsedMb,
            this.dataColumnDIFileStreamFreeMb,
            this.dataColumnDIFileStreamFreePct,
            this.dataColumnDISortDBSizeMb,
            this.dataColumnDISortDBUsedMb,
            this.dataColumnDISortDBFreeMb,
            this.dataColumnDISortDataSizeMb,
            this.dataColumnDISortDataUsedMb,
            this.dataColumnDISortDataFreeMb,
            this.dataColumnDISortDataFreePct,
            this.dataColumnDISortLogSizeMb,
            this.dataColumnDISortLogUsedMb,
            this.dataColumnDISortLogFreeMb,
            this.dataColumnDISortLogFreePct,
            this.dataColumnDISortFileStreamMb,
            this.dataColumnDISortFileStreamUsedMb,
            this.dataColumnDISortFileStreamFreeMb,
            this.dataColumnDISortFileStreamFreePct});
            this.dataTableDatabaseInformation.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "database_id"}, true)});
            this.dataTableDatabaseInformation.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumnDIDatabaseId};
            this.dataTableDatabaseInformation.TableName = "DatabaseInformation";
            // 
            // dataColumnDIDatabaseId
            // 
            this.dataColumnDIDatabaseId.AllowDBNull = false;
            this.dataColumnDIDatabaseId.ColumnName = "database_id";
            this.dataColumnDIDatabaseId.DataType = typeof(int);
            // 
            // dataColumnDIDatabaseName
            // 
            this.dataColumnDIDatabaseName.ColumnName = "Database_Name";
            // 
            // dataColumnDIOwner
            // 
            this.dataColumnDIOwner.ColumnName = "Owner";
            // 
            // dataColumnDICreateDate
            // 
            this.dataColumnDICreateDate.ColumnName = "create_date";
            this.dataColumnDICreateDate.DataType = typeof(System.DateTime);
            // 
            // dataColumnDICompatibilityLevel
            // 
            this.dataColumnDICompatibilityLevel.ColumnName = "compatibility_level";
            this.dataColumnDICompatibilityLevel.DataType = typeof(int);
            // 
            // dataColumnDICollationName
            // 
            this.dataColumnDICollationName.ColumnName = "collation_name";
            // 
            // dataColumnDIUserAccessDesc
            // 
            this.dataColumnDIUserAccessDesc.ColumnName = "user_access_desc";
            // 
            // dataColumnDIIsReadOnly
            // 
            this.dataColumnDIIsReadOnly.ColumnName = "is_read_only";
            this.dataColumnDIIsReadOnly.DataType = typeof(bool);
            // 
            // dataColumnDIStateDesc
            // 
            this.dataColumnDIStateDesc.ColumnName = "state_desc";
            // 
            // dataColumnDIRecoveryModelDesc
            // 
            this.dataColumnDIRecoveryModelDesc.ColumnName = "recovery_model_desc";
            // 
            // dataColumnDIRestoreDate
            // 
            this.dataColumnDIRestoreDate.ColumnName = "restore_date";
            this.dataColumnDIRestoreDate.DataType = typeof(System.DateTime);
            // 
            // dataColumnDILastFullBackup
            // 
            this.dataColumnDILastFullBackup.ColumnName = "last_full_backup";
            this.dataColumnDILastFullBackup.DataType = typeof(System.DateTime);
            // 
            // dataColumnDILastFullBackupSize
            // 
            this.dataColumnDILastFullBackupSize.ColumnName = "last_full_backup_size";
            this.dataColumnDILastFullBackupSize.DataType = typeof(decimal);
            // 
            // dataColumnDILastFullBackupCompressedSize
            // 
            this.dataColumnDILastFullBackupCompressedSize.ColumnName = "last_full_backup_compressed_size";
            this.dataColumnDILastFullBackupCompressedSize.DataType = typeof(decimal);
            // 
            // dataColumnDILastOtherBackup
            // 
            this.dataColumnDILastOtherBackup.ColumnName = "last_other_backup";
            this.dataColumnDILastOtherBackup.DataType = typeof(System.DateTime);
            // 
            // dataColumnDILastOtherBackupSize
            // 
            this.dataColumnDILastOtherBackupSize.ColumnName = "last_other_backup_size";
            this.dataColumnDILastOtherBackupSize.DataType = typeof(decimal);
            // 
            // dataColumnDILastOtherBackupCompressedSize
            // 
            this.dataColumnDILastOtherBackupCompressedSize.ColumnName = "last_other_backup_compressed_size";
            this.dataColumnDILastOtherBackupCompressedSize.DataType = typeof(decimal);
            // 
            // dataColumnDIBackupType
            // 
            this.dataColumnDIBackupType.ColumnName = "BackupType";
            // 
            // dataColumnDIDBSizeMb
            // 
            this.dataColumnDIDBSizeMb.ColumnName = "DB_Size_Mb";
            // 
            // dataColumnDIDBUsedMb
            // 
            this.dataColumnDIDBUsedMb.ColumnName = "DB_Used_Mb";
            // 
            // dataColumnDIDBFreeMb
            // 
            this.dataColumnDIDBFreeMb.ColumnName = "DB_Free_Mb";
            // 
            // dataColumnDIDataSizeMb
            // 
            this.dataColumnDIDataSizeMb.ColumnName = "Data_Size_Mb";
            // 
            // dataColumnDIDataUsedMb
            // 
            this.dataColumnDIDataUsedMb.ColumnName = "Data_Used_Mb";
            // 
            // dataColumnDIDataFreeMb
            // 
            this.dataColumnDIDataFreeMb.ColumnName = "Data_Free_Mb";
            // 
            // dataColumnDIDataFreePct
            // 
            this.dataColumnDIDataFreePct.ColumnName = "Data_Free_Pct";
            // 
            // dataColumnDILogSizeMb
            // 
            this.dataColumnDILogSizeMb.ColumnName = "Log_Size_Mb";
            // 
            // dataColumnDILogUsedMb
            // 
            this.dataColumnDILogUsedMb.ColumnName = "Log_Used_Mb";
            // 
            // dataColumnDILogFreeMb
            // 
            this.dataColumnDILogFreeMb.ColumnName = "Log_Free_Mb";
            // 
            // dataColumnDILogFreePct
            // 
            this.dataColumnDILogFreePct.ColumnName = "Log_Free_Pct";
            // 
            // dataColumnDIFileStreamMb
            // 
            this.dataColumnDIFileStreamMb.ColumnName = "FileStream_Mb";
            // 
            // dataColumnDIFileStreamUsedMb
            // 
            this.dataColumnDIFileStreamUsedMb.ColumnName = "FileStream_Used_Mb";
            // 
            // dataColumnDIFileStreamFreeMb
            // 
            this.dataColumnDIFileStreamFreeMb.ColumnName = "FileStream_Free_Mb";
            // 
            // dataColumnDIFileStreamFreePct
            // 
            this.dataColumnDIFileStreamFreePct.ColumnName = "FileStream_Free_Pct";
            // 
            // dataColumnDISortDBSizeMb
            // 
            this.dataColumnDISortDBSizeMb.ColumnName = "Sort_DB_Size_Mb";
            this.dataColumnDISortDBSizeMb.DataType = typeof(int);
            // 
            // dataColumnDISortDBUsedMb
            // 
            this.dataColumnDISortDBUsedMb.ColumnName = "Sort_DB_Used_Mb";
            this.dataColumnDISortDBUsedMb.DataType = typeof(int);
            // 
            // dataColumnDISortDBFreeMb
            // 
            this.dataColumnDISortDBFreeMb.ColumnName = "Sort_DB_Free_Mb";
            this.dataColumnDISortDBFreeMb.DataType = typeof(int);
            // 
            // dataColumnDISortDataSizeMb
            // 
            this.dataColumnDISortDataSizeMb.ColumnName = "Sort_Data_Size_Mb";
            this.dataColumnDISortDataSizeMb.DataType = typeof(int);
            // 
            // dataColumnDISortDataUsedMb
            // 
            this.dataColumnDISortDataUsedMb.ColumnName = "Sort_Data_Used_Mb";
            this.dataColumnDISortDataUsedMb.DataType = typeof(int);
            // 
            // dataColumnDISortDataFreeMb
            // 
            this.dataColumnDISortDataFreeMb.ColumnName = "Sort_Data_Free_Mb";
            this.dataColumnDISortDataFreeMb.DataType = typeof(int);
            // 
            // dataColumnDISortDataFreePct
            // 
            this.dataColumnDISortDataFreePct.ColumnName = "Sort_Data_Free_Pct";
            this.dataColumnDISortDataFreePct.DataType = typeof(decimal);
            // 
            // dataColumnDISortLogSizeMb
            // 
            this.dataColumnDISortLogSizeMb.ColumnName = "Sort_Log_Size_Mb";
            this.dataColumnDISortLogSizeMb.DataType = typeof(int);
            // 
            // dataColumnDISortLogUsedMb
            // 
            this.dataColumnDISortLogUsedMb.ColumnName = "Sort_Log_Used_Mb";
            this.dataColumnDISortLogUsedMb.DataType = typeof(int);
            // 
            // dataColumnDISortLogFreeMb
            // 
            this.dataColumnDISortLogFreeMb.ColumnName = "Sort_Log_Free_Mb";
            this.dataColumnDISortLogFreeMb.DataType = typeof(int);
            // 
            // dataColumnDISortLogFreePct
            // 
            this.dataColumnDISortLogFreePct.ColumnName = "Sort_Log_Free_Pct";
            this.dataColumnDISortLogFreePct.DataType = typeof(decimal);
            // 
            // dataColumnDISortFileStreamMb
            // 
            this.dataColumnDISortFileStreamMb.ColumnName = "Sort_FileStream_Mb";
            this.dataColumnDISortFileStreamMb.DataType = typeof(int);
            // 
            // dataColumnDISortFileStreamUsedMb
            // 
            this.dataColumnDISortFileStreamUsedMb.ColumnName = "Sort_FileStream_Used_Mb";
            this.dataColumnDISortFileStreamUsedMb.DataType = typeof(int);
            // 
            // dataColumnDISortFileStreamFreeMb
            // 
            this.dataColumnDISortFileStreamFreeMb.ColumnName = "Sort_FileStream_Free_Mb";
            this.dataColumnDISortFileStreamFreeMb.DataType = typeof(int);
            // 
            // dataColumnDISortFileStreamFreePct
            // 
            this.dataColumnDISortFileStreamFreePct.ColumnName = "Sort_FileStream_Free_Pct";
            this.dataColumnDISortFileStreamFreePct.DataType = typeof(decimal);
            // 
            // dataTableSizes
            // 
            this.dataTableSizes.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.dataTableSizes.TableName = "dataTableSizes";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "data_size_mb";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "log_size_mb";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "filestream_size_mb";
            this.dataColumn3.DataType = typeof(int);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 21);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Size = new System.Drawing.Size(697, 72);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 72);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ucDataLabel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 46);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(228, 23);
            this.panel5.TabIndex = 2;
            // 
            // ucDataLabel3
            // 
            this.ucDataLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDataLabel3.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", this.dataSetServerInformation, "dataTableSizes.filestream_size_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "#,##0Mb", "#,##0Mb"));
            this.ucDataLabel3.DataTitle = "File Stream";
            this.ucDataLabel3.DataTitleWidth = 80;
            this.ucDataLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataLabel3.LabelData = "";
            this.ucDataLabel3.Location = new System.Drawing.Point(0, 0);
            this.ucDataLabel3.Name = "ucDataLabel3";
            this.ucDataLabel3.Size = new System.Drawing.Size(228, 23);
            this.ucDataLabel3.TabIndex = 1;
            this.ucDataLabel3.Resize += new System.EventHandler(this.ucDataLabel3_Resize);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ucDataLabel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(228, 23);
            this.panel4.TabIndex = 1;
            // 
            // ucDataLabel2
            // 
            this.ucDataLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDataLabel2.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", this.dataSetServerInformation, "dataTableSizes.log_size_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "#,##0Mb", "#,##0Mb"));
            this.ucDataLabel2.DataTitle = "Log";
            this.ucDataLabel2.DataTitleWidth = 80;
            this.ucDataLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataLabel2.LabelData = "";
            this.ucDataLabel2.Location = new System.Drawing.Point(0, 0);
            this.ucDataLabel2.Name = "ucDataLabel2";
            this.ucDataLabel2.Size = new System.Drawing.Size(228, 23);
            this.ucDataLabel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ucDataLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 23);
            this.panel3.TabIndex = 0;
            // 
            // ucDataLabel1
            // 
            this.ucDataLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDataLabel1.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", this.dataSetServerInformation, "dataTableSizes.data_size_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "#,##0Mb", "#,##0Mb"));
            this.ucDataLabel1.DataTitle = "Data";
            this.ucDataLabel1.DataTitleWidth = 80;
            this.ucDataLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataLabel1.LabelData = "";
            this.ucDataLabel1.Location = new System.Drawing.Point(0, 0);
            this.ucDataLabel1.Name = "ucDataLabel1";
            this.ucDataLabel1.Size = new System.Drawing.Size(228, 23);
            this.ucDataLabel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.panelFileStreamGraph);
            this.panel6.Controls.Add(this.panelLogGraph);
            this.panel6.Controls.Add(this.panelDataGraph);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(461, 72);
            this.panel6.TabIndex = 4;
            // 
            // panelFileStreamGraph
            // 
            this.panelFileStreamGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFileStreamGraph.Location = new System.Drawing.Point(0, 46);
            this.panelFileStreamGraph.Name = "panelFileStreamGraph";
            this.panelFileStreamGraph.Size = new System.Drawing.Size(457, 23);
            this.panelFileStreamGraph.TabIndex = 3;
            // 
            // panelLogGraph
            // 
            this.panelLogGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogGraph.Location = new System.Drawing.Point(0, 23);
            this.panelLogGraph.Name = "panelLogGraph";
            this.panelLogGraph.Size = new System.Drawing.Size(457, 23);
            this.panelLogGraph.TabIndex = 2;
            // 
            // panelDataGraph
            // 
            this.panelDataGraph.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDataGraph.Location = new System.Drawing.Point(0, 0);
            this.panelDataGraph.Name = "panelDataGraph";
            this.panelDataGraph.Size = new System.Drawing.Size(457, 23);
            this.panelDataGraph.TabIndex = 1;
            // 
            // labelPopup
            // 
            this.labelPopup.BackColor = System.Drawing.Color.LemonChiffon;
            this.labelPopup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPopup.Location = new System.Drawing.Point(0, 0);
            this.labelPopup.Name = "labelPopup";
            this.labelPopup.Size = new System.Drawing.Size(162, 68);
            this.labelPopup.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.labelPopup);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(697, 21);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(166, 72);
            this.panel7.TabIndex = 5;
            // 
            // ucTitleBarText
            // 
            this.ucTitleBarText.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitleBarText.Location = new System.Drawing.Point(0, 0);
            this.ucTitleBarText.Name = "ucTitleBarText";
            this.ucTitleBarText.Size = new System.Drawing.Size(863, 21);
            this.ucTitleBarText.TabIndex = 1;
            this.ucTitleBarText.TitleBold = false;
            this.ucTitleBarText.TitleText = null;
            // 
            // ucDatabaseStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.ucTitleBarText);
            this.Name = "ucDatabaseStorage";
            this.Size = new System.Drawing.Size(863, 93);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucDatabaseStorage_Paint);
            this.Resize += new System.EventHandler(this.ucDatabaseStorage_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetServerInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableDatabaseInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableSizes)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dataSetServerInformation;
        private System.Data.DataTable dataTableDatabaseInformation;
        private System.Data.DataColumn dataColumnDIDatabaseId;
        private System.Data.DataColumn dataColumnDIDatabaseName;
        private System.Data.DataColumn dataColumnDIOwner;
        private System.Data.DataColumn dataColumnDICreateDate;
        private System.Data.DataColumn dataColumnDICompatibilityLevel;
        private System.Data.DataColumn dataColumnDICollationName;
        private System.Data.DataColumn dataColumnDIUserAccessDesc;
        private System.Data.DataColumn dataColumnDIIsReadOnly;
        private System.Data.DataColumn dataColumnDIStateDesc;
        private System.Data.DataColumn dataColumnDIRecoveryModelDesc;
        private System.Data.DataColumn dataColumnDIRestoreDate;
        private System.Data.DataColumn dataColumnDILastFullBackup;
        private System.Data.DataColumn dataColumnDILastFullBackupSize;
        private System.Data.DataColumn dataColumnDILastFullBackupCompressedSize;
        private System.Data.DataColumn dataColumnDILastOtherBackup;
        private System.Data.DataColumn dataColumnDILastOtherBackupSize;
        private System.Data.DataColumn dataColumnDILastOtherBackupCompressedSize;
        private System.Data.DataColumn dataColumnDIBackupType;
        private System.Data.DataColumn dataColumnDIDBSizeMb;
        private System.Data.DataColumn dataColumnDIDBUsedMb;
        private System.Data.DataColumn dataColumnDIDBFreeMb;
        private System.Data.DataColumn dataColumnDIDataSizeMb;
        private System.Data.DataColumn dataColumnDIDataUsedMb;
        private System.Data.DataColumn dataColumnDIDataFreeMb;
        private System.Data.DataColumn dataColumnDIDataFreePct;
        private System.Data.DataColumn dataColumnDILogSizeMb;
        private System.Data.DataColumn dataColumnDILogUsedMb;
        private System.Data.DataColumn dataColumnDILogFreeMb;
        private System.Data.DataColumn dataColumnDILogFreePct;
        private System.Data.DataColumn dataColumnDIFileStreamMb;
        private System.Data.DataColumn dataColumnDIFileStreamUsedMb;
        private System.Data.DataColumn dataColumnDIFileStreamFreeMb;
        private System.Data.DataColumn dataColumnDIFileStreamFreePct;
        private System.Data.DataColumn dataColumnDISortDBSizeMb;
        private System.Data.DataColumn dataColumnDISortDBUsedMb;
        private System.Data.DataColumn dataColumnDISortDBFreeMb;
        private System.Data.DataColumn dataColumnDISortDataSizeMb;
        private System.Data.DataColumn dataColumnDISortDataUsedMb;
        private System.Data.DataColumn dataColumnDISortDataFreeMb;
        private System.Data.DataColumn dataColumnDISortDataFreePct;
        private System.Data.DataColumn dataColumnDISortLogSizeMb;
        private System.Data.DataColumn dataColumnDISortLogUsedMb;
        private System.Data.DataColumn dataColumnDISortLogFreeMb;
        private System.Data.DataColumn dataColumnDISortLogFreePct;
        private System.Data.DataColumn dataColumnDISortFileStreamMb;
        private System.Data.DataColumn dataColumnDISortFileStreamUsedMb;
        private System.Data.DataColumn dataColumnDISortFileStreamFreeMb;
        private System.Data.DataColumn dataColumnDISortFileStreamFreePct;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private UCDataLabel ucDataLabel3;
        private System.Windows.Forms.Panel panel4;
        private UCDataLabel ucDataLabel2;
        private System.Windows.Forms.Panel panel3;
        private UCDataLabel ucDataLabel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panelFileStreamGraph;
        private System.Windows.Forms.Panel panelLogGraph;
        private System.Windows.Forms.Panel panelDataGraph;
        private System.Data.DataTable dataTableSizes;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.Label labelPopup;
        private System.Windows.Forms.Panel panel7;
        private ucTitleBar ucTitleBarText;
    }
}
