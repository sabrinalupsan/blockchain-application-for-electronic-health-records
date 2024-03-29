﻿namespace BlockchainApp
{
    partial class AdminInterface
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbDoctorID = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSpecialisation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelDoctor = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRePassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbPatientID = new System.Windows.Forms.TextBox();
            this.tbPatientLastName = new System.Windows.Forms.TextBox();
            this.tbPatientFirstName = new System.Windows.Forms.TextBox();
            this.tbPatientPassword = new System.Windows.Forms.TextBox();
            this.tbPatientREPass = new System.Windows.Forms.TextBox();
            this.btnOkPatient = new System.Windows.Forms.Button();
            this.btnCancelPatient = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbPatientEmailAddress = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbDoctorEmailAddress = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.progressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.labelNoRecords = new System.Windows.Forms.Label();
            this.labelNoDoctors = new System.Windows.Forms.Label();
            this.labelNoPatients = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnOverwrite = new System.Windows.Forms.Button();
            this.tbLastBackup = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "New ID";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(133)))), ((int)(((byte)(203)))));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(40, 402);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 28);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbDoctorID
            // 
            this.tbDoctorID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbDoctorID.Location = new System.Drawing.Point(183, 68);
            this.tbDoctorID.Name = "tbDoctorID";
            this.tbDoctorID.Size = new System.Drawing.Size(155, 22);
            this.tbDoctorID.TabIndex = 0;
            this.tbDoctorID.Click += new System.EventHandler(this.controlClicked);
            // 
            // tbLastName
            // 
            this.tbLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbLastName.Location = new System.Drawing.Point(183, 118);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(155, 22);
            this.tbLastName.TabIndex = 1;
            this.tbLastName.Click += new System.EventHandler(this.controlClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last name";
            // 
            // tbFirstName
            // 
            this.tbFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbFirstName.Location = new System.Drawing.Point(183, 168);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(155, 22);
            this.tbFirstName.TabIndex = 2;
            this.tbFirstName.Click += new System.EventHandler(this.controlClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "First name";
            // 
            // tbSpecialisation
            // 
            this.tbSpecialisation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbSpecialisation.Location = new System.Drawing.Point(183, 218);
            this.tbSpecialisation.Name = "tbSpecialisation";
            this.tbSpecialisation.Size = new System.Drawing.Size(155, 22);
            this.tbSpecialisation.TabIndex = 3;
            this.tbSpecialisation.Click += new System.EventHandler(this.controlClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Specialization";
            // 
            // btnCancelDoctor
            // 
            this.btnCancelDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(133)))), ((int)(((byte)(203)))));
            this.btnCancelDoctor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelDoctor.ForeColor = System.Drawing.Color.White;
            this.btnCancelDoctor.Location = new System.Drawing.Point(171, 402);
            this.btnCancelDoctor.Name = "btnCancelDoctor";
            this.btnCancelDoctor.Size = new System.Drawing.Size(104, 28);
            this.btnCancelDoctor.TabIndex = 8;
            this.btnCancelDoctor.Text = "Cancel";
            this.btnCancelDoctor.UseVisualStyleBackColor = false;
            this.btnCancelDoctor.Click += new System.EventHandler(this.btnCancelDoctor_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPassword.Location = new System.Drawing.Point(183, 311);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(155, 22);
            this.tbPassword.TabIndex = 5;
            this.tbPassword.Click += new System.EventHandler(this.controlClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Password";
            // 
            // tbRePassword
            // 
            this.tbRePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbRePassword.Location = new System.Drawing.Point(183, 361);
            this.tbRePassword.Name = "tbRePassword";
            this.tbRePassword.PasswordChar = '*';
            this.tbRePassword.Size = new System.Drawing.Size(155, 22);
            this.tbRePassword.TabIndex = 6;
            this.tbRePassword.Click += new System.EventHandler(this.controlClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Reinput password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "New doctor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "New patient";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "New ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Last name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "First name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Password";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 312);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = "Reinput password";
            // 
            // tbPatientID
            // 
            this.tbPatientID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPatientID.Location = new System.Drawing.Point(183, 68);
            this.tbPatientID.Name = "tbPatientID";
            this.tbPatientID.Size = new System.Drawing.Size(155, 22);
            this.tbPatientID.TabIndex = 0;
            this.tbPatientID.Click += new System.EventHandler(this.controlClicked);
            // 
            // tbPatientLastName
            // 
            this.tbPatientLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPatientLastName.Location = new System.Drawing.Point(183, 118);
            this.tbPatientLastName.Name = "tbPatientLastName";
            this.tbPatientLastName.Size = new System.Drawing.Size(155, 22);
            this.tbPatientLastName.TabIndex = 1;
            this.tbPatientLastName.Click += new System.EventHandler(this.controlClicked);
            // 
            // tbPatientFirstName
            // 
            this.tbPatientFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPatientFirstName.Location = new System.Drawing.Point(183, 168);
            this.tbPatientFirstName.Name = "tbPatientFirstName";
            this.tbPatientFirstName.Size = new System.Drawing.Size(155, 22);
            this.tbPatientFirstName.TabIndex = 2;
            this.tbPatientFirstName.Click += new System.EventHandler(this.controlClicked);
            // 
            // tbPatientPassword
            // 
            this.tbPatientPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPatientPassword.Location = new System.Drawing.Point(183, 265);
            this.tbPatientPassword.Name = "tbPatientPassword";
            this.tbPatientPassword.PasswordChar = '*';
            this.tbPatientPassword.Size = new System.Drawing.Size(155, 22);
            this.tbPatientPassword.TabIndex = 4;
            this.tbPatientPassword.Click += new System.EventHandler(this.controlClicked);
            // 
            // tbPatientREPass
            // 
            this.tbPatientREPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPatientREPass.Location = new System.Drawing.Point(183, 311);
            this.tbPatientREPass.Name = "tbPatientREPass";
            this.tbPatientREPass.PasswordChar = '*';
            this.tbPatientREPass.Size = new System.Drawing.Size(155, 22);
            this.tbPatientREPass.TabIndex = 5;
            this.tbPatientREPass.Click += new System.EventHandler(this.controlClicked);
            // 
            // btnOkPatient
            // 
            this.btnOkPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(133)))), ((int)(((byte)(203)))));
            this.btnOkPatient.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOkPatient.ForeColor = System.Drawing.Color.White;
            this.btnOkPatient.Location = new System.Drawing.Point(40, 402);
            this.btnOkPatient.Name = "btnOkPatient";
            this.btnOkPatient.Size = new System.Drawing.Size(104, 28);
            this.btnOkPatient.TabIndex = 7;
            this.btnOkPatient.Text = "OK";
            this.btnOkPatient.UseVisualStyleBackColor = false;
            this.btnOkPatient.Click += new System.EventHandler(this.btnOkPacient_Click);
            // 
            // btnCancelPatient
            // 
            this.btnCancelPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(133)))), ((int)(((byte)(203)))));
            this.btnCancelPatient.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelPatient.ForeColor = System.Drawing.Color.White;
            this.btnCancelPatient.Location = new System.Drawing.Point(171, 402);
            this.btnCancelPatient.Name = "btnCancelPatient";
            this.btnCancelPatient.Size = new System.Drawing.Size(104, 28);
            this.btnCancelPatient.TabIndex = 8;
            this.btnCancelPatient.Text = "Cancel";
            this.btnCancelPatient.UseVisualStyleBackColor = false;
            this.btnCancelPatient.Click += new System.EventHandler(this.btnCancelPatient_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tbPatientEmailAddress);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.dtpBirthday);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnCancelPatient);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnOkPatient);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbPatientREPass);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.tbPatientPassword);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tbPatientFirstName);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.tbPatientLastName);
            this.panel1.Controls.Add(this.tbPatientID);
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 445);
            this.panel1.TabIndex = 29;
            // 
            // tbPatientEmailAddress
            // 
            this.tbPatientEmailAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPatientEmailAddress.Location = new System.Drawing.Point(183, 218);
            this.tbPatientEmailAddress.Name = "tbPatientEmailAddress";
            this.tbPatientEmailAddress.Size = new System.Drawing.Size(155, 22);
            this.tbPatientEmailAddress.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 218);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 17);
            this.label18.TabIndex = 32;
            this.label18.Text = "Email address";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 362);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 17);
            this.label14.TabIndex = 30;
            this.label14.Text = "Birthday";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.dtpBirthday.Location = new System.Drawing.Point(183, 361);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(155, 22);
            this.dtpBirthday.TabIndex = 6;
            this.dtpBirthday.DropDown += new System.EventHandler(this.controlClicked);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tbDoctorEmailAddress);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.btnCancelDoctor);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.tbRePassword);
            this.panel2.Controls.Add(this.tbDoctorID);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbPassword);
            this.panel2.Controls.Add(this.tbLastName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbFirstName);
            this.panel2.Controls.Add(this.tbSpecialisation);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(20, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 449);
            this.panel2.TabIndex = 30;
            // 
            // tbDoctorEmailAddress
            // 
            this.tbDoctorEmailAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbDoctorEmailAddress.Location = new System.Drawing.Point(183, 265);
            this.tbDoctorEmailAddress.Name = "tbDoctorEmailAddress";
            this.tbDoctorEmailAddress.Size = new System.Drawing.Size(155, 22);
            this.tbDoctorEmailAddress.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 265);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 17);
            this.label17.TabIndex = 17;
            this.label17.Text = "Email address";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.progressLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 620);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(408, 24);
            this.statusStrip1.TabIndex = 33;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 18);
            // 
            // progressLabel
            // 
            this.progressLabel.BackColor = System.Drawing.Color.White;
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(0, 19);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 88);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 513);
            this.tabControl1.TabIndex = 34;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(376, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add doctor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(376, 484);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add patient";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.labelNoRecords);
            this.tabPage3.Controls.Add(this.labelNoDoctors);
            this.tabPage3.Controls.Add(this.labelNoPatients);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.btnOverwrite);
            this.tabPage3.Controls.Add(this.tbLastBackup);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.btnBackup);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(376, 484);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Backup";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // labelNoRecords
            // 
            this.labelNoRecords.AutoSize = true;
            this.labelNoRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.labelNoRecords.Location = new System.Drawing.Point(33, 309);
            this.labelNoRecords.Name = "labelNoRecords";
            this.labelNoRecords.Size = new System.Drawing.Size(12, 18);
            this.labelNoRecords.TabIndex = 7;
            this.labelNoRecords.Text = ".";
            // 
            // labelNoDoctors
            // 
            this.labelNoDoctors.AutoSize = true;
            this.labelNoDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.labelNoDoctors.Location = new System.Drawing.Point(33, 292);
            this.labelNoDoctors.Name = "labelNoDoctors";
            this.labelNoDoctors.Size = new System.Drawing.Size(12, 18);
            this.labelNoDoctors.TabIndex = 6;
            this.labelNoDoctors.Text = ".";
            // 
            // labelNoPatients
            // 
            this.labelNoPatients.AutoSize = true;
            this.labelNoPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.labelNoPatients.Location = new System.Drawing.Point(33, 275);
            this.labelNoPatients.Name = "labelNoPatients";
            this.labelNoPatients.Size = new System.Drawing.Size(12, 18);
            this.labelNoPatients.TabIndex = 5;
            this.labelNoPatients.Text = ".";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label16.Location = new System.Drawing.Point(33, 249);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 18);
            this.label16.TabIndex = 4;
            this.label16.Text = "Statistics";
            // 
            // btnOverwrite
            // 
            this.btnOverwrite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(133)))), ((int)(((byte)(203)))));
            this.btnOverwrite.ForeColor = System.Drawing.Color.White;
            this.btnOverwrite.Location = new System.Drawing.Point(25, 178);
            this.btnOverwrite.Name = "btnOverwrite";
            this.btnOverwrite.Size = new System.Drawing.Size(104, 28);
            this.btnOverwrite.TabIndex = 3;
            this.btnOverwrite.Text = "Overwrite";
            this.btnOverwrite.UseVisualStyleBackColor = false;
            this.btnOverwrite.Click += new System.EventHandler(this.btnOverwrite_Click);
            // 
            // tbLastBackup
            // 
            this.tbLastBackup.Enabled = false;
            this.tbLastBackup.Location = new System.Drawing.Point(127, 60);
            this.tbLastBackup.Name = "tbLastBackup";
            this.tbLastBackup.Size = new System.Drawing.Size(143, 22);
            this.tbLastBackup.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label15.Location = new System.Drawing.Point(22, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 18);
            this.label15.TabIndex = 1;
            this.label15.Text = "Last backup:";
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(133)))), ((int)(((byte)(203)))));
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(25, 133);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(104, 28);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // AdminInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(408, 644);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "AdminInterface";
            this.Text = "Admin Page";
            this.Load += new System.EventHandler(this.AdminInterface_Load);
            this.Click += new System.EventHandler(this.AdminInterface_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbDoctorID;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSpecialisation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelDoctor;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRePassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbPatientID;
        private System.Windows.Forms.TextBox tbPatientLastName;
        private System.Windows.Forms.TextBox tbPatientFirstName;
        private System.Windows.Forms.TextBox tbPatientPassword;
        private System.Windows.Forms.TextBox tbPatientREPass;
        private System.Windows.Forms.Button btnOkPatient;
        private System.Windows.Forms.Button btnCancelPatient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel progressLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbLastBackup;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnOverwrite;
        private System.Windows.Forms.Label labelNoRecords;
        private System.Windows.Forms.Label labelNoDoctors;
        private System.Windows.Forms.Label labelNoPatients;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbPatientEmailAddress;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbDoctorEmailAddress;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}