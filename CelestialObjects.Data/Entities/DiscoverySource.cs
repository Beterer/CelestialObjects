using System;

namespace CelestialObjects.Data.Entities
{
    public class DiscoverySource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime EstablishmentDate { get; set; }

        public DiscoverySourceType Type { get; set; }

        public int TypeId { get; set; }

        public string StateOwner { get; set; }
    }
}
