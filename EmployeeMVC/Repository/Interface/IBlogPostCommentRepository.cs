using EmployeeMVC.Models.Domain;

namespace EmployeeMVC.Repository.Interface
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);
        Task<BlogPostComment?> UpdateAsync(BlogPostComment blogPostComment);
        Task<BlogPostComment?> DeleteAsync(Guid blogPostId);
        Task<IEnumerable<BlogPostComment>> GetCommentsByIdAsync(Guid blogPostId);
    }
}
