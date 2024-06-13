using Task7.Entities;

namespace Task7.Repositories.Abstraction
{
    public interface IJsonRepository
    {
        void SaveCatalog(Catalog catalog, string filePath);
        Catalog LoadCatalog(string filePath);
    }
}
