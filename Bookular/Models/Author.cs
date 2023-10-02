namespace Bookular.Models
{
    public class Author
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
