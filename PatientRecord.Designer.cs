namespace BlockchainApp
{
    partial class PatientRecord
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
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.btnSeeRecord = new System.Windows.Forms.Button();
            this.tbPacientID = new System.Windows.Forms.TextBox();
            this.tbPacientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(168, 152);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(133, 35);
            this.btnAddRecord.TabIndex = 4;
            this.btnAddRecord.Text = "Add record";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            // 
            // btnSeeRecord
            // 
            this.btnSeeRecord.Location = new System.Drawing.Point(22, 152);
            this.btnSeeRecord.Name = "btnSeeRecord";
            this.btnSeeRecord.Size = new System.Drawing.Size(129, 35);
            this.btnSeeRecord.TabIndex = 3;
            this.btnSeeRecord.Text = "See records";
            this.btnSeeRecord.UseVisualStyleBackColor = true;
            // 
            // tbPacientID
            // 
            this.tbPacientID.Location = new System.Drawing.Point(125, 39);
            this.tbPacientID.Name = "tbPacientID";
            this.tbPacientID.ReadOnly = true;
            this.tbPacientID.Size = new System.Drawing.Size(100, 22);
            this.tbPacientID.TabIndex = 5;
            // 
            // tbPacientName
            // 
            this.tbPacientName.Location = new System.Drawing.Point(125, 92);
            this.tbPacientName.Name = "tbPacientName";
            this.tbPacientName.ReadOnly = true;
            this.tbPacientName.Size = new System.Drawing.Size(100, 22);
            this.tbPacientName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Patient ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Patient name";
            // 
            // PatientRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 229);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPacientName);
            this.Controls.Add(this.tbPacientID);
            this.Controls.Add(this.btnAddRecord);
            this.Controls.Add(this.btnSeeRecord);
            this.Name = "PatientRecord";
            this.Text = "PacientRecord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Button btnSeeRecord;
        private System.Windows.Forms.TextBox tbPacientID;
        private System.Windows.Forms.TextBox tbPacientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}