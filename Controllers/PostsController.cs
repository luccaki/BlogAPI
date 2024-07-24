using BlogAPI.Dtos;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _blogPostService;

        public PostsController(IPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetBlogPosts()
        {
            var posts = await _blogPostService.GetPostsAsync();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> CreateBlogPost(CreatePostDto postDto)
        {
            var blogPost = await _blogPostService.CreatePostAsync(postDto);
            return CreatedAtAction(nameof(GetBlogPost), new { id = blogPost.Id }, blogPost);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostWithCommentsDto>> GetBlogPost(int id)
        {
            var blogPost = await _blogPostService.GetPostByIdAsync(id);
            return Ok(blogPost);
        }
    }
}