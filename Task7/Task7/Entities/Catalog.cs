namespace Task7.Entities
{
    public class Catalog
    {
        public Dictionary<string, Book> Books { get; private set; }

        public Catalog()
        {
            Books = new Dictionary<string, Book>();
        }

        public void AddBook(string identifier, Book book)
        {
            if (Books.ContainsKey(identifier))
            {
                throw new ArgumentException(nameof(identifier));
            }

            Books.Add(identifier, book);
        }

        public Book GetBook(string isbn)
        {
            if (Books.TryGetValue(isbn, out Book book))
            {
                return book;
            }
            return null;
        }

        public IList<Book> GetBooksByAuthor(Author author)
        {
            return Books.Values.Where(x => x.Authors.Contains(author)).ToList();
        }
    }
}
