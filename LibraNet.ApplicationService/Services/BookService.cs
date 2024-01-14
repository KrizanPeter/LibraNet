using AutoMapper;
using LibraNet.Contracts.Correlation;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Entities;
using LibraNet.Contracts.Enums.LibraNetEntity;
using LibraNet.Contracts.Exceptions;
using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Services;
using Microsoft.Extensions.Logging;

namespace LibraNet.Services.Services
{

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private ILogger<BookService> _logger;
        private readonly IMapper _mapper;

        public BookService(ILogger<BookService> logger, IBookRepository bookRepository, IMapper mapper) {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Create(BookCreateDto bookCreateDto, CorrelationId correlationId)
        {
            var bookEntity = _mapper.Map<Book>(bookCreateDto);
            await _bookRepository.AddAsync(bookEntity);
            _bookRepository.SaveChanges();
            
            return await GetById(bookEntity.Id, correlationId);
        }

        public async void Delete(Guid id, CorrelationId correlationId)
        {
            var bookentity = await _bookRepository.GetFirstOrDefaultAsync(a => a.Id == id);

            if (bookentity == null)
            {
                _logger.LogError($"Close operation for {LibraNetEntity.Book.GetEnumName()} {id} has not been found. CorrelationId {correlationId.Id}");
                throw new DataNotFoundException(LibraNetEntity.Book.GetEnumName() + " has not been found");
            }

            _bookRepository.Remove(bookentity);
        }

        public async Task<BookDto> GetById(Guid id, CorrelationId correlationId)
        {
            var bookentity = await _bookRepository.GetFirstOrDefaultAsync(a=>a.Id == id);
            
            if (bookentity == null)
            {
                _logger.LogError($"Close operation for {LibraNetEntity.Book.GetEnumName()} {id} has not been found. CorrelationId {correlationId.Id}");
                throw new DataNotFoundException(LibraNetEntity.Book.GetEnumName() + " has not been found");
            }
            return _mapper.Map<BookDto>(bookentity);
        }

        public async Task<BookDto> Update(BookUpdateDto bookUpdateDto, CorrelationId correlationId)
        {
            var bookEntity = await _bookRepository.GetFirstOrDefaultAsync(a => a.Id == bookUpdateDto.Id);

            if (bookEntity == null)
            {
                _logger.LogError($"Close operation for {LibraNetEntity.Book.GetEnumName()} {bookUpdateDto.Id} has not been found. CorrelationId {correlationId.Id}");
                throw new DataNotFoundException(LibraNetEntity.Book.GetEnumName() + " has not been found");
            }

            var updatedBookEntity = _mapper.Map(bookUpdateDto, bookEntity);

            _bookRepository.Update(updatedBookEntity);

            return await GetById(bookEntity.Id, correlationId);
        }
    }
}