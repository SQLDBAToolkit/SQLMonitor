using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace GraphTester
{

    public partial class ucGraph : UserControl
    {
        #region Fields
        private ucGraphSeries[] FSeries;
        private double FTrendLinePosition = 0;
        private double FTopValue = 100;
        private double FBottomValue = 0;
        private int FDisplayFrom = 0;
        private string FGraphTitle = "Graph Title";
        private int FMinLegendWidth = 10;
        private Color FBackGroundTopLeft = Color.Black;
        private Color FBackGroundBottomRight = Color.DarkGray;
        private Color FGraphPanelTopLeft = Color.Black;
        private Color FGraphPanelBottomRight = Color.DarkGray;
        private Color FGraphPanelMainGridLine = Color.LightGray;
        private Color FGraphPanelMinorGridLine = Color.LightGray;
        #endregion
        #region Properties
        public ucGraphSeries[] Series
        {
            get
            {
                return FSeries;
            }

            set
            {

                for (int i = 0; i < value.Length; i++)
                {
                    value[i].ParentGraph = this;
                    value[i].SeriesOrder = i;
                }
                FSeries = value;
            }
        }
        public string GraphTitle
        {
            get
            {
                return FGraphTitle;
            }

            set
            {
                FGraphTitle = value;
                labelGraphTitle.Text = value;
            }
        }
        public double TrendLinePosition { get => FTrendLinePosition; set => FTrendLinePosition = value; }
        public double TopValue { get => FTopValue; set => FTopValue = value; }
        public double BottomValue { get => FBottomValue; set => FBottomValue = value; }
        public int DisplayFrom { get => FDisplayFrom; set => FDisplayFrom = value; }
        public int MinLegendWidth { get => FMinLegendWidth; set => FMinLegendWidth = value; }
        public Color BackGroundTopLeft
        {
            get
            {
                return FBackGroundTopLeft;
            }
            set
            {
                FBackGroundTopLeft = value;
                SetGraphBackground();
            }
        }
        public Color BackGroundBottomRight
        {
            get
            {
                return FBackGroundBottomRight;
            }
            set
            {
                FBackGroundBottomRight = value;
                SetGraphBackground();
            }
        }
        public Color GraphPanelTopLeft
        {
            get
            {
                return FGraphPanelTopLeft;
            }
            set
            {
                FGraphPanelTopLeft = value;
                DrawGraph();
            }
        }
        public Color GraphPanelBottomRight
        {
            get
            {
                return FGraphPanelBottomRight;
            }
            set
            {
                FGraphPanelBottomRight = value;
                DrawGraph();
            }
        }
        public Color GraphPanelMainGridLine
        {
            get
            {
                return FGraphPanelMainGridLine;
            }
            set
            {
                FGraphPanelMainGridLine = value;
                DrawGraph();
            }
        }
        public Color GraphPanelMinorGridLine
        {
            get
            {
                return FGraphPanelMinorGridLine;
            }
            set
            {
                FGraphPanelMinorGridLine = value;
                DrawGraph();
            }
        }

        #endregion
        #region Constructor
        public ucGraph()
        {

            InitializeComponent();
            //FSeries = new ucGraphSeries[0];
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetGraphBackground();
            DrawGraph();

        }
        #endregion
        #region Painters
        private void DrawGraph()
        {
            Rectangle fullRect = new Rectangle(0, 0, panelGraphImage.Width, panelGraphImage.Height);
            using (LinearGradientBrush lgbGRBackground = new LinearGradientBrush(fullRect, GraphPanelTopLeft, GraphPanelBottomRight, LinearGradientMode.ForwardDiagonal))
            using (Bitmap GradBackground = new Bitmap(panelGraphImage.Width, panelGraphImage.Height))
            {
                Graphics grBackground = Graphics.FromImage(GradBackground);
                // First Draw Backgroup
                grBackground.FillRectangle(lgbGRBackground, 0, 0, panelGraphImage.Width, panelGraphImage.Height);

                // Draw the Minor grids
                using (Pen gridMinorLine = new Pen(GraphPanelMinorGridLine))
                {
                    float x;
                    float y;

                    int loop = 1;
                    x = (float)panelGraphImage.Width / 8;
                    y = (float)panelGraphImage.Height / 8;
                    gridMinorLine.DashPattern = new float[] { 4.0F, 2.0F };

                    while (x < panelGraphImage.Width)
                    {
                        if (loop != 4 && loop != 2 && loop != 6)
                        {
                            grBackground.DrawLine(gridMinorLine, 0, y, panelGraphImage.Width, y);
                            grBackground.DrawLine(gridMinorLine, x, 0, x, panelGraphImage.Height);

                        }
                        loop++;
                        x += ((float)panelGraphImage.Width / 8);
                        y += ((float)panelGraphImage.Height / 8);
                    }
                }

                // Next draw main grids
                using (Pen gridMainLine = new Pen(GraphPanelMainGridLine))
                {
                    grBackground.DrawRectangle(gridMainLine, 0, 0, panelGraphImage.Width - 1, panelGraphImage.Height - 1);
                    gridMainLine.DashPattern = new float[] { 4.0F, 1.0F };
                    grBackground.DrawLine(gridMainLine, 0, ((float)panelGraphImage.Height / 2), panelGraphImage.Width, ((float)panelGraphImage.Height / 2));
                    grBackground.DrawLine(gridMainLine, ((float)panelGraphImage.Width / 2), 0, ((float)panelGraphImage.Width / 2), panelGraphImage.Height);
                    grBackground.DrawLine(gridMainLine, ((float)panelGraphImage.Width / 4), 0, ((float)panelGraphImage.Width / 4), panelGraphImage.Height);
                    grBackground.DrawLine(gridMainLine, (((float)panelGraphImage.Width / 4) * 3), 0, (((float)panelGraphImage.Width / 4) * 3), panelGraphImage.Height);
                    grBackground.DrawLine(gridMainLine, 0, ((float)panelGraphImage.Height / 4), panelGraphImage.Width, ((float)panelGraphImage.Height / 4));
                    grBackground.DrawLine(gridMainLine, 0, (((float)panelGraphImage.Height / 4) * 3), panelGraphImage.Width, (((float)panelGraphImage.Height / 4) * 3));
                }
                this.SuspendLayout();
                if (panelGraphImage.BackgroundImage != null) panelGraphImage.BackgroundImage.Dispose();

                panelGraphImage.BackgroundImage = GradBackground.Clone(
                    new Rectangle(0, 0, GradBackground.Width, GradBackground.Height),
                    System.Drawing.Imaging.PixelFormat.DontCare);
                panelGraphImage.BackgroundImageLayout = ImageLayout.Stretch;
                this.ResumeLayout();

            }


        }
        private void SetupLabels()
        {
            this.SuspendLayout();
            int minLegendWidth = FMinLegendWidth;
            if (Series != null)
            {
                if (Series.Count() > 0)
                {
                    int labelY;

                    labelY = labelGraphTitle.Height + labelGraphTitle.Top + 10;
                    for (int i = 0; i < Series.Count(); i++)
                    {
                        if (Series[i].SeriesLabel == null)
                        {
                            //Series[i].SeriesLabel = new Label();
                            addNewSeriesLabel(Series[i]);
                            //Series[i].SeriesLabel.Parent = panelLegend;
                            //Series[i].SeriesLabel.AutoSize = true;
                            //Series[i].SeriesLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            //Series[i].SeriesLabel.Location = new System.Drawing.Point(10, labelY);
                            //Series[i].SeriesLabel.Name = "labelGraphTitle";
                            //Series[i].SeriesLabel.Size = new System.Drawing.Size(47, 13);
                            //Series[i].SeriesLabel.TabIndex = 0;
                            //Series[i].SeriesLabel.Show();
                        }
                        Series[i].SeriesLabel.ForeColor = Series[i].LabelColor;
                        if (Series[i].SeriesValues == null)
                        {
                            Series[i].SeriesLabel.Text = String.Format(Series[i].SeriesLabelFormat, "0");
                        }
                        else if (Series[i].SeriesValues.Count() > 0)
                        {
                            Series[i].SeriesLabel.Text = String.Format(Series[i].SeriesLabelFormat, Series[i].SeriesValues[Series[i].SeriesValues.Count() - 1].ToString(Series[i].DisplayFormat));
                        }
                        else
                        {
                            Series[i].SeriesLabel.Text = String.Format(Series[i].SeriesLabelFormat, "0");
                        }
                        labelY += Series[i].SeriesLabel.Height + 5;

                        if (Series[i].SeriesLabel.Width + Series[i].SeriesLabel.Left > minLegendWidth)
                        {
                            minLegendWidth = Series[i].SeriesLabel.Width + Series[i].SeriesLabel.Left;
                        }
                    }
                }
            }
            //if (minLegendWidth < labelGraphTitle.Width + labelGraphTitle.Left)
            //    minLegendWidth = labelGraphTitle.Width + labelGraphTitle.Left;

            minLegendWidth += 5;

            if (minLegendWidth < MinLegendWidth)
                minLegendWidth = MinLegendWidth;
            splitContainerGraphBody.SplitterDistance = minLegendWidth;
            this.ResumeLayout();
        }
        public void SetGraphBackground()
        {

            Rectangle fullRect = new Rectangle(0, 0, splitContainerGraphBody.Width, splitContainerGraphBody.Height);
            using (LinearGradientBrush lgbGRBackground = new LinearGradientBrush(fullRect, FBackGroundTopLeft, FBackGroundBottomRight, LinearGradientMode.ForwardDiagonal))
            using (Bitmap GradBackground = new Bitmap(splitContainerGraphBody.Width, splitContainerGraphBody.Height))
            {
                Graphics grBackground = Graphics.FromImage(GradBackground);
                grBackground.FillRectangle(lgbGRBackground, 0, 0, splitContainerGraphBody.Width, splitContainerGraphBody.Height);

                this.SuspendLayout();
                if (splitContainerGraphBody.BackgroundImage != null) splitContainerGraphBody.BackgroundImage.Dispose();

                splitContainerGraphBody.BackgroundImage = GradBackground.Clone(
                    new Rectangle(0, 0, GradBackground.Width, GradBackground.Height),
                    System.Drawing.Imaging.PixelFormat.DontCare);
                splitContainerGraphBody.BackgroundImageLayout = ImageLayout.Stretch;
                this.ResumeLayout();

            }

        }

        #endregion
        public void addNewSeriesLabel(ucGraphSeries series)
        {
            series.SeriesLabel = new Label();
            series.SeriesValueLabel = new Label();

            panelLegend.Controls.Add(series.SeriesLabel);
            panelLegend.Controls.Add(series.SeriesValueLabel);

            series.SeriesLabel.Text = series.SeriesName + ":";
            series.SeriesLabel.AutoSize = series.SeriesValueLabel.AutoSize = true;
            series.SeriesLabel.Left = 5;

            series.SeriesValueLabel.Left = series.SeriesLabel.Left + series.SeriesLabel.Width + 4;
            series.SeriesValueLabel.Top = series.SeriesLabel.Top = 5 + ((series.SeriesLabel.Font.Height + 5) * (series.SeriesOrder));
            series.SeriesValueLabel.Height = series.SeriesLabel.Height = series.SeriesLabel.Font.Height + 2;
            series.SeriesValueLabel.Visible = series.SeriesLabel.Visible = true;
            series.SeriesLabel.Show();
            series.SeriesValueLabel.Show();
        }
        private void panelLegend_Paint(object sender, PaintEventArgs e)
        {

            if (Series.Length > 0)
                for (int i = 0; i < Series.Length; i++)
                    Series[i].RedrawLabel();
        }

        private void panelGraphImage_Resize(object sender, EventArgs e)
        {
            SetGraphBackground();
            DrawGraph();

        }
    }
    public class ucGraphSeries : IDisposable
    {
        #region Fields
        private String FSeriesName = "SeriesName";
        private String FSeriesLabelFormat = "Series: {0}";
        private decimal[] FSeriesValues;
        private bool[] FSeriesValuesSet;
        private String FDisplayFormat = "#,##0.00";
        private Color FLineColorTop = Color.White;
        private Color FLineColorBottom = Color.White;
        private Color FLabelColor = Color.White;
        private Boolean FShowArea = true;
        private int FAreaTransparency = 50;
        private Label FSeriesLabel;
        private Label FSeriesValueLabel;
        private ucGraph FParentGraph;
        private int FSeriesOrder = 0;
        private bool FShowOnGraph = true;
        #endregion
        #region Properties
        public string SeriesName { get => FSeriesName; set => FSeriesName = value; }
        public decimal[] SeriesValues { get => FSeriesValues; set => FSeriesValues = value; }
        public bool[] SeriesValuesSet { get => FSeriesValuesSet; set => FSeriesValuesSet = value; }
        public string DisplayFormat { get => FDisplayFormat; set => FDisplayFormat = value; }
        public Color LineColorTop { get => FLineColorTop; set => FLineColorTop = value; }
        public Color LineColorBottom { get => FLineColorBottom; set => FLineColorBottom = value; }
        public bool ShowArea { get => FShowArea; set => FShowArea = value; }
        public int AreaTransparency { get => FAreaTransparency; set => FAreaTransparency = value; }
        public string SeriesLabelFormat { get => FSeriesLabelFormat; set => FSeriesLabelFormat = value; }
        public Label SeriesLabel { get => FSeriesLabel; set => FSeriesLabel = value; }
        public Label SeriesValueLabel { get => FSeriesValueLabel; set => FSeriesValueLabel = value; }
        public Color LabelColor { get => FLabelColor; set => FLabelColor = value; }
        public ucGraph ParentGraph { get => FParentGraph; set => FParentGraph = value; }
        public int SeriesOrder { get => FSeriesOrder; set => FSeriesOrder = value; }
        public bool ShowOnGraph { get => FShowOnGraph; set => FShowOnGraph = value; }
        #endregion
        #region Constructor
        public ucGraphSeries()
        {
            System.ComponentModel.LicenseUsageMode usageMode = new LicenseUsageMode();
            if (usageMode == LicenseUsageMode.Designtime)
            {
                FSeriesValues = new decimal[200];
                decimal val = 10;
                Random rand = new Random();
                for (int i = 0; i < 200; i++)
                {
                    FSeriesValues[i] = val;
                    FSeriesValuesSet[i] = true;

                    val += (rand.Next(-5, 5));
                    if (val < 0)
                        val = 0 + rand.Next(0, 10);
                }
            }

        }
        public void Dispose()
        {
        }
        #endregion
        #region Methods
        public void RedrawLabel()
        {
            // Do I need to build the series label?
            if (SeriesLabel == null && ParentGraph != null)
            {
                ParentGraph.addNewSeriesLabel(this);
            }
            SeriesLabel.Text = SeriesName + ":";
            SeriesValueLabel.Text = DisplayFormat;
            SeriesValueLabel.Left = SeriesLabel.Left + SeriesLabel.Width + 4;
            SeriesValueLabel.ForeColor = SeriesLabel.ForeColor = LabelColor;

        }
        public void DrawSeries(Graphics grBody, Panel targetPanel, decimal minValue, decimal maxValue, ucGraphSeries[] fullSeriesSet)
        {
            // If this series is not a label only series.  Label only could be
            // IO error as most of the time this is small or does not change. 
            if (ShowOnGraph)
            {
                // Get the graph rectangle for drawing
                Rectangle rectGraphArea = new Rectangle(1, 1, targetPanel.Width - 2, targetPanel.Height - 2);
                // set the graph colours
                using (LinearGradientBrush brushSeries = new LinearGradientBrush(rectGraphArea, LineColorTop, LineColorBottom, LinearGradientMode.Vertical))
                using (LinearGradientBrush brushArea = new LinearGradientBrush(rectGraphArea, Color.FromArgb(AreaTransparency, FLineColorTop), Color.FromArgb(AreaTransparency, LineColorBottom), LinearGradientMode.Vertical))
                using (Pen penSeries = new Pen(brushSeries))
                using (Pen penArea = new Pen(brushArea))
                {
                    // Set the pen width based on the size of the graph
                    penSeries.Width = ((rectGraphArea.Height > 100 && rectGraphArea.Width > 150) ? 2 : 1);

                    // For each point on the graph
                    for (int point = 0; point < SeriesValues.Length; point++)
                    {
                        // check if point is initialised
                        if (SeriesValuesSet[point])
                        {

                        }


                    }

                }

            }
        }
        #endregion
    }
}
