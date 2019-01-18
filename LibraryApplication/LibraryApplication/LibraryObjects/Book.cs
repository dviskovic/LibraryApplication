using Newtonsoft.Json;
using System.Linq;

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
                return this.Count - DataFileSystem.IO.DataFile.Users.Select(x => x.BorrowedBooks.Where(bborrow => bborrow.Book.Name == this.Name && bborrow.Book == this)).Count();
            }
        }
    }
}
