namespace HMS_project
{
    partial class DoctorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.Minimize = new System.Windows.Forms.PictureBox();
            this.Maximize = new System.Windows.Forms.PictureBox();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.dataGridViewAppointments = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNewDrug = new System.Windows.Forms.TextBox();
            this.txtComments = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.comboPeriod = new System.Windows.Forms.ComboBox();
            this.comboFrequency = new System.Windows.Forms.ComboBox();
            this.comboDosage = new System.Windows.Forms.ComboBox();
            this.drugList = new System.Windows.Forms.ListBox();
            this.selectDrugs = new System.Windows.Forms.ComboBox();
            this.txtSymptoms = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboGender = new System.Windows.Forms.ComboBox();
            this.comboBlood = new System.Windows.Forms.ComboBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.txtAppNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnRefreshGrid = new System.Windows.Forms.Button();
            this.btnSendToPharma = new System.Windows.Forms.Button();
            this.btnMoreDetails = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointments)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.Minimize);
            this.panel1.Controls.Add(this.Maximize);
            this.panel1.Controls.Add(this.Exit);
            this.panel1.Location = new System.Drawing.Point(-13, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 37);
            this.panel1.TabIndex = 4;
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(27, 2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(38, 33);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHome.TabIndex = 10;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // Minimize
            // 
            this.Minimize.Image = ((System.Drawing.Image)(resources.GetObject("Minimize.Image")));
            this.Minimize.Location = new System.Drawing.Point(884, 2);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(38, 33);
            this.Minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Minimize.TabIndex = 6;
            this.Minimize.TabStop = false;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // Maximize
            // 
            this.Maximize.Image = ((System.Drawing.Image)(resources.GetObject("Maximize.Image")));
            this.Maximize.Location = new System.Drawing.Point(928, 2);
            this.Maximize.Name = "Maximize";
            this.Maximize.Size = new System.Drawing.Size(38, 33);
            this.Maximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Maximize.TabIndex = 5;
            this.Maximize.TabStop = false;
            this.Maximize.Click += new System.EventHandler(this.Maximize_Click);
            // 
            // Exit
            // 
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Location = new System.Drawing.Point(972, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(38, 33);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Exit.TabIndex = 4;
            this.Exit.TabStop = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // dataGridViewAppointments
            // 
            this.dataGridViewAppointments.AllowUserToAddRows = false;
            this.dataGridViewAppointments.AllowUserToDeleteRows = false;
            this.dataGridViewAppointments.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppointments.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewAppointments.Location = new System.Drawing.Point(663, 83);
            this.dataGridViewAppointments.Name = "dataGridViewAppointments";
            this.dataGridViewAppointments.ReadOnly = true;
            this.dataGridViewAppointments.Size = new System.Drawing.Size(325, 203);
            this.dataGridViewAppointments.TabIndex = 5;
            this.dataGridViewAppointments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAppointments_CellClick_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtNewDrug);
            this.groupBox1.Controls.Add(this.txtComments);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btn_Add);
            this.groupBox1.Controls.Add(this.comboPeriod);
            this.groupBox1.Controls.Add(this.comboFrequency);
            this.groupBox1.Controls.Add(this.comboDosage);
            this.groupBox1.Controls.Add(this.drugList);
            this.groupBox1.Controls.Add(this.selectDrugs);
            this.groupBox1.Controls.Add(this.txtSymptoms);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboGender);
            this.groupBox1.Controls.Add(this.comboBlood);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtPatientID);
            this.groupBox1.Controls.Add(this.txtAppNo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 585);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(522, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNewDrug
            // 
            this.txtNewDrug.Location = new System.Drawing.Point(429, 301);
            this.txtNewDrug.Name = "txtNewDrug";
            this.txtNewDrug.Size = new System.Drawing.Size(193, 22);
            this.txtNewDrug.TabIndex = 27;
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(98, 516);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(524, 54);
            this.txtComments.TabIndex = 26;
            this.txtComments.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 519);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 16);
            this.label12.TabIndex = 25;
            this.label12.Text = "Comments";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(518, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "Period";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(408, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Frequency";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Dosage";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(96, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Drug";
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(522, 272);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(100, 23);
            this.btn_Add.TabIndex = 19;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // comboPeriod
            // 
            this.comboPeriod.FormattingEnabled = true;
            this.comboPeriod.Items.AddRange(new object[] {
            "For 1 day",
            "For 2 days",
            "For 3 days",
            "For 4 days",
            "For 5 days",
            "For 1 week",
            "For 2 week",
            "For 3 week",
            "For 1 month"});
            this.comboPeriod.Location = new System.Drawing.Point(521, 242);
            this.comboPeriod.Name = "comboPeriod";
            this.comboPeriod.Size = new System.Drawing.Size(101, 24);
            this.comboPeriod.TabIndex = 18;
            // 
            // comboFrequency
            // 
            this.comboFrequency.FormattingEnabled = true;
            this.comboFrequency.Items.AddRange(new object[] {
            "Once a day",
            "Twice a day",
            "Three times a day",
            "Four times a day",
            "Every 6 hours",
            "Every 8 hours",
            "Every 12 hours",
            "As needed"});
            this.comboFrequency.Location = new System.Drawing.Point(411, 242);
            this.comboFrequency.Name = "comboFrequency";
            this.comboFrequency.Size = new System.Drawing.Size(104, 24);
            this.comboFrequency.TabIndex = 17;
            // 
            // comboDosage
            // 
            this.comboDosage.FormattingEnabled = true;
            this.comboDosage.Items.AddRange(new object[] {
            "1",
            "1/2",
            "1/3",
            "1/4",
            "2",
            "2/3"});
            this.comboDosage.Location = new System.Drawing.Point(331, 242);
            this.comboDosage.Name = "comboDosage";
            this.comboDosage.Size = new System.Drawing.Size(65, 24);
            this.comboDosage.TabIndex = 16;
            // 
            // drugList
            // 
            this.drugList.FormattingEnabled = true;
            this.drugList.ItemHeight = 16;
            this.drugList.Location = new System.Drawing.Point(99, 282);
            this.drugList.Name = "drugList";
            this.drugList.Size = new System.Drawing.Size(317, 212);
            this.drugList.TabIndex = 15;
            // 
            // selectDrugs
            // 
            this.selectDrugs.FormattingEnabled = true;
            this.selectDrugs.Location = new System.Drawing.Point(99, 242);
            this.selectDrugs.Name = "selectDrugs";
            this.selectDrugs.Size = new System.Drawing.Size(217, 24);
            this.selectDrugs.TabIndex = 14;
            // 
            // txtSymptoms
            // 
            this.txtSymptoms.Location = new System.Drawing.Point(99, 155);
            this.txtSymptoms.Name = "txtSymptoms";
            this.txtSymptoms.Size = new System.Drawing.Size(523, 54);
            this.txtSymptoms.TabIndex = 13;
            this.txtSymptoms.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Symptoms:";
            // 
            // comboGender
            // 
            this.comboGender.BackColor = System.Drawing.SystemColors.Window;
            this.comboGender.Enabled = false;
            this.comboGender.ForeColor = System.Drawing.Color.Red;
            this.comboGender.FormattingEnabled = true;
            this.comboGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.comboGender.Location = new System.Drawing.Point(79, 110);
            this.comboGender.Name = "comboGender";
            this.comboGender.Size = new System.Drawing.Size(195, 24);
            this.comboGender.TabIndex = 11;
            // 
            // comboBlood
            // 
            this.comboBlood.Enabled = false;
            this.comboBlood.ForeColor = System.Drawing.Color.Red;
            this.comboBlood.FormattingEnabled = true;
            this.comboBlood.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "O+",
            "O-",
            "AB+",
            "AB-"});
            this.comboBlood.Location = new System.Drawing.Point(422, 110);
            this.comboBlood.Name = "comboBlood";
            this.comboBlood.Size = new System.Drawing.Size(93, 24);
            this.comboBlood.TabIndex = 10;
            // 
            // txtAge
            // 
            this.txtAge.ForeColor = System.Drawing.Color.Red;
            this.txtAge.Location = new System.Drawing.Point(562, 15);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(60, 22);
            this.txtAge.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.ForeColor = System.Drawing.Color.Red;
            this.txtName.Location = new System.Drawing.Point(113, 62);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(509, 22);
            this.txtName.TabIndex = 8;
            // 
            // txtPatientID
            // 
            this.txtPatientID.ForeColor = System.Drawing.Color.Red;
            this.txtPatientID.Location = new System.Drawing.Point(79, 12);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.ReadOnly = true;
            this.txtPatientID.Size = new System.Drawing.Size(134, 22);
            this.txtPatientID.TabIndex = 7;
            // 
            // txtAppNo
            // 
            this.txtAppNo.ForeColor = System.Drawing.Color.Red;
            this.txtAppNo.Location = new System.Drawing.Point(438, 15);
            this.txtAppNo.Name = "txtAppNo";
            this.txtAppNo.ReadOnly = true;
            this.txtAppNo.Size = new System.Drawing.Size(67, 22);
            this.txtAppNo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(310, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Blood Group:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gender:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(521, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Age:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Patient\'s Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Appointment No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient ID:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(881, 38);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(121, 39);
            this.btnSubmit.TabIndex = 23;
            this.btnSubmit.Text = "Logout";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnRefreshGrid
            // 
            this.btnRefreshGrid.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRefreshGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshGrid.ForeColor = System.Drawing.Color.White;
            this.btnRefreshGrid.Location = new System.Drawing.Point(663, 294);
            this.btnRefreshGrid.Name = "btnRefreshGrid";
            this.btnRefreshGrid.Size = new System.Drawing.Size(98, 31);
            this.btnRefreshGrid.TabIndex = 24;
            this.btnRefreshGrid.Text = "Refresh";
            this.btnRefreshGrid.UseVisualStyleBackColor = false;
            this.btnRefreshGrid.Click += new System.EventHandler(this.btnRefreshGrid_Click);
            // 
            // btnSendToPharma
            // 
            this.btnSendToPharma.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSendToPharma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendToPharma.ForeColor = System.Drawing.Color.White;
            this.btnSendToPharma.Location = new System.Drawing.Point(663, 577);
            this.btnSendToPharma.Name = "btnSendToPharma";
            this.btnSendToPharma.Size = new System.Drawing.Size(334, 45);
            this.btnSendToPharma.TabIndex = 25;
            this.btnSendToPharma.Text = "Send Prescription to Pharmacy";
            this.btnSendToPharma.UseVisualStyleBackColor = false;
            this.btnSendToPharma.Click += new System.EventHandler(this.btnSendToPharma_Click);
            // 
            // btnMoreDetails
            // 
            this.btnMoreDetails.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMoreDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoreDetails.ForeColor = System.Drawing.Color.White;
            this.btnMoreDetails.Location = new System.Drawing.Point(663, 501);
            this.btnMoreDetails.Name = "btnMoreDetails";
            this.btnMoreDetails.Size = new System.Drawing.Size(334, 45);
            this.btnMoreDetails.TabIndex = 26;
            this.btnMoreDetails.Text = "View more details of the patient";
            this.btnMoreDetails.UseVisualStyleBackColor = false;
            this.btnMoreDetails.Click += new System.EventHandler(this.btnMoreDetails_Click);
            // 
            // DoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 649);
            this.Controls.Add(this.btnMoreDetails);
            this.Controls.Add(this.btnSendToPharma);
            this.Controls.Add(this.btnRefreshGrid);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewAppointments);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DoctorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoctorForm";
            this.Load += new System.EventHandler(this.DoctorForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointments)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Minimize;
        private System.Windows.Forms.PictureBox Maximize;
        private System.Windows.Forms.PictureBox Exit;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.DataGridView dataGridViewAppointments;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.TextBox txtAppNo;
        private System.Windows.Forms.ComboBox comboGender;
        private System.Windows.Forms.ComboBox comboBlood;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnRefreshGrid;
        private System.Windows.Forms.RichTextBox txtSymptoms;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox selectDrugs;
        private System.Windows.Forms.ListBox drugList;
        private System.Windows.Forms.ComboBox comboPeriod;
        private System.Windows.Forms.ComboBox comboFrequency;
        private System.Windows.Forms.ComboBox comboDosage;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox txtComments;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSendToPharma;
        private System.Windows.Forms.Button btnMoreDetails;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNewDrug;
    }
}