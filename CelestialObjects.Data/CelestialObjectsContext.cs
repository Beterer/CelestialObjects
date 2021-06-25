using CelestialObjects.Domain;
using Microsoft.EntityFrameworkCore;

namespace CelestialObjects.Data
{
    public class CelestialObjectsContext : DbContext
    {       
        public CelestialObjectsContext(DbContextOptions<CelestialObjectsContext> options)
            : base(options)
        {
        }

        public DbSet<CelestialObject> CelestialObjects { get; set; }

        public DbSet<DiscoverySource> DiscoverySources { get; set; }

        public DbSet<CelestialObjectType> CelestialObjectTypes { get; set; }

        public DbSet<DiscoverySourceType> DiscoverySourceTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CelestialObjectType>().HasData(
                CelestialObjectTypeEnum.Planet, CelestialObjectTypeEnum.Star, CelestialObjectTypeEnum.BlackHole);
            modelBuilder.Entity<DiscoverySourceType>().HasData(
               DiscoverySourceTypeEnum.GroundTelescope, DiscoverySourceTypeEnum.SpaceTelescope, DiscoverySourceTypeEnum.Other);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var discoverySources = new DiscoverySource[]
                        {
                new DiscoverySource
                {
                    Id = 1,
                    Name = "Hubble Space Telescope",
                    EstablishmentDate = new System.DateTime(2019, 3, 10),
                    StateOwner = "USA",
                    TypeId = 1
                },
                new DiscoverySource
                {
                    Id = 2,
                    Name = "Arecibo Observatory",
                    EstablishmentDate = new System.DateTime(2019, 3, 10),
                    StateOwner = "Puerto Rico",
                    TypeId = 2
                }
                        };
            modelBuilder.Entity<DiscoverySource>().HasData(discoverySources);

            var celestialObjects = new CelestialObject[]
            {
                new CelestialObject
                {
                    Id = 1,
                    Name = "Kepler-37b",
                    Mass = 5.97237e24,
                    EquatorialDiameter = 12756200,
                    SurfaceTemperature = 5800,
                    DiscoveryDate = new System.DateTime(2018, 12, 15),
                    DiscoverySourceId = 1,
                    TypeId = 1
                },
                new CelestialObject
                {
                    Id = 2,
                    Name = "X1 NGC 4889",
                    Mass = 4.2e40,
                    EquatorialDiameter = 4280000,
                    SurfaceTemperature = 2000,
                    DiscoveryDate = new System.DateTime(2019, 3, 10),
                    DiscoverySourceId = 1,
                    TypeId = 3
                },
                new CelestialObject
                {
                    Id = 3,
                    Name = "V538 Carinae",
                    Mass = 3.65e29,
                    EquatorialDiameter = 184502000,
                    SurfaceTemperature = 4800,
                    DiscoveryDate = new System.DateTime(2010, 1, 25),
                    DiscoverySourceId = 2,
                    TypeId = 2
                }
            };
            modelBuilder.Entity<CelestialObject>().HasData(celestialObjects);

            base.OnModelCreating(modelBuilder);
        }
    }
}
