using System.Xml.Serialization;
using Task7.Entities;
using Task7.Repositories.Abstraction;

namespace Task7.Repositories
{
    public class XmlRepository : IXmlRepository
    {
        public void SaveEBooks(Catalog<EBook> catalog, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Catalog<EBook>));

            using (var writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, catalog);
            }
        }

        public void SavePaperBooks(Catalog<PaperBook> catalog, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Catalog<PaperBook>));

            using (var writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, catalog);
            }
        }
    }
}
