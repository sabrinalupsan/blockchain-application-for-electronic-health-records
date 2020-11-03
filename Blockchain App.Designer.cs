namespace BlockchainApp
{
    partial class ProfileSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileSelect));
            this.btnDoc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPacient = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDoc
            // 
            this.btnDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnDoc.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoc.ForeColor = System.Drawing.Color.White;
            this.btnDoc.Location = new System.Drawing.Point(122, 147);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(152, 37);
            this.btnDoc.TabIndex = 1;
            this.btnDoc.Text = "I\'m a doctor/nurse";
            this.btnDoc.UseVisualStyleBackColor = false;
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(99, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please select your profile";
            // 
            // btnPacient
            // 
            this.btnPacient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnPacient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacient.ForeColor = System.Drawing.Color.White;
            this.btnPacient.Location = new System.Drawing.Point(122, 205);
            this.btnPacient.Name = "btnPacient";
            this.btnPacient.Size = new System.Drawing.Size(152, 37);
            this.btnPacient.TabIndex = 3;
            this.btnPacient.Text = "I\'m a patient";
            this.btnPacient.UseVisualStyleBackColor = false;
            this.btnPacient.Click += new System.EventHandler(this.btnPacient_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.Location = new System.Drawing.Point(122, 317);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(152, 35);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(151, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(74, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 44);
            this.label2.TabIndex = 7;
            this.label2.Text = "Blockchain App";
            // 
            // ProfileSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(391, 391);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnPacient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProfileSelect";
            this.Text = "BlockchainApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPacient;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
    }
}

