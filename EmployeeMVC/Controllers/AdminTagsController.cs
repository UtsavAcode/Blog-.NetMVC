using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    public class AdminTagsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
