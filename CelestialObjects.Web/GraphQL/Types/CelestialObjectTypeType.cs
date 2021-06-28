using GraphQL.Types;

namespace CelestialObjects.Web.GraphQL.Types
{
    public class CelestialObjectTypeType : ObjectGraphType<Data.Entities.CelestialObjectType>
    {
        public CelestialObjectTypeType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Description);
        }
    }
}
