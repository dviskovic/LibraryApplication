using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        public List<BorrowedBook> BorrowedBooks = new List<BorrowedBook>();

        [JsonIgnore]
        public Action OnUpdate = new Action(() => { });

        [JsonIgnore]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        [JsonIgnore]
        public int BorrowedBookCount
        {
            get
            {
                return this.BorrowedBooks.Count;
            }
        }
    }
}
