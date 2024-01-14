using AutoMapper;
using FluentAssertions;
using LibraNet.Contracts.Correlation;
using LibraNet.Contracts.Dtos.Borrowing;
using LibraNet.Contracts.Entities;
using LibraNet.Contracts.Enums;
using LibraNet.Contracts.Exceptions;
using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Services;
using LibraNet.Services.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq.Expressions;


namespace LibraNet.Services.Tests
{
    public class BorrowingServiceTests
    {
        private readonly Mock<IBorrowingRepository> _mockBorrowingRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<BorrowingService>> _mockLogger;
        private readonly IBorrowingService _borrowingService;

        public BorrowingServiceTests()
        {
            _mockBorrowingRepository = new Mock<IBorrowingRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<BorrowingService>>();
            _borrowingService = new BorrowingService(_mockLogger.Object, _mockBorrowingRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Close_ShouldCloseBorrowing_Ok()
        {
            // Arrange
            var id = Guid.NewGuid();
            var correlationId = new CorrelationId();
            var borrowingEntity = new Borrowing { Id = id, Status = BorrowingStatus.Active };

            _mockBorrowingRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Borrowing, bool>>>()))
                                  .ReturnsAsync(borrowingEntity);

            // Act
            var result = await _borrowingService.Close(id, correlationId);

            // Assert
            _mockBorrowingRepository.Verify(repo => repo.Update(It.IsAny<Borrowing>()), Times.Once);
            borrowingEntity.Status.Should().Be(BorrowingStatus.Closed);
            borrowingEntity.ClosedAt.Should().NotBe(null);
            result.Should().BeEquivalentTo(await _borrowingService.GetById(id, correlationId));
        }

        [Fact]
        public async Task Close_ShouldThrowDataNotFoundExceptionWhenBorrowingNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            var correlationId = new CorrelationId();

            _mockBorrowingRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Borrowing, bool>>>()))
                                  .ReturnsAsync((Borrowing)null);

            // Act and Assert
            await Assert.ThrowsAsync<DataNotFoundException>(() => _borrowingService.Close(id, correlationId));
        }

        [Fact]
        public async Task Create_ShouldCreateBorrowing_Ok()
        {
            // Arrange
            var borrowingCreateDto = new BorrowingCreateDto { BookId = Guid.NewGuid() };
            var borrowingEntity = new Borrowing { Id = Guid.NewGuid() };
            var correlationId = new CorrelationId();

            _mockMapper.Setup(m => m.Map<Borrowing>(borrowingCreateDto)).Returns(borrowingEntity);
            _mockMapper.Setup(m => m.Map<BorrowingDto>(borrowingEntity)).Returns(new BorrowingDto { Id = borrowingEntity.Id });
            _mockBorrowingRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Borrowing, bool>>>()))
                      .ReturnsAsync(borrowingEntity);
            // Act
            var result = await _borrowingService.Create(borrowingCreateDto, correlationId);

            // Assert
            _mockBorrowingRepository.Verify(repo => repo.AddAsync(It.IsAny<Borrowing>()), Times.Once);
            _mockBorrowingRepository.Verify(repo => repo.SaveChanges(), Times.Once);
            result.Should().BeEquivalentTo(borrowingEntity);
        }

        [Fact]
        public async Task GetById_ShouldGetBorrowingById_Ok()
        {
            // Arrange
            var id = Guid.NewGuid();
            var correlationId = new CorrelationId();
            var borrowingEntity = new Borrowing { Id = id };
            var borrowingDto = new BorrowingDto { Id = id };

            _mockBorrowingRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Borrowing, bool>>>()))
                                  .ReturnsAsync(borrowingEntity);
            _mockMapper.Setup(m => m.Map<BorrowingDto>(borrowingEntity)).Returns(borrowingDto);

            // Act
            var result = await _borrowingService.GetById(id, correlationId);

            // Assert
            result.Should().BeEquivalentTo(borrowingDto);
        }

        [Fact]
        public async Task GetById_ShouldThrowDataNotFoundExceptionWhenBorrowingNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            var correlationId = new CorrelationId();

            _mockBorrowingRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Borrowing, bool>>>()))
                                  .ReturnsAsync((Borrowing)null);

            // Act and Assert
            await Assert.ThrowsAsync<DataNotFoundException>(() => _borrowingService.GetById(id, correlationId));
        }

        [Fact]
        public async Task Prolong_ShouldProlongBorrowing_Ok()
        {
            // Arrange
            var borrowingProlongDto = new BorrowingProlongDto { Id = Guid.NewGuid(), BorrowingTo = DateTime.UtcNow.AddDays(7) };
            var borrowingEntity = new Borrowing { Id = borrowingProlongDto.Id, Status = BorrowingStatus.Active };
            var updatedBorrowingEntity = new Borrowing { Id = borrowingProlongDto.Id, BorrowingTo = borrowingProlongDto.BorrowingTo };
            var correlationId = new CorrelationId();

            _mockBorrowingRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Borrowing, bool>>>()))
                                  .ReturnsAsync(borrowingEntity);
            _mockMapper.Setup(m => m.Map(borrowingProlongDto, borrowingEntity)).Returns(updatedBorrowingEntity);
            _mockMapper.Setup(m => m.Map<BorrowingDto>(updatedBorrowingEntity)).Returns(new BorrowingDto { Id = updatedBorrowingEntity.Id, BorrowingTo = updatedBorrowingEntity.BorrowingTo });

            // Act
            var result = await _borrowingService.Prolong(borrowingProlongDto, correlationId);

            // Assert
            _mockBorrowingRepository.Verify(repo => repo.Update(updatedBorrowingEntity), Times.Once);
            result.Should().BeEquivalentTo(await _borrowingService.GetById(updatedBorrowingEntity.Id, correlationId));
        }

        [Fact]
        public async Task Prolong_ShouldThrowDataNotFoundExceptionWhenBorrowingNotFound()
        {
            // Arrange
            var borrowingProlongDto = new BorrowingProlongDto { Id = Guid.NewGuid(), BorrowingTo = DateTime.UtcNow.AddDays(7) };
            var correlationId = new CorrelationId();

            _mockBorrowingRepository.Setup(repo => repo.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Borrowing, bool>>>()))
                                  .ReturnsAsync((Borrowing)null);

            // Act and Assert
            await Assert.ThrowsAsync<DataNotFoundException>(() => _borrowingService.Prolong(borrowingProlongDto, correlationId));
        }
    }
}
