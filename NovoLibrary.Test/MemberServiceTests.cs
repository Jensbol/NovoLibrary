
using NovoLibrary.Core;
using NovoLibrary.Models;
using NovoLibrary.Services.MemberService;


namespace NoveLibrary.Test
{
    public class MemberServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private MemberService _memberService;

        public MemberServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _memberService = new MemberService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task AddMember_ShouldAddNewMember_WhenCalled()
        {
            // Arrange
            var newMember = new Member { Id = 1, Name = "John Doe" };
            var membersList = new List<Member>();

            _unitOfWorkMock.Setup(u => u.MemberRepository.Add(It.IsAny<Member>()))
                .Callback<Member>(member => membersList.Add(member))
                .Returns(Task.FromResult(true));
            _unitOfWorkMock.Setup(u => u.MemberRepository.GetAll())
                .ReturnsAsync(membersList);
            _unitOfWorkMock.Setup(u => u.CompleteAsync()).Returns(Task.CompletedTask);

            // Act
            var result = await _memberService.AddMember(newMember);

            // Assert
            Assert.Contains(newMember, result);
        }

        [Fact]
        public async Task DeleteMember_ShouldDeleteMember_WhenCalled()
        {
            // Arrange
            var memberToDelete = new Member { Id = 1, Name = "John Doe" };
            var membersList = new List<Member> { memberToDelete };

            _unitOfWorkMock.Setup(u => u.MemberRepository.GetById(It.IsAny<int>())).ReturnsAsync(memberToDelete);
            _unitOfWorkMock.Setup(u => u.MemberRepository.Delete(It.IsAny<Member>()))
                .Callback<Member>(member => membersList.Remove(member))
                .Returns(Task.FromResult(true));
            _unitOfWorkMock.Setup(u => u.MemberRepository.GetAll())
                .ReturnsAsync(membersList);
            _unitOfWorkMock.Setup(u => u.CompleteAsync()).Returns(Task.CompletedTask);

            // Act
            var result = await _memberService.DeleteMember(memberToDelete.Id);

            // Assert
            Assert.DoesNotContain(memberToDelete, result);
        }

        [Fact]
        public async Task UpdateMember_ShouldUpdateMember_WhenCalled()
        {
            // Arrange
            var existingMember = new Member { Id = 1, Name = "John Doe" };
            var updatedMember = new Member { Id = 1, Name = "Jane Doe" };

            _unitOfWorkMock.Setup(u => u.MemberRepository.GetById(It.IsAny<int>())).ReturnsAsync(existingMember);
            _unitOfWorkMock.Setup(u => u.MemberRepository.Update(It.IsAny<Member>()))
                .Callback<Member>(member => existingMember.Name = member.Name)
                .Returns(Task.FromResult(true));
            _unitOfWorkMock.Setup(u => u.MemberRepository.GetAll())
                .ReturnsAsync(new List<Member> { existingMember });
            _unitOfWorkMock.Setup(u => u.CompleteAsync()).Returns(Task.CompletedTask);

            // Act
            var result = await _memberService.UpdateMember(updatedMember.Id, updatedMember);

            // Assert
            Assert.Equal(updatedMember.Name, result.First().Name);
        }
    }
}
