using EmployeeMVC.Data;
using EmployeeMVC.Models.Domain;
using EmployeeMVC.Repository.Interface;

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
    }
}
