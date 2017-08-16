using guisfits.HealthTrack.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace guisfits.HealthTrack.Presentation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
