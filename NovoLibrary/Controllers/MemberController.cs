using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovoLibrary.Data;
using NovoLibrary.Models;
using NovoLibrary.Services.BookService;
using NovoLibrary.Services.MemberService;

namespace NovoLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetAllMembers()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMemberById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<List<Member>>> AddMember(Member memberRequest)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Member>>> UpdateMember(int id, Member memberRequest)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Member>>> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }
}
