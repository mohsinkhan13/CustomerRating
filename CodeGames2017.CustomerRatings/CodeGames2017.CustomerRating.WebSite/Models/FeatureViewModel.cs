using CodeGames2017.CustomerRating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeGames2017.CustomerRating.WebSite.Models
{
    public class FeatureViewModel
    {
        public IEnumerable<Feature> Features { get; set; }

        public FeatureViewModel()
        {
            Features = new List<Feature>();
        }
    }
}