using System.Web.Mvc;

namespace guisfits.HealthTrack.CrossCutting.MvcFilters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(filterContext.Exception != null)
            {
                //filterContext.ExceptionHandled = true;
                //filterContext.Result = new HttpStatusCodeResult(500);
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
