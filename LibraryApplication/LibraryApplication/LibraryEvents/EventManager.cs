using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.LibraryEvents
{
    class EventManager
    {
        public static void AutoSave(object o, EventArgs e)
        {
            DataFileSystem.IO.SaveUserData();
        }

        public static void Startup()
        {
            DataFileSystem.IO.SetupFolders();
            DataFileSystem.IO.LoadUserData();
            DataFileSystem.IO.DefaultImage();
        }

        public static Action OnDataFileChanged;
    }
}
