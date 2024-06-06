namespace Task7.Entities
{
    public class Catalog<T> where T : Book
    {
        public Dictionary<string, T> Books { get; set; }

        public Catalog()
        {
            Books = new Dictionary<string, T>();
        }

        public void AddBook(string identifier, T book)
        {
            if (Books.ContainsKey(identifier))
            {
                throw new ArgumentException(nameof(identifier));
            }

            Books.Add(identifier, book);
        }
    }
}
