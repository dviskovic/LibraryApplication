using LibraryApplication.LibraryObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LibraryApplication.LibraryForms
{
    public partial class AddNewUserForm : Form
    {
        private Random random;
        private MainForm mainForm = null;

        public AddNewUserForm(MainForm mainForm)
        {
            random = new Random();
            this.mainForm = mainForm;
            InitializeComponent();
            this.AddButton.Enabled = false;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //this.pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            //this.pictureBox1.BackColor = Color.Black;
            this.pictureBox1.ImageLocation = DataFileSystem.FileLocations.DefaultUserImagePath;
        }

        private string ImagePath = string.Empty;

        private void TextChangedEvent(object o, EventArgs e)
        {
            this.AddButton.Enabled = this.FirstNameTextBox.Text != string.Empty && this.LastNameTextBox.Text != string.Empty;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string fileName = "default_user.png";
            if (ImagePath != string.Empty)
            {
                string TargetFileName = this.FirstNameTextBox.Text + "_" + this.LastNameTextBox.Text + random.Next().ToString() + Path.GetExtension(ImagePath);
                string Destination = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, TargetFileName);
                File.Copy(ImagePath, Destination);
                fileName = TargetFileName;
            }

            DataFileSystem.IO.DataFile.Users.Add(new User {
                FirstName = this.FirstNameTextBox.Text,
                LastName = this.LastNameTextBox.Text,
                Address = this.AddressTextBox.Text,
                Phone = this.PhoneTextBox.Text,
                Email = this.EmailTextBox.Text,
                BorrowedBooks = new List<BookBorrow>(),
                ImageID = fileName
            });

            DataFileSystem.IO.SaveUserData();
            

            this.mainForm.Focus();
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

        private void AddNewUserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.mainForm.CurrentAddNewUserForm = null;
                this.Close();
            }
        }

        private void AddNewUserForm_Closing(object sender, FormClosingEventArgs e)
        {
            this.mainForm.CurrentAddNewUserForm = null;
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
