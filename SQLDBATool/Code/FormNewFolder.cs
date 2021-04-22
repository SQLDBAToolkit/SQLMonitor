using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class FormNewFolder : Form
    {
        private CLSTreeInformation FParentTreeInformation;
        private ucConnectionTree FConnTree;
        public FormNewFolder(CLSTreeInformation parentTreeInformation, ucConnectionTree connTree)
        {
            InitializeComponent();
            FParentTreeInformation = parentTreeInformation;
            FConnTree = connTree;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                clsServerTreeController serverTreeController = new clsServerTreeController();
                ServerTree serverTree = serverTreeController.AddServerTree(
                    textBox1.Text,
                    1,
                    FParentTreeInformation.ServerTree.ServerTreeID,
                    true,
                    Guid.Empty,
                    false);
                serverTree.ChildTreeNodes = new List<ServerTree>();
                FConnTree.AppendNewTreeItem(serverTree, FParentTreeInformation);
                this.Close();
            }
            else
                MessageBox.Show("Please enter a name for the folder", "Folder Name", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void FormNewFolder_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
