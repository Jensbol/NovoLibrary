using NovoLibrary.Core.Repositories;
using NovoLibrary.Models;

namespace NovoLibrary.Core
{
    public interface IUnitOfWork
    {
        IGenericRepository<Book> BookRepository { get; }
        IGenericRepository<Member> MemberRepository { get; }
        IBorrowRepository BorrowTransactionRepository { get; }
        Task CompleteAsync();
    }
}
