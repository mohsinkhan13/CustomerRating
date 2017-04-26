using System.Web;
using System.Web.Mvc;

namespace CodeGames2017.CustomerRating.WebSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
