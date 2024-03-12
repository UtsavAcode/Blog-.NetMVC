using EmployeeMVC.Models.Domain;

namespace EmployeeMVC.Repository.Interface
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);
    }
}
