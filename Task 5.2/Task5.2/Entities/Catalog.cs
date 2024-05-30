using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;

namespace Task5._2.Entities
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
            return (isbn.Length == 17 && Regex.IsMatch(isbn, @"\d{3}-\d{1}-\d{2}-\d{6}-\d{1}")) || 
                (isbn.Length == 13 && Regex.IsMatch(isbn, @"\d{13}"));
        }

        public Book GetBook(string isbn)
        {
            if (!IsInCorrectFormat(isbn))
            {
                throw new ArgumentException(nameof(isbn));
            }

            string cleanIsbn = isbn.Replace("-", "");

            if (_books.TryGetValue(cleanIsbn, out Book book))
            {
                return book;
            }

            return null;
        }

        public IList<string> GetBookTitles()
        {
            return _books
                .OrderBy(x => x.Value.Title)
                .Select(x => x.Value.Title)
                .ToList();
        }

        public IList<Book> GetBooksByAuthor(string author)
        {
            if (string.IsNullOrEmpty(author))
            {
                throw new ArgumentNullException(author);
            }

            return _books
                .Where(x => x.Value.Authors.Contains(author))
                .OrderBy(x => x.Value.PublicationDate)
                .Select(x => x.Value)
                .ToList();
        }

        public IList<(string, int)> GetSetAuthorBooksCount()
        {
            return _books
                .SelectMany(x => x.Value.Authors)
                .GroupBy(a => a)
                .Select(group => (Author: group.Key, Count: group.Count()))
                .OrderBy(x => x.Author)
                .ToList();
        }
    }
}
