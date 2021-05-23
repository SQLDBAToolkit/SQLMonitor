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
    public partial class ucTitleBar : UserControl
    {
        private string FTitleText;
        public ucTitleBar()
        {
            InitializeComponent();
        }

        public string TitleText
        {
            get => FTitleText;
            set
            {
                FTitleText = value;
                this.Refresh();
            }
        }

        public bool TitleBold
        {
            get => labelFont.Font.Bold;
            set
            {
                if (value)
                {
                    labelFont.Font = new Font(labelFont.Font, FontStyle.Bold);
                }
                else
                {
                    labelFont.Font = new Font(labelFont.Font, FontStyle.Regular);
                }
            }
        }

        private void DrawHeaderBackground(PaintEventArgs e)
        {
            // Is there something to draw
            if (e.ClipRectangle.Width + e.ClipRectangle.Height > 0)
            {
                // We should draw the whole graph and clip what we want
                using (Bitmap bmGraph = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
                {
                    Graphics grGraph = Graphics.FromImage(bmGraph);

                    #region Draw the graph background
                    using (LinearGradientBrush lgBrush = new LinearGradientBrush(e.ClipRectangle, Color.LightCyan, Color.LightSkyBlue, LinearGradientMode.Vertical))
                    {
                        grGraph.FillRectangle(lgBrush, this.ClientRectangle);
                    }
                    using (SolidBrush myBrush = new SolidBrush(Color.Black))
                    using (SolidBrush myBrushShadow = new SolidBrush(Color.White))
                    {
                        grGraph.DrawString(FTitleText, labelFont.Font, myBrushShadow, ClientRectangle.X + 4, ClientRectangle.Y + 4);
                        grGraph.DrawString(FTitleText, labelFont.Font, myBrush, ClientRectangle.X + 3, ClientRectangle.Y + 3);
                    }

                    #endregion

                    e.Graphics.DrawImage(bmGraph, e.ClipRectangle.X, e.ClipRectangle.Y);
                }
            }
        }

        private void panelBackground_Paint(object sender, PaintEventArgs e)
        {
            DrawHeaderBackground(e);
        }
    }
}
