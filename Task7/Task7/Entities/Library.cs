using Task7.Factories.Abstraction;

namespace Task7.Entities
{
    public class Library
    {
        public Catalog Catalog { get; private set; }
        public HashSet<string> PressReleaseItems { get; set; }

        public Library(IAbstractCatalogFactory catalogFactory)
        {
            Catalog = catalogFactory.CreateCatalog();
            PressReleaseItems = catalogFactory.CreatePressReleaseItems(Catalog);
        }
    }
}
