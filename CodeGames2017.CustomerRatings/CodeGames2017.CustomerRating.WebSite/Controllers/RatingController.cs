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
        public ActionResult Index(string application, string feature, string clientCode) {
            var applications = _context.Applications
                .ByKey(application)
                 .Execute() as QueryOperationResponse<Application>;

            var viewModel = new ApplicationViewModel {
                Applications = applications
            };


            return View(viewModel);
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(RatingViewModel model) {
            //var applications = _context.Applications
            //    .Execute() as QueryOperationResponse<Application>;

            //var viewModel = new ApplicationViewModel {
            //    Applications = applications
            //};


            //return View(viewModel);

            return null; 
        }
    }
}