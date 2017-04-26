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
using System.Web.OData;
using System.Web.OData.Routing;
using CodeGames2017.CustomerRating.Api.Helpers;

namespace CodeGames2017.CustomerRating.Api.Controllers
{
    public class ApplicationsController : ODataController
    {
        private RatingsDbContext db = new RatingsDbContext();

        // GET: api/Applications
        public IQueryable<Application> GetApplications()
        {
            return db.Applications;
        }

        // GET: api/Applications/5
        [ResponseType(typeof(Application))]
        public async Task<IHttpActionResult> GetApplication([FromODataUri]Guid key)
        {
            Application application = await db.Applications.FindAsync(key);
            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("Applications({key})/Features")]
        public IHttpActionResult GetFeatures([FromODataUri] Guid key)
        {
            var collectionPropertyToGet = Url.Request.RequestUri.Segments.Last();
            var application = db.Applications.Include(collectionPropertyToGet)
                .FirstOrDefault(p => p.ApplicationId == key);

            if (application == null)
            {
                return NotFound();
            }

            if (!application.HasProperty(collectionPropertyToGet))
            {
                return NotFound();
            }

            var collectionPropertyValue = application.GetValue(collectionPropertyToGet);

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

        private bool ApplicationExists(Guid id)
        {
            return db.Applications.Count(e => e.ApplicationId == id) > 0;
        }
    }
}