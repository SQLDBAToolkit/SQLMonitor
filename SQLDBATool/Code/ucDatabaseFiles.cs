using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class ucDatabaseFiles : UserControl
    {
        public ucDatabaseFiles()
        {
            InitializeComponent();
        }

        public void PopulateDatabaseFileInformation(int database_id, DataTable fileInformation)
        {
            if (fileInformation.Rows.Count > 0)
            {
                ucTitleBar1.TitleText = database_id.ToString();
                string databaseSearchString = "database_id = " + database_id.ToString();
                dataTableDatabaseFiles.Clear();
                foreach (DataRow r in fileInformation.Select(databaseSearchString))
                {
                    dataTableDatabaseFiles.Rows.Add(r.ItemArray);
                }
            }
            else
            { 
                dataTableDatabaseFiles.Rows.Clear();
            }
        }
    }
}
