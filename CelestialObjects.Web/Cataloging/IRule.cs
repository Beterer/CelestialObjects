using CelestialObjects.Data.Entities;
using CelestialObjects.Web.Models.Requests;

namespace CelestialObjects.Web.Cataloging
{
    public interface IRule
    {
        bool RuleIsMet(CelestialObjectRequestDto celestialObjectInfo);

        double RulePrecedence { get; }

        CelestialObjectTypeEnum CelestialObjectType { get; }
    }
}
