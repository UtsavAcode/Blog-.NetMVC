using EmployeeMVC.Models.Domain;

namespace EmployeeMVC.Repository.Interface
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);
        Task<BlogPostComment?> UpdateAsync(BlogPostComment blogPostComment);
        Task<BlogPostComment?> DeleteAsync(Guid Id);
        Task<IEnumerable<BlogPostComment>> GetCommentsByIdAsync(Guid Id);
        Task<BlogPostComment> GetByIdAsync(Guid Id);
    }
}
