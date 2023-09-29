using Bookular.Models;

namespace Bookular.DAL.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> All();
        IEnumerable<Book> Find(string title);
    }
}
