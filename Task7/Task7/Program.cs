using Task7.Entities;
using Task7.Factories;
using Task7.Repositories;


string filePath = "../../../../files/books_info.csv";

var csvRepository = new CsvRepository(filePath);
var ebookFactory = new EBookCatalogLibrary(csvRepository);
var paperBookFactory = new PaperBookCatalogLibrary(csvRepository);

var paperBookLibrary = new Library(paperBookFactory);
var eBookLibrary = new Library(ebookFactory);

var xmlRepository = new XmlPaperBookRepository();
xmlRepository.SaveCatalog(paperBookLibrary.Catalog, "../../../../files/paperCatalog.xml");
var paperBookCatalog = xmlRepository.LoadCatalog("../../../../files/paperCatalog.xml");

var jsonRepository = new JsonEBookRepository();
jsonRepository.SaveCatalog(eBookLibrary.Catalog, "../../../../files/eBookCatalog.json");
var eBookCatalog = jsonRepository.LoadCatalog("../../../../files/eBookCatalog.json");

Console.WriteLine();
