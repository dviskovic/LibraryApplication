using LibraryApplication.LibraryObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.DataFileSystem
{
    class IO
    {
        public static DataFile DataFile;
        public static readonly string FileName = "userdata.json";

        public static void LoadUserData()
        {
            if (!File.Exists(Path.Combine(FileLocations.DatabasePath, FileName)))
            {
                IO.DataFile = new DataFile();
                File.WriteAllText(Path.Combine(FileLocations.DatabasePath, FileName), JsonConvert.SerializeObject(IO.DataFile, Formatting.Indented));
                return;
            }

            IO.DataFile = JsonConvert.DeserializeObject<DataFile>(File.ReadAllText(Path.Combine(FileLocations.DatabasePath, FileName)));
        }

        public static void SaveUserData()
        {
            IO.DataFile.LastSaveTime = DateTime.UtcNow;

            if (!File.Exists(Path.Combine(FileLocations.DatabasePath, FileName)))
            {
                throw new Exception("File does not exist on saving!!");
            }

            File.WriteAllText(Path.Combine(FileLocations.DatabasePath, FileName), JsonConvert.SerializeObject(IO.DataFile, Formatting.Indented));
            LibraryEvents.EventManager.OnDataFileChanged();
        }

        public static void SetupFolders()
        {
            if (!Directory.Exists(FileLocations.DatabasePath)) Directory.CreateDirectory(FileLocations.DatabasePath);

            if (!Directory.Exists(FileLocations.ImagesFolderPath))
                Directory.CreateDirectory(FileLocations.ImagesFolderPath);
        }

        public static void DefaultImage()
        {
            if (!File.Exists(FileLocations.DefaultUserImagePath)) File.WriteAllBytes(FileLocations.DefaultUserImagePath, LibraryHelpers.ImageHelper.ConvertToByteArray(Properties.Resources.defaultUser));
            if (!File.Exists(FileLocations.DefaultBookImagePath)) File.WriteAllBytes(FileLocations.DefaultBookImagePath, LibraryHelpers.ImageHelper.ConvertToByteArray(Properties.Resources.defaultBook));
        }

        public static void Wipe()
        {
            DataFile = new DataFile();
            SaveUserData();
        }
    }
}
