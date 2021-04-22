using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class ucChart : UserControl
    {
        private Color FTopColor = Color.Black;
        private Color FBottomColor = Color.Black;
        private int FLegendWidth = 100;
        public ucSeries[] Series
        {
            get
            {
                return ChartArea.Series;
            }
            set
            {
                ChartArea.Series = value;
            }
        }
        public Color ChartAreaTopColor
        {
            get
            {
                return ChartArea.TopColor;
            }
            set
            {
                ChartArea.TopColor = value;
            }
        }
        public Color ChartAreaBottomColor
        {
            get
            {
                return ChartArea.BottomColor;
            }
            set
            {
                ChartArea.BottomColor = value;
            }
        }
        public bool IsStacked
        {
            get
            {
                return ChartArea.IsStacked;
            }
            set
            {
                ChartArea.IsStacked = value;
            }
        }
        public Color TopColor { get => FTopColor; set => FTopColor = value; }
        public Color BottomColor { get => FBottomColor; set => FBottomColor = value; }
        public Color GridLineColor
        {
            get
            {
                return ChartArea.GridLineColor;
            }
            set
            {
                ChartArea.GridLineColor = value;
            }
        }
        public DataTable GraphTable
        {
            get
            {
                return ChartArea.GraphTable;
            }
            set
            {
                ChartArea.GraphTable = value;
            }
        }
        public DataTable LegendTable
        {
            get
            {
                return ChartArea.LegendTable;
            }
            set
            {
                ChartArea.LegendTable = value;
            }
        }
        public Int64 MaxValue
        {
            get
            {
                return ChartArea.MaxValue;
            }
            set
            {
                ChartArea.MaxValue = value;
            }
        }
        public int LegendWidth
        {
            get
            {
                return FLegendWidth;
            }
            set
            {
                FLegendWidth = value;
            }
        }
        public string ChartTitle
        {
            get => labelChartTitle.Text;
            set => labelChartTitle.Text = value;
        }

        public ucChart()
        {
            InitializeComponent();
        }

        private void ucChart_Paint(object sender, PaintEventArgs e)
        {
            DrawGraph(e);
        }

        private void DrawGraph(PaintEventArgs e)
        {
            // Is there something to draw
            if (e.ClipRectangle.Width + e.ClipRectangle.Height > 0)
            {
                // We should draw the whole graph and clip what we want
                using (Bitmap bmGraph = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb))
                {
                    Graphics grGraph = Graphics.FromImage(bmGraph);

                    #region Draw the graph background
                    using (LinearGradientBrush lgBrush = new LinearGradientBrush(e.ClipRectangle, TopColor, BottomColor, LinearGradientMode.ForwardDiagonal))
                    {
                        grGraph.FillRectangle(lgBrush, this.ClientRectangle);
                    }
                    #endregion
                    #region Draw the Graph Titlebar
                    Rectangle rect = new Rectangle(0, 0, ClientRectangle.Width, 20);
                    using (LinearGradientBrush lgBrush = new LinearGradientBrush(rect, Color.Black, Color.DarkGray, LinearGradientMode.Vertical))
                    {
                        grGraph.FillRectangle(lgBrush, rect);
                    }
                    using (SolidBrush myBrushShadow = new SolidBrush(Color.Black))
                    using (SolidBrush myBrush = new SolidBrush(Color.White))
                    {
                        grGraph.DrawString(ChartTitle, labelChartTitle.Font, myBrushShadow, ClientRectangle.X + 4, ClientRectangle.Y + 4);
                        grGraph.DrawString(ChartTitle, labelChartTitle.Font, myBrush, ClientRectangle.X + 3, ClientRectangle.Y + 3);
                    }
                    //grGraph.FillRectangle(Brushes.DarkGray, rect);
                    grGraph.DrawLine(Pens.WhiteSmoke, 0, 20, ClientRectangle.Width, 20);
                    #endregion
                    #region Draw the Legend
                    if (Series != null)
                    {
                        Rectangle rectAxis = new Rectangle(ChartArea.Left - 30, 21, ChartArea.Left, ChartArea.Height);
                        grGraph.FillRectangle(Brushes.DarkGray, rectAxis);
                        grGraph.DrawLine(Pens.DarkGray, rectAxis.Left, rectAxis.Top, rectAxis.Left, rectAxis.Bottom);

                        if (Series.Count() > 0)
                        {
                            int top = 40 + ((Series.Length - 1) * labelLegend.Height);
                            labelLegend.Text = FormatMaxValue();
                            grGraph.DrawString(labelLegend.Text, labelLegend.Font, Brushes.Black, ChartArea.Left - labelLegend.Width - 2, ChartArea.Top + 2);
                            labelLegend.Text = "0";
                            grGraph.DrawString("0", labelLegend.Font, Brushes.Black, ChartArea.Left - labelLegend.Width - 2, ChartArea.Height + ChartArea.Top - 13);
                            foreach (ucSeries series in Series)
                            {
                                SolidBrush myBrush = new SolidBrush(series.LegendColor);
                                grGraph.DrawString(series.SeriesLedgendSource, labelLegend.Font, myBrush, ClientRectangle.X + 4, top);
                                top = top - labelLegend.Height;
                            }
                        }
                    }
                    #endregion
                    e.Graphics.DrawImage(bmGraph, e.ClipRectangle.X, e.ClipRectangle.Y);

                    //                    this.ChartArea.Refresh();

                }
            }
        }
        private string FormatMaxValue()
        {
            string text = MaxValue.ToString();
            string[] suffixs = { "K", "M", "B", "T", "Q" };

            int i = -1;
            while (text.Length > 3 && i < 4)
            {
                i++;
                text = text.Substring(0, text.Length - 3);
            }

            if (i >= 0)
                text = text + suffixs[i];

            return text;
        }

        private void ucChart_SizeChanged(object sender, EventArgs e)
        {
            ChartArea.Size = new Size((this.ClientRectangle.Width - FLegendWidth), (this.ClientRectangle.Height - (ChartArea.Top + 4)));
            ChartArea.Left = FLegendWidth;

        }


    }
}
