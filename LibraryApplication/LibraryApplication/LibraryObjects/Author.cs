using Newtonsoft.Json;

namespace LibraryApplication.LibraryObjects
{
    public class Author
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ID { get; set; }

        [JsonIgnore]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
