using System.Collections.Generic;
using System.Threading.Tasks;
using CelestialObjects.Data.Entities;

namespace CelestialObjects.Data.Repositories
{
    public interface ICelestialObjectsRepository
    {
        Task<IEnumerable<CelestialObject>> GetCelestialObjectsAsync();

        Task<IEnumerable<CelestialObject>> GetCelestialObjectsByTypeAsync(int typeId);

        Task<CelestialObject> GetCelestialObjectsByNameAsync(string name);

        Task<IEnumerable<CelestialObject>> GetCelestialObjectsByCountryDiscoveredAsync(string countryName);

        Task<IEnumerable<CelestialObjectType>> GetCelestialObjectTypes();
    }
}
