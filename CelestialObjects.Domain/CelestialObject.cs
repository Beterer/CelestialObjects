using System;

namespace CelestialObjects.Domain
{
    public class CelestialObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Mass { get; set; }

        public double EquatorialDiameter { get; set; }

        public double SurfaceTemperature { get; set; }

        public DateTime DiscoveryDate { get; set; }

        public DiscoverySource DiscoverySource { get; set; }

        public CelestialObjectType Type { get; set; }
    }
}
