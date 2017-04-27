using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CodeGames2017.CustomerRating.DataAccessLayer;
using CodeGames2017.CustomerRating.Model;
using System.Web.OData;
using System.Web.OData.Routing;

namespace CodeGames2017.CustomerRating.Api.Controllers
{
    public class RatingsController : ODataController
    {
        private RatingsDbContext db = new RatingsDbContext();

        // GET: api/Ratings
        public IQueryable<Rating> GetRatings()
        {
            return db.Ratings;
        }

        // GET: api/Ratings/5
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> GetRating([FromODataUri]Guid key)
        {
            Rating rating = await db.Ratings.FindAsync(key);
            if (rating == null)
            {
                return NotFound();
            }

            return Ok(rating);
        }

        // POST: api/Ratings
        [ResponseType(typeof(Rating))]
        [ODataRoute("Ratings")]
        public async Task<IHttpActionResult> PostRating(Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ratings.Add(rating);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RatingExists(rating.RatingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(rating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RatingExists(Guid id)
        {
            return db.Ratings.Count(e => e.RatingId == id) > 0;
        }
    }
}