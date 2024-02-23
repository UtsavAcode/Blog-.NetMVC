using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
