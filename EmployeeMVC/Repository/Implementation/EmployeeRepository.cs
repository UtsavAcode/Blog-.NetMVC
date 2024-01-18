using EmployeeMVC.Data;
using EmployeeMVC.Models.Domain;
using EmployeeMVC.Repository.IRepository;

namespace EmployeeMVC.Repository.Implementation
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private ApplicationDbContext _employeeContext;

        public EmployeeRepository(ApplicationDbContext employeeContext) : base(employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public void Save()
        {
            _employeeContext.SaveChanges();
        }

        public void Update(Employee model)
        {
            _employeeContext.Employees?.Update(model);
        }
    }
}
