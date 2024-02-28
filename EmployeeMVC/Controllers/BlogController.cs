using EmployeeMVC.Models.ViewModels;
using EmployeeMVC.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostRepository _blogRepo;
        private readonly IBlogPostLikeRepository likesRepo;

        public BlogController(IBlogPostRepository blogRepo, IBlogPostLikeRepository likesRepo)
        {
            _blogRepo = blogRepo;
            this.likesRepo = likesRepo;
        }
        public async Task<IActionResult> Index(string urlHandle)
        {
            var blog = await _blogRepo.GetByUrlHandleAsync(urlHandle);
            var blogDetailsViewModel = new BlogDetailsViewModel();


            if (blog != null)
            {
                var totalLikes = await likesRepo.GetTotalLikes(blog.Id);

                blogDetailsViewModel = new BlogDetailsViewModel

                {
                    Id = blog.Id,
                    Content = blog.Content,
                    PageTitle = blog.PageTitle,
                    Author = blog.Author,
                    FeaturedImageUrl = blog.FeaturedImageUrl,
                    Heading = blog.Heading,
                    PublishedDate = blog.PublishedDate,
                    ShortDescription = blog.ShortDescription,
                    UrlHandle = blog.UrlHandle,
                    Visible = blog.Visible,
                    Tags = blog.Tags,
                    TotalLikes = totalLikes,
                };
            }
            return View(blogDetailsViewModel);
        }
    }
}
