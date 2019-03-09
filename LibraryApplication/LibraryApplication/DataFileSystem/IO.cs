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
                IO.configFile = new ConfigFile();
                IO.configFile.DataLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                SaveConfig();
            }

            IO.configFile = JsonConvert.DeserializeObject<ConfigFile>(File.ReadAllText(FileLocations.ConfigFilePath));

            if (string.IsNullOrEmpty(configFile.Password))
            {
                var setup = new SetupPaswordForm();
                setup.Show();
            }

            if (configFile.LateFee == 0)
            {
                var FeeSetup = new SetUpLateFeeForm();
                FeeSetup.Show();
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
            try
            {
                if (!File.Exists(Path.Combine(FileLocations.DatabasePath, FileName)))
                {
                    if (File.Exists(Path.Combine(FileLocations.DatabasePath, FileName) + "2"))
                    {
                        if (!LoadFromFile(Path.Combine(FileLocations.DatabasePath, FileName) + "2"))
                        {
                            File.WriteAllText(Path.Combine(FileLocations.DatabasePath, FileName) + ".broken", File.ReadAllText(Path.Combine(FileLocations.DatabasePath, FileName) + "2"));
                            //MessageBox.Show("An error occured while loading user data");
                            CreateNewDataFile();
                        }

                        else
                        {
                            //MessageBox.Show("An error occured while loading user data but we managed to recover everything");
                            SaveUserData();
                        }
                    }
                    //First time starting the app
                    else CreateNewDataFile();

                    return;
                }

                else
                {
                    if (!LoadFromFile(Path.Combine(FileLocations.DatabasePath, FileName)))
                    {
                        if (File.Exists(Path.Combine(FileLocations.DatabasePath, FileName) + "2"))
                        {
                            if (!LoadFromFile(Path.Combine(FileLocations.DatabasePath, FileName) + "2"))
                            {
                                File.WriteAllText(Path.Combine(FileLocations.DatabasePath, FileName) + ".broken", File.ReadAllText(Path.Combine(FileLocations.DatabasePath, FileName) + "2"));
                                //MessageBox.Show("An error occured while loading user data");
                                CreateNewDataFile();
                            }

                            else
                            {
                                //MessageBox.Show("An error occured while loading user data but we managed to recover everything");
                                SaveUserData();
                            }   
                        }

                        else
                        {
                            File.WriteAllText(Path.Combine(FileLocations.DatabasePath, FileName) + ".broken", File.ReadAllText(Path.Combine(FileLocations.DatabasePath, FileName)));
                            //MessageBox.Show("An error occured while loading user data");
                            CreateNewDataFile();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                //MessageBox.Show("An exception occured while loading user data");
                CreateNewDataFile();
            }
        }

        private static void CreateNewDataFile()
        {
            IO.DataFile = new DataFile();
            File.WriteAllText(Path.Combine(FileLocations.DatabasePath, FileName), JsonConvert.SerializeObject(IO.DataFile, Formatting.Indented));
        }

        private static bool LoadFromFile(string path)
        {
            try
            {
                IO.DataFile = JsonConvert.DeserializeObject<DataFile>(File.ReadAllText(path));
            }

            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static void SaveUserData()
        {
            IO.DataFile.LastSaveTime = DateTime.UtcNow;

            if (!File.Exists(Path.Combine(FileLocations.DatabasePath, FileName)))
            {
                throw new FileNotFoundException("File does not exist on saving!", FileName);
            }

            if (File.Exists(Path.Combine(FileLocations.DatabasePath, FileName) + "2")) File.Delete(Path.Combine(FileLocations.DatabasePath, FileName) + "2");
            File.Move(Path.Combine(FileLocations.DatabasePath, FileName), Path.Combine(FileLocations.DatabasePath, FileName) + "2");

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
