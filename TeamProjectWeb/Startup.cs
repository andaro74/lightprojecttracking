using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamProjectWeb.Startup))]
namespace TeamProjectWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
