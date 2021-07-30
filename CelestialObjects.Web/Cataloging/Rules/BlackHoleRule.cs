using CelestialObjects.Data.Entities;
using CelestialObjects.Web.Models.Requests;
using System;

namespace CelestialObjects.Web.Cataloging.Rules
{
    public class BlackHoleRule : IRule
    {
        public double RulePrecedence => 0;

        public CelestialObjectTypeEnum CelestialObjectType => CelestialObjectTypeEnum.BlackHole;

        public bool RuleIsMet(CelestialObjectRequestDto celestialObjectInfo)
        {
            // This needs more clarifications from business :D
            return new Random().Next(1, 3) == 3;
        }
    }
}
