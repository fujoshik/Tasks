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

        public Library<EBook> SaveEBooks()
        {
            var catalog = new Catalog<EBook>();

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

                catalog.AddBook(record.Identifier, new EBook(record.Title, record.Identifier, formats));
            }

            return new Library<EBook>(catalog);
        }

        public Library<PaperBook> SavePaperBooks()
        {
            var catalog = new Catalog<PaperBook>();

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

                catalog.AddBook(record.Identifier, new PaperBook(record.Title, record.Publisher, isbns));
            }

            return new Library<PaperBook>(catalog);
        }
    }
}
