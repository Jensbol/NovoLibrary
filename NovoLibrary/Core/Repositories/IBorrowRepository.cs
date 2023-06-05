using NovoLibrary.Models;

namespace NovoLibrary.Core.Repositories
{
    public interface IBorrowRepository : IGenericRepository<BorrowTransaction>
    {
        Task<List<Book>> getBooksByMember(int memberID);
    }
}
