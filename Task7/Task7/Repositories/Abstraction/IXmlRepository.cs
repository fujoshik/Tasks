using Task7.Entities;

namespace Task7.Repositories.Abstraction
{
    public interface IXmlRepository
    {
        void SaveCatalog(Catalog catalog, string filePath);
        Catalog LoadCatalog(string filePath);
    }
}
