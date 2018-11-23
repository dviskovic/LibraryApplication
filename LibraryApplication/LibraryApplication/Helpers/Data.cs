using LibraryApplication.LibraryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Helpers
{
    class Data
    {
        public static dynamic FindByNameAndImage(string Name, string ImagePath)
        {
            foreach (var user in DataFileSystem.IO.DataFile.Users)
                if (string.Compare(user.FullName, Name, StringComparison.OrdinalIgnoreCase) == 0 && ImagePath == user.ImageID) return user;

            foreach (var book in DataFileSystem.IO.DataFile.Books)
                if (string.Compare(book.Name, Name, StringComparison.OrdinalIgnoreCase) == 0 && ImagePath == book.ImageID) return book;

            return null;
        }

        public static TimeSpan TimeSinceLastSave()
        {
            return DateTime.UtcNow.Subtract(DataFileSystem.IO.DataFile.LastSaveTime);
        }

        public static string GetReadableTimeFromTimeSpan(TimeSpan span, string stringFormat = "N0")
        {
            if (span == TimeSpan.MinValue) return string.Empty;
            var str = string.Empty;
            if (span.TotalHours >= 24) str = (int)span.TotalDays + " day" + (span.TotalDays >= 2 ? "s" : string.Empty) + " " + (span.TotalHours - ((int)span.TotalDays * 24)).ToString(stringFormat) + " hour(s)";
            else if (span.TotalMinutes > 60) str = (int)span.TotalHours + " hour" + (span.TotalHours >= 2 ? "s" : string.Empty) + " " + (span.TotalMinutes - ((int)span.TotalHours * 60)).ToString(stringFormat) + " minute(s)";
            else if (span.TotalMinutes > 1.0) str = (span.Minutes + " minute" + (span.Minutes >= 2 ? "s" : string.Empty)) + (span.Seconds < 1 ? string.Empty : " " + span.Seconds + " second" + (span.Seconds >= 2 ? "s" : string.Empty));
            if (!string.IsNullOrEmpty(str)) return str;
            return (span.TotalDays >= 1.0) ? (span.TotalDays.ToString(stringFormat)) + " day" + (span.TotalDays >= 1.5 ? "s" : string.Empty) : (span.TotalHours >= 1.0) ? (span.TotalHours.ToString(stringFormat)) + " hour" + (span.TotalHours >= 1.5 ? "s" : string.Empty) : (span.TotalMinutes >= 1.0) ? (span.TotalMinutes.ToString(stringFormat)) + " minute" + (span.TotalMinutes >= 1.5 ? "s" : string.Empty) : (span.TotalSeconds >= 1.0) ? (span.TotalSeconds.ToString(stringFormat)) + " second" + (span.TotalSeconds >= 1.5 ? "s" : string.Empty) : "Now";
        }

        public static void DeleteEntryFromDataFile(dynamic entry)
        {
            if (entry is User)
            {
                var entryDefined = entry as User;
                foreach (var user in DataFileSystem.IO.DataFile.Users.ToList())
                {
                    if (string.Compare(user.FullName, entryDefined.FullName, StringComparison.OrdinalIgnoreCase) == 0 && entryDefined.ImageID == user.ImageID)
                    {
                        DataFileSystem.IO.DataFile.Users.Remove(user);
                        DataFileSystem.IO.SaveUserData();
                        return;
                    }
                }
            }

            if (entry is Book)
            {
                var entryDefined = entry as Book;
                foreach (var book in DataFileSystem.IO.DataFile.Books.ToList())
                {
                    if (string.Compare(book.Name, entryDefined.Name, StringComparison.OrdinalIgnoreCase) == 0 && entryDefined.ImageID == book.ImageID)
                    {
                        DataFileSystem.IO.DataFile.Books.Remove(book);
                        DataFileSystem.IO.SaveUserData();
                        return;
                    }
                }
            }

            else throw new NotImplementedException("Requested to delete something we don't recognize");
        }
    }
}
