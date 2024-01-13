using LibraNet.Contracts.Correlation;
using LibraNet.Contracts.Dtos.Borrowing;
using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Services;
using Microsoft.Extensions.Logging;

namespace LibraNet.Services.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IBorrowingRepository _borrowingRepository;
        private ILogger<BorrowingService> _logger;

        public BorrowingService(ILogger<BorrowingService> logger, IBorrowingRepository borrowingRepository)
        {
            _logger = logger;
            _borrowingRepository = borrowingRepository;
        }

        public BorrowingDto Create(BorrowingCreateDto bookCreateDto, CorrelationId correlationId)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public BorrowingDto GetById(Guid Id, CorrelationId correlationId)
        {
            throw new NotImplementedException();
        }

        public BorrowingDto Update(BorrowingUpdateDto bookUpdateDto, CorrelationId correlationId)
        {
            throw new NotImplementedException();
        }
    }
}
