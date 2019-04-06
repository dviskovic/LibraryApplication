using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryForms
{
    public partial class BookSearch : Form
    {
        private UserBooks userBooksForm;

        private User currentUser;

        public BookSearch(UserBooks userBooksForm, User user)
        {
            this.currentUser = user;
            this.userBooksForm = userBooksForm;
            this.InitializeComponent();
            this.UpdateList();
            this.currentUser.OnUpdate += new Action(this.UpdateList);
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
                        if (this.currentUser.BorrowedBooks.Select(x => x.BookID).Contains(book.ID))
                        {
                            continue;
                        }

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
                    if (this.currentUser.BorrowedBooks.Select(x => x.BookID).Contains(book.ID))
                    {
                        continue;
                    }

                    if ((string.Compare(this.SearchTextBox.Text, book.Name, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(this.SearchTextBox.Text, book.Author?.FullName, StringComparison.OrdinalIgnoreCase) == 0 || book.Name.Contains(this.SearchTextBox.Text) || book.Author.FullName.Contains(this.SearchTextBox.Text)) && !string.IsNullOrEmpty(this.SearchTextBox.Text))
                    {
                        resultList.Add(new SearchResult { Name = "\"" + book.Name + "\"", ISBN = book.ISBN, Available = book.Available > 0 ? "Yes (" + book.Available + ")" : "No", Author = "\"" + book.Author.FullName + "\"" });
                    }
                }
            }

            this.BookList.Rows.Clear();

            foreach (var result in resultList)
            {
                this.BookList.Rows.Add(result.Name, result.Author, result.Available, result.ISBN);
            }
        }

        private void AvailableBookList_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (var rowObj in this.BookList.Rows)
            {
                if (rowObj is DataGridViewRow row)
                {
                    string Name = this.BookList.Rows[e.RowIndex].Cells[0].Value.ToString();

                    var item = LibraryHelpers.Data.Find(Name, SearchResult.Types.Book);

                    if (item == null)
                    {
                        return;
                    }
                   
                    if (item is Book book)
                    {
                        var form = new NewBookBorrow(this, book, this.currentUser);
                        form.Show();
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
