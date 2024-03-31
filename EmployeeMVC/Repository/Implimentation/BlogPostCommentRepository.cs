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

        public async Task<BlogPostComment?> DeleteAsync(Guid Id)
        {
            var comment = await GetByIdAsync(Id);
            if (comment != null)
            {
                context.PostComments.Remove((BlogPostComment)comment);
                await context.SaveChangesAsync();
            }

            return ((BlogPostComment)comment);
        }

        public async Task<BlogPostComment> GetByIdAsync(Guid Id)
        {
            return await context.PostComments.FirstOrDefaultAsync(comment => comment.Id == Id);
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByIdAsync(Guid Id)
        {
           return await context.PostComments.Where(x=> x.Id == Id).ToListAsync();
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
