using LibraryApplication.LibraryObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibraryApplication.LibraryForms
{
    public partial class AddNewAuthorForm : Form
    {
        private MainForm mainForm = null;

        private readonly string FirstText = "First name";

        private readonly string LastText = "Last name";

        public AddNewAuthorForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            this.AddNewAuthorButton.Enabled = false;
            this.Focus();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DataFileSystem.IO.DataFile.Authors.Add(new Author
            {
                FirstName = this.FirstNameTextBox.Text,
                LastName = this.LastNameTextBox.Text,
            });

            DataFileSystem.IO.SaveUserData();

            this.mainForm.Focus();
            this.Close();
        }

        private void TextChangedEvent(object o, EventArgs e)
        {
            this.AddNewAuthorButton.Enabled = this.FirstNameTextBox.Text != string.Empty && this.LastNameTextBox.Text != string.Empty && this.FirstNameTextBox.Text != this.FirstText && this.LastNameTextBox.Text != this.LastText;
        }

        private void AddNewAuthorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.mainForm.CurrentAddNewAuthorForm = null;
                this.Close();
            }
        }

        private void AddNewAuthorForm_Closing(object sender, FormClosingEventArgs e)
        {
            this.mainForm.CurrentAddNewAuthorForm = null;
        }

        private void FirstNameTextBox_Enter(object sender, EventArgs e)
        {
            if (this.FirstNameTextBox.Text == this.FirstText) this.FirstNameTextBox.Text = string.Empty;
        }

        private void FirstNameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.FirstNameTextBox.Text)) this.FirstNameTextBox.Text = this.FirstText;
        }

        private void LastNameTextBox_Enter(object sender, EventArgs e)
        {
            if (this.LastNameTextBox.Text == this.LastText) this.LastNameTextBox.Text = string.Empty;
        }

        private void LastNameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.LastNameTextBox.Text)) this.LastNameTextBox.Text = this.LastText;
        }

        private void LastNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (this.AddNewAuthorButton.Enabled) this.AddButton_Click(null, null);
            }
        }
    }
}
