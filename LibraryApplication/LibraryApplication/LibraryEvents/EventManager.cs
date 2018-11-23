using System;

namespace LibraryApplication.LibraryEvents
{
    class EventManager
    {
        public static Action OnDataFileChanged { get; set; }

        public static void AutoSave(object o, EventArgs e)
        {
            DataFileSystem.IO.SaveUserData();
        }

        public static void Startup()
        {
            DataFileSystem.IO.SetupFolders();
            DataFileSystem.IO.DefaultImage();
            DataFileSystem.IO.LoadUserData();
        }
    }
}
