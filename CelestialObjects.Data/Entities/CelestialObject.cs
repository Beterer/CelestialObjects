using System;

namespace CelestialObjects.Data.Entities
{
    public class CelestialObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Mass { get; set; }

        public double EquatorialDiameter { get; set; }

        public double SurfaceTemperature { get; set; }

        public DateTime DiscoveryDate { get; set; }

        public DiscoverySource DiscoverySource { get; set; }

        public int DiscoverySourceId { get; set; }

        public virtual CelestialObjectType Type { get; set; }
        
        public int TypeId { get; set; }
    }
}
