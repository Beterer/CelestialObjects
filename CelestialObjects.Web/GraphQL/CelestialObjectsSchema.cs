using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CelestialObjects.Web.GraphQL
{
    public class CelestialObjectsSchema : Schema, ISchema
    {
        public CelestialObjectsSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<CelestialObjectsQuery>();
            Mutation = provider.GetRequiredService<CelestialObjectMutation>();
        }
    }
}
