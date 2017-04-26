using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGames2017.CustomerRating.Model
{
    public class Application
    {
        public Guid ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public ICollection<Feature> Features { get; set; }
    }
}
