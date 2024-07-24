using BlogAPI.Models;

namespace BlogAPI.Repositories
{
    public interface ICommentRepository
    {

        public Task<Comment> AddAsync(Comment entity);
    }
}