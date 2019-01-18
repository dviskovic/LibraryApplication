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
    public partial class BookControl : Form
    {
        private Author SelectedAuthor = null;

        private Book currentBook;

        private MainForm form;

        private string ImagePath;

        private bool DefaultImage
        {
            get
            {
                return Path.GetFileName(this.ImagePath) == "default_book.png";
            }
        }

        public BookControl(Book book, MainForm form)
        {
            InitializeComponent();
            this.currentBook = book;
            this.form = form;
            this.Text = "Info about " + this.currentBook.Name;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.ImagePath = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, book.ImageID); 
            var image = Image.FromFile(this.ImagePath);
            this.pictureBox1.Image = image;
            this.pictureBox1.Refresh();
            this.NameBox.Text = book.Name;
            this.CountBox.Text = book.Count.ToString();
            this.AuthorBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LibraryEvents.EventManager.OnAuthorListChanged += UpdateAuthorList;
            this.UpdateAuthorList();
        }

        private void UpdateAuthorList()
        {
            List<string> DataSource = new List<string> { "Select an Author", "--Add a New Author--" };
            foreach (var item in DataFileSystem.IO.DataFile.Authors.Select(x => x.FirstName + " " + x.LastName).ToList()) DataSource.Add(item);
            this.AuthorBox.DataSource = DataSource;
            //this.AuthorBox.SelectedIndex = DataFileSystem.IO.DataFile.Authors.IndexOf(this.currentBook.Author) + 1;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var Dialog = MessageBox.Show("Are you sure you want to delete \"" + this.currentBook.Name + "\"", "Delete Confirmation", MessageBoxButtons.YesNo);

            if (Dialog == DialogResult.Yes)
            {
                var pass = new PasswordForm(() => {
                    MessageBox.Show("Deleted \"" + this.currentBook.Name + "\"", "Notification");
                    LibraryHelpers.Data.DeleteEntryFromDataFile(this.currentBook);
                    this.Close();
                });

                pass.Show();
                pass.Focus();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveAndExit_Click(object sender, EventArgs e)
        {
            this.currentBook.Name = this.NameBox.Text;
            this.currentBook.Count = int.Parse(this.CountBox.Text);
            if (this.SelectedAuthor != null) this.currentBook.AuthorID = this.SelectedAuthor.ID;
            this.currentBook.ImageID = this.DefaultImage ? "default_book.png" : LibraryHelpers.ImageHelper.SaveImage(this.currentBook, this.ImagePath);
            DataFileSystem.IO.SaveUserData();
            this.Close();
        }

        private void BookInfoForm_Closing(object sender, FormClosingEventArgs e)
        {
            this.form.BookDictionary.Remove(this.currentBook);
        }

        private void AuthorBox_TextChanged(object sender, EventArgs e)
        {
            if (this.AuthorBox?.SelectedIndex > 0)
            {
                if (this.AuthorBox?.SelectedIndex == 1)
                {
                    if (this.form.CurrentAddNewAuthorForm != null) this.form.CurrentAddNewAuthorForm.Focus();
                    this.form.CurrentAddNewAuthorForm = new AddNewAuthorForm(this.form);
                    this.form.CurrentAddNewAuthorForm.Show();
                }
                else this.SelectedAuthor = DataFileSystem.IO.DataFile.Authors[this.AuthorBox.SelectedIndex - 2];
            }
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
    }
}
