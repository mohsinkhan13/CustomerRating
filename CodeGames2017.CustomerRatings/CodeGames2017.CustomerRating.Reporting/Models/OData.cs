using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeGames2017.CustomerRating.Reporting.Models
{
    public class OData<T>
    {
        [JsonProperty("odata.context")]
        public string Metadata { get; set; }
        public T value { get; set; }
    }
}