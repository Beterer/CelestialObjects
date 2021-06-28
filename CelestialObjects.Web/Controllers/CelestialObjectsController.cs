using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CelestialObjects.Data.Services;
using System.Linq;
using CelestialObjects.Web.Extensions;

namespace CelestialObjects.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CelestialObjectsController : ControllerBase
    {
        private readonly ILogger<CelestialObjectsController> _logger;
        private readonly ICelestialObjectsRepository _celestialObjectsRepository;
                
        public CelestialObjectsController(ILogger<CelestialObjectsController> logger,
            ICelestialObjectsRepository celestialObjectsRepository)
        {
            _logger = logger;
            _celestialObjectsRepository = celestialObjectsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var celestialObjects = await _celestialObjectsRepository.GetCelestialObjectsAsync();
            var result = celestialObjects.Select(x => x.ToDto());

            return Ok(result);
        }
    }
}
