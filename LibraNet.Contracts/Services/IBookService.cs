
using LibraNet.Contracts.Correlation;
using LibraNet.Contracts.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Contracts.Services
{
    public interface IBookService
    {
        BookDto GetById(Guid Id, CorrelationId correlationId);
        BookDto Create(BookCreateDto bookCreateDto, CorrelationId correlationId);
        BookDto Update(BookUpdateDto bookUpdateDto, CorrelationId correlationId);
        void Delete(Guid Id, CorrelationId correlationId);
    }
}
