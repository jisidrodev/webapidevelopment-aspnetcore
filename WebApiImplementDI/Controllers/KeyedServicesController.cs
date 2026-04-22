using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiImplementDI.Services.Interfaces;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyedServicesController : ControllerBase
    {
        [HttpGet("sql")]
        public ActionResult GetSqlData([FromKeyedServices("sqlDatabaseService")] IDataService dataService)
        {
            return Content(dataService.GetData());
        }

        [HttpGet("cosmos")]
        public ActionResult GetCosmosata([FromKeyedServices("cosmosDatabaseService")] IDataService dataService)
        {
            return Content(dataService.GetData());
        }
    }
}
