using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using CelestialObjects.Web.Extensions;
using CelestialObjects.Web.Services;

namespace CelestialObjects.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CelestialObjectTypesController : ControllerBase
    {
        private readonly ILogger<CelestialObjectTypesController> _logger;
        private readonly ICelestialObjectsService _celestialObjectsService;

        public CelestialObjectTypesController(ILogger<CelestialObjectTypesController> logger,
            ICelestialObjectsService celestialObjectsService)
        {
            _logger = logger;
            _celestialObjectsService = celestialObjectsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var celestialObjects = await _celestialObjectsService.GetCelestialObjectTypes();
            var result = celestialObjects.Select(x => x.ToDto());

            return Ok(result);
        }        
    }
}
