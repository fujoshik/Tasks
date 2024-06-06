using System.Text.Json;
using Task6.Entities;
using Task6.Serializers.Abstraction;

namespace Task6.Serializers
{
    public class JsonCatalogSerializer : ICatalogSerializer
    {
        public void Save(Catalog catalog, string directoryPath)
        {
            string jsonString = JsonSerializer.Serialize(catalog);

            File.WriteAllText(directoryPath + "file.json", jsonString);
        }

        public Catalog Restore(string directoryPath)
        {
            var jsonContent = File.ReadAllText(directoryPath);
            var catalog = JsonSerializer.Deserialize<Catalog>(jsonContent);

            return catalog;
        }
    }
}
