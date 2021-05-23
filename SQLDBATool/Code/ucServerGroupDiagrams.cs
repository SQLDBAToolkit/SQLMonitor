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
    public partial class ucServerGroupDiagrams : UserControl
    {
        ucConnectionTree FParentTree;
        public ucServerGroupDiagrams()
        {
            InitializeComponent();
        }

        public ucConnectionTree ParentTree
        {
            get => FParentTree;
            set
            { 
                FParentTree = value;
                ucTitleBarGroupName.TitleText = FParentTree.ThisTreeInformation.ServerTree.TreeName;
            }
        }
    }
}
