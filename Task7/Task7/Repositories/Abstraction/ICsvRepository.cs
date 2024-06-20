using Task7.Entities;

namespace Task7.Repositories.Abstraction
{
    public interface ICsvRepository
    {
        Catalog SaveEBooks();
        Catalog SavePaperBooks();
    }
}
