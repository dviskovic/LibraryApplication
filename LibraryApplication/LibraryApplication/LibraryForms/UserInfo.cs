using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryForms
{
    public partial class UserInfo : Form
    {
        public UserBooks UserBooks;

        private User user;

        private bool DefaultImage
        {
            get { return Path.GetFileName(this.imagePath) == "default_user.png"; }
        }

        private string imagePath = string.Empty;

        public UserInfo(User user)
        {
            this.user = user;
            this.InitializeComponent();
            this.Text = user.FullName;
            this.imagePath = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, user.ImageID);
            this.pictureBox1.Image = Image.FromFile(File.Exists(this.imagePath) ? this.imagePath : DataFileSystem.FileLocations.DefaultUserImagePath);
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
            this.user.ImageID = this.DefaultImage ? "default_user.png" : LibraryHelpers.ImageHelper.SaveImage(this.user, this.imagePath);
            this.user.Address = this.Address.Text;
            this.user.Phone = this.Phone.Text;
            this.user.Email = this.Email.Text;
            DataFileSystem.IO.SaveUserData();
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

        private void BooksButton_Click(object sender, EventArgs e)
        {
            if (this.UserBooks != null)
            {
                this.UserBooks.Focus();
            }

            else
            {
                this.UserBooks = new UserBooks(this.user);
                this.UserBooks.Show();
                this.UserBooks.FormClosing += new FormClosingEventHandler((o2, e2) => this.UserBooks = null);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Are you sure you want to delete \"" + this.user.FullName + "\"", "Delete Confirmation", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                var pass = new PasswordForm(() => 
                {
                    MessageBox.Show("Deleted \"" + this.user.FullName + "\"", "Notification");
                    LibraryHelpers.Data.DeleteEntryFromDataFile(this.user);
                    this.Close();
                });

                pass.Show();
            }
        }

        private void TextChangedEvent(object sender, EventArgs e)
        {
            this.SaveAndExit.Enabled = !string.IsNullOrEmpty(this.FirstName.Text) && !string.IsNullOrEmpty(this.LastName.Text) && !string.IsNullOrEmpty(this.Address.Text) && !string.IsNullOrEmpty(this.Email.Text) && !string.IsNullOrEmpty(this.Phone.Text);
        }

        private void Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}
