using System.Collections.Generic;
using System.Threading.Tasks;
using CelestialObjects.Data.Entities;

namespace CelestialObjects.Data.Repositories
{
    public interface ICelestialObjectsRepository
    {
        Task<IEnumerable<CelestialObject>> GetAllAsync();

        Task<IEnumerable<CelestialObject>> GetByTypeAsync(int typeId);

        Task<CelestialObject> GetByNameAsync(string name);

        Task<IEnumerable<CelestialObject>> GetByCountryDiscoveredAsync(string countryName);

        Task<IEnumerable<CelestialObjectType>> GetCelestialObjectTypes();

        Task<CelestialObjectType> GetTypeByIdAsync(int typeId);

        Task<CelestialObject> AddAsync(CelestialObject celestialObject);
    }
}
