using LibraryApplication.LibraryForms;
using System;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Timer AutoSaveTimer = new Timer { Enabled = true, Interval = 60000 };
            AutoSaveTimer.Tick += new EventHandler(LibraryEvents.EventManager.AutoSave);
            AutoSaveTimer.Start();
            Application.Run(new StartupForm());   
        }
    }
}
