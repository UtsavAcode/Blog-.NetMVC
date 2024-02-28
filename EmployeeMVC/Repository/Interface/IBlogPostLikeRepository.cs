namespace EmployeeMVC.Repository.Interface
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikes(Guid blogPostId); 
    }
}
