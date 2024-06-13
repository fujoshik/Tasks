using System.Xml.Serialization;
using Task6.Entities;
using Task6.Serializers.Abstraction;

namespace Task6.Serializers
{
    public class XmlCatalogSerializer : ICatalogSerializer
    {
        private readonly XmlSerializer _serializer;

        public XmlCatalogSerializer()
        {
            _serializer = new XmlSerializer(typeof(List<Book>));
        }
        public void SaveCatalog(Catalog catalog, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                _serializer.Serialize(stream, catalog.Books);
            }
        }

        public Catalog LoadCatalog(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                var books = _serializer.Deserialize(stream);
                var catalog = new Catalog();
                foreach (var book in books as List<Book>)
                {
                    catalog.AddBook(book.Isbn, book);
                }
                return catalog;
            }
        }
    }
}
