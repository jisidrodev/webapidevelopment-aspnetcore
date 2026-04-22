using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiImplementDI.Models;
using WebApiImplementDI.Services;
using WebApiImplementDI.Services.Interfaces;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            this._postService = postService;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postService.GetPost(id);
            if(post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            await _postService.CreatePost(post);
            return CreatedAtAction(nameof(GetPost), new {Id = post.Id}, post);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(int id, Post post)
        {
            if(id != post.Id)
                return BadRequest();
            
            var updatedPost = await _postService.UpdatePost(id,post);
            if(updatedPost == null)
                return NotFound();
            
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _postService.DeletePost(id);
            return Ok();
        }

        [HttpGet]
        public async  Task<ActionResult<List<Post>>> GetPosts()
        {
            var posts = await _postService.GetAllPosts();
            return Ok(posts);
        }

    }
}
