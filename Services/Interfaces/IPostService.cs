using BlogAPI.Dtos;

namespace BlogAPI.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetPostsAsync();
        Task<PostDto> CreatePostAsync(CreatePostDto postDto);
        Task<PostWithCommentsDto> GetPostByIdAsync(long id);
    }
}