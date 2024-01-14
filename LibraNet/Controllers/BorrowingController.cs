using LibraNet.Api.Controllers;
using LibraNet.Contracts.Constants;
using LibraNet.Contracts.Correlation;
using LibraNet.Contracts.Dtos.Book;
using LibraNet.Contracts.Dtos.Borrowing;
using LibraNet.Contracts.Exceptions;
using LibraNet.Contracts.Services;
using LibraNet.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : BaseController
    {
        private readonly ILogger<BorrowingController> _logger;
        private readonly IBorrowingService _borrowingService;

        public BorrowingController(ILogger<BorrowingController> logger, IBorrowingService borrowingService) : base(logger)
        {
            _logger = logger;
            _borrowingService = borrowingService;
        }

        [HttpGet(Name = "getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var correlationId = GetNewCorrelationId();
            _logger.LogInformation($"{Endpoints.BorrowingGet} started. CorrelationId: {correlationId}");

            try
            {
                var book = await _borrowingService.GetById(id, correlationId);
                return Ok(book);
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Endpoints.BorrowingGet} failed. CorrelationId: {correlationId}");
                return StatusCode(500, ex.Message);
            }     
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(BorrowingCreateDto borrowingCreateDto)
        {
            var correlationId = GetNewCorrelationId();
            _logger.LogInformation($"{Endpoints.BorrowingCreate} started. CorrelationId: {correlationId}");

            try
            {
                var borrowing = await _borrowingService.Create(borrowingCreateDto, GetNewCorrelationId());
                return Ok(borrowing);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Endpoints.BorrowingCreate} failed. CorrelationId: {correlationId}, {ex}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("prolong")]
        public async Task<IActionResult> Prolong(BorrowingProlongDto borrowingProlongDto)
        {
            var correlationId = GetNewCorrelationId();
            _logger.LogInformation($"{Endpoints.BorrowingProlong} started. CorrelationId: {correlationId}");

            try
            {
                var borrowing = await _borrowingService.Prolong(borrowingProlongDto, GetNewCorrelationId());
                return Ok(borrowing);
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Endpoints.BorrowingProlong} failed. CorrelationId: {correlationId}, {ex}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("close")]
        public async Task<IActionResult> Close(Guid Id)
        {
            var correlationId = GetNewCorrelationId();
            _logger.LogInformation($"{Endpoints.BorrowingClose} started. CorrelationId: {correlationId}");

            try
            {
                var borrowing = await _borrowingService.Close(Id, GetNewCorrelationId());
                return Ok(borrowing);
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{Endpoints.BorrowingClose} failed. CorrelationId: {correlationId}, {ex}");
                return StatusCode(500, ex.Message);
            }
        }


    }
}
