using LibraNet.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;


        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet(Name = "getBookById")]
        public IActionResult GetById(Guid Id)
        {
            return StatusCode(404);
        }
    }
}
