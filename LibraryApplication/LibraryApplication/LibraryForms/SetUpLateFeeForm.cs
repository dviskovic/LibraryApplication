using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryApplication.LibraryForms
{
    public partial class SetUpLateFeeForm : Form
    {
        private double Current;

        public SetUpLateFeeForm()
        {
            InitializeComponent();
            this.FinishButton.Enabled = false;
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            DataFileSystem.IO.configFile.LateFee = this.Current;
            DataFileSystem.IO.SaveConfig();
            this.Close();
        }

        private void Form_TextChanged(object sender, EventArgs e)
        {
            this.FinishButton.Enabled = (!string.IsNullOrEmpty(this.FeeTextBox.Text) && double.TryParse(this.FeeTextBox.Text, out this.Current));
        }
    }
}
