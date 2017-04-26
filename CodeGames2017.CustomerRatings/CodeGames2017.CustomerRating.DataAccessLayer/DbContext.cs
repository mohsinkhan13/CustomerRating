using CodeGames2017.CustomerRating.Model;
using System.Data.Entity;

namespace CodeGames2017.CustomerRating.DataAccessLayer
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbSet<Rating> Ratings { get; set; }
    
        public DbContext()
        {
            Database.SetInitializer(new DBInitializer());
            Configuration.LazyLoadingEnabled = false;          
        }
    }
}
