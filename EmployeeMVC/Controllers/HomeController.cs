using EmployeeMVC.Models;
using EmployeeMVC.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostRepository _blog;

        public HomeController(ILogger<HomeController> logger, IBlogPostRepository blog)
        {
            _logger = logger;
            _blog = blog;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blog.GetAllAsync();
            return View(blogs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
