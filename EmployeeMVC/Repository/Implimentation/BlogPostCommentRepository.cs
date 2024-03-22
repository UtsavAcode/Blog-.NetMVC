using EmployeeMVC.Data;
using EmployeeMVC.Models.Domain;
using EmployeeMVC.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Repository.Implimentation
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly ApplicationDbContext context;

        public BlogPostCommentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await context.PostComments.AddAsync(blogPostComment);
            await context.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<BlogPostComment?> DeleteAsync(Guid blogPostId)
        {
           var existingComment = await context.PostComments.FindAsync(blogPostId);
            if (existingComment != null)
            {
                context.PostComments.Remove(existingComment);
                await context.SaveChangesAsync();
                return existingComment;
            }

            return null;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByIdAsync(Guid blogPostId)
        {
           return await context.PostComments.Where(x=> x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<BlogPostComment?> UpdateAsync(BlogPostComment blogPostComment)
        {
           var existingComment = await  context.PostComments.FirstOrDefaultAsync(x => x.Id == blogPostComment.Id);

            if(existingComment != null)
            {
                existingComment.Id = blogPostComment.Id;
                existingComment.Description = blogPostComment.Description;
                await context.SaveChangesAsync();
                return existingComment;
            }
            return null;
        }
    }
}
