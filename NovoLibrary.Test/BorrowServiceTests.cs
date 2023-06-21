using Moq;
using NovoLibrary.Core;
using NovoLibrary.Models;
using NovoLibrary.Services.BorrowService;
using System;

namespace NoveLibrary.Test
{
    public class BorrowServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private BorrowService _borrowService;

        public BorrowServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _borrowService = new BorrowService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task BorrowBook_ShouldThrowException_WhenBookIsNotAvailable()
        {
            // Arrange
            var book = new Book { Id = 1, IsAvailable = false };
            _unitOfWorkMock.Setup(u => u.BookRepository.GetById(It.IsAny<int>())).ReturnsAsync(book);


            var borrowTransaction = new BorrowTransaction
            {
                BookId = 1,
                MemberId = 1,
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7)
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _borrowService.BorrowBook(borrowTransaction));

            Assert.Equal("Book is not available", exception.Message);
        }

        [Fact]
        public async Task BorrowBook_ShouldSetBorrowDate_WhenCalled()
        {
            // Arrange
            _unitOfWorkMock.Setup(u => u.BookRepository.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Book { IsAvailable = true });

            var transaction = new BorrowTransaction { BookId = 1, MemberId = 1 };

            // Act
            await _borrowService.BorrowBook(transaction);

            //Assert
            var excception = await Assert.ThrowsAsync<InvalidOperationException>(() => _borrowService.BorrowBook(transaction));
            Assert.Equal("You need to set the borrow date for this transaction", excception.Message);
        }

        [Fact]
        public async Task BorrowBook_ShouldSetReturnDate_WhenCalled()
        {
            // Arrange
            var book = new Book { Id = 1, IsAvailable = true };
            _unitOfWorkMock.Setup(u => u.BookRepository.GetById(It.IsAny<int>())).ReturnsAsync(book);

            _unitOfWorkMock.Setup(u => u.BorrowTransactionRepository.Add(It.IsAny<BorrowTransaction>()))
                .Callback<BorrowTransaction>(bt => bt.ReturnDate = DateTime.UtcNow)
                .ReturnsAsync(true);


            var borrowTransaction = new BorrowTransaction
            {
                BookId = 1,
                MemberId = 1
            };


            //Act
            await _borrowService.BorrowBook(borrowTransaction);


            //Assert
            Assert.NotNull(borrowTransaction.ReturnDate);
            Assert.Equal(DateTime.UtcNow.Date, borrowTransaction.ReturnDate.Date);
        }

        [Fact]
        public async Task GetBooksByMember_ShouldReturnOnlyNotAvailableBooks()
        {
            // Arrange
            var memberId = 1;
            var books = new List<Book> {
                new Book { Id = 1, IsAvailable = false },  // borrowed book
                new Book { Id = 2, IsAvailable = true },   // available book
                new Book { Id = 3, IsAvailable = false },  // borrowed book
            };


            _unitOfWorkMock.Setup(u => u.BorrowTransactionRepository.getBooksByMember(memberId)).ReturnsAsync(books);

            // Act
            var result = await _borrowService.GetBooksByMember(memberId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.DoesNotContain(result, b => b.IsAvailable);
        }


        [Fact]
        public async Task ReturnBook_ShouldUpdateBookAvailability_WhenCalled()
        {
            // Arrange
            var book = new Book { Id = 1, IsAvailable = false }; // a borrowed book
            var borrowTransaction = new BorrowTransaction { Id = 1, BookId = book.Id, MemberId = 1, BorrowDate = DateTime.Now, ReturnDate = DateTime.Now };

            _unitOfWorkMock.Setup(u => u.BorrowTransactionRepository.GetById(borrowTransaction.Id)).ReturnsAsync(borrowTransaction);
            _unitOfWorkMock.Setup(u => u.BookRepository.GetById(book.Id)).ReturnsAsync(book);
            _unitOfWorkMock.Setup(u => u.BookRepository.Update(It.IsAny<Book>())).Returns(Task.FromResult(true));
            _unitOfWorkMock.Setup(u => u.BorrowTransactionRepository.Update(It.IsAny<BorrowTransaction>())).Returns(Task.FromResult(true));
            _unitOfWorkMock.Setup(u => u.CompleteAsync()).Returns(Task.CompletedTask);

            // Act
            await _borrowService.ReturnBook(borrowTransaction.Id);

            // Assert
            Assert.True(book.IsAvailable);
            _unitOfWorkMock.Verify(u => u.BookRepository.Update(It.IsAny<Book>()), Times.Once());
            _unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Once());
        }

        [Fact]
        public async Task ReturnBook_ShouldThrowException_WhenBookIsAlreadyAvailable()
        {
            // Arrange
            var book = new Book { Id = 1, IsAvailable = true }; // Book is already marked as available
            var borrowTransaction = new BorrowTransaction { Id = 1, BookId = book.Id, MemberId = 1, BorrowDate = DateTime.Now };

            _unitOfWorkMock.Setup(u => u.BorrowTransactionRepository.GetById(borrowTransaction.Id)).ReturnsAsync(borrowTransaction);
            _unitOfWorkMock.Setup(u => u.BookRepository.GetById(book.Id)).ReturnsAsync(book);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await _borrowService.ReturnBook(borrowTransaction.Id));
        }
    }
}