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
            this.currentUser.OnUpdate += new Action(UpdateList);
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
                        resultList.Add(new SearchResult { Name = "\"" + book.Name + "\"", ISBN = book.ISBN, Available = book.Available > 0 ? "Yes (" + book.Available + ")" : "No", Author = "\"" + book.Author.FullName + "\"" });
                    }
                }

                else
                {
                    this.BookList.Rows.Clear();
                }
            }

            else
            {
                foreach (var book in DataFileSystem.IO.DataFile.Books.Where(x => x.Available != 0).ToList())
                {
                    if (this.currentUser.BorrowedBooks.Select(x => x.Book.Name).Contains(book.Name)) continue;
                    if (string.Compare(this.SearchTextBox.Text, book.Name, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(this.SearchTextBox.Text, book.Author?.FullName, StringComparison.OrdinalIgnoreCase) == 0 || book.Name.Contains(this.SearchTextBox.Text) || book.Author.FullName.Contains(this.SearchTextBox.Text) && !string.IsNullOrEmpty(this.SearchTextBox.Text))
                        resultList.Add(new SearchResult { Name = "\"" + book.Name + "\"", ISBN = book.ISBN, Available = book.Available > 0 ? "Yes (" + book.Available + ")" : "No", Author = "\"" + book.Author.FullName + "\"" });
                }
            }

            this.BookList.Rows.Clear();

            foreach (var result in resultList)
                this.BookList.Rows.Add(result.Name, result.Author, result.Available, result.ISBN);
        }

        private void AvailableBookList_DoubleClick(object sender, DataGridViewCellEventArgs e)
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
                        var form = new NewBookBorrowForm(this, book, this.currentUser);
                        form.Show();
                    }                 
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
