using Bookular.Models;

namespace Bookular.DAL.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> Find(string title);
    }
}
