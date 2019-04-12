using System;
using System.IO;
using System.Windows.Forms;
using LibraryApplication.LibraryForms;
using LibraryApplication.LibraryObjects;
using Newtonsoft.Json;

namespace LibraryApplication.DataFileSystem
{
    public class IO
    {
        public static readonly string FileName = "userdata.json";

        public static DataFile DataFile;

        public static ConfigFile ConfigFile;  

        public static void InitConfig()
        {
            if (!File.Exists(FileLocations.ConfigFilePath))
            {
                IO.ConfigFile = new ConfigFile
                {
                    DataLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };
                SaveConfig();
            }

            IO.ConfigFile = JsonConvert.DeserializeObject<ConfigFile>(File.ReadAllText(FileLocations.ConfigFilePath));

            if (string.IsNullOrEmpty(ConfigFile.Password))
            {
                var setup = new SetupPassword();
                LibraryEvents.EventManager.OnStartupFinished += new Action(() => setup.Show());
            }

            if (ConfigFile.LateFee == 0)
            {
                var feeSetup = new SetUpLateFee();
                LibraryEvents.EventManager.OnStartupFinished += new Action(() => feeSetup.Show());
            }
            
            if (string.IsNullOrEmpty(ConfigFile.DataLocation))
            {
                LibraryEvents.EventManager.OnStartupFinished += new Action(() => 
                {
                    var op = new FolderBrowserDialog
                    {
                        Description = "Select the folder for storing data"
                    };
                    op.ShowDialog();
                    ConfigFile.DataLocation = op.SelectedPath;
                    SaveConfig();
                });
            }

            if (!string.IsNullOrEmpty(ConfigFile.DataLocation))
            {
                FileLocations.DatabasePath = IO.ConfigFile.DataLocation;
            }
        }

        public static void SaveConfig()
        {
            File.WriteAllText(FileLocations.ConfigFilePath, JsonConvert.SerializeObject(IO.ConfigFile, Formatting.Indented));
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
                            LibraryEvents.EventManager.OnStartupFinished += new Action(() => MessageBox.Show("An error occured while loading user data")); 
                            CreateNewDataFile();
                        }

                        else
                        {
                            LibraryEvents.EventManager.OnStartupFinished += new Action(() => MessageBox.Show("An error occured while loading user data but we managed to recover everything"));
                            SaveUserData();
                        }
                    }

                    else
                    {
                        CreateNewDataFile();
                    }

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
                                LibraryEvents.EventManager.OnStartupFinished += new Action(() => MessageBox.Show("An error occured while loading user data"));
                                CreateNewDataFile();
                            }

                            else
                            {
                                LibraryEvents.EventManager.OnStartupFinished += new Action(() => MessageBox.Show("An error occured while loading user data but we managed to recover everything"));
                                SaveUserData();
                            }   
                        }

                        else
                        {
                            File.WriteAllText(Path.Combine(FileLocations.DatabasePath, FileName) + ".broken", File.ReadAllText(Path.Combine(FileLocations.DatabasePath, FileName)));
                            LibraryEvents.EventManager.OnStartupFinished += new Action(() => MessageBox.Show("An error occured while loading user data"));
                            CreateNewDataFile();
                        }
                    }
                }
            }

            catch (Exception)
            {
                LibraryEvents.EventManager.OnStartupFinished += new Action(() => MessageBox.Show("An exception occured while loading user data"));
                CreateNewDataFile();
            }
        }

        public static void SaveUserData()
        {
            IO.DataFile.LastSaveTime = DateTime.UtcNow;

            if (!File.Exists(Path.Combine(FileLocations.DatabasePath, FileName)))
            {
                CreateNewDataFile();
            }

            if (File.Exists(Path.Combine(FileLocations.DatabasePath, FileName) + "2"))
            {
                File.Delete(Path.Combine(FileLocations.DatabasePath, FileName) + "2");
            }

            File.Move(Path.Combine(FileLocations.DatabasePath, FileName), Path.Combine(FileLocations.DatabasePath, FileName) + "2");

            File.WriteAllText(Path.Combine(FileLocations.DatabasePath, FileName), JsonConvert.SerializeObject(IO.DataFile, Formatting.Indented));
            LibraryEvents.EventManager.OnDataFileChanged();
        }

        public static void SetupFolders()
        {
            if (!Directory.Exists(FileLocations.DatabasePath))
            {
                Directory.CreateDirectory(FileLocations.DatabasePath);
            }

            if (!Directory.Exists(FileLocations.ImagesFolderPath))
            {
                Directory.CreateDirectory(FileLocations.ImagesFolderPath);
            } 
        }

        public static void SetupFiles()
        {
            if (!File.Exists(FileLocations.DefaultUserImagePath))
            {
                File.WriteAllBytes(FileLocations.DefaultUserImagePath, LibraryHelpers.ImageHelper.ConvertToByteArray(Properties.Resources.defaultUser));
            }

            if (!File.Exists(FileLocations.DefaultBookImagePath))
            {
                File.WriteAllBytes(FileLocations.DefaultBookImagePath, LibraryHelpers.ImageHelper.ConvertToByteArray(Properties.Resources.defaultBook));
            }
        }

        public static void Wipe()
        {
            DataFile = new DataFile();
            SaveUserData();
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
    }
}
