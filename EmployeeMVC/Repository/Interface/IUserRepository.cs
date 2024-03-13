using Microsoft.AspNetCore.Identity;

namespace EmployeeMVC.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>>GetAll();
    }
}
