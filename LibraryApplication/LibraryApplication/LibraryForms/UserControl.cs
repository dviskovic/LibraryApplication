using LibraryApplication.LibraryObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryApplication.LibraryForms
{
    public partial class UserControl : Form
    {
        private MainForm form;
        private User user;

        public UserBooksForm userBooks;

        private bool DefaultImage;

        private string ImagePath;

        public UserControl(User user, MainForm form)
        {
            this.form = form;
            this.user = user;
            InitializeComponent();
            this.Text = "Info about " + user.FullName;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.ImagePath = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, user.ImageID);
            this.DefaultImage = Path.GetFileName(this.ImagePath) == "default_user.png";

            var image = Image.FromFile(this.ImagePath);
            this.pictureBox1.Image = image;
            this.pictureBox1.Refresh();
            this.FirstName.Text = user.FirstName;
            this.LastName.Text = user.LastName;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.form.UserDictionary.Remove(this.user);
            this.Close();
        }

        private void SaveAndExit_Click(object sender, EventArgs e)
        {
            this.user.FirstName = this.FirstName.Text;
            this.user.LastName = this.LastName.Text;
            this.user.ImageID = this.DefaultImage ? "default_user.png" : LibraryHelpers.ImageHelper.SaveImage(this.user, this.ImagePath);
            DataFileSystem.IO.SaveUserData();
            this.form.UserDictionary.Remove(this.user);
            this.Close();
        }

        private void SelectImageButton_Click(object sender, EventArgs e)
        {
            var FileBrowser = new OpenFileDialog
            {
                Title = "Select an image",
                Filter = "Image Files|*.jpg;*.png;*.jpeg;*.png;..."
            };
            FileBrowser.ShowDialog();
            this.pictureBox1.ImageLocation = ImagePath = FileBrowser.FileName;
        }

        private void InfoForm_Closing(object sender, FormClosingEventArgs e)
        {
            this.form.UserDictionary.Remove(this.user);
        }

        private void BooksButton_Click(object sender, EventArgs e)
        {
            if (this.userBooks != null) this.userBooks.Focus();
            else
            {
                this.userBooks = new UserBooksForm(this, this.user);
                this.userBooks.Show();
            }
        }
    }
}
