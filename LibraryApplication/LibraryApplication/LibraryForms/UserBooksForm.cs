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
    public partial class UserBooksForm : Form
    {
        private User user;

        private UserControl userControl;

        public AddNewBookBorrowForm AddNewBookBorrowForm;

        public UserBooksForm(UserControl userControl, User user)
        {
            this.userControl = userControl;
            this.user = user;
            InitializeComponent();
            this.Text = "\"" + user.FullName + "\"'s Borrowed Books";
            this.UpdateList();
        }

        public void UpdateList()
        {
            GC.Collect();
            var resultList = new List<SearchResult>();

            foreach (var book in this.user.BorrowedBooks)
            {
                resultList.Add(new SearchResult { Text = book.Book.Name, Image = string.IsNullOrEmpty(book.Book.ImageID) ? "default_book.png" : book.Book.ImageID });
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

            this.BookList.BeginUpdate();
            this.BookList.Clear();
            this.BookList.LargeImageList = imagelist;

            foreach (var result in resultList)
                this.BookList.Items.Add(new ListViewItem(result.Text, result.Image));

            this.BookList.EndUpdate();
        }

        private void UserBooksForm_Closing(object sender, FormClosingEventArgs e)
        {
            this.userControl.userBooks = null;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.UpdateList();
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            if (this.AddNewBookBorrowForm != null) this.AddNewBookBorrowForm.Focus();
            else
            {
                this.AddNewBookBorrowForm = new AddNewBookBorrowForm(this, this.user);
                this.AddNewBookBorrowForm.Show();
            }
        }

        private void BookList_DoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in this.BookList.Items)
            {
                if (item.Bounds.Contains(new Point(e.X, e.Y)))
                {
                    MessageBox.Show("HIT " + item.Text);
                    return;
                }
            }
        }
    }
}
