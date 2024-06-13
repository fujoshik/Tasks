using System.Xml.Serialization;
using Task7.Entities;
using Task7.Repositories.Abstraction;

namespace Task7.Repositories
{
    public class XmlPaperBookRepository : IXmlRepository
    {
        private readonly XmlSerializer _serializer;

        public XmlPaperBookRepository()
        {
            _serializer = new XmlSerializer(typeof(List<EBook>));
        }

        public Catalog LoadCatalog(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                var books = _serializer.Deserialize(stream);
                var catalog = new Catalog();

                foreach (var book in books as List<EBook>)
                {
                    catalog.AddBook(book.ResourceId, book);
                }

                return catalog;
            }
        }

        public void SaveCatalog(Catalog catalog, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                var ebooks = catalog.Books.Values.OfType<EBook>();
                _serializer.Serialize(stream, ebooks);
            }
        }
    }
}
