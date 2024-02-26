using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seed Roles (User, Admin, SuperAdmin)
            var superAdminRoleId = "0a0fe3d1-83f2-4bc7-9579-d40c5c0016c3";
            var adminRoleId = "2ff7ed94-68a2-472a-a28e-4389f4e220b1";
            var userRoleId = "fcbbac14-0548-45a4-aaf2-6bd00d3ab396";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },

                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },

                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            //Seed SuperAdminUser
            var superAdminId = "68706714-9680-4caf-9742-4faef5c9f1ad";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@blog.com",
                Email = "superadmin@blog.com",
                NormalizedEmail = "superadmin@blog.com".ToUpper(),
                NormalizedUserName = "superadmin@blog.com".ToUpper(),
                Id = superAdminId
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Superadmin@123");
            
            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Add All the roles to SuperAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },

                new IdentityUserRole<string>{
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },

                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }

    }
}
