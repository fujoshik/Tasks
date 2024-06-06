using Task7.Entities;

namespace Task7.Repositories.Abstraction
{
    public interface IJsonRepository
    {
        void SaveEBooks(Catalog<EBook> catalog, string fileName);
        void SavePaperBooks(Catalog<PaperBook> catalog, string fileName);
    }
}
