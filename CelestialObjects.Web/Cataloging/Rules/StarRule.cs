using CelestialObjects.Data.Entities;
using CelestialObjects.Web.Models.Requests;

namespace CelestialObjects.Web.Cataloging.Rules
{
    public class StarRule : IRule
    {
        private const int MinStarTemperature = 2500;

        public double RulePrecedence => 1;

        public CelestialObjectTypeEnum CelestialObjectType => CelestialObjectTypeEnum.Star;

        public bool RuleIsMet(CelestialObjectRequestDto celestialObjectInfo)
        {
            return celestialObjectInfo.Mass > Constants.MaxPlanetaryMass && celestialObjectInfo.SurfaceTemperature >= MinStarTemperature;
        }
    }
}
