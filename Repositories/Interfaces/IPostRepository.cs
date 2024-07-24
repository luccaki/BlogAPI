using BlogAPI.Models;

namespace BlogAPI.Repositories
{
    public interface IPostRepository
    {
        public Task<IEnumerable<Post>> GetAllAsync();

        public Task<Post> GetByIdAsync(long id);

        public Task<Post> AddAsync(Post entity);
    }
}