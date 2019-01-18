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
            var resultList = new List<SearchResult>();

            foreach (var book in this.user.BorrowedBooks)
            {
                resultList.Add(new SearchResult { Name = book.Book.Name, Author = book.Book.Author.FullName, ISBN = book.Book.ISBN});
            }

            this.BookList.Rows.Clear();

            foreach (var result in resultList)
                this.BookList.Rows.Add(result.Name, result.Author, result.ISBN);
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
                    }
                }
            }
        }
    }
}
