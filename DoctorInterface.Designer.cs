namespace BlockchainApp
{
    partial class DoctorInterface
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
            this.lvPacients = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PacientLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectPacient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.tbNewPacientID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbDetails = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddNewRecord = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.Details = new System.Windows.Forms.Label();
            this.tbPIN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.ListBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.selectRecord = new System.Windows.Forms.Button();
            this.btnDones = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lvPacients
            // 
            this.lvPacients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.lvPacients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.PacientLastName,
            this.columnHeader2});
            this.lvPacients.FullRowSelect = true;
            this.lvPacients.GridLines = true;
            this.lvPacients.HideSelection = false;
            this.lvPacients.Location = new System.Drawing.Point(12, 49);
            this.lvPacients.Name = "lvPacients";
            this.lvPacients.Size = new System.Drawing.Size(471, 180);
            this.lvPacients.TabIndex = 1;
            this.lvPacients.UseCompatibleStateImageBehavior = false;
            this.lvPacients.View = System.Windows.Forms.View.Details;
            this.lvPacients.SelectedIndexChanged += new System.EventHandler(this.lvPacients_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Patient ID";
            this.columnHeader1.Width = 90;
            // 
            // PacientLastName
            // 
            this.PacientLastName.Text = "Patient last name";
            this.PacientLastName.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Patient first name";
            this.columnHeader2.Width = 164;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Patients list";
            // 
            // btnSelectPacient
            // 
            this.btnSelectPacient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnSelectPacient.ForeColor = System.Drawing.Color.White;
            this.btnSelectPacient.Location = new System.Drawing.Point(12, 241);
            this.btnSelectPacient.Name = "btnSelectPacient";
            this.btnSelectPacient.Size = new System.Drawing.Size(107, 26);
            this.btnSelectPacient.TabIndex = 3;
            this.btnSelectPacient.Text = "Select patient";
            this.btnSelectPacient.UseVisualStyleBackColor = false;
            this.btnSelectPacient.Click += new System.EventHandler(this.btnSelectPacient_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "New patient";
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(82, 131);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // tbNewPacientID
            // 
            this.tbNewPacientID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbNewPacientID.Location = new System.Drawing.Point(119, 57);
            this.tbNewPacientID.Name = "tbNewPacientID";
            this.tbNewPacientID.Size = new System.Drawing.Size(100, 22);
            this.tbNewPacientID.TabIndex = 6;
            this.tbNewPacientID.Validating += new System.ComponentModel.CancelEventHandler(this.tbNewPacientID_Validating);
            this.tbNewPacientID.Validated += new System.EventHandler(this.tbNewPacientID_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pacient ID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.tbNewPacientID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnDone);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(541, 317);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 186);
            this.panel1.TabIndex = 8;
            // 
            // tbDetails
            // 
            this.tbDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbDetails.Location = new System.Drawing.Point(89, 134);
            this.tbDetails.Multiline = true;
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.Size = new System.Drawing.Size(372, 129);
            this.tbDetails.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddNewRecord);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.dtpDate);
            this.panel2.Controls.Add(this.tbTitle);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnCheck);
            this.panel2.Controls.Add(this.Details);
            this.panel2.Controls.Add(this.tbPIN);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbDetails);
            this.panel2.Location = new System.Drawing.Point(12, 273);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 321);
            this.panel2.TabIndex = 10;
            // 
            // btnAddNewRecord
            // 
            this.btnAddNewRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnAddNewRecord.ForeColor = System.Drawing.Color.White;
            this.btnAddNewRecord.Location = new System.Drawing.Point(220, 283);
            this.btnAddNewRecord.Name = "btnAddNewRecord";
            this.btnAddNewRecord.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewRecord.TabIndex = 18;
            this.btnAddNewRecord.Text = "OK";
            this.btnAddNewRecord.UseVisualStyleBackColor = false;
            this.btnAddNewRecord.Click += new System.EventHandler(this.btnAddNewRecord_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Type";
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.dtpDate.Location = new System.Drawing.Point(89, 54);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 15;
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbTitle.Location = new System.Drawing.Point(89, 98);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(200, 22);
            this.tbTitle.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Date";
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnCheck.ForeColor = System.Drawing.Color.White;
            this.btnCheck.Location = new System.Drawing.Point(313, 14);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 13;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // Details
            // 
            this.Details.AutoSize = true;
            this.Details.Location = new System.Drawing.Point(3, 131);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(51, 17);
            this.Details.TabIndex = 11;
            this.Details.Text = "Details";
            // 
            // tbPIN
            // 
            this.tbPIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.tbPIN.Location = new System.Drawing.Point(89, 14);
            this.tbPIN.Name = "tbPIN";
            this.tbPIN.Size = new System.Drawing.Size(200, 22);
            this.tbPIN.TabIndex = 10;
            this.tbPIN.Text = "Input PIN here";
            this.tbPIN.Click += new System.EventHandler(this.tbPIN_Click);
            this.tbPIN.Validating += new System.ComponentModel.CancelEventHandler(this.tbPIN_Validating);
            this.tbPIN.Validated += new System.EventHandler(this.tbPIN_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "New record";
            // 
            // lbRecords
            // 
            this.lbRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.lbRecords.FormattingEnabled = true;
            this.lbRecords.ItemHeight = 16;
            this.lbRecords.Location = new System.Drawing.Point(492, 49);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(305, 180);
            this.lbRecords.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // selectRecord
            // 
            this.selectRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.selectRecord.ForeColor = System.Drawing.Color.White;
            this.selectRecord.Location = new System.Drawing.Point(600, 235);
            this.selectRecord.Name = "selectRecord";
            this.selectRecord.Size = new System.Drawing.Size(107, 26);
            this.selectRecord.TabIndex = 11;
            this.selectRecord.Text = "Select record";
            this.selectRecord.UseVisualStyleBackColor = false;
            this.selectRecord.Click += new System.EventHandler(this.selectRecord_Click);
            // 
            // btnDones
            // 
            this.btnDones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnDones.ForeColor = System.Drawing.Color.White;
            this.btnDones.Location = new System.Drawing.Point(541, 556);
            this.btnDones.Name = "btnDones";
            this.btnDones.Size = new System.Drawing.Size(75, 23);
            this.btnDones.TabIndex = 12;
            this.btnDones.Text = "Done";
            this.btnDones.UseVisualStyleBackColor = false;
            this.btnDones.Click += new System.EventHandler(this.btnDones_Click);
            // 
            // DoctorInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(809, 606);
            this.Controls.Add(this.btnDones);
            this.Controls.Add(this.selectRecord);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSelectPacient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvPacients);
            this.Name = "DoctorInterface";
            this.Text = "DoctorInterface";
            this.Load += new System.EventHandler(this.DoctorInterface_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvPacients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectPacient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TextBox tbNewPacientID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader PacientLastName;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Details;
        private System.Windows.Forms.TextBox tbPIN;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbRecords;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddNewRecord;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button selectRecord;
        private System.Windows.Forms.Button btnDones;
    }
}