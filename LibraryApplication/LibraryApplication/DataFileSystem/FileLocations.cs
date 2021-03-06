using System;
using System.IO;

namespace LibraryApplication.DataFileSystem
{
    public class FileLocations
    {
        public static string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LibraryApplication");

        public static readonly string ConfigFilePath = Path.Combine(DatabasePath, "config.json");

        public static readonly string ImagesFolderPath = Path.Combine(DatabasePath, "Images");

        public static readonly string DefaultUserImagePath = Path.Combine(ImagesFolderPath, "default_user.png");

        public static readonly string DefaultBookImagePath = Path.Combine(ImagesFolderPath, "default_book.png");

        public static readonly string NewtonsoftJson = Path.Combine(DatabasePath, "Newtonsoft.Json.dll");
    }
}
