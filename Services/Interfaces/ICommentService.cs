using BlogAPI.Dtos;

namespace BlogAPI.Services
{
    public interface ICommentService
    {
        Task<CommentDto> AddCommentAsync(long postId, CreateCommentDto commentDto);
    }
}