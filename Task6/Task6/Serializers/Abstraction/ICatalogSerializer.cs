using Task6.Entities;

namespace Task6.Serializers.Abstraction
{
    public interface ICatalogSerializer
    {
        void Save(Catalog catalog, string directoryPath);
        Catalog Restore(string directoryPath);
    }
}
