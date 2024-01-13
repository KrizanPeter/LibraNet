using LibraNet.Api.Controllers;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService) :base(logger)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet(Name = "getBookById")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var book = _bookService.GetById(id, GetNewCorrelationId());
            }
            catch { }

            return StatusCode(404);
        }

        [HttpPost(Name = "createBook")]
        public IActionResult Create(BookCreateDto bookCreateDto)
        {
            try
            {
                var book = _bookService.Create(bookCreateDto, GetNewCorrelationId());
            }
            catch { 
            
            }

            return StatusCode(404);
        }

        [HttpPut(Name = "updateBook")]
        public IActionResult Update(BookUpdateDto bookUpdateDto)
        {
            try
            {
                var book = _bookService.Update(bookUpdateDto, GetNewCorrelationId());
            }
            catch { }


            return StatusCode(404);
        }

        [HttpPut(Name = "deleteBook")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _bookService.Delete(id, GetNewCorrelationId());
            }
            catch { }

            return StatusCode(404);
        }


    }
}
