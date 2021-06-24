using CelestialObjects.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CelestialObjects.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CelestialObjectsController : ControllerBase
    {
        private readonly ILogger<CelestialObjectsController> _logger;
        private readonly CelestialObjectsContext _celestialObjectsContext;

        public CelestialObjectsController(ILogger<CelestialObjectsController> logger, CelestialObjectsContext celestialObjectsContext)
        {
            _logger = logger;
            _celestialObjectsContext = celestialObjectsContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _celestialObjectsContext.Add(new object()); ;
            return Ok();
        }
    }
}
