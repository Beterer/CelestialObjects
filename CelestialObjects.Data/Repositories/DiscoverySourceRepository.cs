using CelestialObjects.Data.Contexts;
using CelestialObjects.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CelestialObjects.Data.Repositories
{
    public class DiscoverySourceRepository : IDiscoverySourceRepository
    {
        private readonly CelestialObjectsContext _celestialObjectsContext;

        public DiscoverySourceRepository(CelestialObjectsContext celestialObjectsContext)
        {
            _celestialObjectsContext = celestialObjectsContext;
        }

        public async Task<DiscoverySource> GetByIdAsync(int id)
        {
            return await _celestialObjectsContext.DiscoverySources.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
