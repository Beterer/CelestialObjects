using CelestialObjects.Data.Entities;
using GraphQL.Types;

namespace CelestialObjects.Web.GraphQL.Types
{
    public class DiscoverySourceType : ObjectGraphType<DiscoverySource>
    {
        public DiscoverySourceType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.EstablishmentDate);
            Field(t => t.StateOwner);
            Field(t => t.TypeId);
        }
    }
}
