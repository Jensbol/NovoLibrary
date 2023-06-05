using NovoLibrary.Core;
using NovoLibrary.Models;
using NovoLibrary.Services.BookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoveLibrary.Test
{
    public class BookServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private BookService _bookService;

        public BookServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _bookService = new BookService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task GetAllBooks_ShouldRetrieveAllBooks_WhenCalled()
        {
            // Arrange
            var books = new List<Book> {
                new Book { Id = 1, Title = "Book1", Author = "Author1", PublicationYear = 2000, IsAvailable = true },
                new Book { Id = 2, Title = "Book2", Author = "Author2", PublicationYear = 2001, IsAvailable = false }
            };

            _unitOfWorkMock.Setup(u => u.BookRepository.GetAll()).ReturnsAsync(books);

            // Act
            var result = await _bookService.GetAllBooks();

            // Assert
            Assert.Equal(books, result);
        }

        [Fact]
        public async Task GetBookById_ShouldReturnBook_WhenBookExists()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Book1", Author = "Author1", PublicationYear = 2000, IsAvailable = true };
            _unitOfWorkMock.Setup(u => u.BookRepository.GetById(It.IsAny<int>())).ReturnsAsync(book);

            // Act
            var result = await _bookService.GetBookById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(book, result);
        }

        [Fact]
        public async Task GetBookById_ShouldThrowException_WhenBookDoesNotExist()
        {
            // Arrange
            _unitOfWorkMock.Setup(u => u.BookRepository.GetById(It.IsAny<int>())).ReturnsAsync((Book)null);

            // Act
            await Assert.ThrowsAsync<Exception>(() => _bookService.GetBookById(1));
        }
    }
}
