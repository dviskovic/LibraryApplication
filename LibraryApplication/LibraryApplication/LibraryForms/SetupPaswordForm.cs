﻿using LibraryApplication.DataFileSystem;
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
    public partial class SetupPaswordForm : Form
    {
        private const string PasswordText = "Password";
        private const string PasswordTextConfirm = "Confirm Password";
        private bool CanClose = false;

        public SetupPaswordForm()
        {
            InitializeComponent();
            this.ConfirmButton.Enabled = false;
        }

        private void TextBoxes_TextChanged(object sender, EventArgs e)
        {
            if (this.Password.Text == this.PasswordConfirm.Text && !string.IsNullOrEmpty(this.Password.Text) && !string.IsNullOrEmpty(this.PasswordConfirm.Text) && this.Password.Text.ToLower() != "password")
            {
                this.ConfirmButton.Enabled = true;
            }

            else this.ConfirmButton.Enabled = false;
        }

        private void PasswordConfirm_Enter(object sender, EventArgs e)
        {
            if (this.PasswordConfirm.Text == PasswordTextConfirm)
            {
                this.PasswordConfirm.Text = "";
                this.PasswordConfirm.PasswordChar = '*';
            }
        }

        private void PasswordConfirm_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.PasswordConfirm.Text))
            {
                this.PasswordConfirm.Text = PasswordTextConfirm;
                this.PasswordConfirm.PasswordChar = '\0';
            }
        }

        private void Password_Enter(object sender, EventArgs e)
        {
            if (this.Password.Text == PasswordText)
            {
                this.Password.Text = "";
                this.Password.PasswordChar = '*';
            }
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Password.Text))
            {
                this.Password.Text = PasswordText;
                this.Password.PasswordChar = '\0';
            }
        }

        private void SetupPasswordForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (!this.CanClose) e.Cancel = true;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DataFileSystem.IO.configFile.Password = this.Password.Text;
            DataFileSystem.IO.SaveConfig();
            this.CanClose = true;
            this.Close();
        }
    }
}
