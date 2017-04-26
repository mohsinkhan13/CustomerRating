using CodeGames2017.CustomerRating.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeGames2017.CustomerRating.WebSite.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index(string application, string feature, string clientCode) {
            var rating = new RatingViewModel {
                Application = application,
                Feature = feature,
                ClientCode = clientCode
            };
             
            return View(rating);
        }
    }
}