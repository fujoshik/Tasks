using System.Text.Json;
using Task7.Entities;
using Task7.Repositories.Abstraction;

namespace Task7.Repositories
{
    public class JsonRepository : IJsonRepository
    {
        public void SaveEBooks(Catalog<EBook> catalog, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(catalog);

            File.WriteAllText(fileName, jsonString);
        }

        public void SavePaperBooks(Catalog<PaperBook> catalog, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(catalog);

            File.WriteAllText(fileName, jsonString);
        }
    }
}
