using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Profile()
        {

            return View();
        }
    }
}
