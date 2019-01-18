using LibraryApplication.LibraryForms;
using LibraryApplication.LibraryObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApplication.DataFileSystem
{
    class IO
    {
        public static DataFile DataFile;
        public static ConfigFile configFile;
        public static readonly string FileName = "userdata.json";

        public static void InitConfig()
        {
            if (!File.Exists(FileLocations.ConfigFilePath))
            {
                MessageBox.Show("It appears that you are running the application first time, please select the folder for saving data");
                IO.configFile = new ConfigFile();
                var op = new FolderBrowserDialog
                {
                    Description = "Select the folder for storing data"
                };
                op.ShowDialog();

                if (!string.IsNullOrEmpty(op.SelectedPath)) configFile.DataLocation = op.SelectedPath;

                SaveConfig();
            }

            IO.configFile = JsonConvert.DeserializeObject<ConfigFile>(File.ReadAllText(FileLocations.ConfigFilePath));

            if (string.IsNullOrEmpty(configFile.Password))
            {
                var setup = new SetupPaswordForm();
                setup.Show();
            }
            
            if (string.IsNullOrEmpty(configFile.DataLocation))
            {
                var op = new FolderBrowserDialog
                {
                    Description = "Select the folder for storing data"
                };
                op.ShowDialog();
                configFile.DataLocation = op.SelectedPath;
                SaveConfig();
            }

            if (!string.IsNullOrEmpty(configFile.DataLocation)) FileLocations.DatabasePath = IO.configFile.DataLocation;
        }

        public static void SaveConfig()
        {
            File.WriteAllText(FileLocations.ConfigFilePath, JsonConvert.SerializeObject(IO.configFile, Formatting.Indented));
        }

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
                throw new Exception("File does not exist on saving!");
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

        public static void SetupFiles()
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
