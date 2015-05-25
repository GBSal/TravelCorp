using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelCorpBasket.Web.Startup))]
namespace TravelCorpBasket.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
