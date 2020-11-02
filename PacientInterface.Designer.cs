namespace BlockchainApp
{
    partial class PacientInterface
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
            this.lvRecords = new System.Windows.Forms.ListView();
            this.btnSeeRecord = new System.Windows.Forms.Button();
            this.btnPrintRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lvRecords
            // 
            this.lvRecords.GridLines = true;
            this.lvRecords.HideSelection = false;
            this.lvRecords.Location = new System.Drawing.Point(12, 55);
            this.lvRecords.Name = "lvRecords";
            this.lvRecords.Size = new System.Drawing.Size(279, 168);
            this.lvRecords.TabIndex = 0;
            this.lvRecords.UseCompatibleStateImageBehavior = false;
            // 
            // btnSeeRecord
            // 
            this.btnSeeRecord.Location = new System.Drawing.Point(12, 244);
            this.btnSeeRecord.Name = "btnSeeRecord";
            this.btnSeeRecord.Size = new System.Drawing.Size(99, 23);
            this.btnSeeRecord.TabIndex = 1;
            this.btnSeeRecord.Text = "Show record";
            this.btnSeeRecord.UseVisualStyleBackColor = true;
            // 
            // btnPrintRecord
            // 
            this.btnPrintRecord.Location = new System.Drawing.Point(12, 284);
            this.btnPrintRecord.Name = "btnPrintRecord";
            this.btnPrintRecord.Size = new System.Drawing.Size(99, 23);
            this.btnPrintRecord.TabIndex = 2;
            this.btnPrintRecord.Text = "Print record";
            this.btnPrintRecord.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "My records";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(307, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 301);
            this.panel1.TabIndex = 4;
            // 
            // PacientInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 331);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrintRecord);
            this.Controls.Add(this.btnSeeRecord);
            this.Controls.Add(this.lvRecords);
            this.Name = "PacientInterface";
            this.Text = "PacientInterface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvRecords;
        private System.Windows.Forms.Button btnSeeRecord;
        private System.Windows.Forms.Button btnPrintRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}