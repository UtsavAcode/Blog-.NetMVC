using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
