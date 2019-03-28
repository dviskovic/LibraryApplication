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
    public partial class SetUpLateFee : Form
    {
        private double current;

        public SetUpLateFee()
        {
            this.InitializeComponent();
            this.FinishButton.Enabled = false;
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            DataFileSystem.IO.ConfigFile.LateFee = this.current;
            DataFileSystem.IO.SaveConfig();
            this.Close();
        }

        private void Form_TextChanged(object sender, EventArgs e)
        {
            this.FinishButton.Enabled = !string.IsNullOrEmpty(this.FeeTextBox.Text) && double.TryParse(this.FeeTextBox.Text, out this.current);
        }
    }
}
