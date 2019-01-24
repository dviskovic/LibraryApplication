using LibraryApplication.LibraryObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LibraryApplication.LibraryForms
{
    public partial class AddNewBookForm : Form
    {
        private Random random;
        private MainForm mainForm = null;
        private Author SelectedAuthor = null;

        private readonly string NameText = "Book Name";

        private readonly string CountText = "Quantity";

        private readonly string ISBNText = "ISBN";

        public AddNewBookForm(MainForm mainForm)
        {
            InitializeComponent();
            this.Focus();
            random = new Random();
            this.mainForm = mainForm;
            this.NameBox.Text = this.NameText;
            this.CountBox.Text = this.CountText;
            this.ISBNTextBox.Text = this.ISBNText;
            this.AuthorBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AddNewBookButton.Enabled = false;

            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.ImageLocation = DataFileSystem.FileLocations.DefaultBookImagePath;
            LibraryEvents.EventManager.OnAuthorListChanged += UpdateAuthorList;
            this.UpdateAuthorList();   
        }

        private void UpdateAuthorList()
        {
            List<string> DataSource = new List<string> { "Select an Author", "--Add a New Author--" };
            foreach (var item in DataFileSystem.IO.DataFile.Authors.Select(x => x.FirstName + " " + x.LastName).ToList()) DataSource.Add(item);
            this.AuthorBox.DataSource = DataSource;
        }

        private string ImagePath = string.Empty;

        private void TextChangedEvent(object o, EventArgs e)
        {
            if (this.AuthorBox?.SelectedIndex > 0)
            {
                if (this.AuthorBox?.SelectedIndex == 1)
                {
                    if (this.mainForm.CurrentAddNewAuthorForm != null) this.mainForm.CurrentAddNewAuthorForm.Focus();
                    this.mainForm.CurrentAddNewAuthorForm = new AddNewAuthorForm(this.mainForm);
                    this.mainForm.CurrentAddNewAuthorForm.Show();
                }
                else this.SelectedAuthor = DataFileSystem.IO.DataFile.Authors[this.AuthorBox.SelectedIndex - 2];
            }

            this.AddNewBookButton.Enabled = this.CountBox.Text != string.Empty && this.NameBox.Text != string.Empty && this.CountBox.Text != this.CountText && this.NameBox.Text != this.NameText && this.AuthorBox.SelectedIndex != 0 && this.ISBNTextBox.Text != string.Empty;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string fileName = "default_book.png";

            if (ImagePath != string.Empty)
            {
                string TargetFileName = this.NameBox.Text + random.Next().ToString() + Path.GetExtension(ImagePath);
                string Destination = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, TargetFileName);
                File.Copy(ImagePath, Destination);
                fileName = TargetFileName;
            }

            DataFileSystem.IO.DataFile.Books.Add(new Book
            {
                Count = int.Parse(this.CountBox.Text),
                AuthorID = SelectedAuthor.ID,
                Name = this.NameBox.Text,
                ImageID = fileName,
                ISBN = this.ISBNTextBox.Text
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

        private void CountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AddNewBookForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.mainForm.CurrentAddNewBookForm = null;
                this.Close();
            }
        }

        private void AddNewBookForm_Closing(object sender, FormClosingEventArgs e)
        {
            this.mainForm.CurrentAddNewBookForm = null;
        }

        private void NameBox_Enter(object sender, EventArgs e)
        {
            if (this.NameBox.Text == this.NameText) this.NameBox.Text = string.Empty;
        }

        private void NameBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameBox.Text)) this.NameBox.Text = this.NameText;
        }

        private void CountBox_Enter(object sender, EventArgs e)
        {
            if (this.CountBox.Text == this.CountText) this.CountBox.Text = string.Empty;
        }

        private void CountBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.CountBox.Text)) this.CountBox.Text = this.CountText;
        }

        private void ISBNBox_Enter(object sender, EventArgs e)
        {
            if (this.ISBNTextBox.Text == this.ISBNText) this.ISBNTextBox.Text = string.Empty;
        }

        private void ISBNBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ISBNTextBox.Text)) this.ISBNTextBox.Text = this.ISBNText;
        }

        private void ISBNBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}
