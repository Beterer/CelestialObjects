using GraphQL.Types;

namespace CelestialObjects.Web.GraphQL.Types
{
    public class CelestialObjectInputType : InputObjectGraphType
    {
        public CelestialObjectInputType()
        {
            Name = "celestialObjectInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<FloatGraphType>>("mass");
            Field<NonNullGraphType<FloatGraphType>>("equatorialDiameter");
            Field<NonNullGraphType<FloatGraphType>>("surfaceTemperature");
            Field<NonNullGraphType<DateGraphType>>("discoveryDate");
            Field<NonNullGraphType<IntGraphType>>("discoverySourceId");
        }
    }
}
