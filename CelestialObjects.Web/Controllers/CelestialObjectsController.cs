using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CelestialObjects.Data.Services;
using System.Linq;
using CelestialObjects.Web.Extensions;
using System;
using CelestialObjects.Data.Entities;

namespace CelestialObjects.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetAll()
        {
            var celestialObjects = await _celestialObjectsRepository.GetCelestialObjectsAsync();
            var result = celestialObjects.Select(x => x.ToDto());

            return Ok(result);
        }        

        [HttpGet]
        [Route("{typeName}")]
        public async Task<IActionResult> GetByType(string typeName)
        {
            CelestialObjectTypeEnum celestialObjectType;
            var isTypeValid = Enum.TryParse(typeName, ignoreCase:true, out celestialObjectType);

            if (isTypeValid)
            {
                var celestialObjects = await _celestialObjectsRepository.GetCelestialObjectsByTypeAsync((int)celestialObjectType);
                var result = celestialObjects.Select(x => x.ToDto());

                return Ok(result);
            }

            return BadRequest("Invalid Celestial Object Type.");
            
        }
    }
}
