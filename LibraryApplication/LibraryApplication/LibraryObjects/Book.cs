namespace LibraryApplication.LibraryObjects
{
    class Book
    {
        public string Name { get; set; }

        public string ImageID { get; set; }

        public int Count { get; set; }

        public Author Author { get; set; }
    }
}
