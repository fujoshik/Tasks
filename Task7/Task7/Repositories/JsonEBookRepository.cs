﻿using Newtonsoft.Json;
using Task7.Entities;
using Task7.Repositories.Abstraction;

namespace Task7.Repositories
{
    public class JsonEBookRepository : IJsonRepository
    {
        public Catalog LoadCatalog(string filePath)
        {
            var catalog = new Catalog();

            if (Directory.Exists(filePath))
            {
                var files = Directory.GetFiles(filePath, "*.json");

                foreach (var file in files)
                {
                    var json = File.ReadAllText(file);
                    var books = JsonConvert.DeserializeObject<List<EBook>>(json);

                    foreach (var dto in books)
                    {
                        var authors = dto.Authors.Select(a => new Author(a.FirstName, a.LastName, a.BirthDate)).ToHashSet();
                        var book = new EBook(dto.Title, dto.ResourceId, dto.AvailableFormats, authors);

                        if (catalog.GetBook(book.ResourceId) == null)
                        {
                            catalog.AddBook(book.ResourceId, book);
                        }
                    }
                }
            }
            return catalog;
        }

        public void SaveCatalog(Catalog catalog, string filePath)
        {
            var authors = catalog.Books.Values.SelectMany(x => x.Authors).Distinct().ToHashSet();
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
