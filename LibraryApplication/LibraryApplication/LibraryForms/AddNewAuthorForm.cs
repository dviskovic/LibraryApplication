﻿using LibraryApplication.LibraryObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LibraryApplication.LibraryForms
{
    public partial class AddNewAuthorForm : Form
    {
        private MainForm mainForm = null;

        public AddNewAuthorForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            this.AddNewAuthorButton.Enabled = false;
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

        private void TextChanged(object o, EventArgs e)
        {
            this.AddNewAuthorButton.Enabled = this.FirstNameTextBox.Text != string.Empty && this.LastNameTextBox.Text != string.Empty;
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
    }
}
