using Microsoft.EntityFrameworkCore;
using UFINETTest.Entities;

namespace UFINETTest
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CountrySite>().HasKey(cs => new {cs.CountryId,cs.RestaurantId,cs.HotelId });
        }



        public DbSet<Country> Countries { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<CountrySite> CountrySites { get; set; }

    }
}
