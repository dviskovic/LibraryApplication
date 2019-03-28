using System;
using System.Collections.Generic;

namespace LibraryApplication.LibraryObjects
{
    public class DataFile
    {
        public List<Book> Books = new List<Book>();

        public List<User> Users = new List<User>();

        public List<Author> Authors = new List<Author>();

        public DateTime LastSaveTime = DateTime.UtcNow;
    }
}
