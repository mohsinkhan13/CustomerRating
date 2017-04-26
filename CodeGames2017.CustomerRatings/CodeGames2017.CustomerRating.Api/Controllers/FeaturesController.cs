﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CodeGames2017.CustomerRating.DataAccessLayer;
using CodeGames2017.CustomerRating.Model;
using System.Web.OData;
using System.Web.OData.Routing;
using CodeGames2017.CustomerRating.Api.Helpers;

namespace CodeGames2017.CustomerRating.Api.Controllers
{
    public class FeaturesController : ODataController
    {
        private RatingsDbContext db = new RatingsDbContext();

        // GET: api/Features
        public IQueryable<Feature> GetFeatures()
        {
            return db.Features;
        }

        // GET: api/Features/5
        [ResponseType(typeof(Feature))]
        public async Task<IHttpActionResult> GetFeature([FromODataUri]Guid key)
        {
            Feature feature = await db.Features.FindAsync(key);
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
            var feature = db.Features.Include(collectionPropertyToGet)
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


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeatureExists(Guid id)
        {
            return db.Features.Count(e => e.FeatureId == id) > 0;
        }
    }
}