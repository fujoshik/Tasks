using Task7.Entities;

namespace Task7.Repositories.Abstraction
{
    public interface ICsvRepository
    {
        Library<EBook> SaveEBooks();
        Library<PaperBook> SavePaperBooks();
    }
}
