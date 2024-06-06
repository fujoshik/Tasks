namespace Task7.Entities
{
    public class Library<T> where T : Book
    {
        public Catalog<T> Catalog { get; private set; }
        public HashSet<string> PressReleaseItems { get; set; }

        public Library(Catalog<T> catalog)
        {
            Catalog = catalog;
            FillPressReleaseItems();
        }

        private void FillPressReleaseItems()
        {
            PressReleaseItems = new HashSet<string>();

            if (typeof(T) == typeof(EBook))
            {
                var eBooks = Catalog.Books.Select(x => x.Value as EBook).ToList();

                foreach (var item in eBooks)
                {
                    item.AvailableFormats.ForEach(x => PressReleaseItems.Add(x));
                }
            }
            else if (typeof(T) == typeof(PaperBook))
            {
                var paperBooks = Catalog.Books.Select(x => x.Value as PaperBook).ToList();

                paperBooks.ForEach(x => PressReleaseItems.Add(x.Publisher));
            }
        }
    }
}
