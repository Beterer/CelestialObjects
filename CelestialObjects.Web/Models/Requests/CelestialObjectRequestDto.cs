using System;

namespace CelestialObjects.Web.Models.Requests
{
    public class CelestialObjectRequestDto
    {
        public string Name { get; set; }

        public double Mass { get; set; }

        public double EquatorialDiameter { get; set; }

        public double SurfaceTemperature { get; set; }

        public DateTime DiscoveryDate { get; set; }

        public int DiscoverySourceId { get; set; }
    }
}
