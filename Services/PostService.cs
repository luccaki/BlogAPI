using BlogAPI.Dtos;
using BlogAPI.Models;
using BlogAPI.Repositories;

namespace BlogAPI.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PostDto>> GetPostsAsync()
        {
            var posts = await _repository.GetAllAsync();
            return posts.Select(bp => new PostDto(bp.Id, bp.Title, bp.Content, bp.Comments.Count)).ToList();
        }

        public async Task<PostDto> CreatePostAsync(CreatePostDto postDto)
        {
            var post = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content
            };

            await _repository.AddAsync(post);

            return new PostDto(post.Id, post.Title, post.Content, post.Comments.Count);
        }

        public async Task<PostWithCommentsDto> GetPostByIdAsync(long id)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post is null)
                throw new KeyNotFoundException($"Post with id {id}, not found!");

            return new PostWithCommentsDto(post.Id, post.Title, post.Content, post.Comments.Select(c => new CommentDto(c.Id, c.Text, c.PostId)));
        }
    }
}