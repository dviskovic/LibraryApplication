using LibraryApplication.LibraryObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryApplication.LibraryObjects
{
    class DataFile
    {
        public List<Book> Books = new List<Book>();

        public List<User> Users = new List<User>();

        public List<Author> Authors = new List<Author>();

        public DateTime LastSaveTime = DateTime.UtcNow;
    }
}
