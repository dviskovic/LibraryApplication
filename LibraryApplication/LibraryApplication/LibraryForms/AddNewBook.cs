using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryForms
{
    public partial class AddNewBook : Form
    {
        private Random random = new Random();

        private MainForm mainForm = null;

        private Author selectedAuthor = null;

        private string imagePath = string.Empty;

        private bool recentlyRequestedNewAuthor = false;

        public AddNewBook(MainForm mainForm)
        {
            this.InitializeComponent();
            this.mainForm = mainForm;
            LibraryEvents.EventManager.OnAuthorListChanged += new Action(() => this.UpdateAuthorList(true));
            this.UpdateAuthorList();   
        }

        private void UpdateAuthorList(bool selectLast = false)
        {
            List<string> dataSource = new List<string> { "Select an Author", "--Add a New Author--" };

            foreach (var item in DataFileSystem.IO.DataFile.Authors.Select(x => x.FirstName + " " + x.LastName).ToList())
            {
                dataSource.Add(item);
            }

            this.AuthorBox.DataSource = dataSource;
            if (selectLast && this.recentlyRequestedNewAuthor)
            {
                try
                {
                    this.AuthorBox.SelectedIndex = dataSource.Count - 1;
                }
                
                catch (Exception)
                {
                    this.AuthorBox.SelectedIndex = dataSource.Count - 2;
                }
            }
        }

        private void TextChangedEvent(object o, EventArgs e)
            {
                if (this.AuthorBox?.SelectedIndex > 0)
                {
                    if (this.AuthorBox?.SelectedIndex == 1)
                    {
                        this.recentlyRequestedNewAuthor = true;

                        if (this.mainForm.CurrentAddNewAuthorForm != null)
                        {
                            this.mainForm.CurrentAddNewAuthorForm.Focus();
                        }

                        else
                        {
                            this.mainForm.CurrentAddNewAuthorForm = new AddNewAuthor(this.mainForm);
                            this.mainForm.CurrentAddNewAuthorForm.Show();
                        }
                    }

                    else
                    {
                        this.selectedAuthor = DataFileSystem.IO.DataFile.Authors[this.AuthorBox.SelectedIndex - 2];
                    }
                }

                this.AddNewBookButton.Enabled = this.CountBox.Text != string.Empty && this.NameBox.Text != string.Empty && this.AuthorBox.SelectedIndex > 1 && this.ISBNTextBox.Text != string.Empty;
            }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string fileName = "default_book.png";

            if (this.imagePath != string.Empty)
            {
                string targetFileName = this.NameBox.Text + this.random.Next().ToString() + Path.GetExtension(this.imagePath);
                string destination = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, targetFileName);
                File.Copy(this.imagePath, destination);
                fileName = targetFileName;
            }

            var ID = "";

            do
            {
                ID = LibraryHelpers.StringHelper.RandomString();
            }

            while (DataFileSystem.IO.DataFile.Books.Select(x => x.ID).Contains(ID));

            DataFileSystem.IO.DataFile.Books.Add(new Book
            {
                ID = ID,
                Count = int.Parse(this.CountBox.Text),
                AuthorID = this.selectedAuthor.ID,
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
            var fileBrowser = new OpenFileDialog
            {
                Title = "Select an image",
                Filter = "Image Files|*.jpg;*.png;*.jpeg;..."
            };
            fileBrowser.ShowDialog();
            this.pictureBox1.ImageLocation = this.imagePath = fileBrowser.FileName;
        }

        private void CountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AddNewBookForm_Closing(object sender, FormClosingEventArgs e)
        {
            LibraryEvents.EventManager.OnAuthorListChanged -= new Action(() => this.UpdateAuthorList());
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
