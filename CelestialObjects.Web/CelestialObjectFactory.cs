using CelestialObjects.Data.Entities;
using CelestialObjects.Web.Models.Requests;
using System;

namespace CelestialObjects.Web
{
    public class CelestialObjectFactory : ICelestialObjectFactory
    {
        const double MaxPlanetaryMass = 1.898E27;

        public CelestialObject BuildCelestialObject(CelestialObjectRequestDto celestialObjectInfo)
        {
            if(IsBlackHole(celestialObjectInfo))
            {
                return InitCelestialObject(celestialObjectInfo, CelestialObjectTypeEnum.BlackHole);
            }

            if (IsStar(celestialObjectInfo))
            {
                return InitCelestialObject(celestialObjectInfo, CelestialObjectTypeEnum.Star);
            }

            if (IsPlanet(celestialObjectInfo))
            {
                return InitCelestialObject(celestialObjectInfo, CelestialObjectTypeEnum.Planet);
            }

            return InitCelestialObject(celestialObjectInfo, CelestialObjectTypeEnum.Undetermined);
        }

        private bool IsBlackHole(CelestialObjectRequestDto celestialObjectInfo)
        {
            // Lol
            return new Random().Next(1, 3) == 3;
        }

        private bool IsStar(CelestialObjectRequestDto celestialObjectInfo)
        {
            return celestialObjectInfo.Mass > MaxPlanetaryMass && celestialObjectInfo.SurfaceTemperature >= 2500;
        }

        private bool IsPlanet(CelestialObjectRequestDto celestialObjectInfo)
        {
            return celestialObjectInfo.Mass <= MaxPlanetaryMass;
        }        

        private CelestialObject InitCelestialObject(CelestialObjectRequestDto celestialObjectInfo, CelestialObjectTypeEnum type)
        {
            return new CelestialObject
            {
                Name = celestialObjectInfo.Name,
                Mass = celestialObjectInfo.Mass,
                EquatorialDiameter = celestialObjectInfo.EquatorialDiameter,
                SurfaceTemperature = celestialObjectInfo.SurfaceTemperature,
                DiscoveryDate = celestialObjectInfo.DiscoveryDate,
                DiscoverySourceId = celestialObjectInfo.DiscoverySourceId,
                TypeId = (int)type                
            };
        }        
    }
}
