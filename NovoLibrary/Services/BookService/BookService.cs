using NovoLibrary.Core;
using NovoLibrary.Core.Repositories;
using NovoLibrary.Models;

namespace NovoLibrary.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _unitOfWork.BookRepository.GetAll();
            return books;
        }

        public async Task<Book>? GetBookById(int id)
        {
            var book = await _unitOfWork.BookRepository.GetById(id);
            if ( book is null)
                return null;
            
            return book;
        }

        public async Task<List<Book>> AddBook(Book book)
        {
            await _unitOfWork.BookRepository.Add(book);
            await _unitOfWork.CompleteAsync();
            return await _unitOfWork.BookRepository.GetAll();
        }

        public async Task<List<Book>>? DeleteBook(int id)
        {
            var bookToDelete = await _unitOfWork.BookRepository.GetById(id);
            if (bookToDelete is null)
                return null;

            await _unitOfWork.BookRepository.Delete(bookToDelete);
            await _unitOfWork.CompleteAsync();

            return await _unitOfWork.BookRepository.GetAll(); ;
        }

        public async Task<List<Book>>? UpdateBook(int id, Book request)
        {
            var bookToUpdate = await _unitOfWork.BookRepository.GetById(id);
            if (bookToUpdate is null)
                return null;

            bookToUpdate.Title = request.Title;
            bookToUpdate.Author = request.Author;
            bookToUpdate.PublicationYear = request.PublicationYear;
            bookToUpdate.IsAvailable = request.IsAvailable;

            await _unitOfWork.BookRepository.Update(bookToUpdate);
            await _unitOfWork.CompleteAsync();

            return await _unitOfWork.BookRepository.GetAll();


        }
    }
}
