using NovoLibrary.Models;

namespace NovoLibrary.Services.BorrowService
{
    public interface IBorrowService
    {
        Task<List<Book>> GetBooksByMember(int memberId);

        Task<BorrowTransaction> BorrowBook(BorrowTransaction borrowTransaction);

        Task<List<BorrowTransaction>> ReturnBook(int bookId);

    }
}
