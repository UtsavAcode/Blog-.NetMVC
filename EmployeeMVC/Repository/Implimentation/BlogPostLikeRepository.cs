using EmployeeMVC.Data;
using EmployeeMVC.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Repository.Implimentation
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly ApplicationDbContext context;

        public BlogPostLikeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await context.PostLikes
                .CountAsync(x=> x.BlogPostId == blogPostId);
        }
    }
}
