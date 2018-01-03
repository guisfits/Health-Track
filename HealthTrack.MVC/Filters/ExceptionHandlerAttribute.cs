using System;
using System.Web.Mvc;
using HealthTrack.Data.Context;
using HealthTrack.Data.Repository;
using HealthTrack.Domain.Models;
using Microsoft.AspNet.Identity;

namespace HealthTrack.MVC.Filters
{
    public class ExceptionHandlerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var log = new Log()
            {
                Data = DateTime.Now,
                Mensagem = filterContext.Exception.Message,
                IdentityId = (filterContext.Controller as Controller)?.User.Identity.GetUserId(),
                Ip = filterContext.HttpContext.Request.UserHostAddress
            };

            var _logRepository = new LogRepository(new HealthTrackContext());
            _logRepository.RegistrarLog(log);

            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}