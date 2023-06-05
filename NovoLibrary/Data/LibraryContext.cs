using Microsoft.EntityFrameworkCore;
using NovoLibrary.Models;

namespace NovoLibrary.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BorrowTransaction> BorrowTransactions { get; set; }

    }
}
