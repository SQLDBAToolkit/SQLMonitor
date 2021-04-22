namespace SQLDBATool.Code
{
    partial class FormNewConnection
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxWinAuth = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxConnectionName = new System.Windows.Forms.TextBox();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPageConnectionProperties = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDownExecutionTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDownConnectionTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDownNetworkPacketSize = new System.Windows.Forms.NumericUpDown();
            this.comboBoxNetworkProtocol = new System.Windows.Forms.ComboBox();
            this.checkBoxTrustServerCertificate = new System.Windows.Forms.CheckBox();
            this.checkBoxEncryptConnection = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelConnectionFailed = new System.Windows.Forms.Label();
            this.labelConnectionSuccessful = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageConnectionProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExecutionTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConnectionTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNetworkPacketSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server Name:";
            // 
            // checkBoxWinAuth
            // 
            this.checkBoxWinAuth.AutoSize = true;
            this.checkBoxWinAuth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxWinAuth.Checked = true;
            this.checkBoxWinAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxWinAuth.Location = new System.Drawing.Point(48, 120);
            this.checkBoxWinAuth.Name = "checkBoxWinAuth";
            this.checkBoxWinAuth.Size = new System.Drawing.Size(215, 17);
            this.checkBoxWinAuth.TabIndex = 4;
            this.checkBoxWinAuth.Text = "Connect using Windows Authentication:";
            this.checkBoxWinAuth.UseVisualStyleBackColor = true;
            this.checkBoxWinAuth.CheckedChanged += new System.EventHandler(this.checkBoxWinAuth_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "User ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Specify the Database Server connection details";
            // 
            // textBoxConnectionName
            // 
            this.textBoxConnectionName.Location = new System.Drawing.Point(149, 75);
            this.textBoxConnectionName.Name = "textBoxConnectionName";
            this.textBoxConnectionName.Size = new System.Drawing.Size(258, 20);
            this.textBoxConnectionName.TabIndex = 0;
            this.textBoxConnectionName.TextChanged += new System.EventHandler(this.textBoxConnectionName_TextChanged);
            // 
            // textBoxServerName
            // 
            this.textBoxServerName.Location = new System.Drawing.Point(149, 96);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(258, 20);
            this.textBoxServerName.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(149, 159);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.ReadOnly = true;
            this.textBoxPassword.Size = new System.Drawing.Size(258, 20);
            this.textBoxPassword.TabIndex = 6;
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Enabled = false;
            this.textBoxUserID.Location = new System.Drawing.Point(149, 138);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.ReadOnly = true;
            this.textBoxUserID.Size = new System.Drawing.Size(258, 20);
            this.textBoxUserID.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(375, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(191, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Test Connection";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(462, 76);
            this.label6.TabIndex = 8;
            this.label6.Text = "SQL  Server\r\nDatabase Administrator Assistance Tool";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 76);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSalmon;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 5);
            this.panel2.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLogin);
            this.tabControl1.Controls.Add(this.tabPageConnectionProperties);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(442, 282);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPageLogin.Controls.Add(this.pictureBox1);
            this.tabPageLogin.Controls.Add(this.label7);
            this.tabPageLogin.Controls.Add(this.label4);
            this.tabPageLogin.Controls.Add(this.label1);
            this.tabPageLogin.Controls.Add(this.label2);
            this.tabPageLogin.Controls.Add(this.checkBoxWinAuth);
            this.tabPageLogin.Controls.Add(this.label3);
            this.tabPageLogin.Controls.Add(this.textBoxPassword);
            this.tabPageLogin.Controls.Add(this.label5);
            this.tabPageLogin.Controls.Add(this.textBoxUserID);
            this.tabPageLogin.Controls.Add(this.textBoxConnectionName);
            this.tabPageLogin.Controls.Add(this.textBoxServerName);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(434, 256);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Login";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SQLDBATool.Properties.Resources.ShadowHorizontalLine;
            this.pictureBox1.Location = new System.Drawing.Point(56, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(366, 2);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Server";
            // 
            // tabPageConnectionProperties
            // 
            this.tabPageConnectionProperties.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPageConnectionProperties.Controls.Add(this.label16);
            this.tabPageConnectionProperties.Controls.Add(this.numericUpDownExecutionTimeOut);
            this.tabPageConnectionProperties.Controls.Add(this.label15);
            this.tabPageConnectionProperties.Controls.Add(this.numericUpDownConnectionTimeOut);
            this.tabPageConnectionProperties.Controls.Add(this.label14);
            this.tabPageConnectionProperties.Controls.Add(this.numericUpDownNetworkPacketSize);
            this.tabPageConnectionProperties.Controls.Add(this.comboBoxNetworkProtocol);
            this.tabPageConnectionProperties.Controls.Add(this.checkBoxTrustServerCertificate);
            this.tabPageConnectionProperties.Controls.Add(this.checkBoxEncryptConnection);
            this.tabPageConnectionProperties.Controls.Add(this.label13);
            this.tabPageConnectionProperties.Controls.Add(this.label12);
            this.tabPageConnectionProperties.Controls.Add(this.pictureBox3);
            this.tabPageConnectionProperties.Controls.Add(this.label11);
            this.tabPageConnectionProperties.Controls.Add(this.label10);
            this.tabPageConnectionProperties.Controls.Add(this.label9);
            this.tabPageConnectionProperties.Controls.Add(this.pictureBox2);
            this.tabPageConnectionProperties.Controls.Add(this.label8);
            this.tabPageConnectionProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnectionProperties.Name = "tabPageConnectionProperties";
            this.tabPageConnectionProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnectionProperties.Size = new System.Drawing.Size(434, 256);
            this.tabPageConnectionProperties.TabIndex = 1;
            this.tabPageConnectionProperties.Text = "Connection Properties";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(219, 159);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "seconds";
            // 
            // numericUpDownExecutionTimeOut
            // 
            this.numericUpDownExecutionTimeOut.Location = new System.Drawing.Point(144, 157);
            this.numericUpDownExecutionTimeOut.Maximum = new decimal(new int[] {
            64000,
            0,
            0,
            0});
            this.numericUpDownExecutionTimeOut.Name = "numericUpDownExecutionTimeOut";
            this.numericUpDownExecutionTimeOut.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownExecutionTimeOut.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(219, 135);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "seconds";
            // 
            // numericUpDownConnectionTimeOut
            // 
            this.numericUpDownConnectionTimeOut.Location = new System.Drawing.Point(144, 133);
            this.numericUpDownConnectionTimeOut.Maximum = new decimal(new int[] {
            64000,
            0,
            0,
            0});
            this.numericUpDownConnectionTimeOut.Name = "numericUpDownConnectionTimeOut";
            this.numericUpDownConnectionTimeOut.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownConnectionTimeOut.TabIndex = 20;
            this.numericUpDownConnectionTimeOut.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(219, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "bytes";
            // 
            // numericUpDownNetworkPacketSize
            // 
            this.numericUpDownNetworkPacketSize.Location = new System.Drawing.Point(144, 79);
            this.numericUpDownNetworkPacketSize.Maximum = new decimal(new int[] {
            64000,
            0,
            0,
            0});
            this.numericUpDownNetworkPacketSize.Name = "numericUpDownNetworkPacketSize";
            this.numericUpDownNetworkPacketSize.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownNetworkPacketSize.TabIndex = 18;
            this.numericUpDownNetworkPacketSize.Value = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            // 
            // comboBoxNetworkProtocol
            // 
            this.comboBoxNetworkProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNetworkProtocol.FormattingEnabled = true;
            this.comboBoxNetworkProtocol.Items.AddRange(new object[] {
            "<default>",
            "Named Pipes (dbnmpntw)",
            "Shared Memory (dbmslpcn)",
            "TCP/IP (dbmssocn)",
            "Multiprotocol (dbmsrpcn)",
            "AppleTalk (dbmsadsn)",
            "VIA (dbmsgnet)",
            "IPX/SPX (dbmsspxn)"});
            this.comboBoxNetworkProtocol.Location = new System.Drawing.Point(144, 52);
            this.comboBoxNetworkProtocol.Name = "comboBoxNetworkProtocol";
            this.comboBoxNetworkProtocol.Size = new System.Drawing.Size(277, 21);
            this.comboBoxNetworkProtocol.TabIndex = 17;
            // 
            // checkBoxTrustServerCertificate
            // 
            this.checkBoxTrustServerCertificate.AutoSize = true;
            this.checkBoxTrustServerCertificate.Location = new System.Drawing.Point(39, 208);
            this.checkBoxTrustServerCertificate.Name = "checkBoxTrustServerCertificate";
            this.checkBoxTrustServerCertificate.Size = new System.Drawing.Size(131, 17);
            this.checkBoxTrustServerCertificate.TabIndex = 16;
            this.checkBoxTrustServerCertificate.Text = "Trust server certificate";
            this.checkBoxTrustServerCertificate.UseVisualStyleBackColor = true;
            // 
            // checkBoxEncryptConnection
            // 
            this.checkBoxEncryptConnection.AutoSize = true;
            this.checkBoxEncryptConnection.Location = new System.Drawing.Point(39, 185);
            this.checkBoxEncryptConnection.Name = "checkBoxEncryptConnection";
            this.checkBoxEncryptConnection.Size = new System.Drawing.Size(118, 17);
            this.checkBoxEncryptConnection.TabIndex = 15;
            this.checkBoxEncryptConnection.Text = "Encrpyt connection";
            this.checkBoxEncryptConnection.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Execution time-out:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Connection time-out:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SQLDBATool.Properties.Resources.ShadowHorizontalLine;
            this.pictureBox3.Location = new System.Drawing.Point(77, 115);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(344, 2);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Connection";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Network packet size:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Network protocol:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SQLDBATool.Properties.Resources.ShadowHorizontalLine;
            this.pictureBox2.Location = new System.Drawing.Point(66, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(356, 2);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Network";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(462, 302);
            this.panel3.TabIndex = 11;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(452, 10);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 282);
            this.panel7.TabIndex = 14;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 282);
            this.panel6.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 292);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(462, 10);
            this.panel5.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(462, 10);
            this.panel4.TabIndex = 11;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.labelConnectionFailed);
            this.panel8.Controls.Add(this.labelConnectionSuccessful);
            this.panel8.Controls.Add(this.button2);
            this.panel8.Controls.Add(this.button1);
            this.panel8.Controls.Add(this.button3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 378);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(462, 34);
            this.panel8.TabIndex = 8;
            // 
            // labelConnectionFailed
            // 
            this.labelConnectionFailed.AutoSize = true;
            this.labelConnectionFailed.ForeColor = System.Drawing.Color.Tomato;
            this.labelConnectionFailed.Location = new System.Drawing.Point(90, 12);
            this.labelConnectionFailed.Name = "labelConnectionFailed";
            this.labelConnectionFailed.Size = new System.Drawing.Size(92, 13);
            this.labelConnectionFailed.TabIndex = 9;
            this.labelConnectionFailed.Text = "Connection Failed";
            this.labelConnectionFailed.Visible = false;
            // 
            // labelConnectionSuccessful
            // 
            this.labelConnectionSuccessful.AutoSize = true;
            this.labelConnectionSuccessful.ForeColor = System.Drawing.Color.SeaGreen;
            this.labelConnectionSuccessful.Location = new System.Drawing.Point(69, 12);
            this.labelConnectionSuccessful.Name = "labelConnectionSuccessful";
            this.labelConnectionSuccessful.Size = new System.Drawing.Size(116, 13);
            this.labelConnectionSuccessful.TabIndex = 8;
            this.labelConnectionSuccessful.Text = "Connection Successful";
            this.labelConnectionSuccessful.Visible = false;
            // 
            // FormNewConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 412);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormNewConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Connection";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageConnectionProperties.ResumeLayout(false);
            this.tabPageConnectionProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExecutionTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConnectionTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNetworkPacketSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxWinAuth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxConnectionName;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPageConnectionProperties;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxTrustServerCertificate;
        private System.Windows.Forms.CheckBox checkBoxEncryptConnection;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxNetworkProtocol;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDownExecutionTimeOut;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDownConnectionTimeOut;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDownNetworkPacketSize;
        private System.Windows.Forms.Label labelConnectionSuccessful;
        private System.Windows.Forms.Label labelConnectionFailed;
    }
}