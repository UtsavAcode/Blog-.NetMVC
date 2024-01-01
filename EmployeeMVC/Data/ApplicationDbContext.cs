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

        public DbSet<Employee> Register { get; set;}


      
    }
}
