using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryForms
{
    public partial class UserBooks : Form
    {
        public BookSearch AddNewBookBorrowForm;

        private User user;

        public UserBooks(User user)
        {
            this.user = user;
            this.InitializeComponent();
            this.Text = user.FullName + " - Borrowed Books";
            this.UpdateList();
            this.user.OnUpdate += this.UpdateList;
        }

        public void UpdateList()
        {
            if (this.BookList.IsDisposed || this.BookList.Disposing) return;
            this.BookList.Rows.Clear();

            foreach (var book in this.user.BorrowedBooks)
            {
                Book b = DataFileSystem.IO.DataFile.Books.FirstOrDefault(x => x.ID == book.BookID);

                if (b == null)
                {
                    continue;
                }

                var late = DateTime.UtcNow.Subtract(TimeZoneInfo.ConvertTimeFromUtc(book.BorrowedUntil, TimeZoneInfo.Local));
                var isLate = late.TotalMilliseconds > 0;

                var lateString = isLate ? "Yes (" + late.Days + " day" + (late.Days > 1 ? "s" : "") + ", " + Math.Round(late.Days * DataFileSystem.IO.ConfigFile.LateFee, 2) + " HRK)" : "No (" + Math.Abs(late.Days) + " day" + (Math.Abs(late.Days) > 1 ? "s" : "") + " left)";

                var ID = this.BookList.Rows.Add(b.Name, b.Author.FullName, b.ISBN, TimeZoneInfo.ConvertTimeFromUtc(book.BorrowedAt, TimeZoneInfo.Local), TimeZoneInfo.ConvertTimeFromUtc(book.BorrowedUntil, TimeZoneInfo.Local), lateString);

                if (isLate)
                {
                    var style = this.BookList.Rows[ID].Cells[this.BookList.Rows[ID].Cells.Count - 1].Style;
                    style.ForeColor = Color.Red;
                    style.BackColor = Color.Gray;
                    style.Font = new Font(this.BookList.Font, FontStyle.Bold);
                }
            }
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
                this.AddNewBookBorrowForm.FormClosing += new FormClosingEventHandler((o2, e2) => this.AddNewBookBorrowForm = null);
            }
        }

        private void BookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Name = this.BookList.Rows[e.RowIndex].Cells[0].Value.ToString();

            var item = LibraryHelpers.Data.Find(Name, SearchResult.Types.Book);

            if (item == null)
            {
                return;
            }

            if (item is Book book)
            {
                var form = new ReturnBook(this.user, item, this);
                form.Show();
                return;
            }
        }
    }
}
