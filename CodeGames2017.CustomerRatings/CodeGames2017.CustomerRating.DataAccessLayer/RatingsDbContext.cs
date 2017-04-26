using CodeGames2017.CustomerRating.Model;
using System.Data.Entity;

namespace CodeGames2017.CustomerRating.DataAccessLayer
{
    public class RatingsDbContext : System.Data.Entity.DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public RatingsDbContext()
        {
            Database.SetInitializer(new RatingsDbInitializer());
            Configuration.LazyLoadingEnabled = false;          
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().HasMany(m => m.Features)
                .WithRequired(f => f.Application).WillCascadeOnDelete(true);

            modelBuilder.Entity<Feature>().HasMany(p => p.Ratings)
                .WithRequired(r => r.Feature).WillCascadeOnDelete(true);
        }

    }
}
