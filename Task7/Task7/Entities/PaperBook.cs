namespace Task7.Entities
{
    public class PaperBook : Book
    {
        public DateTime? PublicationDate { get; set; }
        public string Publisher { get; set; }
        public List<string> Isbns { get; set; }

        public PaperBook(string title, string publisher, List<string> isbns, HashSet<Author> authors) 
            : base(title)
        {
            Isbns = isbns;
            Publisher = publisher;
            Authors = authors;
        }
    }
}
