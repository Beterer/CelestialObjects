using CelestialObjects.Data.Entities;
using CelestialObjects.Web.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CelestialObjects.Web.Services
{
    public interface ICelestialObjectsService
    {
        Task<IEnumerable<CelestialObject>> GetCelestialObjectsAsync();

        Task<IEnumerable<CelestialObject>> GetCelestialObjectsByTypeAsync(int typeId);

        Task<CelestialObject> GetCelestialObjectsByNameAsync(string name);

        Task<IEnumerable<CelestialObject>> GetCelestialObjectsByCountryDiscoveredAsync(string countryName);

        Task<IEnumerable<CelestialObjectType>> GetCelestialObjectTypes();

        Task<CelestialObjectType> GetTypeByIdAsync(int typeId);

        Task<DiscoverySource> GetDiscoverySourceByIdAsync(int id);

        Task<IEnumerable<DiscoverySource>> GetDiscoverySourcesAsync();
        
        Task<CelestialObject> AddCelestialObject(CelestialObjectRequestDto celestialObjectInput);
    }
}
