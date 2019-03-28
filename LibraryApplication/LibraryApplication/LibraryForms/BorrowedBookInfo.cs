using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryForms
{
    public partial class BorrowedBookInfo : Form
    {
        private User user;
        private Book book;
        private UserBooks userBooksForm;
        private BorrowedBook borrowedBook;

        public BorrowedBookInfo(User user, Book book, UserBooks userBooksForm)
        {
            this.InitializeComponent();
            this.user = user;
            this.userBooksForm = userBooksForm;
            this.book = book;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            var imagePath = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, book.ImageID);
            this.pictureBox1.Image = Image.FromFile(File.Exists(imagePath) ? imagePath : DataFileSystem.FileLocations.DefaultBookImagePath);
            this.Text = user.FullName + " - " + book.Name;
            this.UserTextBox.Text = user.FullName;
            this.BookTextBox.Text = book.Name;
            this.borrowedBook = this.user.BorrowedBooks.FirstOrDefault(x => x.Book.Equals(this.book));

            if (this.borrowedBook == null)
            {
                return;
            }
            
            this.AtTextBox.Text = TimeZoneInfo.ConvertTimeFromUtc(this.borrowedBook.BorrowedAt, TimeZoneInfo.Local).ToString();
            this.UntilTextBox.Text = TimeZoneInfo.ConvertTimeFromUtc(this.borrowedBook.BorrowedUntil, TimeZoneInfo.Local).ToString();
            var late = DateTime.UtcNow.Subtract(TimeZoneInfo.ConvertTimeFromUtc(this.borrowedBook.BorrowedUntil, TimeZoneInfo.Local));
            var isLate = late.TotalMilliseconds > 0;
            var lateString = isLate ? "Yes (" + late.Days + " day" + (late.Days > 1 ? "s" : "") + ", " + Math.Round(late.Days * DataFileSystem.IO.ConfigFile.LateFee, 2) + " HRK)" : "No (" + Math.Ceiling(this.borrowedBook.BorrowedUntil.Subtract(this.borrowedBook.BorrowedAt).TotalDays) + " day" + (Math.Ceiling(this.borrowedBook.BorrowedUntil.Subtract(this.borrowedBook.BorrowedAt).TotalDays) > 1 ? "s" : "") + " left)";
            this.LateTextBox.Text = lateString;
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
