using System.Text.RegularExpressions;

namespace Task6.Entities
{
    public class Catalog
    {
        private Dictionary<string, Book> _books;

        public Catalog()
        {
            _books = new Dictionary<string, Book>();
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
            _books.Add(cleanIsbn, book);
        }

        private bool IsInCorrectFormat(string isbn)
        {
            return isbn.Length == 17 && Regex.IsMatch(isbn, @"\d{3}-\d{1}-\d{2}-\d{6}-\d{1}") ||
                isbn.Length == 13 && Regex.IsMatch(isbn, @"\d{13}");
        }
    }
}
