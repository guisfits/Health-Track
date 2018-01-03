using System;
using System.Web.Http;
using HealthTrack.MVC.Filters;

namespace HealthTrack.MVC.Controllers.Api
{
    [RoutePrefix("api/home")]
    [ExceptionHandler]
    public class HomeApiController : ApiController
    {
        [Route("erro")]
        [HttpGet]
        public IHttpActionResult ErroApi()
        {
            throw new Exception();
            return Ok("ok result");
        }
    }
}
