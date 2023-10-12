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

        [HttpGet("GetBooks")]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await _bookRepository.GetBooks());
        }

        [HttpGet("GetBook/{title}")]
        public async Task<ActionResult<List<Book>>> GetBook(string title)
        {
            return Ok(await _bookRepository.GetBook(title));
        }

        [HttpGet("GetBookByIsbn/{isbn}")]
        public async Task<ActionResult<List<Book>>> GetBookByIsbn(long isbn)
        {
            return Ok(await _bookRepository.GetBookByIsbn(isbn));
        }

        [HttpGet("ApplyDiscount/{isbn}/{discount}")]
        public async Task<ActionResult<List<Book>>> ApplyDiscount(long isbn, int discount)
        {
            var book = await _bookRepository.GetBookByIsbn(isbn);
            book.Price -= (book.Price * discount / 100);
            return Ok(await _bookRepository.PutBook(book.Id, book));
        }

        [HttpGet("ApplyPercentageToAll/{percentage}")]
        public async Task<ActionResult<List<Book>>> ApplyPercentageToAll(int percentage)
        {
            await _bookRepository.ApplyPriceChangeByPercentage(percentage);
            return Ok();
        }

        [HttpPut("PutBook/{id}")]
        public async Task<ActionResult<List<Book>>> PutBook(long id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            return Ok(await _bookRepository.PutBook(id, book));
        }

        [HttpPost("PostBook")]
        public async Task<ActionResult<List<Book>>> PostBook(Book book)
        {
            return Ok(await _bookRepository.PostBook(book));
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(long id)
        {
            return Ok(await _bookRepository.DeleteBook(id));
        }
    }
}
