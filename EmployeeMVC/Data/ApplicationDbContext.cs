using EmployeeMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee>Employees{get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specify the database column type for the "Id" property
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasColumnType("uuid");
        }
    }
}
