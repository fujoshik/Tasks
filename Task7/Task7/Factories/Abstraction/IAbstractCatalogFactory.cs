using Task7.Entities;

namespace Task7.Factories.Abstraction
{
    public interface IAbstractCatalogFactory
    {
        Catalog CreateCatalog();
        HashSet<string> CreatePressReleaseItems(Catalog catalog);
    }
}
