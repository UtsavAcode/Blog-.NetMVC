using EmployeeMVC.Data;
using EmployeeMVC.Models.Domain;
using EmployeeMVC.Repository.Interface;

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

        public Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }


}
