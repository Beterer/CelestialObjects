using CelestialObjects.Data.Entities;
using CelestialObjects.Web.Services;
using GraphQL;
using GraphQL.Types;
using System;

namespace CelestialObjects.Web.GraphQL
{
    public class CelestialObjectsQuery : ObjectGraphType
    {
        public CelestialObjectsQuery(ICelestialObjectsService celestialObjectsService)
        {
            Field<ListGraphType<Types.CelestialObjectType>>(
                "celestialObjects",
                resolve: context => celestialObjectsService.GetCelestialObjectsAsync());

            Field<ListGraphType<Types.DiscoverySourceType>>(
                "discoverySources",
                resolve: context => celestialObjectsService.GetDiscoverySourcesAsync());

            Field<ListGraphType<Types.CelestialObjectTypeType>>(
                "celestialObjectTypes",
                resolve: context => celestialObjectsService.GetCelestialObjectTypes());

            Field<Types.CelestialObjectType>(
                "celestialObject",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "name" }),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    return celestialObjectsService.GetCelestialObjectsByNameAsync(name);
                });

            Field<ListGraphType<Types.CelestialObjectType>>(
                "celestialObjectsByType",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "type" }),
                resolve: context =>
                {
                    var typeName = context.GetArgument<string>("type");
                    CelestialObjectTypeEnum celestialObjectType;
                    var isTypeValid = Enum.TryParse(typeName, ignoreCase: true, out celestialObjectType);

                    return celestialObjectsService.GetCelestialObjectsByTypeAsync((int)celestialObjectType);
                });

            Field<ListGraphType<Types.CelestialObjectType>>(
                "celestialObjectsByDiscoveryCountry",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "country" }),
                resolve: context =>
                {
                    var country = context.GetArgument<string>("country");
                    
                    return celestialObjectsService.GetCelestialObjectsByCountryDiscoveredAsync(country);
                });
        }
    }
}
