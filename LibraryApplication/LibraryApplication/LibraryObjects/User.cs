using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LibraryApplication.LibraryObjects
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string ImageID { get; set; }

        [JsonIgnore]
        public string FullName { get { return FirstName + " " + LastName; } }

        public List<BookBorrow> BorrowedBooks = new List<BookBorrow>();

        [JsonIgnore]
        public Action OnUpdate = new Action(() => { });
    }
}
