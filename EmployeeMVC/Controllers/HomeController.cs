using EmployeeMVC.Models;
using EmployeeMVC.Models.ViewModels;
using EmployeeMVC.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostRepository _blog;
        private readonly ITagRepository _tag;
       

        public HomeController(ILogger<HomeController> logger, IBlogPostRepository blog, ITagRepository tag)
        {
            _logger = logger;
            _blog = blog;
            _tag = tag;
           
        }


        public IActionResult Home()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var blogs = await _blog.GetAllAsync();
            var tags = await _tag.GetAllAsync();

            var model = new HomeViewModel
            {
                BlogPosts = blogs,
                Tags = tags

            };
            return View(model);
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
