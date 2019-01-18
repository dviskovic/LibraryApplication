using LibraryApplication.LibraryObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.LibraryHelpers
{
    class ImageHelper
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
            if (!File.Exists(path)) return string.Empty;

            string TargetFileName = user.FirstName + "_" + user.LastName + random.Next().ToString() + Path.GetExtension(path);
            string Destination = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, TargetFileName);
            File.Copy(path, Destination);
            return TargetFileName;
        }

        public static string SaveImage(Book book, string path)
        {
            if (!File.Exists(path)) return string.Empty;

            string TargetFileName = book.Name + random.Next().ToString() + Path.GetExtension(path);
            string Destination = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, TargetFileName);
            File.Copy(path, Destination);
            return TargetFileName;
        }
    }
}
