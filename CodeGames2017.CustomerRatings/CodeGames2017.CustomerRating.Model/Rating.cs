using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGames2017.CustomerRating.Model
{
    public class Rating
    {
        public Guid RatingId { get; set; }
        public Application Application { get; set; }
        public Feature Feature { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }
        public string RatedBy { get; set; }
        public string ClientCode { get; set; }

    }
}
    