using System;
using System.Text;
using System.Windows.Forms;
using LibraryApplication.DataFileSystem;

namespace LibraryApplication.LibraryForms
{
    public partial class PasswordForm : Form
    {
        private const string PasswordPlaceHolder = "Password";

        private Action Action { get; set; }

        public PasswordForm(Action action)
        {
            this.Action = action;
            this.InitializeComponent();
            this.ConfirmButton.Enabled = false;
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.UTF8.GetString(LibraryObjects.ConfigFile.Hash(this.PasswordInputTextBox.Text)) == IO.ConfigFile.Password)
            {
                this.ConfirmButton.Enabled = true;
            }

            else
            {
                this.ConfirmButton.Enabled = false;
            }
        }

        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            if (this.PasswordInputTextBox.Text == PasswordPlaceHolder)
            {
                this.PasswordInputTextBox.Text = string.Empty;
                this.PasswordInputTextBox.PasswordChar = '*';
            }
        }

        private void PasswordBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.PasswordInputTextBox.Text))
            {
                this.PasswordInputTextBox.Text = PasswordPlaceHolder;
                this.PasswordInputTextBox.PasswordChar = '\0';
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.Action();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
