using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    public class AdminBlogPostsController : Controller
    {
       public IActionResult Add()
        {
            return View();
        }
    }
}
