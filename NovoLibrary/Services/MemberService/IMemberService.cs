using NovoLibrary.Models;

namespace NovoLibrary.Services.MemberService
{
    public interface IMemberService
    {
        Task<List<Member>> GetAllMembers();
        Task<Member>? GetMemberById(int id);
        Task<List<Member>> AddMember(Member member);
        Task<List<Member>>? UpdateMember(int Id, Member request);

        Task<List<Member>>? DeleteMember(int id);
    }
}
