namespace DDCBot6000GUI
{
    partial class frmMain
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
            this.lblAccessToken = new System.Windows.Forms.Label();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.btnSubmitToken = new System.Windows.Forms.Button();
            this.btnQuickSim = new System.Windows.Forms.Button();
            this.lblValidToken = new System.Windows.Forms.Label();
            this.rctConsoleOutput = new System.Windows.Forms.RichTextBox();
            this.btnRandomSim = new System.Windows.Forms.Button();
            this.btnBeginSims = new System.Windows.Forms.Button();
            this.lblQck = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.chkTeams = new System.Windows.Forms.CheckedListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.llbaberuwu = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAccessToken
            // 
            this.lblAccessToken.AutoSize = true;
            this.lblAccessToken.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccessToken.ForeColor = System.Drawing.Color.White;
            this.lblAccessToken.Location = new System.Drawing.Point(161, 15);
            this.lblAccessToken.Name = "lblAccessToken";
            this.lblAccessToken.Size = new System.Drawing.Size(125, 21);
            this.lblAccessToken.TabIndex = 0;
            this.lblAccessToken.Text = "FB Access Token:";
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccessToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.txtAccessToken.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAccessToken.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccessToken.ForeColor = System.Drawing.Color.White;
            this.txtAccessToken.Location = new System.Drawing.Point(292, 13);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(748, 26);
            this.txtAccessToken.TabIndex = 1;
            // 
            // btnSubmitToken
            // 
            this.btnSubmitToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitToken.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitToken.Location = new System.Drawing.Point(1046, 11);
            this.btnSubmitToken.Name = "btnSubmitToken";
            this.btnSubmitToken.Size = new System.Drawing.Size(81, 29);
            this.btnSubmitToken.TabIndex = 2;
            this.btnSubmitToken.Text = "Submit";
            this.btnSubmitToken.UseVisualStyleBackColor = true;
            this.btnSubmitToken.Click += new System.EventHandler(this.btnSubmitToken_Click);
            // 
            // btnQuickSim
            // 
            this.btnQuickSim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickSim.Location = new System.Drawing.Point(12, 139);
            this.btnQuickSim.Name = "btnQuickSim";
            this.btnQuickSim.Size = new System.Drawing.Size(156, 37);
            this.btnQuickSim.TabIndex = 4;
            this.btnQuickSim.Text = "Quick Simulation";
            this.btnQuickSim.UseVisualStyleBackColor = true;
            this.btnQuickSim.Click += new System.EventHandler(this.btnQuickSim_Click);
            // 
            // lblValidToken
            // 
            this.lblValidToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValidToken.AutoSize = true;
            this.lblValidToken.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidToken.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblValidToken.Location = new System.Drawing.Point(487, 42);
            this.lblValidToken.Name = "lblValidToken";
            this.lblValidToken.Size = new System.Drawing.Size(190, 21);
            this.lblValidToken.TabIndex = 5;
            this.lblValidToken.Text = "The token entered is valid!";
            this.lblValidToken.Visible = false;
            // 
            // rctConsoleOutput
            // 
            this.rctConsoleOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rctConsoleOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.rctConsoleOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rctConsoleOutput.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rctConsoleOutput.ForeColor = System.Drawing.Color.White;
            this.rctConsoleOutput.Location = new System.Drawing.Point(524, 215);
            this.rctConsoleOutput.Name = "rctConsoleOutput";
            this.rctConsoleOutput.ReadOnly = true;
            this.rctConsoleOutput.Size = new System.Drawing.Size(603, 462);
            this.rctConsoleOutput.TabIndex = 6;
            this.rctConsoleOutput.Text = "";
            this.rctConsoleOutput.TextChanged += new System.EventHandler(this.rctConsoleOutput_TextChanged);
            // 
            // btnRandomSim
            // 
            this.btnRandomSim.Enabled = false;
            this.btnRandomSim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomSim.Location = new System.Drawing.Point(12, 199);
            this.btnRandomSim.Name = "btnRandomSim";
            this.btnRandomSim.Size = new System.Drawing.Size(156, 37);
            this.btnRandomSim.TabIndex = 7;
            this.btnRandomSim.Text = "Random Simulation";
            this.btnRandomSim.UseVisualStyleBackColor = true;
            this.btnRandomSim.Click += new System.EventHandler(this.btnRandomSim_Click);
            // 
            // btnBeginSims
            // 
            this.btnBeginSims.Enabled = false;
            this.btnBeginSims.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeginSims.Location = new System.Drawing.Point(352, 503);
            this.btnBeginSims.Name = "btnBeginSims";
            this.btnBeginSims.Size = new System.Drawing.Size(144, 39);
            this.btnBeginSims.TabIndex = 8;
            this.btnBeginSims.Text = "Begin Simulations";
            this.btnBeginSims.UseVisualStyleBackColor = true;
            // 
            // lblQck
            // 
            this.lblQck.AutoSize = true;
            this.lblQck.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQck.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblQck.Location = new System.Drawing.Point(174, 134);
            this.lblQck.Name = "lblQck";
            this.lblQck.Size = new System.Drawing.Size(222, 42);
            this.lblQck.TabIndex = 9;
            this.lblQck.Text = "This will run 10 test simulations\r\n[Will not post to Facebook]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(174, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 42);
            this.label1.TabIndex = 10;
            this.label1.Text = "Will simulate 1 random match\r\n[Will post to Facebook]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(12, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Simulation Parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(12, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Number of Sims";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(12, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "Time Interval";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(14, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 21);
            this.label5.TabIndex = 14;
            this.label5.Text = "Number of Teams";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(12, 483);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "Select Teams";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(520, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "Facebook ID:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(520, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 21);
            this.label8.TabIndex = 17;
            this.label8.Text = "Page Name:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(152, 324);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown1.TabIndex = 18;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.Location = new System.Drawing.Point(152, 370);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown2.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(278, 372);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 21);
            this.label9.TabIndex = 20;
            this.label9.Text = "minutes";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown3.Location = new System.Drawing.Point(152, 418);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown3.TabIndex = 21;
            // 
            // chkTeams
            // 
            this.chkTeams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTeams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.chkTeams.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkTeams.ForeColor = System.Drawing.Color.White;
            this.chkTeams.FormattingEnabled = true;
            this.chkTeams.Items.AddRange(new object[] {
            "Monarcas",
            "Club America",
            "C.D. Guadalajara",
            "Cruz Azul",
            "Tigres UANL",
            "C.F. Monterrey",
            "Club Universidad Nacional (PUMAS)",
            "Santos Laguna",
            "Atlas F.C.",
            "Deportivo Toluca F.C.",
            "Club Necaxa",
            "C.F. Pachuca",
            "Club Puebla",
            "Queretaro F.C.",
            "C.D. Veracruz",
            "FC Juarez",
            "Atletico San Luis"});
            this.chkTeams.Location = new System.Drawing.Point(18, 557);
            this.chkTeams.Name = "chkTeams";
            this.chkTeams.Size = new System.Drawing.Size(478, 120);
            this.chkTeams.TabIndex = 22;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Liga MX",
            "MLS",
            "La Liga (Spain)",
            "Bundesliga",
            "EPL"});
            this.comboBox1.Location = new System.Drawing.Point(75, 523);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(14, 524);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 21);
            this.label10.TabIndex = 24;
            this.label10.Text = "League";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(789, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 21);
            this.label11.TabIndex = 25;
            this.label11.Text = "Sims Run:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(789, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 21);
            this.label12.TabIndex = 26;
            this.label12.Text = "Sims Left:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.label13.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(428, 680);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 21);
            this.label13.TabIndex = 28;
            this.label13.Text = "Programmed by";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(1029, 167);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(98, 39);
            this.btnStop.TabIndex = 29;
            this.btnStop.Text = "Stop Sims";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DDCBot6000GUI.Properties.Resources.DDCBot600_logo;
            this.pictureBox1.Location = new System.Drawing.Point(16, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // llbaberuwu
            // 
            this.llbaberuwu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.llbaberuwu.AutoSize = true;
            this.llbaberuwu.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbaberuwu.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.llbaberuwu.Location = new System.Drawing.Point(544, 680);
            this.llbaberuwu.Name = "llbaberuwu";
            this.llbaberuwu.Size = new System.Drawing.Size(84, 21);
            this.llbaberuwu.TabIndex = 31;
            this.llbaberuwu.TabStop = true;
            this.llbaberuwu.Text = "@aberuwu";
            this.llbaberuwu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbaberuwu_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1139, 704);
            this.Controls.Add(this.llbaberuwu);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chkTeams);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblQck);
            this.Controls.Add(this.btnBeginSims);
            this.Controls.Add(this.btnRandomSim);
            this.Controls.Add(this.rctConsoleOutput);
            this.Controls.Add(this.lblValidToken);
            this.Controls.Add(this.btnQuickSim);
            this.Controls.Add(this.btnSubmitToken);
            this.Controls.Add(this.txtAccessToken);
            this.Controls.Add(this.lblAccessToken);
            this.MinimumSize = new System.Drawing.Size(816, 559);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DDCBot6000 v1.0 - Control Panel";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccessToken;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.Button btnSubmitToken;
        private System.Windows.Forms.Button btnQuickSim;
        private System.Windows.Forms.Label lblValidToken;
        private System.Windows.Forms.RichTextBox rctConsoleOutput;
        private System.Windows.Forms.Button btnRandomSim;
        private System.Windows.Forms.Button btnBeginSims;
        private System.Windows.Forms.Label lblQck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.CheckedListBox chkTeams;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llbaberuwu;
    }
}

