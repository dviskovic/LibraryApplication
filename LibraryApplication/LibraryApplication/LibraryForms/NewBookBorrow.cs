using System;
using System.Windows.Forms;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryForms
{
    public partial class NewBookBorrow : Form
    {
        private Book book;

        private User user;

        private BookSearch form;

        private DateTime now = DateTime.Now;

        private DateTime toDate = DateTime.Now;

        public NewBookBorrow(BookSearch form, Book book, User user)
        {
            this.book = book;
            this.form = form;
            this.user = user;

            this.InitializeComponent();

            this.BorrowButton.Enabled = false;
            this.BookNameTextBox.Text = this.book.Name;
            this.UserNameTextBox.Text = this.user.FullName;
            this.SinceTextBox.Text = this.now.ToString();
            this.ToTextBox.Text = "Not set";
            this.DaysTextBox.Text = "Not set";
        }

        private void TextUpdate(object o, EventArgs e)
        {
            this.BorrowButton.Enabled = this.ToTextBox.Text != string.Empty && this.SinceTextBox.Text != string.Empty && DateTime.TryParse(this.ToTextBox.Text, out this.toDate) && this.toDate.Subtract(this.now).TotalHours >= 1;
        }

        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.toDate = new DateTime(e.Start.Year, e.Start.Month, e.Start.Day, this.now.Hour, this.now.Minute, this.now.Second);
            this.toDate = this.toDate.AddMinutes(1);
            this.ToTextBox.Text = this.toDate.ToString();
            var etaText = LibraryHelpers.Data.GetReadableTimeFromTimeSpan(this.toDate.Subtract(this.now));
            this.DaysTextBox.Text = etaText == "Now" ? "Invalid Date!" : etaText;
            this.TextUpdate(null, null);
        }

        private void BorrowButton_Click(object sender, EventArgs e)
        {
            this.user.BorrowedBooks.Add(new BorrowedBook
            {
                Book = this.book,
                BorrowedAt = TimeZoneInfo.ConvertTimeToUtc(this.now),
                BorrowedUntil = TimeZoneInfo.ConvertTimeToUtc(this.toDate)
            });

            DataFileSystem.IO.SaveUserData();
            this.user.OnUpdate();
            this.form.Close();
            this.Close();
        }
    }
}
