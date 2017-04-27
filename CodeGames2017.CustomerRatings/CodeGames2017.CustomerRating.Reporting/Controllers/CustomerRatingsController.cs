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

            var viewModel = new ApplicationViewModel
            {
                Applications = applications
            };

            return View(viewModel);
        }

        public async Task<ActionResult> Feature(Guid applicationId)
        {
            var applications = await _context.Applications
                .Expand(a => a.Features)
                .ExecuteAsync() as QueryOperationResponse<Application>;

            var app = applications.FirstOrDefault(x => x.ApplicationId == applicationId);
            var appF = app.Features.ToList();

            

            var viewModel = new FeatureViewModel
            {
                Features = appF
            };


            //foreach (var feature in appFeatures)
            //{
            //    var count = feature.Ratings.Count();
            //    var avg = feature.Ratings.Sum(x=>x.RatingValue) / count;
            //    var one = feature.Ratings.Where(x => x.RatingValue == 1).Count();
            //    var two = feature.Ratings.Where(x => x.RatingValue == 2).Count();
            //    var three = feature.Ratings.Where(x => x.RatingValue == 3).Count();
            //    var four = feature.Ratings.Where(x => x.RatingValue == 4).Count();
            //    var five = feature.Ratings.Where(x => x.RatingValue == 5).Count();
            //    var rptData = new ReportData
            //    {
            //        TotalRatings = count,
            //        AvgRating = avg,
            //        Rating1 = one,
            //        Rating2 = two, 
            //        Rating3 = three, 
            //        Rating4 = four, 
            //        Rating5 = five
            //    };

            //}
           

            //view

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