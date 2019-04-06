﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace LibraryApplication.LibraryObjects
{
    public class Book : IEquatable<Book>
    {
        public string Name { get; set; }

        public string ImageID { get; set; }

        public int Count { get; set; }

        public int AuthorID { get; set; }

        public string ISBN { get; set; }

        public string ID { get; }

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
                var borrowedCount = DataFileSystem.IO.DataFile.Users.Count(x => x.BorrowedBooks.Any(bborrow => bborrow.BookID == this.ID));
                return this.Count - borrowedCount;
            }
        }

        public bool Equals(Book other)
        {
            if (this == null || other == null)
            {
                return false;
            }

            return this.AuthorID == other.AuthorID && this.Name == other.Name && this.ISBN == other.ISBN;
        }
    }
}
