using CodeGames2017.CustomerRating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeGames2017.CustomerRating.Reporting.Models
{
    public class ReportingViewModel
    {
        public IEnumerable<Application> Applications { get; set; }
        public IEnumerable<Feature> Features { get; set; }
        public ReportingViewModel() {
            Applications = new List<Application>();
            Features = new List<Feature>();
        }
    }
}