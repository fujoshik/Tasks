namespace Task5._2.Entities
{
    public class Book
    {
        public string Title { get; set; }
        public DateTime? PublicationDate { get; set; }
        public List<string> Authors { get; set; }

        public Book(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }
            Title = title;
            Authors = new List<string>();
        }

        public Book(string title, DateTime publicationDate, IList<string> authors)
            : this(title)
        {
            PublicationDate = publicationDate;
            Authors = authors.Distinct().ToList();
        }
    }
}
