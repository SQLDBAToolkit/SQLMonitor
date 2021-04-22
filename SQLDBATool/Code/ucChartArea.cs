using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SQLDBATool.Code
{
    public partial class ucChartArea : UserControl
    {

        private Color FTopColor = Color.Black;
        private Color FBottomColor = Color.Black;
        private Color FGridLineColor = Color.GhostWhite;
        private DataTable FGraphTable;
        private DataTable FLegendTable;
        private ucSeries[] FSeries;
        double[] FStackedTracker;

        private bool FIsStacked;
        private Int64 FMaxValue;
        public Int64 MaxValue { get => FMaxValue; set => FMaxValue = value; }
        public bool IsStacked { get => FIsStacked; set => FIsStacked = value; }
        public Color TopColor { get => FTopColor; set => FTopColor = value; }
        public Color BottomColor { get => FBottomColor; set => FBottomColor = value; }
        public Color GridLineColor { get => FGridLineColor; set => FGridLineColor = value; }
        public DataTable GraphTable { get => FGraphTable; set => FGraphTable = value; }
        public DataTable LegendTable { get => FLegendTable; set => FLegendTable = value; }
        public ucSeries[] Series
        {
            get => FSeries;
            set
            {
                FSeries = value;
                this.Refresh();
            }
        }

        public ucChartArea()
        {
            InitializeComponent();
        }

        public void DrawSeries(ucSeries series, Graphics grGraph, bool drawShadow)
        {
            if (FGraphTable != null)
            {
                if (FGraphTable.Columns.Contains(series.ColumnName))
                {
                    int maxPoints = (FGraphTable.Rows.Count > 300 ? FGraphTable.Rows.Count : 300);

                    float xIterations = ((float)(this.ClientRectangle.Width - 2) / maxPoints);
                    float yIterations = ((float)(this.ClientRectangle.Height - 2) / FMaxValue);
                    float x = 0;
                    float y = 0;
                    Point currentPoint = new Point();
                    Point previousPoint = new Point();
                    Point previousPointBottom = new Point();
                    using (LinearGradientBrush seriesBrush = new LinearGradientBrush(this.ClientRectangle, series.TopColor, series.BottomColor, LinearGradientMode.Vertical))
                    using (LinearGradientBrush seriesAreaBrush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(80, series.TopColor), Color.FromArgb(80, series.BottomColor), LinearGradientMode.Vertical))
                    {
                        //Draw first point

                        if (FGraphTable.Rows.Count >= 1)
                        {
                            previousPoint.X = 0;
                            previousPoint.Y = (this.ClientRectangle.Height - 1) - (int)((getPoint(series, 0) + FStackedTracker[0]) * yIterations);
                            previousPointBottom.X = 0;
                            previousPointBottom.Y = (this.ClientRectangle.Height - 1) - (int)(FStackedTracker[0] * yIterations);

                            if (this.IsStacked)
                            {
                                FStackedTracker[0] = (int)(getPoint(series, 0) + FStackedTracker[0]);
                            }


                            using (System.Drawing.Pen seriesPen = new System.Drawing.Pen(seriesBrush))
                            using (System.Drawing.Pen seriesAreaPen = new System.Drawing.Pen(seriesAreaBrush))
                            {
                                seriesPen.Width = 1;

                                for (int index = 1; index < FGraphTable.Rows.Count; index++)
                                {
                                    Point currentPointBottom = new Point();
                                    double pointValue = getPoint(series, index);
                                    currentPointBottom.Y = (this.ClientRectangle.Height - 1) - (int)((FStackedTracker[index]) * yIterations);
                                    currentPointBottom.X = currentPoint.X;

                                    currentPoint.X = (int)(xIterations * index);
                                    currentPoint.Y = (this.ClientRectangle.Height - 1) - (int)((pointValue + FStackedTracker[index]) * yIterations);


                                    Point[] points = { previousPoint, currentPoint, currentPointBottom, previousPointBottom };
                                    if (pointValue > 0 || !IsStacked)
                                    {
                                        if (drawShadow)
                                            grGraph.FillPolygon(seriesAreaBrush, points, FillMode.Winding);
                                        else
                                            grGraph.DrawLine(seriesPen, previousPoint, currentPoint);
                                    }
                                    previousPoint = currentPoint;
                                    previousPointBottom = currentPointBottom;
                                    if (IsStacked)
                                        FStackedTracker[index] += pointValue;

                                }
                            }
                        }
                    }
                }
            }
        }


        private double getPoint(ucSeries series, int index)
        {
            double ret = 0;

            if (FGraphTable.Rows[index][series.ColumnName].GetType().FullName == "System.Decimal")
                ret = (double)(decimal)FGraphTable.Rows[index][series.ColumnName];
            if (FGraphTable.Rows[index][series.ColumnName].GetType().FullName == "System.Int32")
                ret = (double)(int)FGraphTable.Rows[index][series.ColumnName];
            if (FGraphTable.Rows[index][series.ColumnName].GetType().FullName == "System.Int64")
                ret = (double)(Int64)FGraphTable.Rows[index][series.ColumnName];
            //else if (series.CellDataType == "int")
            //    ret = (double)(int)FGraphTable.Rows[index][series.ColumnName];
            //else if (series.CellDataType == "long")
            //    ret = (double)(long)FGraphTable.Rows[index][series.ColumnName];
            //else if (series.CellDataType == "decimal")
            //    ret = (double)(decimal)FGraphTable.Rows[index][series.ColumnName];

            return ret;
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
                    using (LinearGradientBrush lgBrush = new LinearGradientBrush(e.ClipRectangle, TopColor, BottomColor, LinearGradientMode.Vertical))
                    {
                        grGraph.FillRectangle(lgBrush, this.ClientRectangle);
                    }
                    #endregion
                    #region Draw the grid lines
                    using (Pen pen = new Pen(Color.WhiteSmoke))
                    {
                        pen.DashPattern = new float[] { 5.0F, 2.0F };
                        grGraph.DrawLine(pen, this.ClientRectangle.Left, this.ClientRectangle.Height / 2, this.ClientRectangle.Width, this.ClientRectangle.Height / 2);
                        grGraph.DrawLine(pen, this.ClientRectangle.Width / 2, this.ClientRectangle.Top, this.ClientRectangle.Width / 2, this.ClientRectangle.Bottom);

                        pen.DashPattern = new float[] { 2.0F, 4.0F };
                        grGraph.DrawLine(pen, this.ClientRectangle.Left, this.ClientRectangle.Height / 4, this.ClientRectangle.Width, this.ClientRectangle.Height / 4);
                        grGraph.DrawLine(pen, this.ClientRectangle.Left, (this.ClientRectangle.Height / 4) * 3, this.ClientRectangle.Width, (this.ClientRectangle.Height / 4) * 3);
                        grGraph.DrawLine(pen, this.ClientRectangle.Width / 4, this.ClientRectangle.Top, this.ClientRectangle.Width / 4, this.ClientRectangle.Bottom);
                        grGraph.DrawLine(pen, (this.ClientRectangle.Width / 4) * 3, this.ClientRectangle.Top, (this.ClientRectangle.Width / 4) * 3, this.ClientRectangle.Bottom);

                    }
                    #endregion
                    #region Draw Series
                    if (FSeries != null)
                    {
                        //if (FIsStacked)
                        //{
                        //}    
                        FStackedTracker = new double[300];
                        for (int i = 0; i < 300; i++)
                            FStackedTracker[i] = 0;
                        foreach (ucSeries series in FSeries)
                        {
                            DrawSeries(series, grGraph, true);
                        }
                        FStackedTracker = new double[300];
                        for (int i = 0; i < 300; i++)
                            FStackedTracker[i] = 0;
                        foreach (ucSeries series in FSeries)
                        {
                            DrawSeries(series, grGraph, false);
                        }
                    }
                    #endregion

                    e.Graphics.DrawImage(bmGraph, e.ClipRectangle.X, e.ClipRectangle.Y);
                }
            }
        }
    }


    public class ucSeries : Control, IDisposable
    {
        private string FColumnName;
        private string FDataType;
        private Color FTopColor = Color.Lime;
        private Color FBottomColor = Color.Lime;
        private int FGradeientPercent = 50;
        private string FSeriesLedgendSource;
        private Color FLegendColor = Color.Lime;
        public ucSeries()
        {
            InitialiseComponent();
        }
        private void InitialiseComponent()
        {

        }
        protected void OnLoad(EventArgs e)
        {

        }
        public string ColumnName { get => FColumnName; set => FColumnName = value; }
        public string CellDataType { get => FDataType; set => FDataType = value; }
        public Color TopColor { get => FTopColor; set => FTopColor = value; }
        public Color LegendColor { get => FLegendColor; set => FLegendColor = value; }
        public Color BottomColor { get => FBottomColor; set => FBottomColor = value; }
        public int GradeientPercent { get => FGradeientPercent; set => FGradeientPercent = value; }
        public string SeriesLedgendSource { get => FSeriesLedgendSource; set => FSeriesLedgendSource = value; }

        //public void Dispose()
        //{

        //}
    }

}
