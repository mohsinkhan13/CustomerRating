using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeGames2017.CustomerRating.WebSite.Startup))]
namespace CodeGames2017.CustomerRating.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
