using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(guisfits.HealthTrack.Presentation.Startup))]
namespace guisfits.HealthTrack.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
