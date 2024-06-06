using Task7.Entities;

namespace Task7.Factories.Abstraction
{
    public interface IAbstractLibraryFactory
    {
        Library<EBook> CreateEBookLibrary();
        Library<PaperBook> CreatePaperBookLibrary();
    }
}
