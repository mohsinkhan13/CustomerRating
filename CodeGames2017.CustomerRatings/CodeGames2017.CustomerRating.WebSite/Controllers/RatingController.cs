using CodeGames2017.CustomerRating.Model;
using CodeGames2017.CustomerRating.WebSite.Models;
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
        // GET: Rating
        public ActionResult Index(string application, string feature, string clientCode) {
            var rating = new RatingViewModel {
                Application = application,
                Feature = feature,
                ClientCode = clientCode
            };

            return View(rating);
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(RatingViewModel model) {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:28305/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("odata/Applications");
                if (response.IsSuccessStatusCode) {
                    var applications = await response.Content.ReadAsAsync<List<Application>>();
                }
            }
            return View("Close");
        }
    }
}