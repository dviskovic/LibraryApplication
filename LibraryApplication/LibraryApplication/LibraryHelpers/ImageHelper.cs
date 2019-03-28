using System;
using System.Drawing;
using System.IO;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication.LibraryHelpers
{
    public class ImageHelper
    {
        private static Random random = new Random();

        public static byte[] ConvertToByteArray(Image image)
        {
            var stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }

        public static string SaveImage(User user, string path)
        {
            if (!File.Exists(path))
            {
                return string.Empty;
            }

            string targetFileName = user.FirstName + "_" + user.LastName + random.Next().ToString() + Path.GetExtension(path);
            string destination = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, targetFileName);
            File.Copy(path, destination);
            return targetFileName;
        }

        public static string SaveImage(Book book, string path)
        {
            if (!File.Exists(path))
            {
                return string.Empty;
            }

            string targetFileName = book.Name + random.Next().ToString() + Path.GetExtension(path);
            string destination = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, targetFileName);
            File.Copy(path, destination);
            return targetFileName;
        }
    }
}
