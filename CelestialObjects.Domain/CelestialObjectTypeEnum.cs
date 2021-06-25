using System.ComponentModel;

namespace CelestialObjects.Domain
{
    public enum CelestialObjectTypeEnum
    {
        [Description("Planet")]
        Planet = 1,
        [Description("Star")]
        Star = 2,
        [Description("Black Hole")]
        BlackHole = 3
    }
}
