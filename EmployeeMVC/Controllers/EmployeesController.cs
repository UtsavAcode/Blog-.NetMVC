using EmployeeMVC.Data;
using EmployeeMVC.Models;
using EmployeeMVC.Models.Domain;
using EmployeeMVC.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository applicationDbContext;
        public EmployeesController(IEmployeeRepository applicationDbContext)
        {
           this.applicationDbContext = applicationDbContext;
        }

/*        public ApplicationDbContext ApplicationDbContext { get; }

        public ApplicationDbContext ApplicationDbContext1 => applicationDbContext;
*/
        [HttpGet]
        public IActionResult Index()
        {

            var employees = applicationDbContext.GetAll();
            return View (employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeModel addEmployeeRequest) 
        {
            var employee = new Employee()
            {
               
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Phone = addEmployeeRequest.Phone,
                Department = addEmployeeRequest.Department,
                Salary = addEmployeeRequest.Salary,

            };

            applicationDbContext.Add(employee);
            applicationDbContext.Save();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult View(Guid Id)
        {
            var employee = applicationDbContext.Get(x => x.Id == Id);

            if (employee != null)
            {
                var viewModel = new UpdateEmployeeModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Department = employee.Department,
                    Salary = employee.Salary,

                };

                return View("View",viewModel);


            }
            return RedirectToAction("Index");

        }

        [HttpPost]

        public IActionResult View(UpdateEmployeeModel model)
        {
            var employee = applicationDbContext.FindById(model.Id);

            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Phone = model.Phone;
                employee.Department = model.Department;
                employee.Salary = model.Salary;

                applicationDbContext.Update(employee);
                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(UpdateEmployeeModel model)
        {
            var employee = applicationDbContext.FindById(model.Id);

            if (employee != null)
            {
                applicationDbContext.Remove(employee);
                applicationDbContext.Save();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //this is for the registration of the employees 
        [HttpPost]
        public IActionResult Register(RegisterEmployee model)
        {
            var employee = new Employee()
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Department = model.Department,
                Salary = model.Salary,
            };

            applicationDbContext.Add(employee);
            applicationDbContext.Save();
            return View(employee); ;
           


        }

    }
}
