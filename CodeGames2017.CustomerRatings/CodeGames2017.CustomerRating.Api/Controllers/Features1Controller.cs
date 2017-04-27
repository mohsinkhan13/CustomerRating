using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CodeGames2017.CustomerRating.DataAccessLayer;
using CodeGames2017.CustomerRating.Model;

namespace CodeGames2017.CustomerRating.Api.Controllers
{
    public class Features1Controller : ApiController
    {
        private RatingsDbContext db = new RatingsDbContext();

        // GET: api/Features1
        public IQueryable<Feature> GetFeatures()
        {
            return db.Features;
        }

        // GET: api/Features1/5
        [ResponseType(typeof(Feature))]
        public async Task<IHttpActionResult> GetFeature(Guid id)
        {
            Feature feature = await db.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            return Ok(feature);
        }

        // PUT: api/Features1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFeature(Guid id, Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feature.FeatureId)
            {
                return BadRequest();
            }

            db.Entry(feature).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Features1
        [ResponseType(typeof(Feature))]
        public async Task<IHttpActionResult> PostFeature(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Features.Add(feature);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FeatureExists(feature.FeatureId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = feature.FeatureId }, feature);
        }

        // DELETE: api/Features1/5
        [ResponseType(typeof(Feature))]
        public async Task<IHttpActionResult> DeleteFeature(Guid id)
        {
            Feature feature = await db.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            db.Features.Remove(feature);
            await db.SaveChangesAsync();

            return Ok(feature);
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