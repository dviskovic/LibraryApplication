using Newtonsoft.Json;
using System.Linq;
using System.Windows.Forms;

namespace LibraryApplication.LibraryObjects
{
    public class Book
    {
        public string Name { get; set; }

        public string ImageID { get; set; }

        public int Count { get; set; }

        public int AuthorID { get; set; }

        public string ISBN { get; set; }

        [JsonIgnore]
        public Author Author
        {
            get
            {
                return DataFileSystem.IO.DataFile.Authors.FirstOrDefault(x => x.ID == this.AuthorID);
            }
        }

        [JsonIgnore]
        public int Available
        {
            get
            {
                var BorrowedCount = DataFileSystem.IO.DataFile.Users.Count(x => x.BorrowedBooks.Any(bborrow => bborrow.Book.Name == this.Name && bborrow.Book == this));
                return this.Count - BorrowedCount;
            }
        }
    }
}
