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
    [System.ComponentModel.DefaultBindingProperty("LabelData")]
    public partial class UCDataLabel : UserControl
    {
        public string DataTitle { get => labelTitle.Text; set => labelTitle.Text = value; }
        public string LabelData { get => labelData.Text; set => labelData.Text = value; }
        public int DataTitleWidth { get => labelTitle.Width; set => labelTitle.Width = value; }
        //public ControlBindingsCollection LabelDataBindings { get => labelData.DataBindings; }
        public UCDataLabel()
        {
            InitializeComponent();
            //labelData.DataBindings.Add("Text", this, "Tag");
            //this.Tag
            //labelData.DataBindings
        }


    }
}
