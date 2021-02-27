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
            this.forgotLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnDoc
            // 
            this.btnDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(133)))), ((int)(((byte)(203)))));
            this.btnDoc.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoc.ForeColor = System.Drawing.Color.White;
            this.btnDoc.Location = new System.Drawing.Point(112, 161);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(90, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please select your profile";
            // 
            // btnPacient
            // 
            this.btnPacient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(133)))), ((int)(((byte)(203)))));
            this.btnPacient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacient.ForeColor = System.Drawing.Color.White;
            this.btnPacient.Location = new System.Drawing.Point(112, 219);
            this.btnPacient.Name = "btnPacient";
            this.btnPacient.Size = new System.Drawing.Size(152, 37);
            this.btnPacient.TabIndex = 3;
            this.btnPacient.Text = "I\'m a patient";
            this.btnPacient.UseVisualStyleBackColor = false;
            this.btnPacient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(133)))), ((int)(((byte)(203)))));
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.Location = new System.Drawing.Point(114, 378);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(152, 35);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // forgotLabel
            // 
            this.forgotLabel.AutoSize = true;
            this.forgotLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.forgotLabel.Location = new System.Drawing.Point(111, 276);
            this.forgotLabel.Name = "forgotLabel";
            this.forgotLabel.Size = new System.Drawing.Size(153, 17);
            this.forgotLabel.TabIndex = 8;
            this.forgotLabel.TabStop = true;
            this.forgotLabel.Text = "Forgot your password?";
            this.forgotLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgotLabel_LinkClicked);
            // 
            // ProfileSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(371, 437);
            this.Controls.Add(this.forgotLabel);
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
        private System.Windows.Forms.LinkLabel forgotLabel;
    }
}

