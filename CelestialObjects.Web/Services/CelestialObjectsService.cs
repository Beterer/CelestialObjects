using System.Collections.Generic;
using System.Threading.Tasks;
using CelestialObjects.Data.Entities;
using CelestialObjects.Data.Repositories;

namespace CelestialObjects.Web.Services
{
    public class CelestialObjectsService : ICelestialObjectsService
    {
        private readonly ICelestialObjectsRepository _celestialObjectsRepository;

        public CelestialObjectsService(ICelestialObjectsRepository celestialObjectsRepository)
        {
            _celestialObjectsRepository = celestialObjectsRepository;
        }

        public async Task<IEnumerable<CelestialObject>> GetCelestialObjectsAsync()
        {
            return await _celestialObjectsRepository.GetAllAsync();
        }

        public async Task<IEnumerable<CelestialObject>> GetCelestialObjectsByCountryDiscoveredAsync(string countryName)
        {
            return await _celestialObjectsRepository.GetByCountryDiscoveredAsync(countryName); ;
        }

        public async Task<CelestialObject> GetCelestialObjectsByNameAsync(string name)
        {
            return await _celestialObjectsRepository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<CelestialObject>> GetCelestialObjectsByTypeAsync(int typeId)
        {
            return await _celestialObjectsRepository.GetByTypeAsync(typeId);
        }

        public async Task<IEnumerable<CelestialObjectType>> GetCelestialObjectTypes()
        {
            return await _celestialObjectsRepository.GetCelestialObjectTypes();
        }
    }
}
