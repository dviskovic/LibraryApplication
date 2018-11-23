using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApplication.LibraryObjects
{
    class SearchResultType
    {
        public enum Type
        {
            All,
            Books,
            Users
        }

        public static Type ParseFromString(string input)
        {
            Enum.TryParse(input, out Type type);
            return type;
        }

        public static List<string> StringArray()
        {
            return Enum.GetNames(typeof(Type)).ToList();
        }
    }
}
