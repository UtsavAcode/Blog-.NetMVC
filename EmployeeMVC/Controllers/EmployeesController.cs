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
            return RedirectToAction("Dashboard");
        }


        [HttpGet]
        public IActionResult Dashboard()
        {
            /* var worker = applicationDbContext.Employees.FirstOrDefault(x => x.Id == Id);

             if(worker !=null) {

                 return View(worker);
             }

             return View();*/

            var model = new Employee();
            return View(model);
            
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

   




        public IActionResult  Profile(Guid id)
        {
            var users = applicationDbContext.Employees.FirstOrDefault(x => x.Id == id);

            if (users != null)
            {
                var create = new Employee()
                {
                    Id = users.Id,
                    Name = users.Name,
                    Email = users.Email,
                    Phone = users.Phone,
                    Department = users.Department,
                    Salary = users.Salary,



                };

                return View(create);

            }

            return RedirectToAction("Add");
        }



        [HttpPost]
        public async Task<IActionResult> Profile(Employee updatedEmployee)
        {
            if (ModelState.IsValid)
            {
                // Update the employee in the database
                var employee = await applicationDbContext.Employees.FindAsync(updatedEmployee.Id);

                if (employee != null)
                {
                    employee.Name = updatedEmployee.Name;
                    employee.Email = updatedEmployee.Email;
                    employee.Phone = updatedEmployee.Phone;
                    employee.Department = updatedEmployee.Department;
                    employee.Salary = updatedEmployee.Salary;

                    await applicationDbContext.SaveChangesAsync();
                    TempData["Success"] = "Profile updated successfully";
                }

                // Redirect to a page or action after the update
                return RedirectToAction("Index");
            }

            // If ModelState is not valid, redisplay the form with validation errors
            return View(updatedEmployee);
        }



    }

       
}