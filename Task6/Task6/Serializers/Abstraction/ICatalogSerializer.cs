using Task6.Entities;

namespace Task6.Serializers.Abstraction
{
    public interface ICatalogSerializer
    {
        void SaveCatalog(Catalog catalog, string filePath);
        Catalog LoadCatalog(string filePath);
    }
}
