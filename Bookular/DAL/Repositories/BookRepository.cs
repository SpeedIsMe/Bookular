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

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBook(string title)
        {
            var books = await _context.Books.Include(b => b.Author).Where(b => b.Title.Contains(title)).ToListAsync();
            return books == null ? null : books;
        }

        public async Task<IEnumerable<Book>> GetBookByIsbn(long isbn)
        {
            var books = await _context.Books.Include(b => b.Author).Where(b => b.Isbn == isbn).ToListAsync();
            return books == null ? null : books;
        }

        public async Task<Book> PutBook(long id, Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();

            return book;
        }

        public async Task<Book> PostBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }

        public async Task<Book> DeleteBook(long id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return book;
        }
    }
}
