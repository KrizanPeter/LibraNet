using Microsoft.AspNetCore.Mvc;

namespace LibraNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "getById")]
        public IActionResult GetById(Guid Id)
        {
            return StatusCode(404);
        }
    }
}
