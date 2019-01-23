using LibraryApplication.LibraryObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryApplication.LibraryForms
{
    public partial class NewBookBorrowForm : Form
    {
        private Book book;

        private User user;

        private AddNewBookBorrowForm form;

        private DateTime Now = DateTime.Now;

        private DateTime ToDate = DateTime.Now;

        public NewBookBorrowForm(AddNewBookBorrowForm form, Book book, User user)
        {
            this.book = book;
            this.form = form;
            this.user = user;

            InitializeComponent();

            this.BorrowButton.Enabled = false;
            this.BookNameTextBox.Text = this.book.Name;
            this.UserNameTextBox.Text = this.user.FullName;
            this.SinceTextBox.Text = Now.ToString();
            this.ToTextBox.Text = "Not set";
            this.DaysTextBox.Text = "Not set";
        }

        private void TextUpdate(object o, EventArgs e)
        {
            this.BorrowButton.Enabled = this.ToTextBox.Text != string.Empty && this.SinceTextBox.Text != string.Empty && DateTime.TryParse(this.ToTextBox.Text, out this.ToDate) && this.ToDate.Subtract(this.Now).TotalHours >= 1;
        }

        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.ToDate = new DateTime(e.Start.Year, e.Start.Month, e.Start.Day, this.Now.Hour, this.Now.Minute + 1, this.Now.Second);
            this.ToTextBox.Text = this.ToDate.ToString();
            var ETAText = LibraryHelpers.Data.GetReadableTimeFromTimeSpan(this.ToDate.Subtract(this.Now));
            this.DaysTextBox.Text = (ETAText == "Now" ? "Invalid Date!" : ETAText);
            this.TextUpdate(null, null);
        }

        private void BorrowButton_Click(object sender, EventArgs e)
        {
            this.user.BorrowedBooks.Add(new BookBorrow
            {
                Book = this.book,
                BorrowedAt = this.Now,
                BorrowedUntil = this.ToDate
            });

            DataFileSystem.IO.SaveUserData();
            this.user.OnUpdate();
            this.form.Close();
            this.Close();
        }
    }
}
