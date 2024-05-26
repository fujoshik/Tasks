namespace Task5._2.Entities
{
    public class Book
    {
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public HashSet<string> Authors { get; set; }

        public Book(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }
            Title = title;
            Authors = new HashSet<string>();
        }

        public Book(string title, DateTime publicationDate, HashSet<string> authors)
            : this(title)
        {
            PublicationDate = publicationDate;
            Authors = authors;
        }
    }
}
