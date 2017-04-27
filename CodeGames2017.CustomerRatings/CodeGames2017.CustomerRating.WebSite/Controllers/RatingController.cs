using CodeGames2017.CustomerRating.Model;
using CodeGames2017.CustomerRating.WebSite.Models;
using CodeGames2017CustomerRating;
using Microsoft.OData.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CodeGames2017.CustomerRating.WebSite.Controllers
{
    public class RatingController : Controller
    {
        private CodeGames2017CustomerRatingContainer _context =
            new CodeGames2017CustomerRatingContainer(new Uri("http://localhost:28305/odata"));


        // GET: Rating
        public async Task<ActionResult> Index(Guid applicationId, Guid featureId, string clientCode) {
            var application = await _context.Applications
                .ByKey(applicationId)
                .GetValueAsync();

            var applicationFeature = await _context.Features
                .ByKey(featureId)
                .GetValueAsync();

            var viewModel = new RatingViewModel
            {
                ClientCode = clientCode,
                ApplicationId = application.ApplicationId,
                Application = application.ApplicationName,
                FeatureId = applicationFeature.FeatureId,
                Feature = applicationFeature.FeatureName
            };

            return View(viewModel);
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(RatingViewModel model) {

            return null; 
        }
    }
}