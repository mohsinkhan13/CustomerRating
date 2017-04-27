using CodeGames2017.CustomerRating.Model;
using Microsoft.OData.Edm;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace CodeGames2017.CustomerRating.Api
{
    public static class WebApiConfig
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services

        //    // Web API routes
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );

        //}

        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("ODataRoute", "odata", GetEdmModel());
            config.EnsureInitialized();
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "CodeGames2017CustomerRating";
            builder.ContainerName = "CodeGames2017CustomerRatingContainer";

            builder.EntitySet<Application>("Applications");
            builder.EntitySet<Feature>("Features");
            builder.EntitySet<Rating>("Ratings");
            builder.EntitySet<Report>("Report");

            return builder.GetEdmModel();
        }

    }
}
