using Bookular.DAL.Repositories;
using Bookular.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet("Find/{title}")]
        [HttpGet("Find/")]
        public ActionResult<List<Book>> Find(string? title)
        {
            if (title == null)
            {
                return Ok(bookRepository.All());
            }
            else
            {
                return Ok(bookRepository.Find(title));
            }
        }
    }
}
