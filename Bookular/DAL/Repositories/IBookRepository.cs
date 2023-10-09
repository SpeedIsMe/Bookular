using Bookular.Models;

namespace Bookular.DAL.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<IEnumerable<Book>> GetBook(string title);
        Task<IEnumerable<Book>> GetBookByIsbn(long isbn);
        Task<Book> PutBook(long id, Book book);
        Task<Book> PostBook(Book book);
        Task<Book> DeleteBook(long id);
    }
}
