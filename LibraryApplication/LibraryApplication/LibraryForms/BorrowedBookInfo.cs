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
    public partial class BorrowedBookInfo : Form
    {
        private User user;
        private Book book;
        private UserBooksForm userBooksForm;
        private BookBorrow borrowedBook;

        public BorrowedBookInfo(User user, Book book, UserBooksForm userBooksForm)
        {
            InitializeComponent();
            this.user = user;
            this.userBooksForm = userBooksForm;
            this.book = book;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            var ImagePath = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, book.ImageID);
            this.pictureBox1.Image = Image.FromFile(File.Exists(ImagePath) ? ImagePath : DataFileSystem.FileLocations.DefaultBookImagePath);
            this.Text = user.FullName + " - " + book.Name;
            this.UserTextBox.Text = user.FullName;
            this.BookTextBox.Text = book.Name;
            this.borrowedBook = this.user.BorrowedBooks.FirstOrDefault(x => x.Book.Equals(this.book));
            if (this.borrowedBook == null) return;
            
            this.AtTextBox.Text = TimeZoneInfo.ConvertTimeFromUtc(this.borrowedBook.BorrowedAt, TimeZoneInfo.Local).ToString();
            this.UntilTextBox.Text = TimeZoneInfo.ConvertTimeFromUtc(this.borrowedBook.BorrowedUntil, TimeZoneInfo.Local).ToString();
            var Late = DateTime.UtcNow.Subtract(TimeZoneInfo.ConvertTimeFromUtc(this.borrowedBook.BorrowedUntil, TimeZoneInfo.Local));
            var isLate = Late.TotalMilliseconds > 0;
            var LateString = isLate ? "Yes (" + Late.Days + " day" + (Late.Days > 1 ? "s" : "") + ", " + Math.Round(Late.Days * DataFileSystem.IO.configFile.LateFee, 2) + " HRK)" : "No (" + (this.borrowedBook.BorrowedUntil.Subtract(this.borrowedBook.BorrowedAt).Days) + " day" + (this.borrowedBook.BorrowedUntil.Subtract(this.borrowedBook.BorrowedAt).Days > 1 ? "s" : "") + " left)";
            this.LateTextBox.Text = LateString;
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.user.BorrowedBooks.Remove(this.borrowedBook);
            DataFileSystem.IO.SaveUserData();
            this.userBooksForm.UpdateList();
            this.Close();
        }
    }
}
