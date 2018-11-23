using Newtonsoft.Json;

namespace LibraryApplication.LibraryObjects
{
    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
