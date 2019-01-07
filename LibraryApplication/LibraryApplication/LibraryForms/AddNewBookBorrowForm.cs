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
    public partial class AddNewBookBorrowForm : Form
    {
        private UserBooksForm userBooksForm;

        private User currentUser;

        public AddNewBookBorrowForm(UserBooksForm userBooksForm, User user)
        {
            this.currentUser = user;
            this.userBooksForm = userBooksForm;
            InitializeComponent();

            this.UpdateList();
        }

        public void UpdateList()
        {
            GC.Collect();
            var resultList = new List<SearchResult>();

            if (string.IsNullOrEmpty(this.SearchTextBox.Text))
            {
                if (this.ShowAllCheckBox.Checked)
                {
                    foreach (var book in DataFileSystem.IO.DataFile.Books.Where(x => x.Available != 0).ToList())
                    {
                        if (this.currentUser.BorrowedBooks.Select(x => x.Book.Name).Contains(book.Name)) continue;
                        resultList.Add(new SearchResult { Text = book.Name, Image = string.IsNullOrEmpty(book.ImageID) ? "default_book.png" : book.ImageID });
                    }
                }

                else
                {
                    this.AvailableBookList.BeginUpdate();
                    this.AvailableBookList.Items.Clear();
                    this.AvailableBookList.EndUpdate();
                }
            }

            else
            {
                foreach (var book in DataFileSystem.IO.DataFile.Books.Where(x => x.Available != 0).ToList())
                {
                    if (this.currentUser.BorrowedBooks.Select(x => x.Book.Name).Contains(book.Name)) continue;
                    if (string.Compare(this.SearchTextBox.Text, book.Name, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(this.SearchTextBox.Text, book.Author?.FullName, StringComparison.OrdinalIgnoreCase) == 0 || book.Name.Contains(this.SearchTextBox.Text) || book.Author.FullName.Contains(this.SearchTextBox.Text) && !string.IsNullOrEmpty(this.SearchTextBox.Text))
                    resultList.Add(new SearchResult { Text = book.Name, Image = string.IsNullOrEmpty(book.ImageID) ? "default_book.png" : book.ImageID });
                }
            }

            var imagelist = new ImageList
            {
                ImageSize = new Size(64, 64),
                ColorDepth = ColorDepth.Depth32Bit
            };

            foreach (var result in resultList)
            {
                string path = string.Empty;

                if (!string.IsNullOrEmpty(result.Image))
                {
                    path = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, result.Image);
                }

                else path = DataFileSystem.FileLocations.DefaultUserImagePath;
                imagelist.Images.Add(result.Image, Image.FromFile(path));
            }

            this.AvailableBookList.BeginUpdate();
            this.AvailableBookList.Clear();
            this.AvailableBookList.LargeImageList = imagelist;

            foreach (var result in resultList)
                this.AvailableBookList.Items.Add(new ListViewItem(result.Text, result.Image));

            this.AvailableBookList.EndUpdate();
        }

        private void AvailableBookList_DoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in this.AvailableBookList.Items)
            {
                if (item.Bounds.Contains(new Point(e.X, e.Y)))
                {
                    var res = LibraryHelpers.Data.FindByNameAndImage(item.Text, item.ImageKey);
                    if (res is Book book)
                    {
                        this.currentUser.BorrowedBooks.Add(new BookBorrow { Book = res, BorrowTime = DateTime.UtcNow });
                        this.userBooksForm.UpdateList();
                        this.userBooksForm.AddNewBookBorrowForm = null;
                        this.Close();
                    }

                    return;
                }
            }
        }

        private void AddNewBookBorrowForm_Closing(object sender, FormClosingEventArgs e)
        {
            this.userBooksForm.AddNewBookBorrowForm = null;
        }

        private void SearchQueryChanged(object sender, EventArgs e)
        {
            this.UpdateList();
        }
    }
}
