using CelestialObjects.Data.Entities;
using CelestialObjects.Web.Models.Requests;

namespace CelestialObjects.Web.Cataloging.Rules
{
    public class PlanetRule : IRule
    {
        public double RulePrecedence => 1;

        public CelestialObjectTypeEnum CelestialObjectType => CelestialObjectTypeEnum.Planet;

        public bool RuleIsMet(CelestialObjectRequestDto celestialObjectInfo)
        {
            return celestialObjectInfo.Mass <= Constants.MaxPlanetaryMass;
        }
    }
}
