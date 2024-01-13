using AutoMapper;
using LibraNet.Contracts.Correlation;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Entities;
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
            BookDto returnDto = new();
            try
            {
                var bookEntity = _mapper.Map<Book>(bookCreateDto);
                await _bookRepository.AddAsync(bookEntity);
                _bookRepository.SaveChanges();
                returnDto = _mapper.Map<BookDto>(bookEntity);
            }
            catch (Exception ex)
            {

            }

            return returnDto;
        }

        public void Delete(Guid Id, CorrelationId correlationId)
        {
            throw new NotImplementedException();
        }

        public async Task<BookDto> GetById(Guid Id, CorrelationId correlationId)
        {
            try
            {
                var bookentity = await _bookRepository.GetFirstOrDefaultAsync(a=>a.Id == Id);
                return _mapper.Map<BookDto>(bookentity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<BookDto> Update(BookUpdateDto bookUpdateDto, CorrelationId correlationId)
        {
            throw new NotImplementedException();
        }
    }
}