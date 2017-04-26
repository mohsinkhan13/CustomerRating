using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeGames2017.CustomerRating.Reporting.Startup))]
namespace CodeGames2017.CustomerRating.Reporting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
