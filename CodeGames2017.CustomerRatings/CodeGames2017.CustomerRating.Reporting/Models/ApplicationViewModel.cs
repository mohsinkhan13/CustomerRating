using CodeGames2017.CustomerRating.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGames2017.CustomerRating.Reporting.Models
{
    public class ApplicationViewModel
    {
        //public Guid ApplicationId { get; set; }
        //public string ApplicationName { get; set; }
        //public List<Feature> Features { get; set; }
        public IEnumerable<Application> Applications { get; set; }
        public ApplicationViewModel()
        {
            Applications = new List<Application>();
        }
    }
}
