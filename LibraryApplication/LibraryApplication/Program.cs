using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using LibraryApplication.DataFileSystem;
using LibraryApplication.LibraryForms;

namespace LibraryApplication
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            if (!Directory.Exists(FileLocations.DatabasePath))
            {
                Directory.CreateDirectory(FileLocations.DatabasePath);
            }

            if (!File.Exists(FileLocations.NewtonsoftJson))
            {
                File.WriteAllBytes(FileLocations.NewtonsoftJson, Properties.Resources.Newtonsoft_Json);
            }

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolve);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataFileSystem.IO.InitConfig();
            DataFileSystem.IO.SetupFolders();

            Timer autoSaveTimer = new Timer { Enabled = true, Interval = 60000 };
            autoSaveTimer.Tick += new EventHandler(LibraryEvents.EventManager.AutoSave);
            autoSaveTimer.Start();
            Application.Run(new StartupForm());
        }

        private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Assembly.LoadFile(FileLocations.NewtonsoftJson);
        }
    }
}
