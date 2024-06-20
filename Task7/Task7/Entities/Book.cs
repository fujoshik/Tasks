namespace Task7.Entities
{
    public class Book
    {
        public string Title { get; set; }
        public HashSet<Author> Authors { get; set; }

        public Book(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }
            Title = title;
            Authors = new HashSet<Author>();
        }

        public Book(string title, HashSet<Author> authors)
            : this(title)
        {
            Authors = authors;
        }
    }
}
