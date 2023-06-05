using Microsoft.EntityFrameworkCore;
using NovoLibrary.Data;
using NovoLibrary.Models;

namespace NovoLibrary.Core.Repositories
{
    public class BorrowRepository : GenericRepository<BorrowTransaction>, IBorrowRepository
    {
        public BorrowRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<List<Book>> getBooksByMember(int memberID)
        {
            return await _context.BorrowTransactions
                .Where(bt => bt.MemberId == memberID)
                .Select(bt => bt.BookId)
                .Join(_context.Books,
                    btId => btId,
                    book => book.Id,
                    (btId, book) => book)
                .ToListAsync();
        }
    }
}
