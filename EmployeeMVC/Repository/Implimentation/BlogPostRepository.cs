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

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlog = await _context.BlogPosts.FindAsync(id);

            if(existingBlog != null)
            {
                 _context.BlogPosts.Remove(existingBlog);
                await _context.SaveChangesAsync();
                return existingBlog;
            }

            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts.Include( x => x.Tags ).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
           return await _context.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync( x => x.Id == id );
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await _context.BlogPosts.Include(x=>x.Tags).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
            
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var existingBlog = await _context.BlogPosts.Include( x => x.Tags).FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if (existingBlog != null)
            {
                existingBlog.Id = blogPost.Id;
                existingBlog.Heading = blogPost.Heading;
                existingBlog.Author = blogPost.Author;
                existingBlog.PageTitle = blogPost.PageTitle;
                existingBlog.Content = blogPost.Content;
                existingBlog.ShortDescription = blogPost.ShortDescription;
                existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.PublishedDate = blogPost.PublishedDate;
                existingBlog.Visible = blogPost.Visible;
                existingBlog.Tags = blogPost.Tags;

                await _context.SaveChangesAsync();
                return existingBlog;

            }

            return null;
        }
    }


}
