namespace Task7.Entities
{
    public class EBook : Book
    {
        public string ResourceId { get; set; }
        public List<string> AvailableFormats { get; set; }

        public EBook(string title, string resourseId, List<string> availableFormats, HashSet<Author> authors) 
            : base(title)
        {
            ResourceId = resourseId;
            AvailableFormats = availableFormats;
            Authors = authors;
        }
    }
}
