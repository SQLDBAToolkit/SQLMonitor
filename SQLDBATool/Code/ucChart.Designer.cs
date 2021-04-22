
namespace SQLDBATool.Code
{
    partial class ucChart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelChartTitle = new System.Windows.Forms.Label();
            this.labelLegend = new System.Windows.Forms.Label();
            this.ChartArea = new SQLDBATool.Code.ucChartArea();
            this.SuspendLayout();
            // 
            // labelChartTitle
            // 
            this.labelChartTitle.AutoSize = true;
            this.labelChartTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelChartTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelChartTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartTitle.ForeColor = System.Drawing.Color.Black;
            this.labelChartTitle.Location = new System.Drawing.Point(0, 0);
            this.labelChartTitle.Name = "labelChartTitle";
            this.labelChartTitle.Size = new System.Drawing.Size(73, 15);
            this.labelChartTitle.TabIndex = 1;
            this.labelChartTitle.Text = "Chart Title";
            this.labelChartTitle.Visible = false;
            // 
            // labelLegend
            // 
            this.labelLegend.AutoSize = true;
            this.labelLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLegend.Location = new System.Drawing.Point(3, 23);
            this.labelLegend.Name = "labelLegend";
            this.labelLegend.Size = new System.Drawing.Size(35, 12);
            this.labelLegend.TabIndex = 2;
            this.labelLegend.Text = "Legend";
            this.labelLegend.Visible = false;
            // 
            // ChartArea
            // 
            this.ChartArea.BackColor = System.Drawing.Color.Black;
            this.ChartArea.BottomColor = System.Drawing.Color.Black;
            this.ChartArea.GraphTable = null;
            this.ChartArea.GridLineColor = System.Drawing.Color.GhostWhite;
            this.ChartArea.IsStacked = false;
            this.ChartArea.LegendTable = null;
            this.ChartArea.Location = new System.Drawing.Point(120, 21);
            this.ChartArea.MaxValue = ((long)(0));
            this.ChartArea.Name = "ChartArea";
            this.ChartArea.Series = null;
            this.ChartArea.Size = new System.Drawing.Size(471, 210);
            this.ChartArea.TabIndex = 0;
            this.ChartArea.TopColor = System.Drawing.Color.Black;
            // 
            // ucChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelLegend);
            this.Controls.Add(this.labelChartTitle);
            this.Controls.Add(this.ChartArea);
            this.Name = "ucChart";
            this.Size = new System.Drawing.Size(594, 242);
            this.SizeChanged += new System.EventHandler(this.ucChart_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucChart_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucChartArea ChartArea;
        private System.Windows.Forms.Label labelChartTitle;
        private System.Windows.Forms.Label labelLegend;
    }
}
