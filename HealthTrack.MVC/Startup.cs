using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthTrack.MVC.Startup))]
namespace HealthTrack.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
