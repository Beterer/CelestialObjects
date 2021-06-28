using GraphQL.Types;

namespace CelestialObjects.Web.GraphQL.Types
{
    public class CelestialObjectType : ObjectGraphType<Data.Entities.CelestialObject>
    {
        public CelestialObjectType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Mass);
            Field(t => t.SurfaceTemperature);
            Field(t => t.EquatorialDiameter);
            Field(t => t.DiscoveryDate);
            //Field(t => t.DiscoverySource);
            Field(t => t.DiscoverySourceId);
            //Field(t => t.Type);
            Field(t => t.TypeId);
        }
    }
}
