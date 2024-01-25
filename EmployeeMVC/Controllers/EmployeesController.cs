using EmployeeMVC.Data;
using EmployeeMVC.Models;
using EmployeeMVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        public EmployeesController(ApplicationDbContext applicationDbContext)
        {
           this.applicationDbContext = applicationDbContext;
        }//

        public ApplicationDbContext ApplicationDbContext { get; }

        public ApplicationDbContext ApplicationDbContext1 => applicationDbContext;

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var employees = await applicationDbContext.Employees.ToListAsync();
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

            await applicationDbContext.Employees.AddAsync(employee);
            await applicationDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
           var employee = await applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == Id);

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
                    ///
                };

                return await Task.Run(() => View("View",viewModel));


            }
            return RedirectToAction("Index");

        }

        [HttpPost]

        public async Task<IActionResult> View(UpdateEmployeeModel model)
        {
            var employee = await applicationDbContext.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Phone = model.Phone;
                employee.Department = model.Department;
                employee.Salary = model.Salary;

                await applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(UpdateEmployeeModel model)
        {
            var employee = await applicationDbContext.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                applicationDbContext.Employees.Remove(employee);
                await applicationDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //this is for the registration of the employees 
        [HttpPost]
        public async Task<IActionResult> Register(RegisterEmployee model)
        {
            var employee = new Employee()
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Department = model.Department,
                Salary = model.Salary,
            };

            await applicationDbContext.Employees.AddAsync(employee);
            await applicationDbContext.SaveChangesAsync();
            return View(employee); ;
           


        }

    }
}
