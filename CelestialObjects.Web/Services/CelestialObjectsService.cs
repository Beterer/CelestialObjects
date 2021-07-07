using System.Collections.Generic;
using System.Threading.Tasks;
using CelestialObjects.Data.Entities;
using CelestialObjects.Data.Repositories;
using CelestialObjects.Web.Cataloging;
using CelestialObjects.Web.Models.Requests;

namespace CelestialObjects.Web.Services
{
    public class CelestialObjectsService : ICelestialObjectsService
    {
        private readonly ICelestialObjectsRepository _celestialObjectsRepository;
        private readonly IDiscoverySourceRepository _discoverySourceRepository;
        private readonly ICelestialObjectFactory _celestialObjectFactory;

        public CelestialObjectsService(ICelestialObjectsRepository celestialObjectsRepository,
            IDiscoverySourceRepository discoverySourceRepository,
            ICelestialObjectFactory celestialObjectFactory)
        {
            _celestialObjectsRepository = celestialObjectsRepository;
            _discoverySourceRepository = discoverySourceRepository;
            _celestialObjectFactory = celestialObjectFactory;
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

        public async Task<CelestialObjectType> GetTypeByIdAsync(int typeId)
        {
            return await _celestialObjectsRepository.GetTypeByIdAsync(typeId);
        }

        public async Task<DiscoverySource> GetDiscoverySourceByIdAsync(int id)
        {
            return await _discoverySourceRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<DiscoverySource>> GetDiscoverySourcesAsync()
        {
            return await _discoverySourceRepository.GetAll();
        }

        public async Task<CelestialObject> AddCelestialObject(CelestialObjectRequestDto celestialObjectInput)
        {
            var celestialObjectToAdd = _celestialObjectFactory.BuildCelestialObject(celestialObjectInput);

            return await _celestialObjectsRepository.AddAsync(celestialObjectToAdd);
        }
    }
}
