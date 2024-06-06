using System.Xml.Serialization;
using Task6.Entities;
using Task6.Serializers.Abstraction;

namespace Task6.Serializers
{
    public class XmlCatalogSerializer : ICatalogSerializer
    {
        public Catalog Restore(string directoryPath)
        {
            Catalog catalog = new Catalog();
            XmlSerializer serializer = new XmlSerializer(typeof(Catalog));

            using (var reader = new FileStream(directoryPath, FileMode.Open))
            {
                catalog = serializer.Deserialize(reader) as Catalog;
            }

            return catalog;
        }

        public void Save(Catalog catalog, string directoryPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Catalog));

            using (var writer = new StreamWriter(directoryPath))
            {
                serializer.Serialize(writer, catalog);
            }
        }
    }
}
