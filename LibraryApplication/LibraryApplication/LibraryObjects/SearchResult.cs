﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.LibraryObjects
{
    class SearchResult
    {
        public Types Type { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Available { get; set; }

        public string ISBN { get; set; }

        public enum Types
        {
            All,
            Book,
            User
        }

        public static Types ParseFromString(string input)
        {
            Enum.TryParse(input, out Types type);
            return type;
        }

        public static List<string> StringArray()
        {
            return Enum.GetNames(typeof(Types)).ToList();
        }
    }
}
