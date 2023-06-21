using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovoLibrary.Models;
using NovoLibrary.Models.DTOs;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<BorrowTransactionDto>> BorrowBook(BorrowTransactionDto borrowTransactionDto)
        {
            try
            {
                var borrow = await _borrowService.BorrowBook(new BorrowTransaction
                {
                    BookId = borrowTransactionDto.BookId,
                    MemberId = borrowTransactionDto.MemberId,
                    BorrowDate = borrowTransactionDto.BorrowDate,
                    ReturnDate = borrowTransactionDto.ReturnDate
                });

                return StatusCode(201, borrowTransactionDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPut("{bookId}")]
        public async Task<ActionResult<BorrowTransactionDto>> ReturnBook(int bookId)
        {
            var borrow = await _borrowService.ReturnBook(bookId);
            var borrowTransactionDto = new BorrowTransactionDto
            {
                BookId = borrow.BookId,
                MemberId = borrow.MemberId,
                BorrowDate = borrow.BorrowDate,
                ReturnDate = borrow.ReturnDate
            };
            return Ok(borrowTransactionDto);
        }
       

    }
}
