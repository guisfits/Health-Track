using System;
using System.Web.Mvc;
using HealthTrack.Data.Context;
using HealthTrack.Data.Repository;
using HealthTrack.Domain.Models;
using Microsoft.AspNet.Identity;

namespace HealthTrack.MVC.Filters
{
    public class ExceptionActionFilter : ActionFilterAttribute
    {
        private readonly LogRepository _logRepository;

        public ExceptionActionFilter()
        {
            _logRepository = new LogRepository(new HealthTrackContext());
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                var log = new Log()
                {
                    Data = DateTime.Now,
                    Mensagem = filterContext.Exception.Message,
                    IdentityId = (filterContext.Controller as Controller)?.User.Identity.GetUserId(),
                    Ip = filterContext.HttpContext.Request.UserHostAddress
                };

                _logRepository.RegistrarLog(log);

                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
