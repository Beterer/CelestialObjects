using CelestialObjects.Web.Models.Responses;

namespace CelestialObjects.Web.Extensions
{
    public static class CelestialObjectsExtension
    {
        public static CelestialObjecResponsetDto ToDto(this Data.Entities.CelestialObject model)
        {
            return new CelestialObjecResponsetDto
            {
                Id = model.Id,
                Name = model.Name,
                Mass = model.Mass,
                EquatorialDiameter = model.EquatorialDiameter,
                SurfaceTemperature = model.SurfaceTemperature,
                DiscoveryDate = model.DiscoveryDate,
                DiscoverySourceId = model.DiscoverySourceId,
                Type = model.Type.Description
            };
        }
    }
}
