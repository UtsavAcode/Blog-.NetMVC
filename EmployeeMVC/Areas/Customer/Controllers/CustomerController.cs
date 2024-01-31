using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {
        public IActionResult Customer()
        {
            return View();
        }
    }
}
