using LibraNet.Contracts.Correlation;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Services;
using Microsoft.Extensions.Logging;

namespace LibraNet.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private ILogger<BookService> _logger;

        public BookService(ILogger<BookService> logger, IBookRepository bookRepository) {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public BookDto Create(BookCreateDto bookCreateDto, CorrelationId correlationId)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id, CorrelationId correlationId)
        {
            throw new NotImplementedException();
        }

        public BookDto GetById(Guid Id, CorrelationId correlationId)
        {
            throw new NotImplementedException();
        }

        public BookDto Update(BookUpdateDto bookUpdateDto, CorrelationId correlationId)
        {
            throw new NotImplementedException();
        }
    }
}