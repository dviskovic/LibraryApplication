using System;
using System.Drawing;
using System.Windows.Forms;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryForms
{
    public partial class UserBooks : Form
    {
        public BookSearch AddNewBookBorrowForm;

        private User user;

        private UserInfo userControl;

        public UserBooks(UserInfo userControl, User user)
        {
            this.userControl = userControl;
            this.user = user;
            this.InitializeComponent();
            this.Text = user.FullName + " - Borrowed Books";
            this.UpdateList();
            this.user.OnUpdate += this.UpdateList;
        }

        public void UpdateList()
        {
            this.BookList.Rows.Clear();

            foreach (var book in this.user.BorrowedBooks)
            {
                var late = DateTime.UtcNow.Subtract(TimeZoneInfo.ConvertTimeFromUtc(book.BorrowedUntil, TimeZoneInfo.Local));
                var isLate = late.TotalMilliseconds > 0;
                var lateString = isLate ? "Yes (" + late.Days + " day" + (late.Days > 1 ? "s" : "") + ", " + Math.Round(late.Days * DataFileSystem.IO.ConfigFile.LateFee, 2) + " HRK)" : "No (" + Math.Ceiling(book.BorrowedUntil.Subtract(book.BorrowedAt).TotalDays) + " day" + (Math.Ceiling(book.BorrowedUntil.Subtract(book.BorrowedAt).TotalDays) > 1 ? "s" : "") + " left)";
                var ID = this.BookList.Rows.Add(book.Book.Name, book.Book.Author.FullName, book.Book.ISBN, TimeZoneInfo.ConvertTimeFromUtc(book.BorrowedAt, TimeZoneInfo.Local), TimeZoneInfo.ConvertTimeFromUtc(book.BorrowedUntil, TimeZoneInfo.Local), lateString);

                if (isLate)
                {
                    var style = this.BookList.Rows[ID].Cells[this.BookList.Rows[ID].Cells.Count - 1].Style;
                    style.ForeColor = Color.Red;
                    style.BackColor = Color.Gray;
                    style.Font = new Font(this.BookList.Font, FontStyle.Bold);
                }
            }
        }

        private void UserBooksForm_Closing(object sender, FormClosingEventArgs e)
        {
            this.userControl.UserBooks = null;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.UpdateList();
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            if (this.AddNewBookBorrowForm != null)
            {
                this.AddNewBookBorrowForm.Focus();
            }

            else
            {
                this.AddNewBookBorrowForm = new BookSearch(this, this.user);
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

                    if (item == null)
                    {
                        return;
                    }

                    if (item is Book book)
                    {
                        var form = new BorrowedBookInfo(this.user, item, this);
                        form.Show();
                        return;
                    }
                }
            }
        }
    }
}
