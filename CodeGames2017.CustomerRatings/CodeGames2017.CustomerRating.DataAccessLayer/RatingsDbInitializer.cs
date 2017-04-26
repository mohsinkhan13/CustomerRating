using CodeGames2017.CustomerRating.Model;
using System;
using System.Data.Entity;

namespace CodeGames2017.CustomerRating.DataAccessLayer
{
    public class RatingsDbInitializer : DropCreateDatabaseIfModelChanges<RatingsDbContext> 
    {
        protected override void Seed(RatingsDbContext context)
        {
            Rating rating = null;
            
            for(var i=1;i<=1000;i++)
            {
                rating = new Rating
                {
                    RatingId = Guid.NewGuid(),
                    ApplicationId = "Central",
                    FeatureId = "Screen " + i,
                    RatingValue = 1,
                    Comment = "",
                    RatedBy = "a@gmail.com"
                };
                context.Ratings.Add(rating);
            }
            base.Seed(context);
        }
    }
}
