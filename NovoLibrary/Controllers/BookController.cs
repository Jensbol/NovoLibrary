using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovoLibrary.Data;
using NovoLibrary.Models;
using NovoLibrary.Services.BookService;

namespace NovoLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book is null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book bookRequest)
        {
            var book = await _bookService.AddBook(bookRequest);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Book>>> UpdateBook(int id, Book book)
        {
            var books = await _bookService.UpdateBook(id, book);
            if (books is null)
                return NotFound();

            return Ok(books);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            var books = await _bookService.DeleteBook(id);
            if (books is null)
                return NotFound();

            return Ok(books);
        }

    }
}
