using CodeGames2017.CustomerRating.DataAccessLayer;
using CodeGames2017.CustomerRating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;

namespace CodeGames2017.CustomerRating.Api.Controllers
{
    public class ReportController : ODataController
    {
        private RatingsDbContext _context = new RatingsDbContext();
        [EnableQuery]
        public IQueryable<Report> GetReport()
        {
            return _context.Report;
        }

    }
}