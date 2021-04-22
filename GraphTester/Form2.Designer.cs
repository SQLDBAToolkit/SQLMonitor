namespace GraphTester
{
    partial class Form2
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
            this.ucGraph1 = new GraphTester.ucGraph();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucGraph1
            // 
            this.ucGraph1.BackColor = System.Drawing.Color.Black;
            this.ucGraph1.BottomValue = 0D;
            //this.ucGraph1.ColorBackgroundBottomRight = System.Drawing.Color.DarkCyan;
            //this.ucGraph1.ColorBackgroundTopLeft = System.Drawing.Color.DarkBlue;
            //this.ucGraph1.ColorGraphBorder = System.Drawing.Color.DimGray;
            //this.ucGraph1.ColorGraphMarkerLine = System.Drawing.Color.Orange;
            //this.ucGraph1.ColorGraphPrimaryGrid = System.Drawing.Color.Brown;
            //this.ucGraph1.ColorGraphSecondaryGrid = System.Drawing.Color.Red;
            //this.ucGraph1.ColorGraphTitle = System.Drawing.Color.DimGray;
            //this.ucGraph1.ColorGraphTitleBackground = System.Drawing.Color.Black;
            //this.ucGraph1.ColorLegendBackground = System.Drawing.Color.Black;
            this.ucGraph1.DisplayFrom = 0;
            this.ucGraph1.GraphTitle = "Graph Title";
            this.ucGraph1.Location = new System.Drawing.Point(43, 0);
            this.ucGraph1.MinLegendWidth = 10;
            this.ucGraph1.Name = "ucGraph1";
            ucGraphSeries1.AreaTransparency = 50;
            ucGraphSeries1.DisplayFormat = "#,##0.00";
            ucGraphSeries1.LabelColor = System.Drawing.Color.White;
            ucGraphSeries1.LineColorBottom = System.Drawing.Color.White;
            ucGraphSeries1.LineColorTop = System.Drawing.Color.White;
            ucGraphSeries1.SeriesLabel = null;
            ucGraphSeries1.SeriesLabelFormat = "Series: {0}";
            ucGraphSeries1.SeriesName = "SeriesName";
            ucGraphSeries1.SeriesValues = null;
            ucGraphSeries1.ShowArea = true;
            this.ucGraph1.Series = new GraphTester.ucGraphSeries[] {
        ucGraphSeries1};
            this.ucGraph1.Size = new System.Drawing.Size(752, 330);
            this.ucGraph1.TabIndex = 0;
            this.ucGraph1.TopValue = 100D;
            this.ucGraph1.TrendLinePosition = 0D;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(11, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 225);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 420);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucGraph1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private ucGraph ucGraph1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}