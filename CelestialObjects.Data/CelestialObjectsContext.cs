using Microsoft.EntityFrameworkCore;

namespace CelestialObjects.Data
{
    public class CelestialObjectsContext : DbContext
    {
        // TODO: move conn str to appsettings
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=CelestialObjects;Integrated Security=True");

        public DbSet<Domain.CelestialObject> CelestialObjects { get; set; }

        public DbSet<Domain.DiscoverySource> DiscoverySources { get; set; }
    }
}
