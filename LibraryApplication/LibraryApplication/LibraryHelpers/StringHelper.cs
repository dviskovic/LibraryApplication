using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApplication.LibraryHelpers
{
    public static class StringHelper
    {
        public static bool IncludesOrEqual(this string Str, string Second)
        {
            return Str.ToLower().Contains(Second) || string.Compare(Str, Second, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static bool IsInt(this string Str)
        {
            return int.TryParse(Str, out int a);
        }
    }
}
