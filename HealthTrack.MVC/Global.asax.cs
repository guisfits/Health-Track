using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HealthTrack.MVC.App_Start;
using HealthTrack.MVC.AutoMapper;
using System.Web.Http;

namespace HealthTrack.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SimpleInjectorInitializer.Initialize();
            AutoMapperConfig.Register();
        }

        //protected void Application_Error(Object sender, EventArgs e) { }
    }
}
