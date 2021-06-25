using CelestialObjects.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CelestialObjects.Data.Services;

namespace CelestialObjects.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CelestialObjectsController : ControllerBase
    {
        private readonly ILogger<CelestialObjectsController> _logger;
        private readonly CelestialObjectsContext _celestialObjectsContext;
        private readonly ICelestialObjectsRepository _celestialObjectsRepository;
                
        public CelestialObjectsController(ILogger<CelestialObjectsController> logger,
            CelestialObjectsContext celestialObjectsContext, 
            ICelestialObjectsRepository celestialObjectsRepository)
        {
            _logger = logger;
            _celestialObjectsContext = celestialObjectsContext;
            _celestialObjectsRepository = celestialObjectsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var celestialObjects = await _celestialObjectsRepository.GetCelestialObjectsAsync();
            return Ok(celestialObjects);
        }
    }
}
