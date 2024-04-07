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

        public async Task<BlogPostComment?> GetAsync(Guid Id)
        {
            return await context.PostComments.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByIdAsync(Guid blogPostId)
        {
            return await context.PostComments.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<BlogPostComment?> UpdateAsync(BlogPostComment blogComment)
        {
            var comment = await context.PostComments.FirstOrDefaultAsync(x => x.Id == blogComment.Id);

            if(comment != null)
            {
                comment.Id = blogComment.Id;
                comment.Description = blogComment.Description;
                comment.DateAdded = blogComment.DateAdded;

                await context.SaveChangesAsync();
                return comment;
            }

            return null;
        }
    }
}
