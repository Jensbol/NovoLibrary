using NovoLibrary.Core;
using NovoLibrary.Models;

namespace NovoLibrary.Services.BorrowService
{
    public class BorrowService : IBorrowService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BorrowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BorrowTransaction> BorrowBook(BorrowTransaction borrowTransaction)
        {
            var book = await _unitOfWork.BookRepository.GetById(borrowTransaction.BookId);
            
            if (book is null)
                throw new KeyNotFoundException($"No book found with ID {borrowTransaction.BookId}");

            if (!book.IsAvailable)
                throw new InvalidOperationException("Book is not available");

            book.IsAvailable = false;

            await _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.BorrowTransactionRepository.Add(borrowTransaction);
            await _unitOfWork.CompleteAsync();

            return borrowTransaction;
        }

        public async Task<List<Book>> GetBooksByMember(int memberId)
        {
            var booksByMember = await _unitOfWork.BorrowTransactionRepository.getBooksByMember(memberId);
            return booksByMember.FindAll(b => b.IsAvailable == false);
        }

        public async Task<List<BorrowTransaction>> ReturnBook(int borrowId)
        {
            var bookToReturn = await _unitOfWork.BorrowTransactionRepository.GetById(borrowId);
            if (bookToReturn is null)
                throw new KeyNotFoundException($"No transaction found with ID {borrowId}");

            var book = await _unitOfWork.BookRepository.GetById(bookToReturn.BookId);
            if (book is null)
                throw new KeyNotFoundException($"No book found with ID {bookToReturn.BookId}");

            book.IsAvailable = true;

            await _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.BorrowTransactionRepository.Update(bookToReturn);
            await _unitOfWork.CompleteAsync();

            return await _unitOfWork.BorrowTransactionRepository.GetAll();
        }
    }
}
