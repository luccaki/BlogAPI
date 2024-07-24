using BlogAPI.Data;
using BlogAPI.Models;

namespace BlogAPI.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private BlogDbContext _context;
        public CommentRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> AddAsync(Comment entity)
        {
            await _context.Comments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}