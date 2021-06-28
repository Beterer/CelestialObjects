using CelestialObjects.Data.Entities;
using CelestialObjects.Data.Repositories;
using GraphQL.Types;

namespace CelestialObjects.Web.GraphQL.Types
{
    public class CelestialObjectType : ObjectGraphType<CelestialObject>
    {
        public CelestialObjectType(ICelestialObjectsRepository celestialObjectsRepository, IDiscoverySourceRepository discoverySourceRepository)
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Mass);
            Field(t => t.SurfaceTemperature);
            Field(t => t.EquatorialDiameter);
            Field(t => t.DiscoveryDate);
            Field<DiscoverySourceType>("DiscoverySource", resolve: context => discoverySourceRepository.GetByIdAsync(context.Source.DiscoverySourceId));
            Field(t => t.DiscoverySourceId);
            Field<CelestialObjectTypeType>("Type", resolve: context => celestialObjectsRepository.GetTypeByIdAsync(context.Source.TypeId));
            Field(t => t.TypeId);
        }
    }
}
