using Newtonsoft.Json;
using System.Collections.Generic;

namespace LibraryApplication.LibraryObjects
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageID { get; set; }

        [JsonIgnore]
        public string FullName { get { return FirstName + " " + LastName; } }

        public List<BookBorrow> BorrowedBooks = new List<BookBorrow>();
    }
}
