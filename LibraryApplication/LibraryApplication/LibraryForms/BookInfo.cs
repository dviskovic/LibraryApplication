using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryForms
{
    public partial class BookInfo : Form
    {
        private Author selectedAuthor = null;

        private Book currentBook;

        private MainForm form;

        private string imagePath;

        private bool DefaultImage
        {
            get
            {
                return Path.GetFileName(this.imagePath) == "default_book.png";
            }
        }

        public BookInfo(Book book, MainForm form)
        {
            this.InitializeComponent();
            this.currentBook = book;
            this.form = form;
            this.Text = "Info about \"" + this.currentBook.Name + "\"";
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.imagePath = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, book.ImageID); 
            this.pictureBox1.Image = this.pictureBox1.Image = Image.FromFile(File.Exists(this.imagePath) ? this.imagePath : DataFileSystem.FileLocations.DefaultBookImagePath);
            this.pictureBox1.Refresh();
            this.NameBox.Text = book.Name;
            this.CountBox.Text = book.Count.ToString();
            this.AvailableTextBox.Text = book.Available.ToString();
            this.AuthorBox.DropDownStyle = ComboBoxStyle.DropDownList;
            LibraryEvents.EventManager.OnAuthorListChanged += this.UpdateAuthorList;
            this.UpdateAuthorList();
        }

        private void UpdateAuthorList()
        {
            List<string> dataSource = new List<string> { "Select an Author", "--Add a New Author--" };

            foreach (var item in DataFileSystem.IO.DataFile.Authors.Select(x => x.FirstName + " " + x.LastName).ToList())
            {
                dataSource.Add(item);
            }

            this.AuthorBox.DataSource = dataSource;
            this.AuthorBox.SelectedIndex = DataFileSystem.IO.DataFile.Authors.IndexOf(this.currentBook.Author) + 2;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Are you sure you want to delete \"" + this.currentBook.Name + "\"", "Delete Confirmation", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                var pass = new PasswordForm(() => 
                {
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

            if (this.selectedAuthor != null)
            {
                this.currentBook.AuthorID = this.selectedAuthor.ID;
            }

            this.currentBook.ImageID = this.DefaultImage ? "default_book.png" : LibraryHelpers.ImageHelper.SaveImage(this.currentBook, this.imagePath);
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
                    if (this.form.CurrentAddNewAuthorForm != null)
                    {
                        this.form.CurrentAddNewAuthorForm.Focus();
                    }

                    else
                    {
                        this.form.CurrentAddNewAuthorForm = new AddNewAuthor(this.form);
                        this.form.CurrentAddNewAuthorForm.Show();
                    }
                }

                else
                {
                    this.selectedAuthor = DataFileSystem.IO.DataFile.Authors[this.AuthorBox.SelectedIndex - 2];
                }
            }
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
    }
}
