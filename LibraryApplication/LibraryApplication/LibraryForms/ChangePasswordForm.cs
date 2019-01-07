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
    public partial class ChangePasswordForm : Form
    {
        private MainForm form;

        private const string CurrentPW = "Current Password";

        private const string NewPW = "New Password";

        private const string ConfirmNewPW = "Confirm new Password";

        public ChangePasswordForm(MainForm form1)
        {
            this.form = form1;
            InitializeComponent();
        }

        private void Form_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.UTF8.GetString(LibraryObjects.ConfigFile.Hash(this.CurrentText.Text)) == DataFileSystem.IO.configFile.Password && this.NewText.Text == this.ConfirmNewText.Text)
            {
                this.ConfirmButton.Enabled = true;
            }

            else this.ConfirmButton.Enabled = false;
        }

        private void CurrentText_Enter(object sender, EventArgs e)
        {
            if (this.CurrentText.Text == CurrentPW)
            {
                this.CurrentText.Text = "";
                this.CurrentText.PasswordChar = '*';
            }
        }

        private void CurrentText_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.CurrentText.Text))
            {
                this.CurrentText.Text = CurrentPW;
                this.CurrentText.PasswordChar = '\0';
            }
        }

        private void NewText_Enter(object sender, EventArgs e)
        {
            if (this.NewText.Text == NewPW)
            {
                this.NewText.Text = "";
                this.NewText.PasswordChar = '*';
            }
        }

        private void NewText_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.NewText.Text))
            {
                this.NewText.Text = NewPW;
                this.NewText.PasswordChar = '\0';
            }
        }

        private void ConfirmNewText_Enter(object sender, EventArgs e)
        {
            if (this.ConfirmNewText.Text == ConfirmNewPW)
            {
                this.ConfirmNewText.Text = "";
                this.ConfirmNewText.PasswordChar = '*';
            }
        }

        private void ConfirmNewText_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ConfirmNewText.Text))
            {
                this.ConfirmNewText.Text = ConfirmNewPW;
                this.ConfirmNewText.PasswordChar = '\0';
            }
        }

        private void ChangePasswordForm_Closing(object sender, FormClosingEventArgs e)
        {
            this.form.CurrentChangePasswordForm = null;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DataFileSystem.IO.configFile.Password = this.NewText.Text;
            DataFileSystem.IO.SaveConfig();
            MessageBox.Show("Changed the password successfully");
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
