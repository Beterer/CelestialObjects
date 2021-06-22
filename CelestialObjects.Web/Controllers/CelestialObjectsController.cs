using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CelestialObjects.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CelestialObjectsController : ControllerBase
    {
        private readonly ILogger<CelestialObjectsController> _logger;

        public CelestialObjectsController(ILogger<CelestialObjectsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
