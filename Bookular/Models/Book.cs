using System.Reflection.Metadata;

namespace Bookular.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long AuthorId { get; set; }
        public Author Author { get; set; }
        public string? AuthorName { get; set; }
    }
}
