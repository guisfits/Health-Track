using System.Web.Http;
using guisfits.HealthTrack.Application.AutoMapper;

namespace guisfits.HealthTrack.Services.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
