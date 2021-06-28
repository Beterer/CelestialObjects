using CelestialObjects.Data.Entities;
using System;

namespace CelestialObjects.Web.Models.Responses
{
    public class DiscoverySourceResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime EstablishmentDate { get; set; }

        public DiscoverySourceTypeEnum Type { get; set; }

        public string StateOwner { get; set; }
    }
}
