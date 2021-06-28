using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CelestialObjects.Data.Services;
using System.Linq;
using CelestialObjects.Web.Extensions;

namespace CelestialObjects.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CelestialObjectTypesController : ControllerBase
    {
        private readonly ILogger<CelestialObjectTypesController> _logger;
        private readonly ICelestialObjectsRepository _celestialObjectsRepository;
                
        public CelestialObjectTypesController(ILogger<CelestialObjectTypesController> logger,
            ICelestialObjectsRepository celestialObjectsRepository)
        {
            _logger = logger;
            _celestialObjectsRepository = celestialObjectsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var celestialObjects = await _celestialObjectsRepository.GetCelestialObjectTypes();
            var result = celestialObjects.Select(x => x.ToDto());

            return Ok(result);
        }        
    }
}
