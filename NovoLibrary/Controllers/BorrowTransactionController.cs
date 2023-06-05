using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovoLibrary.Models;


namespace NovoLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowTransactionController : ControllerBase
    {
        

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooksByMember(int memberId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<List<BorrowTransaction>>> BorrowBook(BorrowTransaction borrowTransaction)
        {
            throw new NotImplementedException();


        }

        [HttpPut("{bookId}")]
        public async Task<ActionResult<List<BorrowTransaction>>> ReturnBook(int bookId)
        {
            throw new NotImplementedException();
        }
       

    }
}
