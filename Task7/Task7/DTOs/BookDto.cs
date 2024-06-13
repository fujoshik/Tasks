using CsvHelper.Configuration.Attributes;

namespace Task7.DTOs
{
    public class BookDto
    {
        [Name("creator")]
        public string Creator { get; set; }

        [Name("format")]
        public string Format { get; set; }

        [Name("identifier")]
        public string Identifier { get; set; }

        [Name("publicdate")]
        public string PublicDate { get; set; }

        [Name("publisher")]
        public string Publisher { get; set; }

        [Name("related-external-id")]
        public string RelatedExternalId { get; set; }

        [Name("title")]
        public string Title { get; set; }
    }
}
