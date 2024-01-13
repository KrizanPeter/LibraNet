using LibraNet.Api.Controllers;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Entities;
using LibraNet.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(ILogger<BookController> logger, IBookService bookService) : BaseController(logger)
    {
        private readonly ILogger<BookController> _logger = logger;
        private readonly IBookService _bookService = bookService;

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var book =  await _bookService.GetById(id, GetNewCorrelationId());
                return Ok(book);
            }
            catch { }

            return StatusCode(404);
        }

        [HttpPost("create")]
        public IActionResult Create(BookCreateDto bookCreateDto)
        {

            try
            {
               
                var book = _bookService.Create(bookCreateDto, GetNewCorrelationId());
                return Ok(book);
            }
            catch
            {

            }
            return BadRequest();
            
        }

        [HttpPut("update")]
        public IActionResult Update(BookUpdateDto bookUpdateDto)
        {
            try
            {
                var book = _bookService.Update(bookUpdateDto, GetNewCorrelationId());
            }
            catch 
            {
            
            }


            return StatusCode(404);
        }

        [HttpDelete("delete")]
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
