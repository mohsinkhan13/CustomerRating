using CodeGames2017.CustomerRating.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CodeGames2017.CustomerRating.DataAccessLayer
{
    public class RatingsDbInitializer : DropCreateDatabaseAlways<RatingsDbContext> 
    {
        protected override void Seed(RatingsDbContext context)
        {
            
            var centralFeatures = new List<Feature>
            {
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "Central Feature 1",Ratings = GetSampleRatings(10,5)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "Central Feature 2",Ratings = GetSampleRatings(10,3)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "Central Feature 3",Ratings = GetSampleRatings(10,5)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "Central Feature 4",Ratings = GetSampleRatings(10,4)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "Central Feature 5",Ratings = GetSampleRatings(10,2)},
            };

            var oneClickFeatures = new List<Feature>
            {
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "One Click Feature 1",Ratings = GetSampleRatings(10,5)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "One Click Feature 2",Ratings = GetSampleRatings(10,3)},
                new Feature { FeatureId = Guid.NewGuid(),FeatureName = "One Click Feature 3",Ratings = GetSampleRatings(10,5)},
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
            context.Report.Add(new Report {ReportId= Guid.NewGuid(), FeatureName = "AP", Rating5 = 90, Rating4 = 44, Rating3 = 55, Rating2 = 78, Rating1 = 10 });
            context.Report.Add(new Report {ReportId= Guid.NewGuid(),  FeatureName = "PT", Rating5 = 56, Rating4 = 55, Rating3 = 67, Rating2 = 45, Rating1 = 20 });
            context.Report.Add(new Report {ReportId= Guid.NewGuid(),  FeatureName = "DM", Rating5 = 34, Rating4 = 22, Rating3 = 45, Rating2 = 11, Rating1 = 30 });
            context.Report.Add(new Report {ReportId= Guid.NewGuid(),  FeatureName = "CGT", Rating5 = 66, Rating4 = 77, Rating3 = 67, Rating2 = 66, Rating1 = 40 });
            context.Report.Add(new Report { ReportId = Guid.NewGuid(), FeatureName = "PM", Rating5 = 87, Rating4 = 33, Rating3 = 45, Rating2 = 66, Rating1 = 50 });

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
