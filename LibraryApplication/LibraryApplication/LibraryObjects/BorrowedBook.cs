using System;
using Newtonsoft.Json;

namespace LibraryApplication.LibraryObjects
{
    public class BorrowedBook
    {
        public string BookID { get; set; }

        public DateTime BorrowedAt { get; set; }

        public DateTime BorrowedUntil { get; set; }

        [JsonIgnore]
        public TimeSpan ReturnTimeSpan
        {
            get
            {
                return DateTime.UtcNow.Subtract(this.BorrowedUntil);
            }
        }
    }
}
