
using EmployeeMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BlogPostLike> PostLikes { get; set; }
        public DbSet<BlogPost>BlogPosts{ get; set; }
        public DbSet<Tag> Tags { get; set;}
       




    }
}
