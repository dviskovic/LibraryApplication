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
            this.user.OnUpdate += new Action(UpdateList);
        }

        public void UpdateList()
        {
            this.BookList.Rows.Clear();

            foreach (var book in this.user.BorrowedBooks)
            {
                var Late = DateTime.Now.Subtract(book.BorrowedUntil);
                var LateString = Late.TotalMilliseconds > 0 ? "Yes (" + Late.Days + " day" + (Late.Days > 1 ? "s" : "") + ", " + Math.Round(Late.Days * DataFileSystem.IO.configFile.LateFee, 2) + " HRK)" : "No (" + (book.BorrowedUntil.Subtract(book.BorrowedAt).Days) + " day" + (book.BorrowedUntil.Subtract(book.BorrowedAt).Days > 1 ? "s" : "") + " left)";
                this.BookList.Rows.Add(book.Book.Name, book.Book.Author.FullName, book.Book.ISBN, book.BorrowedAt, book.BorrowedUntil, LateString);
            }
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

        private void BookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (var rowObj in this.BookList.Rows)
            {
                if (rowObj is DataGridViewRow row)
                {
                    string Name = this.BookList.Rows[e.RowIndex].Cells[0].Value.ToString();

                    var item = LibraryHelpers.Data.Find(Name, SearchResult.Types.Book);
                    if (item == null) return;

                    if (item is Book book)
                    {
                        //This is where we open a new form :feelsbadman:
                        MessageBox.Show("HIT " + book.Name);
                        return;
                    }
                }
            }
        }
    }
}
