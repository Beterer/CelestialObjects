﻿using System.Collections.Generic;
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
            return await _celestialObjectsRepository.GetCelestialObjectsAsync();
        }

        public async Task<IEnumerable<CelestialObject>> GetCelestialObjectsByCountryDiscoveredAsync(string countryName)
        {
            return await _celestialObjectsRepository.GetCelestialObjectsByCountryDiscoveredAsync(countryName); ;
        }

        public async Task<CelestialObject> GetCelestialObjectsByNameAsync(string name)
        {
            return await _celestialObjectsRepository.GetCelestialObjectsByNameAsync(name);
        }

        public async Task<IEnumerable<CelestialObject>> GetCelestialObjectsByTypeAsync(int typeId)
        {
            return await _celestialObjectsRepository.GetCelestialObjectsByTypeAsync(typeId);
        }

        public async Task<IEnumerable<CelestialObjectType>> GetCelestialObjectTypes()
        {
            return await _celestialObjectsRepository.GetCelestialObjectTypes();
        }
    }
}