using System.Collections.Generic;
using System.Threading.Tasks;
using CelestialObjects.Data.Entities;

namespace CelestialObjects.Data.Services
{
    public interface ICelestialObjectsRepository
    {
        Task<IEnumerable<CelestialObject>> GetCelestialObjectsAsync();

        Task<IEnumerable<CelestialObject>> GetCelestialObjectsByTypeAsync(CelestialObjectTypeEnum type);

        Task<CelestialObject> GetCelestialObjectsByNameAsync(string name);

        Task<IEnumerable<CelestialObject>> GetCelestialObjectsByCountryDiscoveredAsync(string countryName);
    }
}
