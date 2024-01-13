﻿using LibraNet.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly ILogger<BorrowingController> _logger;
        private readonly IBorrowingService _borrowingService;

        public BorrowingController(ILogger<BorrowingController> logger, IBorrowingService borrowingService)
        {
            _logger = logger;
            _borrowingService = borrowingService;
        }

        [HttpGet(Name = "getBorrowingById")]
        public IActionResult GetById(Guid Id)
        {
            return StatusCode(404);
        }
    }
}
