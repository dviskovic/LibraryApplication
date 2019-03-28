using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApplication.LibraryHelpers
{
    public static class StringHelper
    {
        public static bool IncludesOrEqual(this string str, string second)
        {
            return str.ToLower().Contains(second.ToLower()) || string.Compare(str, second, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static bool IsInt(this string str)
        {
            return int.TryParse(str, out int a);
        }
    }
}
