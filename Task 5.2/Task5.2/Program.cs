using Task5._2.Entities;

var catalog = new Catalog();
var book1 = new Book("Crime and Punishment", new DateTime(1866, 1, 1), new List<string> { "Fyodor Dostoevsky" });
var book2 = new Book("The Idiot", new DateTime(1868, 1, 1), new List<string> { "Fyodor Dostoevsky" });
var book3 = new Book("Beartown", new DateTime(2016, 1, 1), new List<string> { "Frederik Backman" });
var book4 = new Book("Us Against You", new DateTime(2017, 1, 1), new List<string> { "Frederik Backman" });

catalog.AddBook("978-0-596-52068-7", book1);
catalog.AddBook("978-3-16-148410-0", book2);
catalog.AddBook("9789880038273", book3);
catalog.AddBook("1566199093257", book4);

var book = catalog.GetBook("9780596520687");
Console.WriteLine(book.Title);

var books = catalog.GetBooksByAuthor("Fyodor Dostoevsky");
var titles = catalog.GetBookTitles();
var authorBooks = catalog.GetSetAuthorBooksCount();
Console.WriteLine();
