using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGames2017.CustomerRating.Model
{
    public class Report
    {
        public Guid ReportId { get; set; }
        public string FeatureName { get; set; }
        public int Rating1 { get; set; }
        public int Rating2 { get; set; }
        public int Rating3 { get; set; }
        public int Rating4 { get; set; }
        public int Rating5 { get; set; }
    }
}
