using System;

namespace LibraryApplication.LibraryEvents
{
    public class EventManager
    {
        public static Action OnDataFileChanged { get; set; }

        public static Action OnAuthorListChanged { get; set; } = new Action(() => { });

        public static Action OnStartupFinished { get; set; } = new Action(() => { });

        public static void AutoSave(object o, EventArgs e)
        {
            DataFileSystem.IO.SaveUserData();
        }

        public static void Startup()
        {
            DataFileSystem.IO.SetupFolders();
            DataFileSystem.IO.SetupFiles();
            DataFileSystem.IO.LoadUserData();
        }
    }
}
