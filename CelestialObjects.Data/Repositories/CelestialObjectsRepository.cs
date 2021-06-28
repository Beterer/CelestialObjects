using CelestialObjects.Data.Contexts;
using CelestialObjects.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelestialObjects.Data.Repositories
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
            return await InitBaseGetQuery().ToListAsync();
        }

        public async Task<IEnumerable<CelestialObject>> GetCelestialObjectsByTypeAsync(int typeId)
        {
            return await InitBaseGetQuery().
                Where(x => x.TypeId == typeId).ToListAsync();
        }

        public async Task<CelestialObject> GetCelestialObjectsByNameAsync(string name)
        {
            return await _celestialObjectsContext.CelestialObjects.SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<CelestialObject>> GetCelestialObjectsByCountryDiscoveredAsync(string countryName)
        {
            return await InitBaseGetQuery().
                Where(x => x.DiscoverySource.StateOwner == countryName).ToListAsync();
        }      
        
        public async Task<IEnumerable<CelestialObjectType>> GetCelestialObjectTypes()
        {
            return await _celestialObjectsContext.CelestialObjectTypes.ToListAsync();
        }

        public IQueryable<CelestialObject> InitBaseGetQuery()
        {
            return _celestialObjectsContext.CelestialObjects.Include(x => x.Type).Include(x => x.DiscoverySource);
        }
    }
}
