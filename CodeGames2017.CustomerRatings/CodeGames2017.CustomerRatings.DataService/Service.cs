using CodeGames2017.CustomerRating.DataAccessLayer;
using CodeGames2017.CustomerRating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGames2017.CustomerRatings.DataService
{
    public class Service
    {
        private RatingsDbContext _context = new RatingsDbContext();

        public void AddRating(RatingAppDomain rating)
        {
            var ratingDbObject = new Rating
            {
                Application = new Application { ApplicationId = rating.Application },
                Feature = new Feature { FeatureId = rating.Feature },
                ClientCode = rating.ClientCode,
                Comment = rating.Comment,
                RatedBy = rating.RatedBy,
                RatingId = rating.RatingId,
                RatingValue = rating.RatingValue
            };

            try
            {
                
                _context.Ratings.Add(ratingDbObject);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }

    public class RatingAppDomain
    {
        public Guid RatingId { get; set; }
        public Guid Application { get; set; }
        public Guid Feature { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }
        public string RatedBy { get; set; }
        public string ClientCode { get; set; }
    }
}
