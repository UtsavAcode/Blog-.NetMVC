using EmployeeMVC.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostRepository _blogRepo;

        public BlogController(IBlogPostRepository blogRepo)
        {
            _blogRepo = blogRepo;
        }
        public async Task<IActionResult> Index(string urlHandle)
        {
            var blog = await _blogRepo.GetByUrlHandleAsync(urlHandle);
            return View(blog);
        }
    }
}
