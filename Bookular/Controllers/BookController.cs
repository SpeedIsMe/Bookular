using Bookular.DAL.Repositories;
using Bookular.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Book>> GetAll()
        {
            return Ok(_bookRepository.GetAll());
        }

        [HttpGet("Find/{title}")]
        public ActionResult<List<Book>> Find(string title)
        {
            return Ok(_bookRepository.Find(title));
        }
    }
}
