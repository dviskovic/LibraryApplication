using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.DataFileSystem
{
    class FileLocations
    {
        public static readonly string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LibraryApplication");

        public static readonly string ImagesFolderPath = Path.Combine(DatabasePath, "Images");

        public static readonly string DefaultUserImagePath = Path.Combine(ImagesFolderPath, "default_user.png");

        public static readonly string DefaultBookImagePath = Path.Combine(ImagesFolderPath, "default_book.png");

        public static readonly string NewtonsoftJson = Path.Combine(DatabasePath, "Newtonsoft.Json.dll");
    }
}
