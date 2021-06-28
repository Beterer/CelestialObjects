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

        public async Task<IEnumerable<CelestialObject>> GetAllAsync()
        {
            return await InitBaseGetQuery().ToListAsync();
        }

        public async Task<IEnumerable<CelestialObject>> GetByTypeAsync(int typeId)
        {
            return await InitBaseGetQuery().
                Where(x => x.TypeId == typeId).ToListAsync();
        }

        public async Task<CelestialObject> GetByNameAsync(string name)
        {
            return await _celestialObjectsContext.CelestialObjects.SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<CelestialObject>> GetByCountryDiscoveredAsync(string countryName)
        {
            return await InitBaseGetQuery().
                Where(x => x.DiscoverySource.StateOwner.ToLower() == countryName.ToLower().Trim()).ToListAsync();
        }      
        
        public async Task<IEnumerable<CelestialObjectType>> GetCelestialObjectTypes()
        {
            return await _celestialObjectsContext.CelestialObjectTypes.ToListAsync();
        }

        public async Task<CelestialObjectType> GetTypeByIdAsync(int typeId)
        {
            return await _celestialObjectsContext.CelestialObjectTypes.SingleOrDefaultAsync(x => x.Id == typeId);
        }

        public IQueryable<CelestialObject> InitBaseGetQuery()
        {
            return _celestialObjectsContext.CelestialObjects.Include(x => x.Type).Include(x => x.DiscoverySource);
        }        
    }
}
