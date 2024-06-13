using Newtonsoft.Json;
using Task6.Entities;
using Task6.Serializers.Abstraction;

namespace Task6.Serializers
{
    public class JsonCatalogSerializer : ICatalogSerializer
    {
        public Catalog LoadCatalog(string filePath)
        {
            Catalog catalog = new Catalog();
            var jsonFiles = Directory.GetFiles(filePath, "*.json");
            foreach (var jsonFile in jsonFiles)
            {
                string json = File.ReadAllText(jsonFile);
                var books = JsonConvert.DeserializeObject<List<Book>>(json);
                foreach (var book in books)
                {
                    if (catalog.GetBook(book.Isbn) == null)
                    {
                        catalog.AddBook(book.Isbn, book);
                    }
                }
            }
            return catalog;
        }

        public void SaveCatalog(Catalog catalog, string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            List<Author> authors = catalog.Books.Values.SelectMany(x => x.Authors).Distinct().ToList();
            foreach (Author author in authors)
            {
                var books = catalog.GetBooksByAuthor(author).Distinct().ToList();
                string fileName = $"{author.FirstName}_{author.LastName}.json";
                string directory = Path.Combine(filePath, fileName);
                File.WriteAllText(directory, JsonConvert.SerializeObject(books));
            }

        }
    }
}
