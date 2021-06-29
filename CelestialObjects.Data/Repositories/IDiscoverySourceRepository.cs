using CelestialObjects.Data.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CelestialObjects.Data.Repositories
{
    public interface IDiscoverySourceRepository
    {
        Task<IEnumerable<DiscoverySource>> GetAll();

        Task<DiscoverySource> GetByIdAsync(int id);
    }
}
