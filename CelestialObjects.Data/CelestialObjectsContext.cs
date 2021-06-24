using Microsoft.EntityFrameworkCore;

namespace CelestialObjects.Data
{
    public class CelestialObjectsContext : DbContext
    {       
        public CelestialObjectsContext(DbContextOptions<CelestialObjectsContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.CelestialObject> CelestialObjects { get; set; }

        public DbSet<Domain.DiscoverySource> DiscoverySources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var celestialObjects = new Domain.CelestialObject[]
            {
                new Domain.CelestialObject
                {
                    Id = 1,
                    Name = "Kepler-37b",
                    Mass = 5.97237e24,
                    EquatorialDiameter = 12756200,
                    SurfaceTemperature = 5800,
                    DiscoveryDate = new System.DateTime(2018, 12, 15),
                    DiscoverySourceId = 1,
                    Type = Domain.CelestialObjectType.Planet
                },
                new Domain.CelestialObject
                {
                    Id = 2,
                    Name = "X1 NGC 4889",
                    Mass = 4.2e40,
                    EquatorialDiameter = 4280000,
                    SurfaceTemperature = 2000,
                    DiscoveryDate = new System.DateTime(2019, 3, 10),
                    DiscoverySourceId = 1,
                    Type = Domain.CelestialObjectType.BlackHole
                },
                new Domain.CelestialObject
                {
                    Id = 2,
                    Name = "V538 Carinae",
                    Mass = 3.65e29,
                    EquatorialDiameter = 184502000,
                    SurfaceTemperature = 4800,
                    DiscoveryDate = new System.DateTime(2010, 1, 25),
                    DiscoverySourceId = 2,
                    Type = Domain.CelestialObjectType.Star
                }
            };

            var discoverySources = new Domain.DiscoverySource[]
            {
                new Domain.DiscoverySource
                {
                    Id = 1,
                    Name = "Hubble Space Telescope",
                    EstablishmentDate = new System.DateTime(2019, 3, 10),
                    StateOwner = "USA",
                    Type = Domain.DiscoverySourceType.SpaceTelescope
                },
                new Domain.DiscoverySource
                {
                    Id = 2,
                    Name = "Arecibo Observatory",
                    EstablishmentDate = new System.DateTime(2019, 3, 10),
                    StateOwner = "Puerto Rico",
                    Type = Domain.DiscoverySourceType.GroundTelescope
                }
            };
        }
    }
}
