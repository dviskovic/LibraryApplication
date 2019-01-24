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

        private bool DefaultImage {
            get
            {
                return Path.GetFileName(this.ImagePath) == "default_user.png";
            }
        }

        private string ImagePath;

        public UserControl(User user, MainForm form)
        {
            this.form = form;
            this.user = user;
            InitializeComponent();
            this.Text = "Info about " + user.FullName;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.ImagePath = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, user.ImageID);
            this.pictureBox1.Image = Image.FromFile(File.Exists(this.ImagePath) ? this.ImagePath : DataFileSystem.FileLocations.DefaultUserImagePath);
            this.pictureBox1.Refresh();
            this.FirstName.Text = user.FirstName;
            this.LastName.Text = user.LastName;
            this.Email.Text = user.Email;
            this.Phone.Text = user.Phone;
            this.Address.Text = user.Address;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveAndExit_Click(object sender, EventArgs e)
        {
            this.user.FirstName = this.FirstName.Text;
            this.user.LastName = this.LastName.Text;
            this.user.ImageID = this.DefaultImage ? "default_user.png" : LibraryHelpers.ImageHelper.SaveImage(this.user, this.ImagePath);
            this.user.Address = this.Address.Text;
            this.user.Phone = this.Phone.Text;
            this.user.Email = this.Email.Text;
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
            if (this.form.UserDictionary.ContainsKey(this.user)) this.form.UserDictionary.Remove(this.user);
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

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var Dialog = MessageBox.Show("Are you sure you want to delete \"" + this.user.FullName + "\"", "Delete Confirmation", MessageBoxButtons.YesNo);

            if (Dialog == DialogResult.Yes)
            {
                var pass = new PasswordForm(() => {
                    MessageBox.Show("Deleted \"" + this.user.FullName + "\"", "Notification");
                    LibraryHelpers.Data.DeleteEntryFromDataFile(this.user);
                    this.Close();
                });

                pass.Show();
                pass.Focus();
            }
        }
    }
}
