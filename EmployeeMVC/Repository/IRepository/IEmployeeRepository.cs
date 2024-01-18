using EmployeeMVC.Models.Domain;

namespace EmployeeMVC.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee> 
    {
        void Update(Employee model);
        void Save();
        
    }
}
