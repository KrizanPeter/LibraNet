using LibraNet.Contracts.Correlation;
using Microsoft.AspNetCore.Mvc;

namespace LibraNet.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;
        public BaseController(ILogger<BaseController> logger) 
        {
            _logger = logger;
        }

        protected CorrelationId GetNewCorrelationId()
        {
            return new CorrelationId();
        }
    }
}
