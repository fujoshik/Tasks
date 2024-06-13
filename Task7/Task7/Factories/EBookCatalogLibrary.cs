using Task7.Entities;
using Task7.Factories.Abstraction;
using Task7.Repositories.Abstraction;

namespace Task7.Factories
{
    public class EBookCatalogLibrary : IAbstractCatalogFactory
    {
        private ICsvRepository _repository;

        public EBookCatalogLibrary(ICsvRepository repository)
        {
            _repository = repository;
        }

        public HashSet<string> CreatePressReleaseItems(Catalog catalog)
        {
            var pressReleaseItems = new HashSet<string>();
            var eBooks = catalog.Books.Values.Select(x => x as EBook).ToList();

            foreach (var book in eBooks)
            {
                foreach (var format in book.AvailableFormats)
                {
                    if (!pressReleaseItems.Contains(format))
                    {
                        pressReleaseItems.Add(format);
                    }
                }
            }

            return pressReleaseItems;
        }

        public Catalog CreateCatalog()
        {
            return _repository.SaveEBooks();
        }
    }
}
