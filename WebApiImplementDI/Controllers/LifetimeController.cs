using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiImplementDI.Services.Interfaces;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifetimeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get([FromServices] ITransientService transientService, [FromServices] IScopedService scopedService, [FromServices] ISingletonService singletonService)
        {
            var scopedServiceMessage = scopedService.SayHello();
            var transientServiceMessage = transientService.SayHello();
            var singletonServiceMessage = singletonService.SayHello();
            return Content($"{scopedServiceMessage}{Environment.NewLine}{transientServiceMessage}{Environment.NewLine}{singletonServiceMessage}");
        }
    }
}
