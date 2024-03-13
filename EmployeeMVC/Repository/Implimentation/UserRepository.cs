using EmployeeMVC.Data;
using EmployeeMVC.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Repository.Implimentation
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext context;

        public UserRepository(AuthDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users = await context.Users.ToListAsync();

            var superAdmin = await context.Users.FirstOrDefaultAsync(x=> x.Email == "superadmin@gmail.com");

            if(superAdmin != null)
            {
                users.Remove(superAdmin);
            }

            return users;
        }
    }
}
