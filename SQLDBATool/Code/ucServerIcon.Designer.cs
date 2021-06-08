
namespace SQLDBATool.Code
{
    partial class ucServerIcon
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucServerIcon));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelServerName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCPUUsage = new System.Windows.Forms.Label();
            this.labelBHR = new System.Windows.Forms.Label();
            this.labelUpTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Server.png");
            this.imageList1.Images.SetKeyName(1, "ServerBusy.png");
            this.imageList1.Images.SetKeyName(2, "ServerDown.png");
            this.imageList1.Images.SetKeyName(3, "tvDatabase.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelServerName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 34);
            this.panel1.TabIndex = 4;
            // 
            // labelServerName
            // 
            this.labelServerName.BackColor = System.Drawing.Color.LightSlateGray;
            this.labelServerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelServerName.Location = new System.Drawing.Point(0, 0);
            this.labelServerName.Name = "labelServerName";
            this.labelServerName.Size = new System.Drawing.Size(185, 34);
            this.labelServerName.TabIndex = 0;
            this.labelServerName.Text = "Server";
            this.labelServerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 12);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "CPU";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(58, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "BHR";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(122, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Up Time";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelCPUUsage
            // 
            this.labelCPUUsage.Location = new System.Drawing.Point(4, 66);
            this.labelCPUUsage.Name = "labelCPUUsage";
            this.labelCPUUsage.Size = new System.Drawing.Size(56, 20);
            this.labelCPUUsage.TabIndex = 9;
            this.labelCPUUsage.Text = "0";
            this.labelCPUUsage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelBHR
            // 
            this.labelBHR.Location = new System.Drawing.Point(58, 66);
            this.labelBHR.Name = "labelBHR";
            this.labelBHR.Size = new System.Drawing.Size(56, 20);
            this.labelBHR.TabIndex = 10;
            this.labelBHR.Text = "0";
            this.labelBHR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelUpTime
            // 
            this.labelUpTime.Location = new System.Drawing.Point(122, 66);
            this.labelUpTime.Name = "labelUpTime";
            this.labelUpTime.Size = new System.Drawing.Size(56, 29);
            this.labelUpTime.TabIndex = 11;
            this.labelUpTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SQLDBATool.Properties.Resources.ShadowVerticalLine;
            this.pictureBox1.Location = new System.Drawing.Point(58, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SQLDBATool.Properties.Resources.ShadowVerticalLine;
            this.pictureBox2.Location = new System.Drawing.Point(115, 53);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // ucServerIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelUpTime);
            this.Controls.Add(this.labelBHR);
            this.Controls.Add(this.labelCPUUsage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ucServerIcon";
            this.Size = new System.Drawing.Size(185, 99);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCPUUsage;
        private System.Windows.Forms.Label labelBHR;
        private System.Windows.Forms.Label labelUpTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelServerName;
    }
}
