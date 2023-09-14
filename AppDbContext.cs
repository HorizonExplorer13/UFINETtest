using Microsoft.EntityFrameworkCore;
using UFINETTest.Entities;

namespace UFINETTest
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<CountrySites> CountrySites { get; set; }

    }
}
