using CelestialObjects.Data.Entities;
using CelestialObjects.Data.Repositories;
using GraphQL;
using GraphQL.Types;
using System;

namespace CelestialObjects.Web.GraphQL
{
    public class CelestialObjectsQuery : ObjectGraphType
    {
        public CelestialObjectsQuery(ICelestialObjectsRepository celestialObjectsRepository)
        {
            Field<ListGraphType<Types.CelestialObjectType>>(
                "celestialObjects",
                resolve: context => celestialObjectsRepository.GetAllAsync());

            Field<Types.CelestialObjectType>(
                "celestialObject",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "name" }),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    return celestialObjectsRepository.GetByNameAsync(name);
                });

            Field<ListGraphType<Types.CelestialObjectType>>(
                "celestialObjectsByType",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "type" }),
                resolve: context =>
                {
                    var typeName = context.GetArgument<string>("type");
                    CelestialObjectTypeEnum celestialObjectType;
                    var isTypeValid = Enum.TryParse(typeName, ignoreCase: true, out celestialObjectType);
                    //TODO: add check if it is not valid

                    return celestialObjectsRepository.GetByTypeAsync((int)celestialObjectType);
                });
        }
    }
}
