using Newtonsoft.Json;

namespace LibraryApplication.LibraryObjects
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID;

        [JsonIgnore]
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
