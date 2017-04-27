using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeGames2017.CustomerRating.WebSite.Models
{
    public class RatingViewModel
    {
        public Guid ApplicationId { get; set; }
        [Display(Name = "Application")]
        public string Application { get; set; }

        public Guid FeatureId { get; set; }
        [Display(Name = "Feature")]
        public string Feature { get; set; }

        [Display(Name="Rating(1-5)")]
        public int RatingValue { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "Email")]
        public string RatedBy { get; set; }

        public string ClientCode { get; set; }
    }
}