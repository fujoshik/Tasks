using Task7.Entities;
using Task7.Factories.Abstraction;
using Task7.Repositories.Abstraction;

namespace Task7.Factories
{
    public class PaperBookCatalogLibrary : IAbstractCatalogFactory
    {
        private ICsvRepository _repository;

        public PaperBookCatalogLibrary(ICsvRepository repository)
        {
            _repository = repository;
        }

        public Catalog CreateCatalog()
        {
            return _repository.SavePaperBooks();
        }

        public HashSet<string> CreatePressReleaseItems(Catalog catalog)
        {
            var pressReleaseItems = new HashSet<string>();
            var books = catalog.Books.Values.Select(x => x as PaperBook).ToList();

            foreach (var book in books)
            {
                if (!pressReleaseItems.Contains(book.Publisher))
                {
                    pressReleaseItems.Add(book.Publisher);
                }
            }

            return pressReleaseItems;
        }
    }
}
