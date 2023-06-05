using Azure.Core;
using NovoLibrary.Core;
using NovoLibrary.Models;

namespace NovoLibrary.Services.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Member>> AddMember(Member member)
        {
            await _unitOfWork.MemberRepository.Add(member);
            await _unitOfWork.CompleteAsync();

            return await _unitOfWork.MemberRepository.GetAll();
        }

        public async Task<List<Member>>? DeleteMember(int id)
        {
            var memberToDelete = await _unitOfWork.MemberRepository.GetById(id);
            if (memberToDelete is null)
                return null;

            await _unitOfWork.MemberRepository.Delete(memberToDelete);
            await _unitOfWork.CompleteAsync();

            return await _unitOfWork.MemberRepository.GetAll(); ;

        }

        public async Task<List<Member>> GetAllMembers()
        {
            var members = await _unitOfWork.MemberRepository.GetAll();
            return members; ;
        }

        public async Task<Member>? GetMemberById(int id)
        {
            var member = await _unitOfWork.MemberRepository.GetById(id);
            if (member is null)
                return null;

            return member;
        }

        public async Task<List<Member>>? UpdateMember(int id, Member request)
        {
            var memberToUpdate = await _unitOfWork.MemberRepository.GetById(id);
            if (memberToUpdate is null)
                return null;

            memberToUpdate.Name = request.Name;

            await _unitOfWork.MemberRepository.Update(memberToUpdate);
            await _unitOfWork.CompleteAsync();

            return await _unitOfWork.MemberRepository.GetAll();
        }
    }
}
