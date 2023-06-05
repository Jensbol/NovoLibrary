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
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetAllMembers()
        {
            var members = await _memberService.GetAllMembers();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMemberById(int id)
        {
            var member = await _memberService.GetMemberById(id);
            if (member is null)
                return NotFound("The Member you were looking for was not found");

            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<List<Member>>> AddMember(Member memberRequest)
        {
            var member = await _memberService.AddMember(memberRequest);
            return Ok(member);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Member>>> UpdateMember(int id, Member memberRequest)
        {
            var member = await _memberService.UpdateMember(id, memberRequest);
            if (member is null)
                return NotFound("The Member you are trying to update can not be found.");

            return Ok(member);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Member>>> DeleteBook(int id)
        {
            var member = await _memberService.DeleteMember(id);
            if (member is null)
                return NotFound("The Member you are trying to delete was not found.");

            return Ok(member);
        }

    }
}
