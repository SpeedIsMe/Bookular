using System.Diagnostics;
using Bookular.Models;
using Microsoft.Data.SqlClient;
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
            return await _context.Books.Include(b => b.Author).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBook(string title)
        {
            var books = await _context.Books.Include(b => b.Author).Where(b => b.Title.Contains(title)).AsNoTracking().ToListAsync();
            return books;
        }

        public async Task<Book> GetBookByIsbn(long isbn)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .AsNoTracking()
                .SingleOrDefaultAsync(b => b.Isbn == isbn);
            return book;
        }

        public async Task ApplyPriceChangeByPercentage(int percentage)
        {
            //var command = "UPDATE Books SET Price = Price + (Price * @p0 / 100)";
            var parameter = new SqlParameter("@percentage", percentage);
            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateBookPricesByPercentage @percentage", parameter);
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
