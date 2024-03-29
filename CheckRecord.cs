﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainApp
{
    public partial class CheckRecord : MaterialSkin.Controls.MaterialForm
    {
        private string patientLastName;
        private string patientFirstName;
        private long patientID;
        private string title;
        private string description;

        public CheckRecord(string patientLastName, string patientFirstName, long patientID, string title, string description)
        {
            InitializeComponent();
            this.patientFirstName = patientFirstName;
            this.patientLastName = patientLastName;
            this.patientID = patientID;
            this.title = title;
            this.description = description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AreYouSure_Load(object sender, EventArgs e)
        {
            try
            {
                tbLastName.Text = patientLastName;
                tbFirstName.Text = patientFirstName;
                tbID.Text = patientID.ToString();
                tbTitle.Text = title;
                tbDescription.Text = description;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a patient");
                Close();
            }
        }
    }
}
