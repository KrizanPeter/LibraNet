using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly ILogger<BorrowingController> _logger;

        public BorrowingController(ILogger<BorrowingController> logger)
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
