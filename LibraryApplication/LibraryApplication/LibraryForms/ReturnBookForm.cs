using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryForms
{
    public partial class ReturnBookForm : Form
    {
        private User user;
        private Book book;
        private UserBooks userBooksForm;
        private BorrowedBook borrowedBook;

        public ReturnBookForm(User user, Book book, UserBooks userBooksForm)
        {
            this.InitializeComponent();
            this.user = user;
            this.userBooksForm = userBooksForm;
            this.book = book;
            var imagePath = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, book.ImageID);
            this.pictureBox1.Image = Image.FromFile(File.Exists(imagePath) ? imagePath : DataFileSystem.FileLocations.DefaultBookImagePath);
            this.Text = user.FullName + " - " + book.Name;
            this.UserTextBox.Text = user.FullName;
            this.BookTextBox.Text = book.Name;
            this.borrowedBook = this.user.BorrowedBooks.FirstOrDefault(x => x.BookID == this.book.ID);

            if (this.borrowedBook == null) return;

            this.AtTextBox.Text = TimeZoneInfo.ConvertTimeFromUtc(this.borrowedBook.BorrowedAt, TimeZoneInfo.Local).ToString();
            this.UntilTextBox.Text = TimeZoneInfo.ConvertTimeFromUtc(this.borrowedBook.BorrowedUntil, TimeZoneInfo.Local).ToString();
            var late = DateTime.UtcNow.Subtract(TimeZoneInfo.ConvertTimeFromUtc(this.borrowedBook.BorrowedUntil, TimeZoneInfo.Local));
            var isLate = late.TotalMilliseconds > 0;
            var lateString = isLate ? "Yes (" + late.Days + " day" + (late.Days > 1 ? "s" : "") + ", " + Math.Round(late.Days * DataFileSystem.IO.ConfigFile.LateFee, 2) + " HRK)" : "No (" + Math.Abs(late.Days) + " day" + (Math.Abs(late.Days) > 1 ? "s" : "") + " day" + (Math.Abs(late.Days) > 1 ? "s" : "") + " left)";
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
