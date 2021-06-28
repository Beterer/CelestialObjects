using System;

namespace CelestialObjects.Web.Models.Responses
{
    public class CelestialObjecResponsetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Mass { get; set; }

        public double EquatorialDiameter { get; set; }

        public double SurfaceTemperature { get; set; }

        public DateTime DiscoveryDate { get; set; }

        public int DiscoverySourceId { get; set; }

        public string Type { get; set; }
    }
}
