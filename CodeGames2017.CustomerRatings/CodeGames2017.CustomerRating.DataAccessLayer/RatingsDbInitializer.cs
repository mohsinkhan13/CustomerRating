using CodeGames2017.CustomerRating.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CodeGames2017.CustomerRating.DataAccessLayer
{
    public class RatingsDbInitializer : DropCreateDatabaseIfModelChanges<RatingsDbContext> 
    {
        protected override void Seed(RatingsDbContext context)
        {
            
            var centralFeatures = new List<Feature>
            {
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "Central Feature 1",Ratings = GetSampleRatings(600,5)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "Central Feature 2",Ratings = GetSampleRatings(500,3)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "Central Feature 3",Ratings = GetSampleRatings(400,5)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "Central Feature 4",Ratings = GetSampleRatings(200,4)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "Central Feature 5",Ratings = GetSampleRatings(800,2)},
            };

            var oneClickFeatures = new List<Feature>
            {
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "One Click Feature 1",Ratings = GetSampleRatings(500,5)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "One Click Feature 2",Ratings = GetSampleRatings(700,3)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "One Click Feature 3",Ratings = GetSampleRatings(200,5)},
            };

            var applicationCentral = new Application
            {
                ApplicationId = Guid.NewGuid(),
                ApplicationName = "Central",
                Features = centralFeatures
            };

            var applicationOneClick = new Application
            {
                ApplicationId = Guid.NewGuid(),
                ApplicationName = "OneClick",
                Features = oneClickFeatures
            };

            context.Applications.Add(applicationCentral);
            context.Applications.Add(applicationOneClick);

            base.Seed(context);
        }

        private static List<Rating> GetSampleRatings(int noOfRatings,int ratingSeed)
        {
            var ratings = new List<Rating>();

            for (var i = 1; i <= noOfRatings; i++)
            {
                ratings.Add(
                new Rating
                {
                    RatingId = Guid.NewGuid(),
                    RatingValue = int.Parse(new Random().Next(1,ratingSeed).ToString()),
                    RatedBy = "mohsin.khan@wolterskluwer.com"
                    
                });
            }

            return ratings;
        }
    }
}
