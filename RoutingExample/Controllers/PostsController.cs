using Microsoft.AspNetCore.Mvc;

namespace RoutingExample.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    //[Route("api/post-test")] It is not recommended to have multiple routes

    public class PostsController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetPosts()
        {
            return Content("All posts");
        }

        [HttpGet("{id:int:range(1,100):required}")]
        public ActionResult GetPost(int id)
        {
            return Content("A post");
        }

        [HttpPut("{id:int}/publish")]
        public ActionResult PublishPost(int id )
        {
            return Content("To publish a post");
        }

        [HttpGet("paged")]
        public ActionResult GetPosts([FromQuery] int pageIndex,[FromQuery] int pageSize)
        {
            return Content("Get post with pagination");
        }

        /*
            The keyword parameter is a simple type, so [FromQuery] inferred that the keyword parameter
        */
        [HttpGet("search")]
        public ActionResult GetPost(string keyword)
        {
            return Content("Searching a post");
        }
    }
}
