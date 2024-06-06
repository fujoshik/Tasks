using Task7.Entities;
using Task7.Factories.Abstraction;
using Task7.Repositories.Abstraction;

namespace Task7.LibraryFactories
{
    public class CsvLibraryFactory : IAbstractLibraryFactory
    {
        private readonly ICsvRepository _repository;

        public CsvLibraryFactory(ICsvRepository repository)
        {
            _repository = repository;
        }

        public Library<EBook> CreateEBookLibrary()
        {
            return _repository.SaveEBooks();
        }

        public Library<PaperBook> CreatePaperBookLibrary()
        {
            return _repository.SavePaperBooks();
        }
    }
}
