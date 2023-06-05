using NovoLibrary.Core.Repositories;
using NovoLibrary.Data;
using NovoLibrary.Models;

namespace NovoLibrary.Core
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LibraryContext _libraryContext;

        public IGenericRepository<Book> BookRepository { get; }

        public IGenericRepository<Member> MemberRepository { get; }


        public UnitOfWork(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
            BookRepository = new GenericRepository<Book>(_libraryContext);
            MemberRepository = new GenericRepository<Member>(_libraryContext);

        }

        public async Task CompleteAsync()
        {
            await _libraryContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _libraryContext.Dispose();
        }
    }
}
