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
        private Book currentBook;

        private MainForm form;

        private string ImagePath;

        private bool DefaultImage;

        public BookControl(Book book, MainForm form)
        {
            InitializeComponent();
            this.currentBook = book;
            this.form = form;
            this.Text = "Info about " + this.currentBook.Name;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.ImagePath = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, book.ImageID);
            this.DefaultImage = Path.GetFileName(this.ImagePath) == "default_user.png";

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
            this.AuthorBox.Enabled = DataFileSystem.IO.DataFile.Authors.Count > 0;
            List<string> DataSource = new List<string> { this.AuthorBox.Enabled ? "Select an author" : "No authors set up yet" };
            foreach (var item in DataFileSystem.IO.DataFile.Authors.Select(x => x.FirstName + " " + x.LastName).ToList()) DataSource.Add(item);
            this.AuthorBox.DataSource = DataSource;
            this.AuthorBox.SelectedIndex = DataFileSystem.IO.DataFile.Authors.IndexOf(this.currentBook.Author) + 1;
        }
    }
}
