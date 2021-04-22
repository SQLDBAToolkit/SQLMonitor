namespace GraphTester
{
    partial class ucGraph
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
            this.panelLegend = new System.Windows.Forms.Panel();
            this.labelGraphTitle = new System.Windows.Forms.Label();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.panelGraphImage = new System.Windows.Forms.Panel();
            this.panelGraphBottomLegend = new System.Windows.Forms.Panel();
            this.panelGraphLeft = new System.Windows.Forms.Panel();
            this.panelGraphLeftLegend = new System.Windows.Forms.Panel();
            this.labelMidValue = new System.Windows.Forms.Label();
            this.labelLowValue = new System.Windows.Forms.Label();
            this.labelHighValue = new System.Windows.Forms.Label();
            this.labelVerticalDescription = new GraphTester.VerticalLabel();
            this.panelLeftFiller = new System.Windows.Forms.Panel();
            this.panelGraphTitle = new System.Windows.Forms.Panel();
            this.panelMasterBackground = new System.Windows.Forms.Panel();
            this.splitContainerGraphBody = new System.Windows.Forms.SplitContainer();
            this.panelGraph.SuspendLayout();
            this.panelGraphLeft.SuspendLayout();
            this.panelGraphLeftLegend.SuspendLayout();
            this.panelGraphTitle.SuspendLayout();
            this.panelMasterBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGraphBody)).BeginInit();
            this.splitContainerGraphBody.Panel1.SuspendLayout();
            this.splitContainerGraphBody.Panel2.SuspendLayout();
            this.splitContainerGraphBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLegend
            // 
            this.panelLegend.BackColor = System.Drawing.Color.Transparent;
            this.panelLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLegend.Location = new System.Drawing.Point(0, 0);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(197, 268);
            this.panelLegend.TabIndex = 0;
            this.panelLegend.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLegend_Paint);
            // 
            // labelGraphTitle
            // 
            this.labelGraphTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGraphTitle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGraphTitle.ForeColor = System.Drawing.Color.White;
            this.labelGraphTitle.Location = new System.Drawing.Point(0, 0);
            this.labelGraphTitle.Name = "labelGraphTitle";
            this.labelGraphTitle.Size = new System.Drawing.Size(817, 13);
            this.labelGraphTitle.TabIndex = 0;
            this.labelGraphTitle.Text = "labelGraphTitle";
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.Transparent;
            this.panelGraph.Controls.Add(this.panelGraphImage);
            this.panelGraph.Controls.Add(this.panelGraphBottomLegend);
            this.panelGraph.Controls.Add(this.panelGraphLeft);
            this.panelGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraph.Location = new System.Drawing.Point(0, 0);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(619, 268);
            this.panelGraph.TabIndex = 2;
            // 
            // panelGraphImage
            // 
            this.panelGraphImage.BackColor = System.Drawing.Color.White;
            this.panelGraphImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraphImage.Location = new System.Drawing.Point(70, 0);
            this.panelGraphImage.Name = "panelGraphImage";
            this.panelGraphImage.Size = new System.Drawing.Size(549, 247);
            this.panelGraphImage.TabIndex = 2;
            this.panelGraphImage.Resize += new System.EventHandler(this.panelGraphImage_Resize);
            // 
            // panelGraphBottomLegend
            // 
            this.panelGraphBottomLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelGraphBottomLegend.Location = new System.Drawing.Point(70, 247);
            this.panelGraphBottomLegend.Name = "panelGraphBottomLegend";
            this.panelGraphBottomLegend.Size = new System.Drawing.Size(549, 21);
            this.panelGraphBottomLegend.TabIndex = 1;
            // 
            // panelGraphLeft
            // 
            this.panelGraphLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelGraphLeft.Controls.Add(this.panelGraphLeftLegend);
            this.panelGraphLeft.Controls.Add(this.panelLeftFiller);
            this.panelGraphLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelGraphLeft.Location = new System.Drawing.Point(0, 0);
            this.panelGraphLeft.Name = "panelGraphLeft";
            this.panelGraphLeft.Size = new System.Drawing.Size(70, 268);
            this.panelGraphLeft.TabIndex = 0;
            // 
            // panelGraphLeftLegend
            // 
            this.panelGraphLeftLegend.Controls.Add(this.labelMidValue);
            this.panelGraphLeftLegend.Controls.Add(this.labelLowValue);
            this.panelGraphLeftLegend.Controls.Add(this.labelHighValue);
            this.panelGraphLeftLegend.Controls.Add(this.labelVerticalDescription);
            this.panelGraphLeftLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraphLeftLegend.Location = new System.Drawing.Point(0, 0);
            this.panelGraphLeftLegend.Name = "panelGraphLeftLegend";
            this.panelGraphLeftLegend.Size = new System.Drawing.Size(70, 247);
            this.panelGraphLeftLegend.TabIndex = 2;
            // 
            // labelMidValue
            // 
            this.labelMidValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMidValue.ForeColor = System.Drawing.Color.White;
            this.labelMidValue.Location = new System.Drawing.Point(20, 13);
            this.labelMidValue.Name = "labelMidValue";
            this.labelMidValue.Size = new System.Drawing.Size(50, 221);
            this.labelMidValue.TabIndex = 3;
            this.labelMidValue.Text = "500";
            this.labelMidValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLowValue
            // 
            this.labelLowValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelLowValue.ForeColor = System.Drawing.Color.White;
            this.labelLowValue.Location = new System.Drawing.Point(20, 234);
            this.labelLowValue.Name = "labelLowValue";
            this.labelLowValue.Size = new System.Drawing.Size(50, 13);
            this.labelLowValue.TabIndex = 2;
            this.labelLowValue.Text = "0";
            this.labelLowValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelHighValue
            // 
            this.labelHighValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelHighValue.ForeColor = System.Drawing.Color.White;
            this.labelHighValue.Location = new System.Drawing.Point(20, 0);
            this.labelHighValue.Name = "labelHighValue";
            this.labelHighValue.Size = new System.Drawing.Size(50, 13);
            this.labelHighValue.TabIndex = 1;
            this.labelHighValue.Text = "1000";
            this.labelHighValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelVerticalDescription
            // 
            this.labelVerticalDescription.BackgroundImage = global::GraphTester.Properties.Resources.TransBackground;
            this.labelVerticalDescription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.labelVerticalDescription.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelVerticalDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVerticalDescription.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelVerticalDescription.Location = new System.Drawing.Point(0, 0);
            this.labelVerticalDescription.Name = "labelVerticalDescription";
            this.labelVerticalDescription.RenderingMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.labelVerticalDescription.Size = new System.Drawing.Size(20, 247);
            this.labelVerticalDescription.TabIndex = 0;
            this.labelVerticalDescription.Text = "verticalLabel1";
            this.labelVerticalDescription.TextDrawMode = GraphTester.DrawMode.BottomUp;
            this.labelVerticalDescription.TransparentBackground = false;
            // 
            // panelLeftFiller
            // 
            this.panelLeftFiller.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLeftFiller.Location = new System.Drawing.Point(0, 247);
            this.panelLeftFiller.Name = "panelLeftFiller";
            this.panelLeftFiller.Size = new System.Drawing.Size(70, 21);
            this.panelLeftFiller.TabIndex = 3;
            // 
            // panelGraphTitle
            // 
            this.panelGraphTitle.BackColor = System.Drawing.Color.LimeGreen;
            this.panelGraphTitle.Controls.Add(this.labelGraphTitle);
            this.panelGraphTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGraphTitle.Location = new System.Drawing.Point(0, 0);
            this.panelGraphTitle.Name = "panelGraphTitle";
            this.panelGraphTitle.Size = new System.Drawing.Size(817, 18);
            this.panelGraphTitle.TabIndex = 0;
            // 
            // panelMasterBackground
            // 
            this.panelMasterBackground.BackColor = System.Drawing.Color.Black;
            this.panelMasterBackground.BackgroundImage = global::GraphTester.Properties.Resources.TransBackground;
            this.panelMasterBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMasterBackground.Controls.Add(this.splitContainerGraphBody);
            this.panelMasterBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMasterBackground.Location = new System.Drawing.Point(0, 18);
            this.panelMasterBackground.Name = "panelMasterBackground";
            this.panelMasterBackground.Size = new System.Drawing.Size(817, 268);
            this.panelMasterBackground.TabIndex = 0;
            // 
            // splitContainerGraphBody
            // 
            this.splitContainerGraphBody.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerGraphBody.BackgroundImage = global::GraphTester.Properties.Resources.TransBackground;
            this.splitContainerGraphBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerGraphBody.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerGraphBody.IsSplitterFixed = true;
            this.splitContainerGraphBody.Location = new System.Drawing.Point(0, 0);
            this.splitContainerGraphBody.Name = "splitContainerGraphBody";
            // 
            // splitContainerGraphBody.Panel1
            // 
            this.splitContainerGraphBody.Panel1.Controls.Add(this.panelLegend);
            // 
            // splitContainerGraphBody.Panel2
            // 
            this.splitContainerGraphBody.Panel2.Controls.Add(this.panelGraph);
            this.splitContainerGraphBody.Size = new System.Drawing.Size(817, 268);
            this.splitContainerGraphBody.SplitterDistance = 197;
            this.splitContainerGraphBody.SplitterWidth = 1;
            this.splitContainerGraphBody.TabIndex = 0;
            this.splitContainerGraphBody.TabStop = false;
            // 
            // ucGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panelMasterBackground);
            this.Controls.Add(this.panelGraphTitle);
            this.Name = "ucGraph";
            this.Size = new System.Drawing.Size(817, 286);
            this.panelGraph.ResumeLayout(false);
            this.panelGraphLeft.ResumeLayout(false);
            this.panelGraphLeftLegend.ResumeLayout(false);
            this.panelGraphTitle.ResumeLayout(false);
            this.panelMasterBackground.ResumeLayout(false);
            this.splitContainerGraphBody.Panel1.ResumeLayout(false);
            this.splitContainerGraphBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGraphBody)).EndInit();
            this.splitContainerGraphBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLegend;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Label labelGraphTitle;
        private System.Windows.Forms.Panel panelGraphImage;
        private System.Windows.Forms.Panel panelGraphBottomLegend;
        private System.Windows.Forms.Panel panelGraphLeft;
        private System.Windows.Forms.Panel panelGraphLeftLegend;
        private System.Windows.Forms.Panel panelLeftFiller;
        private VerticalLabel labelVerticalDescription;
        private System.Windows.Forms.Label labelMidValue;
        private System.Windows.Forms.Label labelLowValue;
        private System.Windows.Forms.Label labelHighValue;
        private System.Windows.Forms.Panel panelGraphTitle;
        private System.Windows.Forms.Panel panelMasterBackground;
        private System.Windows.Forms.SplitContainer splitContainerGraphBody;
    }
}
