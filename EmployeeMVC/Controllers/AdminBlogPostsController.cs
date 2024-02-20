using EmployeeMVC.Models.Domain;
using EmployeeMVC.Models.ViewModels;
using EmployeeMVC.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeMVC.Controllers
{
    public class AdminBlogPostsController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IBlogPostRepository _blogRepo;

        public AdminBlogPostsController(ITagRepository tagRepository, IBlogPostRepository blogRepo)
        {
            this.tagRepository = tagRepository;
            _blogRepo = blogRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tags = await tagRepository.GetAllAsync();

            var model = new AddBlogPostRequest() {

                Tags = tags.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };

            return View(model);
        }

        [HttpPost]
        public async IActionResult Add(AddBlogPostRequest addBlogPostRequest)
        {
            //Mapping View Model to The Domain model.
            var blogPost = new BlogPost
            {
                Heading = addBlogPostRequest.Heading,
                PageTitle = addBlogPostRequest.PageTitle,
                ShortDescription = addBlogPostRequest.ShortDescription,
                FeaturedImageUrl = addBlogPostRequest.FeaturedImageUrl,
                UrlHandle = addBlogPostRequest.UrlHandle,
                PublishedDate = addBlogPostRequest.PublishedDate,
                Author = addBlogPostRequest.Author,
                Visible = addBlogPostRequest.Visible,
            };

            //Mapping Tags from the selected tags.
            var selectedTags = new List<Tag>();
            foreach(var selectedtTagId in addBlogPostRequest.SelectedTags)
            {
                
            }
            await _blogRepo.AddAsync(blogPost);
            return View();
        }
    }
}
