using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class ucDatabaseDetails : UserControl
    {
        public ucDatabaseDetails()
        {
            InitializeComponent();
        }


        public void SetDataTable(DataSet parentDataSetServerInformation)
        {
            this.ucDataLabelDatabaseID.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.database_id", true));
            this.ucDataLabelDatabaseName.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.database_name", true));
            this.ucDataLabelOwner.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.owner", true));
            this.ucDataLabelCreateDate.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.create_date", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "F"));
            this.ucDataLabelCompatibility.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.compatibility_level", true));
            this.ucDataLabelCollation.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.collation_name", true));
            this.ucDataLabelUserAccess.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.user_access_desc", true));
            this.ucDataLabelReadOnly.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.is_read_only", true));
            this.ucDataLabelDatabaseStatus.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.state_desc", true));
            this.ucDataLabelRecoveryModel.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.recovery_model_desc", true));

            this.ucDataLabelLastRestore.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.restore_date", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "F"));
            this.ucDataLabelLastFullBackup.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.last_full_backup", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "F"));
            this.ucDataLabelLastNonFullBackup.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.last_other_backup", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "F"));
            this.ucDataLabelLastFullBackupSize.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.last_full_backup_size", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelLastFullCompressedSize.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.last_full_backup_compressed_size", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelNonFullBackupSize.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.last_other_backup_size", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelNonFullCompressedSize.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.last_other_backup_compressed_size", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelNonFullBAckupType.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.BackupType", true));

            this.ucDataLabelDBSize.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.sort_db_size_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelDBUsed.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.sort_db_used_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelDBFree.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.sort_db_free_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));

            this.ucDataLabelDataFilesSize.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.sort_data_size_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelDataFilesUsed.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.sort_data_used_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelDataFilesFree.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.sort_data_free_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelDataFilesFreePercentage.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.Data_Free_Pct", true));

            this.ucDataLabelLogFilesSize.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.sort_log_size_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelLogFilesUsed.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.sort_log_used_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelLogFilesFree.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.sort_log_free_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));
            this.ucDataLabelLogFilesFreePercentage.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.log_Free_Pct", true));

            this.ucDataLabelFileStreamSize.DataBindings.Add(new System.Windows.Forms.Binding("LabelData", parentDataSetServerInformation, "DatabaseInformation.sort_filestream_mb", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "#,##0Mb"));

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
