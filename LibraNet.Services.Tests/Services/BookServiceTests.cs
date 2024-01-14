
using AutoMapper;
using FluentAssertions;
using LibraNet.Contracts.Correlation;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Entities;
using LibraNet.Contracts.Enums.LibraNetEntity;
using LibraNet.Contracts.Exceptions;
using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Services;
using LibraNet.Services.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace LibraNet.Services.Tests
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<BookService>> _mockLogger;
        private readonly IBookService _bookService;

        public BookServiceTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<BookService>>();
            _bookService = new BookService(_mockLogger.Object, _mockBookRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Create_ShouldCreateBook_Ok()
        {
            // Arrange
            var bookCreateDto = new BookCreateDto() { Author = "TestAuthor", Title = "TestTitle" };
            var bookEntity = new Book() { Author = "TestAuthor", Title = "TestTitle" };
            var correlationId = new CorrelationId();

            _mockMapper.Setup(m => m.Map<Book>(bookCreateDto)).Returns(new Book() { Author = "TestAuthor", Title = "TestTitle" });
            _mockMapper.Setup(m => m.Map<BookDto>(bookEntity)).Returns(new BookDto() { Author = "TestAuthor", Title = "TestTitle" });

            _mockBookRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                      .ReturnsAsync(bookEntity);
            // Act
            var result = await _bookService.Create(bookCreateDto, correlationId);

            // Assert
            _mockBookRepository.Verify(repo => repo.AddAsync(It.IsAny<Book>()), Times.Once);
            _mockBookRepository.Verify(repo => repo.SaveChanges(), Times.Once);
            bookEntity.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task Create_ShouldCreateBook_ReloadFailed_ThrowException()
        {
            // Arrange
            Book nullEntity = null;
            var bookCreateDto = new BookCreateDto() {Author = "TestAuthor", Title = "TestTitle" };
            var bookEntity = new Book() { Author = "TestAuthor", Title = "TestTitle" };
            var correlationId = new CorrelationId();

            _mockMapper.Setup(m => m.Map<Book>(bookCreateDto)).Returns(new Book() { Author = "TestAuthor", Title = "TestTitle" });
            _mockMapper.Setup(m => m.Map<BookDto>(bookEntity)).Returns(new BookDto() { Author = "TestAuthor", Title = "TestTitle" });

            _mockBookRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                      .ReturnsAsync(nullEntity);

            // Assert & Assert
            var exception = await Assert.ThrowsAsync<DataNotFoundException>(() => _bookService.Create(bookCreateDto, correlationId));
        
            // mby check exception message in future & logs
            // exception.Message.Should().Be(exceptionMessage);

            _mockBookRepository.Verify(repo => repo.AddAsync(It.IsAny<Book>()), Times.Once);
            _mockBookRepository.Verify(repo => repo.SaveChanges(), Times.Once);

        }

        [Fact]
        public async Task Delete_ShouldDeleteBook_Ok()
        {
            // Arrange
            var id = Guid.NewGuid();
            var correlationId = new CorrelationId();
            var bookEntity = new Book { Id = id, Author = "TestAuthor", Title = "TestTitle" };

            _mockBookRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                              .ReturnsAsync(bookEntity);

            // Act
            _bookService.Delete(id, correlationId);

            // Assert
            _mockBookRepository.Verify(repo => repo.Remove(It.IsAny<Book>()), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldThrowDataNotFoundExceptionWhenBookNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            var correlationId = new CorrelationId();

            _mockBookRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                              .ReturnsAsync((Book)null);

            // Act and Assert
            var exception = Assert.ThrowsAsync<DataNotFoundException>(() => _bookService.Delete(id, correlationId));
            _mockBookRepository.Verify(repo => repo.Remove(It.IsAny<Book>()), Times.Never);
        }

        [Fact]
        public async Task GetById_ShouldGetBookById_Ok()
        {
            // Arrange
            var id = Guid.NewGuid();
            var correlationId = new CorrelationId();
            var bookEntity = new Book { Id = id, Author = "TestAuthor", Title = "TestTitle" };
            var bookDto = new BookDto { Id = id, Author = "TestAuthor", Title = "TestTitle" };

            _mockBookRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                              .ReturnsAsync(bookEntity);
            _mockMapper.Setup(m => m.Map<BookDto>(bookEntity)).Returns(bookDto);

            // Act
            var result = await _bookService.GetById(id, correlationId);

            // Assert
            bookDto.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetById_ShouldThrowDataNotFoundExceptionWhenBookNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            var correlationId = new CorrelationId();

            _mockBookRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                              .ReturnsAsync((Book)null);

            // Act and Assert
            await Assert.ThrowsAsync<DataNotFoundException>(() => _bookService.GetById(id, correlationId));
        }

        [Fact]
        public async Task Update_ShouldUpdateBook_Ok()
        {
            // Arrange
            var id = Guid.NewGuid();
            var bookUpdateDto = new BookUpdateDto { Id = id, Author = "UpdatedAuthor", Title = "UpdatedTitle" };
            var bookEntity = new Book { Id = bookUpdateDto.Id, Author = "TestAuthor", Title = "TestTitle" };
            var updatedBookEntity = new Book { Id = bookUpdateDto.Id, Author = "UpdatedAuthor", Title = "UpdatedTitle" };
            var correlationId = new CorrelationId();

            _mockBookRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                              .ReturnsAsync(bookEntity);
            _mockMapper.Setup(m => m.Map(bookUpdateDto, bookEntity)).Returns(updatedBookEntity);
            _mockMapper.Setup(m => m.Map<BookDto>(updatedBookEntity)).Returns(new BookDto { Id = bookUpdateDto.Id, Author = "UpdatedAuthor", Title = "UpdatedTitle" });
            _mockMapper.Setup(m => m.Map<BookDto>(bookEntity)).Returns(new BookDto { Id = bookUpdateDto.Id, Author = "UpdatedAuthor", Title = "UpdatedTitle" });


            // Act
            var result = await _bookService.Update(bookUpdateDto, correlationId);

            // Assert
            _mockBookRepository.Verify(repo => repo.Update(updatedBookEntity), Times.Once);
            updatedBookEntity.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_ShouldThrowDataNotFoundExceptionWhenBookNotFound()
        {
            // Arrange
            var bookUpdateDto = new BookUpdateDto { Id = Guid.NewGuid(), Author = "UpdatedAuthor", Title = "UpdatedTitle" };
            var correlationId = new CorrelationId();

            _mockBookRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Book, bool>>>()))
                              .ReturnsAsync((Book)null);

            // Act and Assert
            await Assert.ThrowsAsync<DataNotFoundException>(() => _bookService.Update(bookUpdateDto, correlationId));
            _mockBookRepository.Verify(repo => repo.Update(It.IsAny<Book>()), Times.Never);

        }
    }
}