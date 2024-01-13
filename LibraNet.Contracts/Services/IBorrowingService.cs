using LibraNet.Contracts.Correlation;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Dtos.Borrowing;


namespace LibraNet.Contracts.Services
{
    public interface IBorrowingService
    {
        BorrowingDto GetById(Guid Id, CorrelationId correlationId);
        BorrowingDto Create(BorrowingCreateDto bookCreateDto, CorrelationId correlationId);
        BorrowingDto Update(BorrowingUpdateDto bookUpdateDto, CorrelationId correlationId);
        void Delete(Guid Id);
    }
}
