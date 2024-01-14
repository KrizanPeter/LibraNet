using LibraNet.Api.Controllers;
using LibraNet.Contracts.Constants;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Exceptions;
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
            var correlationId = GetNewCorrelationId();
            _logger.LogInformation($"{Endpoints.BookGet} started. CorrelationId: {correlationId}");

            try
            {
                var book =  await _bookService.GetById(id, correlationId);
                return Ok(book);
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Endpoints.BookGet} started. CorrelationId: {correlationId}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(BookCreateDto bookCreateDto)
        {
            var correlationId = GetNewCorrelationId();
            _logger.LogInformation($"{Endpoints.BookCreate} started. CorrelationId: {correlationId}");

            try
            {            
                var book = await _bookService.Create(bookCreateDto, correlationId);
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Endpoints.BookCreate} failed. CorrelationId: {correlationId}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(BookUpdateDto bookUpdateDto)
        {
            var correlationId = GetNewCorrelationId();
            _logger.LogInformation($"{Endpoints.BookUpdate} started. CorrelationId: {correlationId}");
            
            try
            {
                var book = await _bookService.Update(bookUpdateDto, correlationId);
                return Ok(book);
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Endpoints.BookUpdate}. CorrelationId: {correlationId}, {ex}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var correlationId = GetNewCorrelationId();
            _logger.LogInformation($"{Endpoints.BookDelete} started. CorrelationId: {correlationId}");

            try
            {
                _bookService.Delete(id, GetNewCorrelationId());
                return Ok();
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Endpoints.BookDelete} failed. CorrelationId: {correlationId}, {ex}");
                return StatusCode(500, ex.Message);
            }
        }


    }
}
