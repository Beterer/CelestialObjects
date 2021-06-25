using System;

namespace CelestialObjects.Domain
{
    public class DiscoverySource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime EstablishmentDate { get; set; }

        public virtual DiscoverySourceType Type { get; set; }

        public int TypeId { get; set; }

        public string StateOwner { get; set; }
    }
}
