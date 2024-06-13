namespace Task6.Entities
{
    public class Book
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public HashSet<Author> Authors { get; set; }

        public Book(string title, string isbn)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }
            Title = title;
            Isbn = isbn;
            Authors = new HashSet<Author>();
        }

        public Book(string title, string isbn, DateTime publicationDate, HashSet<Author> authors)
            : this(title, isbn)
        {
            PublicationDate = publicationDate;
            Authors = authors;
        }
    }
}
