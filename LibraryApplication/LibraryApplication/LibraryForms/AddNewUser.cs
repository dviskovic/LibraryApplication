using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryForms
{
    public partial class AddNewUser : Form
    {
        private Random random = new Random();
        private MainForm mainForm = null;
        private string imagePath = string.Empty;

        public AddNewUser(MainForm mainForm)
        {
            this.mainForm = mainForm;
            this.InitializeComponent();
        }

        private void TextChangedEvent(object o, EventArgs e)
        {
            this.AddButton.Enabled = this.FirstNameTextBox.Text != string.Empty && this.LastNameTextBox.Text != string.Empty && this.EmailTextBox.Text != string.Empty && this.AddressTextBox.Text != string.Empty && this.PhoneTextBox.Text != string.Empty;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string fileName = "default_user.png";
            if (this.imagePath != string.Empty)
            {
                string targetFileName = this.FirstNameTextBox.Text + "_" + this.LastNameTextBox.Text + this.random.Next().ToString() + Path.GetExtension(this.imagePath);
                string destination = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, targetFileName);
                File.Copy(this.imagePath, destination);
                fileName = targetFileName;
            }

            DataFileSystem.IO.DataFile.Users.Add(new User
            {
                FirstName = this.FirstNameTextBox.Text,
                LastName = this.LastNameTextBox.Text,
                Address = this.AddressTextBox.Text,
                Phone = this.PhoneTextBox.Text,
                Email = this.EmailTextBox.Text,
                BorrowedBooks = new List<BorrowedBook>(),
                ImageID = fileName
            });

            DataFileSystem.IO.SaveUserData();
            
            this.mainForm.Focus();
            this.Close();
        }

        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            var fileBrowser = new OpenFileDialog
            {
                Title = "Select an image",
                Filter = "Image Files|*.jpg;*.png;*.jpeg;*.png;..."
            };
            fileBrowser.ShowDialog();
            this.pictureBox1.ImageLocation = this.imagePath = fileBrowser.FileName;
        }

        private void PhoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != '/' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
