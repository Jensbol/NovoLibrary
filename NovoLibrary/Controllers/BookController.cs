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

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book bookRequest)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Book>>> UpdateBook(int id, Book book)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
