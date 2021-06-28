using CelestialObjects.Data.Repositories;
using GraphQL.Types;

namespace CelestialObjects.Web.GraphQL
{
    public class CelestialObjectsQuery : ObjectGraphType
    {
        public CelestialObjectsQuery(ICelestialObjectsRepository celestialObjectsRepository)
        {
            Field<ListGraphType<Types.CelestialObjectType>>(
                "celestialObjects",
                resolve: context => celestialObjectsRepository.GetCelestialObjectsAsync());
        }
    }
}
