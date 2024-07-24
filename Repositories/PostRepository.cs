using BlogAPI.Data;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories
{
    public class PostRepository : IPostRepository
    {
        private BlogDbContext _context;
        public PostRepository(BlogDbContext context){
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllAsync() => await _context.Posts.Include(p => p.Comments).ToListAsync();

        public async Task<Post> GetByIdAsync(long id) => await _context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Post> AddAsync(Post entity)
        {
            await _context.Posts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}