using CelestialObjects.Data.Entities;
using CelestialObjects.Web.Services;
using GraphQL.Types;

namespace CelestialObjects.Web.GraphQL.Types
{
    public class CelestialObjectType : ObjectGraphType<CelestialObject>
    {
        public CelestialObjectType(ICelestialObjectsService celestialObjectsService)
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Mass);
            Field(t => t.SurfaceTemperature);
            Field(t => t.EquatorialDiameter);
            Field(t => t.DiscoveryDate);
            Field<DiscoverySourceType>("DiscoverySource", resolve: context => celestialObjectsService.GetDiscoverySourceByIdAsync(context.Source.DiscoverySourceId));
            Field(t => t.DiscoverySourceId);
            Field<CelestialObjectTypeType>("Type", resolve: context => celestialObjectsService.GetTypeByIdAsync(context.Source.TypeId));
            Field(t => t.TypeId);
        }
    }
}
