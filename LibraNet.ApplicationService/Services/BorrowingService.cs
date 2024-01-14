using AutoMapper;
using LibraNet.Contracts.Correlation;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Dtos.Borrowing;
using LibraNet.Contracts.Entities;
using LibraNet.Contracts.Enums.LibraNetEntity;
using LibraNet.Contracts.Exceptions;
using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Services;
using LibraNet.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace LibraNet.Services.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly ILogger<BorrowingService> _logger;
        private readonly IMapper _mapper;

        public BorrowingService(ILogger<BorrowingService> logger, IBorrowingRepository borrowingRepository, IMapper mapper)
        {
            _logger = logger;
            _borrowingRepository = borrowingRepository;
            _mapper = mapper;
        }

        public async Task<BorrowingDto> Close(Guid id, CorrelationId correlationId)
        {
            var borrowingEntity = await _borrowingRepository.GetFirstOrDefaultAsync(a => a.Id == id);

            if (borrowingEntity == null)
            {
                _logger.LogError($"Close operation for {LibraNetEntity.Borrowing.GetEnumName()} {id} has not been found. CorrelationId {correlationId.Id}");
                throw new DataNotFoundException(LibraNetEntity.Borrowing.GetEnumName() + " has not been found");
            }

            borrowingEntity.Status = Contracts.Enums.BorrowingStatus.Closed;
            borrowingEntity.ClosedAt = DateTime.UtcNow;

            _borrowingRepository.Update(borrowingEntity);

            return await GetById(borrowingEntity.Id, correlationId);
        }

        public async Task<BorrowingDto> Create(BorrowingCreateDto borrowingCreateDto, CorrelationId correlationId)
        {
            var borrowingEntity = _mapper.Map<Borrowing>(borrowingCreateDto);
            await _borrowingRepository.AddAsync(borrowingEntity);
            _borrowingRepository.SaveChanges();

            return await GetById(borrowingEntity.Id, correlationId);
        }

        public async Task<BorrowingDto> GetById(Guid id, CorrelationId correlationId)
        {
            var borrowingEntity = await _borrowingRepository.GetFirstOrDefaultAsync(a => a.Id == id);

            if (borrowingEntity == null)
            {
                _logger.LogError($"Close operation for {LibraNetEntity.Borrowing.GetEnumName()} {id} has not been found. CorrelationId {correlationId.Id}");
                throw new DataNotFoundException(LibraNetEntity.Borrowing.GetEnumName() + " has not been found");
            }
            return _mapper.Map<BorrowingDto>(borrowingEntity);
        }

        public async Task<BorrowingDto> Prolong(BorrowingProlongDto borrowingUpdateDto, CorrelationId correlationId)
        {
            var borrowingEntity = await _borrowingRepository.GetFirstOrDefaultAsync(a => a.Id == borrowingUpdateDto.Id && a.Status != Contracts.Enums.BorrowingStatus.Closed);

            if (borrowingEntity == null)
            {
                _logger.LogError($"Close operation for {LibraNetEntity.Borrowing.GetEnumName()} {borrowingUpdateDto.Id} has not been found. CorrelationId {correlationId.Id}");
                throw new DataNotFoundException(LibraNetEntity.Borrowing.GetEnumName() + "in active/prolonged state has not been found");
            }

            var updatedBookEntity = _mapper.Map(borrowingUpdateDto, borrowingEntity);

            _borrowingRepository.Update(updatedBookEntity);

            return await GetById(borrowingEntity.Id, correlationId);
        }
    }
}
