using CelestialObjects.Data.Contexts;
using CelestialObjects.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelestialObjects.Data.Services
{
    public class CelestialObjectsRepository : ICelestialObjectsRepository
    {
        private readonly CelestialObjectsContext _celestialObjectsContext;

        public CelestialObjectsRepository(CelestialObjectsContext celestialObjectsContext)
        {
            this._celestialObjectsContext = celestialObjectsContext;
        }

        public async Task<IEnumerable<CelestialObject>> GetCelestialObjectsAsync()
        {
            return await _celestialObjectsContext.CelestialObjects.ToListAsync();
        }

        public async Task<IEnumerable<CelestialObject>> GetCelestialObjectsByTypeAsync(CelestialObjectTypeEnum type)
        {
            return await _celestialObjectsContext.CelestialObjects.
                Where(x => x.TypeId == (int)type).ToListAsync();
        }

        public async Task<CelestialObject> GetCelestialObjectsByNameAsync(string name)
        {
            return await _celestialObjectsContext.CelestialObjects.SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<CelestialObject>> GetCelestialObjectsByCountryDiscoveredAsync(string countryName)
        {
            return await _celestialObjectsContext.CelestialObjects.
                Where(x => x.DiscoverySource.StateOwner == countryName).ToListAsync();
        }
    }
}
