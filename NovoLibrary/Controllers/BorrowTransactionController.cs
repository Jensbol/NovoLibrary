using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovoLibrary.Models;
using NovoLibrary.Services.BookService;
using NovoLibrary.Services.BorrowService;

namespace NovoLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowTransactionController : ControllerBase
    {
        private readonly IBorrowService _borrowService;

        public BorrowTransactionController(IBorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooksByMember(int memberId)
        {
            var borrow = await _borrowService.GetBooksByMember(memberId);
            return Ok(borrow);
        }

        [HttpPost]
        public async Task<ActionResult<List<BorrowTransaction>>> BorrowBook(BorrowTransaction borrowTransaction)
        {
            try
            {
                var borrow = await _borrowService.BorrowBook(borrowTransaction);
                return Ok(borrow);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            
        }

        [HttpPut("{bookId}")]
        public async Task<ActionResult<List<BorrowTransaction>>> ReturnBook(int bookId)
        {
            var borrow = await _borrowService.ReturnBook(bookId);
            return Ok(borrow);
        }
       

    }
}
