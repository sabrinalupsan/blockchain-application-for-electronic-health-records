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
            this.tbNewDocID = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSpecialisation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            this.tbPacientID = new System.Windows.Forms.TextBox();
            this.tbPacientLastName = new System.Windows.Forms.TextBox();
            this.tbPacientFirstName = new System.Windows.Forms.TextBox();
            this.tbPacientPassword = new System.Windows.Forms.TextBox();
            this.tbPacientREPass = new System.Windows.Forms.TextBox();
            this.btnOkPacient = new System.Windows.Forms.Button();
            this.btnCancelPacient = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            this.btnOK.TabIndex = 2;
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
            this.tbNewDocID.TabIndex = 3;
            this.tbNewDocID.Validating += new System.ComponentModel.CancelEventHandler(this.tbNewDocID_Validating);
            this.tbNewDocID.Validated += new System.EventHandler(this.tbNewDocID_Validated);
            // 
            // tbLastName
            // 
            this.tbLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbLastName.Location = new System.Drawing.Point(178, 139);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(100, 22);
            this.tbLastName.TabIndex = 5;
            this.tbLastName.Validating += new System.ComponentModel.CancelEventHandler(this.tbLastName_Validating);
            this.tbLastName.Validated += new System.EventHandler(this.tbLastName_Validated);
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
            this.tbFirstName.TabIndex = 7;
            this.tbFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.tbFirstName_Validating);
            this.tbFirstName.Validated += new System.EventHandler(this.tbFirstName_Validated);
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
            this.tbSpecialisation.TabIndex = 9;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(169, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 27);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPassword.Location = new System.Drawing.Point(178, 284);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 22);
            this.tbPassword.TabIndex = 12;
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPassword_Validating);
            this.tbPassword.Validated += new System.EventHandler(this.tbPassword_Validated);
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
            this.tbRePassword.TabIndex = 14;
            this.tbRePassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbRePassword_Validating);
            this.tbRePassword.Validated += new System.EventHandler(this.tbRePassword_Validated);
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
            this.label8.Size = new System.Drawing.Size(115, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "New pacient";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "New Pacient ID";
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
            // tbPacientID
            // 
            this.tbPacientID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPacientID.Location = new System.Drawing.Point(187, 88);
            this.tbPacientID.Name = "tbPacientID";
            this.tbPacientID.Size = new System.Drawing.Size(100, 22);
            this.tbPacientID.TabIndex = 22;
            this.tbPacientID.Validating += new System.ComponentModel.CancelEventHandler(this.tbPacientID_Validating);
            this.tbPacientID.Validated += new System.EventHandler(this.tbPacientID_Validated);
            // 
            // tbPacientLastName
            // 
            this.tbPacientLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPacientLastName.Location = new System.Drawing.Point(187, 136);
            this.tbPacientLastName.Name = "tbPacientLastName";
            this.tbPacientLastName.Size = new System.Drawing.Size(100, 22);
            this.tbPacientLastName.TabIndex = 23;
            this.tbPacientLastName.Validating += new System.ComponentModel.CancelEventHandler(this.tbPacientLastName_Validating);
            this.tbPacientLastName.Validated += new System.EventHandler(this.tbPacientLastName_Validated);
            // 
            // tbPacientFirstName
            // 
            this.tbPacientFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPacientFirstName.Location = new System.Drawing.Point(187, 186);
            this.tbPacientFirstName.Name = "tbPacientFirstName";
            this.tbPacientFirstName.Size = new System.Drawing.Size(100, 22);
            this.tbPacientFirstName.TabIndex = 24;
            this.tbPacientFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.tbPacientFirstName_Validating);
            this.tbPacientFirstName.Validated += new System.EventHandler(this.tbPacientFirstName_Validated);
            // 
            // tbPacientPassword
            // 
            this.tbPacientPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPacientPassword.Location = new System.Drawing.Point(187, 237);
            this.tbPacientPassword.Name = "tbPacientPassword";
            this.tbPacientPassword.PasswordChar = '*';
            this.tbPacientPassword.Size = new System.Drawing.Size(100, 22);
            this.tbPacientPassword.TabIndex = 25;
            this.tbPacientPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPacientPassword_Validating);
            this.tbPacientPassword.Validated += new System.EventHandler(this.tbPacientPassword_Validated);
            // 
            // tbPacientREPass
            // 
            this.tbPacientREPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPacientREPass.Location = new System.Drawing.Point(187, 287);
            this.tbPacientREPass.Name = "tbPacientREPass";
            this.tbPacientREPass.PasswordChar = '*';
            this.tbPacientREPass.Size = new System.Drawing.Size(100, 22);
            this.tbPacientREPass.TabIndex = 26;
            this.tbPacientREPass.Validating += new System.ComponentModel.CancelEventHandler(this.tbPacientREPass_Validating);
            this.tbPacientREPass.Validated += new System.EventHandler(this.tbPacientREPass_Validated);
            // 
            // btnOkPacient
            // 
            this.btnOkPacient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnOkPacient.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOkPacient.ForeColor = System.Drawing.Color.White;
            this.btnOkPacient.Location = new System.Drawing.Point(53, 394);
            this.btnOkPacient.Name = "btnOkPacient";
            this.btnOkPacient.Size = new System.Drawing.Size(75, 23);
            this.btnOkPacient.TabIndex = 27;
            this.btnOkPacient.Text = "OK";
            this.btnOkPacient.UseVisualStyleBackColor = false;
            this.btnOkPacient.Click += new System.EventHandler(this.btnOkPacient_Click);
            // 
            // btnCancelPacient
            // 
            this.btnCancelPacient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnCancelPacient.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelPacient.ForeColor = System.Drawing.Color.White;
            this.btnCancelPacient.Location = new System.Drawing.Point(199, 394);
            this.btnCancelPacient.Name = "btnCancelPacient";
            this.btnCancelPacient.Size = new System.Drawing.Size(75, 23);
            this.btnCancelPacient.TabIndex = 28;
            this.btnCancelPacient.Text = "Cancel";
            this.btnCancelPacient.UseVisualStyleBackColor = false;
            this.btnCancelPacient.Click += new System.EventHandler(this.btnCancelPacient_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(134)))), ((int)(((byte)(190)))));
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.dtpBirthday);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnCancelPacient);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnOkPacient);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbPacientREPass);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.tbPacientPassword);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tbPacientFirstName);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.tbPacientLastName);
            this.panel1.Controls.Add(this.tbPacientID);
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
            this.dtpBirthday.TabIndex = 29;
            this.dtpBirthday.Validating += new System.ComponentModel.CancelEventHandler(this.dtpBirthday_Validating);
            this.dtpBirthday.Validated += new System.EventHandler(this.dtpBirthday_Validated);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(134)))), ((int)(((byte)(190)))));
            this.panel2.Controls.Add(this.button1);
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
            // AdminInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(684, 465);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminInterface";
            this.Text = "AdminInterface";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
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
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.TextBox tbPacientID;
        private System.Windows.Forms.TextBox tbPacientLastName;
        private System.Windows.Forms.TextBox tbPacientFirstName;
        private System.Windows.Forms.TextBox tbPacientPassword;
        private System.Windows.Forms.TextBox tbPacientREPass;
        private System.Windows.Forms.Button btnOkPacient;
        private System.Windows.Forms.Button btnCancelPacient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}