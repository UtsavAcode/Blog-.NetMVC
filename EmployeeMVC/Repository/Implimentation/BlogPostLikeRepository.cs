using EmployeeMVC.Data;
using EmployeeMVC.Models.Domain;
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

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await context.PostLikes.AddAsync(blogPostLike);
            await context.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await context.PostLikes.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await context.PostLikes
                .CountAsync(x=> x.BlogPostId == blogPostId);
        }
    }
}
