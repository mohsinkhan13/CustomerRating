using CodeGames2017.CustomerRating.Model;
using CodeGames2017.CustomerRating.Reporting.Model;
using CodeGames2017.CustomerRating.Reporting.Models;
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
        // GET: CustomerRatings
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var result =  await httpClient.GetStringAsync("http://localhost:28305/odata/Applications");


            //var data = "{\r\n \"@odata.context\":\"http://localhost/ApplicationService/model/$metadata#Edm.String\",\"value\":\"{\\\"Messages\\\":[\\\"message 1\\\",\\\"message 2\\\",\\\"message 3\\\",\\\"message 4\\\"],\\\"IsValidEntity\\\":false}\"\r\n}";
            var outer = Newtonsoft.Json.JsonConvert.DeserializeObject<OData<string>>(result);
            //var inner = Newtonsoft.Json.JsonConvert.DeserializeObject<<List<Application>>(outer.value);



            //var applications = result.Content.().Result;
            return View();
        }
    }
}