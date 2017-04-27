using CodeGames2017.CustomerRating.Model;
using CodeGames2017.CustomerRating.Reporting.Model;
using CodeGames2017.CustomerRating.Reporting.Models;
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

namespace CodeGames2017.CustomerRating.Reporting.Controllers
{
    public class CustomerRatingsController : Controller
    {
        private CodeGames2017CustomerRatingContainer _context = 
            new CodeGames2017CustomerRatingContainer(new Uri("http://localhost:28305/odata"));

        // GET: CustomerRatings
        public async Task<ActionResult> Index()
        {
            
            var applications = _context.Applications
                .Execute() as QueryOperationResponse<Application>;

            var viewModel = new ReportingViewModel
            {
                Applications = applications
            };

            return View(viewModel);
        }

        public async Task<ActionResult> Report(Guid applicationId)
        {
            var application = await _context.Applications
                .ByKey(applicationId)
                .GetValueAsync();

            var features = _context.Features
                .Execute() as QueryOperationResponse<Feature>;

            var viewModel = new ReportingViewModel {
                Features = features
            };

            return View(viewModel);
        }

        //public async Task<ActionResult> Details(Guid id)
        //{

        //    var application = await _context.Applications
        //        .ByKey(id)
        //        .GetValueAsync();

        //    var features = _context.Applications.

        //    var viewModel = new ApplicationViewModel
        //    {
        //        ApplicationId = application.ApplicationId,
        //        ApplicationName = application.ApplicationName
        //    };


        //    return View(viewModel);
        //}
    }
}