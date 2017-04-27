using CodeGames2017.CustomerRating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGames2017.CustomerRating.Reporting.Model
{
    public class FeatureViewModel
    {
        public FeatureViewModel()
        {
            Features = new List<Feature>();
        }
        public IEnumerable<Feature> Features { get; set; }
    }
}
