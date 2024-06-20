using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Task7.DTOs;
using Task7.Entities;
using Task7.Repositories.Abstraction;

namespace Task7.Repositories
{
    public class CsvRepository : ICsvRepository
    {
        private string _filePath = "";

        public CsvRepository(string filePath)
        {
            _filePath = filePath;
        }

        public Catalog SaveEBooks()
        {
            var catalog = new Catalog();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                Escape = '\\'
            };
            using var streamReader = File.OpenText(_filePath);

            using var csv = new CsvReader(streamReader, config);

            var records = csv.GetRecords<BookDto>().ToList();

            foreach (var record in records)
            {
                var formats = new List<string>();

                if (!string.IsNullOrEmpty(record.Format))
                {
                    formats.AddRange(record.Format.Split(","));
                }

                var authors = GetAuthors(record.Creator);

                catalog.AddBook(record.Identifier, new EBook(record.Title, record.Identifier, formats, authors));
            }

            return catalog;
        }

        public Catalog SavePaperBooks()
        {
            var catalog = new Catalog();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                Escape = '\\',
                BadDataFound = null
            };
            using var streamReader = File.OpenText(_filePath);

            using var csv = new CsvReader(streamReader, config);

            var records = csv.GetRecords<BookDto>().ToList();

            foreach (var record in records)
            {
                var isbns = new List<string>();

                if (!string.IsNullOrEmpty(record.RelatedExternalId))
                {
                    var ids = record.RelatedExternalId.Split(",");

                    foreach (var id in ids)
                    {
                        if (id.StartsWith("urn:isbn:"))
                        {
                            var isbn = id.Substring("urn:isbn:".Length);
                            isbns.Add(isbn);
                        }
                    }
                }

                var authors = GetAuthors(record.Creator);

                catalog.AddBook(record.Identifier, new PaperBook(record.Title, record.Publisher, isbns, authors));
            }

            return catalog;
        }

        private HashSet<Author> GetAuthors(string authorsString)
        {
            var result = new HashSet<Author>();

            if (!string.IsNullOrEmpty(authorsString))
            {
                var authors = authorsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < authors.Length; i++)
                {
                    var fullName = authors[i].Trim();
                    DateTime birthDate = new DateTime();

                    if (i + 1 < authors.Length && authors[i + 1].Any(char.IsDigit))
                    {
                        var datePart = authors[i + 1].Trim();
                        var dateSegments = datePart.Split('-');

                        if (dateSegments.Length > 0 && int.TryParse(dateSegments[0], out int year))
                        {
                            birthDate = new DateTime(year, 1, 1);
                        }

                        i++;
                    }

                    var nameParts = fullName.Split(' ');

                    if (nameParts.Length >= 1)
                    {
                        var firstName = nameParts[0];
                        var lastName = nameParts.Length >= 2 ? nameParts[nameParts.Length - 1] : "";

                        result.Add(new Author(firstName, lastName, birthDate));

                    }
                }
            }
            return result;
        }
    }
}
