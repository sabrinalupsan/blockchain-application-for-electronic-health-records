namespace BlockchainApp
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
            this.tbNewDocID = new System.Windows.Forms.TextBox();
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
            this.label14 = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.docPB = new System.Windows.Forms.ProgressBar();
            this.patientPB = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "New doctor ID";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(43, 394);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 27);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbNewDocID
            // 
            this.tbNewDocID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbNewDocID.Location = new System.Drawing.Point(178, 88);
            this.tbNewDocID.Name = "tbNewDocID";
            this.tbNewDocID.Size = new System.Drawing.Size(100, 22);
            this.tbNewDocID.TabIndex = 0;
            this.tbNewDocID.Click += new System.EventHandler(this.controlClicked);
            // 
            // tbLastName
            // 
            this.tbLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbLastName.Location = new System.Drawing.Point(178, 139);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(100, 22);
            this.tbLastName.TabIndex = 1;
            this.tbLastName.Click += new System.EventHandler(this.controlClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Doctor last name";
            // 
            // tbFirstName
            // 
            this.tbFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbFirstName.Location = new System.Drawing.Point(178, 186);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(100, 22);
            this.tbFirstName.TabIndex = 2;
            this.tbFirstName.Click += new System.EventHandler(this.controlClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Doctor first name";
            // 
            // tbSpecialisation
            // 
            this.tbSpecialisation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbSpecialisation.Location = new System.Drawing.Point(178, 232);
            this.tbSpecialisation.Name = "tbSpecialisation";
            this.tbSpecialisation.Size = new System.Drawing.Size(100, 22);
            this.tbSpecialisation.TabIndex = 3;
            this.tbSpecialisation.Click += new System.EventHandler(this.controlClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Doctor specialization";
            // 
            // btnCancelDoctor
            // 
            this.btnCancelDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnCancelDoctor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelDoctor.ForeColor = System.Drawing.Color.White;
            this.btnCancelDoctor.Location = new System.Drawing.Point(169, 394);
            this.btnCancelDoctor.Name = "btnCancelDoctor";
            this.btnCancelDoctor.Size = new System.Drawing.Size(82, 27);
            this.btnCancelDoctor.TabIndex = 7;
            this.btnCancelDoctor.Text = "Cancel";
            this.btnCancelDoctor.UseVisualStyleBackColor = false;
            this.btnCancelDoctor.Click += new System.EventHandler(this.btnCancelDoctor_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPassword.Location = new System.Drawing.Point(178, 284);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 22);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.Click += new System.EventHandler(this.controlClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Password";
            // 
            // tbRePassword
            // 
            this.tbRePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbRePassword.Location = new System.Drawing.Point(178, 337);
            this.tbRePassword.Name = "tbRePassword";
            this.tbRePassword.PasswordChar = '*';
            this.tbRePassword.Size = new System.Drawing.Size(100, 22);
            this.tbRePassword.TabIndex = 5;
            this.tbRePassword.Click += new System.EventHandler(this.controlClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Reinput password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "New doctor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "New patient";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "New Patient ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Last name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "First name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Password";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 287);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = "Reinput password";
            // 
            // tbPatientID
            // 
            this.tbPatientID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPatientID.Location = new System.Drawing.Point(187, 88);
            this.tbPatientID.Name = "tbPatientID";
            this.tbPatientID.Size = new System.Drawing.Size(100, 22);
            this.tbPatientID.TabIndex = 0;
            this.tbPatientID.Click += new System.EventHandler(this.controlClicked);
            // 
            // tbPatientLastName
            // 
            this.tbPatientLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPatientLastName.Location = new System.Drawing.Point(187, 136);
            this.tbPatientLastName.Name = "tbPatientLastName";
            this.tbPatientLastName.Size = new System.Drawing.Size(100, 22);
            this.tbPatientLastName.TabIndex = 1;
            this.tbPatientLastName.Click += new System.EventHandler(this.controlClicked);
            // 
            // tbPatientFirstName
            // 
            this.tbPatientFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPatientFirstName.Location = new System.Drawing.Point(187, 186);
            this.tbPatientFirstName.Name = "tbPatientFirstName";
            this.tbPatientFirstName.Size = new System.Drawing.Size(100, 22);
            this.tbPatientFirstName.TabIndex = 2;
            this.tbPatientFirstName.Click += new System.EventHandler(this.controlClicked);
            // 
            // tbPatientPassword
            // 
            this.tbPatientPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPatientPassword.Location = new System.Drawing.Point(187, 237);
            this.tbPatientPassword.Name = "tbPatientPassword";
            this.tbPatientPassword.PasswordChar = '*';
            this.tbPatientPassword.Size = new System.Drawing.Size(100, 22);
            this.tbPatientPassword.TabIndex = 3;
            this.tbPatientPassword.Click += new System.EventHandler(this.controlClicked);
            // 
            // tbPatientREPass
            // 
            this.tbPatientREPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPatientREPass.Location = new System.Drawing.Point(187, 287);
            this.tbPatientREPass.Name = "tbPatientREPass";
            this.tbPatientREPass.PasswordChar = '*';
            this.tbPatientREPass.Size = new System.Drawing.Size(100, 22);
            this.tbPatientREPass.TabIndex = 4;
            this.tbPatientREPass.Click += new System.EventHandler(this.controlClicked);
            // 
            // btnOkPatient
            // 
            this.btnOkPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnOkPatient.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOkPatient.ForeColor = System.Drawing.Color.White;
            this.btnOkPatient.Location = new System.Drawing.Point(53, 394);
            this.btnOkPatient.Name = "btnOkPatient";
            this.btnOkPatient.Size = new System.Drawing.Size(75, 23);
            this.btnOkPatient.TabIndex = 6;
            this.btnOkPatient.Text = "OK";
            this.btnOkPatient.UseVisualStyleBackColor = false;
            this.btnOkPatient.Click += new System.EventHandler(this.btnOkPacient_Click);
            // 
            // btnCancelPatient
            // 
            this.btnCancelPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnCancelPatient.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelPatient.ForeColor = System.Drawing.Color.White;
            this.btnCancelPatient.Location = new System.Drawing.Point(199, 394);
            this.btnCancelPatient.Name = "btnCancelPatient";
            this.btnCancelPatient.Size = new System.Drawing.Size(75, 23);
            this.btnCancelPatient.TabIndex = 7;
            this.btnCancelPatient.Text = "Cancel";
            this.btnCancelPatient.UseVisualStyleBackColor = false;
            this.btnCancelPatient.Click += new System.EventHandler(this.btnCancelPatient_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(134)))), ((int)(((byte)(190)))));
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
            this.panel1.Location = new System.Drawing.Point(358, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 441);
            this.panel1.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 337);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 17);
            this.label14.TabIndex = 30;
            this.label14.Text = "Birthday";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.dtpBirthday.Location = new System.Drawing.Point(187, 332);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(100, 22);
            this.dtpBirthday.TabIndex = 5;
            this.dtpBirthday.DropDown += new System.EventHandler(this.controlClicked);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(134)))), ((int)(((byte)(190)))));
            this.panel2.Controls.Add(this.btnCancelDoctor);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.tbRePassword);
            this.panel2.Controls.Add(this.tbNewDocID);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbPassword);
            this.panel2.Controls.Add(this.tbLastName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbFirstName);
            this.panel2.Controls.Add(this.tbSpecialisation);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 441);
            this.panel2.TabIndex = 30;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // docPB
            // 
            this.docPB.Location = new System.Drawing.Point(12, 460);
            this.docPB.Name = "docPB";
            this.docPB.Size = new System.Drawing.Size(313, 23);
            this.docPB.TabIndex = 31;
            // 
            // patientPB
            // 
            this.patientPB.Location = new System.Drawing.Point(358, 459);
            this.patientPB.Name = "patientPB";
            this.patientPB.Size = new System.Drawing.Size(314, 23);
            this.patientPB.TabIndex = 32;
            // 
            // AdminInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(684, 486);
            this.Controls.Add(this.patientPB);
            this.Controls.Add(this.docPB);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminInterface";
            this.Text = "AdminInterface";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbNewDocID;
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
        private System.Windows.Forms.ProgressBar patientPB;
        private System.Windows.Forms.ProgressBar docPB;
    }
}