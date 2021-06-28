using CelestialObjects.Data.Entities;
using System.Threading.Tasks;

namespace CelestialObjects.Data.Repositories
{
    public interface IDiscoverySourceRepository
    {
        Task<DiscoverySource> GetByIdAsync(int id);
    }
}
