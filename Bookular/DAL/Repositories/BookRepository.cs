using Bookular.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookular.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext Context;

        public BookRepository(BookContext Context)
        {
            this.Context = Context;
        }

        public IEnumerable<Book> All()
        {
            return Context.Authors.Include(a => a.Books).SelectMany(x => x.Books);
        }

        public IEnumerable<Book> Find(string? title)
        {
            return Context.Authors.Include(a => a.Books).SelectMany(x => x.Books).Where(b => b.Title.Contains(title));
        }
    }
}
