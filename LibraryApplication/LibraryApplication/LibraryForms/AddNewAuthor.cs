﻿using System;
using System.Linq;
using System.Windows.Forms;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryForms
{
    public partial class AddNewAuthor : Form
    {
        private MainForm mainForm = null;

        public AddNewAuthor(MainForm mainForm)
        {
            this.mainForm = mainForm;
            this.InitializeComponent();
            this.AddNewAuthorButton.Enabled = false;
            this.Focus();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DataFileSystem.IO.DataFile.Authors.Add(new Author
            {
                FirstName = this.FirstNameTextBox.Text,
                LastName = this.LastNameTextBox.Text,
                ID = DataFileSystem.IO.DataFile.Authors.Count == 0 ? 0 : DataFileSystem.IO.DataFile.Authors.Last().ID + 1
            });

            LibraryEvents.EventManager.OnAuthorListChanged();

            DataFileSystem.IO.SaveUserData();

            this.Close();
        }

        private void TextChangedEvent(object o, EventArgs e)
        {
            this.AddNewAuthorButton.Enabled = this.FirstNameTextBox.Text != string.Empty && this.LastNameTextBox.Text != string.Empty;
        }

        private void AddNewAuthorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.mainForm.CurrentAddNewAuthorForm = null;
                this.Close();
            }
        }

        private void AddNewAuthorForm_Closing(object sender, FormClosingEventArgs e)
        {
            this.mainForm.CurrentAddNewAuthorForm = null;
        }

        private void LastNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && this.AddNewAuthorButton.Enabled)
            {
                this.AddButton_Click(null, null);
            }
        }
    }
}
