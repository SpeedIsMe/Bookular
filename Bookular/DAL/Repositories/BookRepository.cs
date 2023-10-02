using Bookular.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookular.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.Include(a => a.Author);
        }

        public IEnumerable<Book> Find(string title)
        {
            return _context.Books.Include(a => a.Author).Where(a => a.Title.Contains(title));
        }
    }
}
