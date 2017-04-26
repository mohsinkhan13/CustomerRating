using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeGames2017.CustomerRating.WebSite.Models
{
    public class RatingViewModel
    {
        public Guid RatingId { get; set; }
        public string Application { get; set; }
        public string Section { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }
        public string RatedBy { get; set; }
        public string ClientCode { get; set; }
    }
}