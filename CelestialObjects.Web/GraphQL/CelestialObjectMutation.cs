using CelestialObjects.Web.GraphQL.Types;
using CelestialObjects.Web.Models.Requests;
using CelestialObjects.Web.Services;
using GraphQL;
using GraphQL.Types;

namespace CelestialObjects.Web.GraphQL
{
    public class CelestialObjectMutation : ObjectGraphType
    {
        public CelestialObjectMutation(ICelestialObjectsService celestialObjectsService)
        {
            Field<CelestialObjectType>(
                "addCelestialObject",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CelestialObjectInputType>> { Name = "celestialObjectInput" }),
                resolve: context => 
                {
                    var celestialObjectData = context.GetArgument<CelestialObjectRequestDto>("celestialObjectInput");
                    return celestialObjectsService.AddCelestialObject(celestialObjectData).Result;
                });
        }
    }
}
