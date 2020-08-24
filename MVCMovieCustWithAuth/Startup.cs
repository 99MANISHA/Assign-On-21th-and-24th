using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCMovieCustWithAuth.Startup))]
namespace MVCMovieCustWithAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
