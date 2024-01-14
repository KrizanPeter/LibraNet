using LibraNet.Contracts.Correlation;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Dtos.Borrowing;


namespace LibraNet.Contracts.Services
{
    public interface IBorrowingService
    {
        Task<BorrowingDto> GetById(Guid Id, CorrelationId correlationId);
        Task<BorrowingDto> Create(BorrowingCreateDto bookCreateDto, CorrelationId correlationId);
        Task<BorrowingDto> Prolong(BorrowingProlongDto borrowingProlongDto, CorrelationId correlationId);
        Task<BorrowingDto> Close(Guid Id, CorrelationId correlationId);

    }
}
