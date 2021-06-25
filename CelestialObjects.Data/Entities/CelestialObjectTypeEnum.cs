using System.ComponentModel;

namespace CelestialObjects.Data.Entities
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
