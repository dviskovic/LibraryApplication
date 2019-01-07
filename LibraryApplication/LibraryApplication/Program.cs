using LibraryApplication.DataFileSystem;
using LibraryApplication.LibraryForms;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace LibraryApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!File.Exists(FileLocations.NewtonsoftJson)) File.WriteAllBytes(FileLocations.NewtonsoftJson, Properties.Resources.Newtonsoft_Json);
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolve);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataFileSystem.IO.InitConfig();
            DataFileSystem.IO.SetupFolders();

            Timer AutoSaveTimer = new Timer { Enabled = true, Interval = 60000 };
            AutoSaveTimer.Tick += new EventHandler(LibraryEvents.EventManager.AutoSave);
            AutoSaveTimer.Start();
            Application.Run(new StartupForm());
        }

        private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Assembly.LoadFile(FileLocations.NewtonsoftJson);
        }
    }
}
