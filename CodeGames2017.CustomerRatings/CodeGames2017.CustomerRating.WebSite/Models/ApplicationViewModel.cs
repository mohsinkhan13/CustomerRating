using System.Collections.Generic;
using CodeGames2017.CustomerRating.Model;

namespace CodeGames2017.CustomerRating.WebSite.Models
{
    public class ApplicationViewModel

    {

        public IEnumerable<Application> Applications { get; set; }

        public ApplicationViewModel() {

            Applications = new List<Application>();

        }

    }
}