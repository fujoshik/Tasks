using System.Text.RegularExpressions;

namespace Task6.Entities
{
    public class Catalog
    {
        public Dictionary<string, Book> Books { get; private set; }

        public Catalog()
        {
            Books = new Dictionary<string, Book>();
        }

        public void AddBook(string isbn, Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (!IsInCorrectFormat(isbn))
            {
                throw new ArgumentException(nameof(isbn));
            }

            string cleanIsbn = isbn.Replace("-", "");
            Books.Add(cleanIsbn, book);
        }

        private bool IsInCorrectFormat(string isbn)
        {
            return isbn.Length == 17 && Regex.IsMatch(isbn, @"\d{3}-\d{1}-\d{2}-\d{6}-\d{1}") ||
                isbn.Length == 13 && Regex.IsMatch(isbn, @"\d{13}");
        }

        public Book GetBook(string isbn)
        {
            string cleanIsbn = isbn.Replace("-", "");

            if (Books.TryGetValue(cleanIsbn, out Book book))
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
