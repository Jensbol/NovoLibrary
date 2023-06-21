using NovoLibrary.Models;

namespace NovoLibrary.Services.BorrowService
{
    public interface IBorrowService
    {
        Task<List<Book>> GetBooksByMember(int memberId);

        Task<BorrowTransaction> BorrowBook(BorrowTransaction borrowTransaction);

        Task<BorrowTransaction> ReturnBook(int bookId);

    }
}
