using CodeGames2017.CustomerRating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeGames2017.CustomerRating.Reporting.Models
{
    public class ReportingViewModel
    {
        public string ApplicationName { get; set; }
        public IDictionary<Feature,ReportData> Features { get; set; }
        public ReportingViewModel() {
            Features = new Dictionary<Feature, ReportData>();
        }
    }

    public class ReportData
    {
        public int TotalRatings { get; set; }
        public double AvgRating { get; set; }
        public int Rating5 { get; set; }
        public int Rating4 { get; set; }
        public int Rating3 { get; set; }
        public int Rating2 { get; set; }
        public int Rating1 { get; set; }

    }
}