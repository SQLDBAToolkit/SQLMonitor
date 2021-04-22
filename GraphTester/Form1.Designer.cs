namespace GraphTester
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GraphTester.ucGraphSeries ucGraphSeries1 = new GraphTester.ucGraphSeries();
            GraphTester.ucGraphSeries ucGraphSeries2 = new GraphTester.ucGraphSeries();
            this.ucGraph1 = new GraphTester.ucGraph();
            this.SuspendLayout();
            // 
            // ucGraph1
            // 
            this.ucGraph1.BackColor = System.Drawing.Color.Transparent;
            this.ucGraph1.BackGroundBottomRight = System.Drawing.Color.MidnightBlue;
            this.ucGraph1.BackgroundImage = global::GraphTester.Properties.Resources.TransBackground;
            this.ucGraph1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ucGraph1.BackGroundTopLeft = System.Drawing.Color.DarkSlateGray;
            this.ucGraph1.BottomValue = 0D;
            this.ucGraph1.DisplayFrom = 0;
            this.ucGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGraph1.GraphPanelBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ucGraph1.GraphPanelMainGridLine = System.Drawing.Color.DimGray;
            this.ucGraph1.GraphPanelMinorGridLine = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ucGraph1.GraphPanelTopLeft = System.Drawing.Color.Black;
            this.ucGraph1.GraphTitle = "CPU Usage";
            this.ucGraph1.Location = new System.Drawing.Point(0, 0);
            this.ucGraph1.MinLegendWidth = 200;
            this.ucGraph1.Name = "ucGraph1";
            ucGraphSeries1.AreaTransparency = 50;
            ucGraphSeries1.DisplayFormat = "#,##0";
            ucGraphSeries1.LabelColor = System.Drawing.Color.DarkGreen;
            ucGraphSeries1.LineColorBottom = System.Drawing.Color.White;
            ucGraphSeries1.LineColorTop = System.Drawing.Color.White;
            ucGraphSeries1.ParentGraph = this.ucGraph1;
            ucGraphSeries1.SeriesLabelFormat = "Series: {0}/sec";
            ucGraphSeries1.SeriesName = "This is my new series";
            ucGraphSeries1.SeriesOrder = 0;
            ucGraphSeries1.SeriesValues = new decimal[] {
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    20,
                    0,
                    0,
                    0})};
            ucGraphSeries1.ShowArea = true;
            ucGraphSeries2.AreaTransparency = 50;
            ucGraphSeries2.DisplayFormat = "##0.00%";
            ucGraphSeries2.LabelColor = System.Drawing.Color.OrangeRed;
            ucGraphSeries2.LineColorBottom = System.Drawing.Color.White;
            ucGraphSeries2.LineColorTop = System.Drawing.Color.White;
            ucGraphSeries2.ParentGraph = this.ucGraph1;
            ucGraphSeries2.SeriesLabelFormat = "CPU Usage: {0}";
            ucGraphSeries2.SeriesName = "SeriesName";
            ucGraphSeries2.SeriesOrder = 1;
            ucGraphSeries2.SeriesValues = new decimal[] {
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    0,
                    0,
                    0,
                    0}),
        new decimal(new int[] {
                    2565,
                    0,
                    0,
                    262144})};
            ucGraphSeries2.ShowArea = true;
            this.ucGraph1.Series = new GraphTester.ucGraphSeries[] {
        ucGraphSeries1,
        ucGraphSeries2};
            this.ucGraph1.Size = new System.Drawing.Size(683, 213);
            this.ucGraph1.TabIndex = 0;
            this.ucGraph1.TopValue = 500D;
            this.ucGraph1.TrendLinePosition = 0D;
            this.ucGraph1.Load += new System.EventHandler(this.ucGraph1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 213);
            this.Controls.Add(this.ucGraph1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucGraph ucGraph1;
    }
}

