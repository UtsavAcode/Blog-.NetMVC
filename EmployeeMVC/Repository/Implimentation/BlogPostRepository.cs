using EmployeeMVC.Data;
using EmployeeMVC.Models.Domain;
using EmployeeMVC.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Repository.Implimentation
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await _context.AddAsync(blogPost);
            await _context.SaveChangesAsync();
            return blogPost;
            
            
        }

        public Task<BlogPost?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts.Include( x => x.Tags ).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
           return await _context.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync( x => x.Id == id );
        }

        public Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }


}
