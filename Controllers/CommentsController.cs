using BlogAPI.Dtos;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/posts/{postId}/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult<CommentDto>> AddComment(int postId, CreateCommentDto commentDto)
        {
            var comment = await _commentService.AddCommentAsync(postId, commentDto);
            return Created(string.Empty, comment);
        }
    }
}