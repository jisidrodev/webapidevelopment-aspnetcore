using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiImplementDI.Services.Interfaces;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController(IDemoService _demoService) : ControllerBase
    {
        
        [HttpGet]
        public ActionResult Get()
        {
            return Content(_demoService.SayHello());
        }
    }
}
