using CodeGames2017.CustomerRating.Model;
using System.Data.Entity;

namespace CodeGames2017.CustomerRating.DataAccessLayer
{
    public class RatingsDbContext : System.Data.Entity.DbContext
    {
        public DbSet<Rating> Ratings { get; set; }
    
        public RatingsDbContext()
        {
            Database.SetInitializer(new RatingsDbInitializer());
            Configuration.LazyLoadingEnabled = false;          
        }
    }
}
