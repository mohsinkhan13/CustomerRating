using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CodeGames2017.CustomerRating.DataAccessLayer;
using CodeGames2017.CustomerRating.Model;
using System.Web.OData;
using System.Web.OData.Routing;
using CodeGames2017.CustomerRating.Api.Helpers;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;

namespace CodeGames2017.CustomerRating.Api.Controllers
{
    public class FeaturesController : ODataController
    {
        private RatingsDbContext _context = new RatingsDbContext();

        // GET: api/Features
        [EnableQuery]
        public IQueryable<Feature> GetFeatures()
        {
            return _context.Features;
        }

        // GET: api/Features/5

        [HttpGet]
        [ResponseType(typeof(Feature))]
        [EnableQuery]
        public async Task<IHttpActionResult> GetFeature([FromODataUri]Guid key)
        {
            Feature feature = await _context.Features.FindAsync(key);
            if (feature == null)
            {
                return NotFound();
            }

            return Ok(feature);
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("Features({key})/Ratings")]
        public IHttpActionResult GetFeatures([FromODataUri] Guid key)
        {
            var collectionPropertyToGet = Url.Request.RequestUri.Segments.Last();
            var feature = _context.Features.Include(collectionPropertyToGet)
                .FirstOrDefault(p => p.FeatureId == key);

            if (feature == null)
            {
                return NotFound();
            }

            if (!feature.HasProperty(collectionPropertyToGet))
            {
                return NotFound();
            }

            var collectionPropertyValue = feature.GetValue(collectionPropertyToGet);

            return this.CreateOkHttpActionResult(collectionPropertyValue);
        }

        [HttpPost]
        [ODataRoute("Features({key})/Ratings")]
        public IHttpActionResult CreateRatingForFeature([FromODataUri] Guid key,
            Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var feature = _context.Features.FirstOrDefault(f => f.FeatureId == key);
            if (feature == null)
            {
                return NotFound();
            }

            rating.Feature = feature;

            _context.Ratings.Add(rating);
            _context.SaveChanges();

            return Created(rating);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeatureExists(Guid id)
        {
            return _context.Features.Count(e => e.FeatureId == id) > 0;
        }
    }
}