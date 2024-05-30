using Task6.Entities;
using Task6.Serializers;

var catalog = new Catalog();

var dostoevsky = new Author("Fyodor", "Dostoevsky", new DateTime());
var backman = new Author("Frederik", "Backman", new DateTime());
var hoover = new Author("Colleen", "Hoover", new DateTime());

var book1 = new Book("Crime and Punishment", new DateTime(1866, 1, 1), new HashSet<Author> { dostoevsky });
var book2 = new Book("The Idiot", new DateTime(1868, 1, 1), new HashSet<Author> { dostoevsky });
var book3 = new Book("Beartown", new DateTime(2016, 1, 1), new HashSet<Author> { backman, hoover });
var book4 = new Book("Us Against You", new DateTime(2017, 1, 1), new HashSet<Author> { backman });

catalog.AddBook("978-0-59-652068-7", book1);
catalog.AddBook("978-3-16-148410-0", book2);
catalog.AddBook("9789880038273", book3);
catalog.AddBook("1566199093257", book4);

var jsonSerializer = new JsonCatalogSerializer();
jsonSerializer.Save(catalog, "/");
