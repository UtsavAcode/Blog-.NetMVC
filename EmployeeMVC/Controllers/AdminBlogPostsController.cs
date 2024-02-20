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
        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest)
        {
            //Mapping View Model to The Domain model.
            var blogPost = new BlogPost
            {
                Heading = addBlogPostRequest.Heading,
                PageTitle = addBlogPostRequest.PageTitle,
                ShortDescription = addBlogPostRequest.ShortDescription,
                Content = addBlogPostRequest.Content,
                FeaturedImageUrl = addBlogPostRequest.FeaturedImageUrl,
                UrlHandle = addBlogPostRequest.UrlHandle,
                PublishedDate = addBlogPostRequest.PublishedDate.ToUniversalTime(),
                Author = addBlogPostRequest.Author,
                Visible = addBlogPostRequest.Visible,
            };

            //Mapping Tags from the selected tags.
            var selectedTags = new List<Tag>();
            foreach(var selectedTagId in addBlogPostRequest.SelectedTags)
            {
                var selectedTagIdAsGuid = Guid.Parse(selectedTagId);
                var existingTag = await tagRepository.GetAsync(selectedTagIdAsGuid);

                if(existingTag != null)
                {
                    selectedTags.Add(existingTag);
                }
            }

            blogPost.Tags = selectedTags;
            await _blogRepo.AddAsync(blogPost);
            return RedirectToAction("Add");
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var blogs = await _blogRepo.GetAllAsync();
            return View(blogs);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            //Retrieve the result from the repository
            var blogPosts = await _blogRepo.GetAsync(id);
            var tagsDomainModel = await tagRepository.GetAllAsync();


            if(blogPosts != null)
            {
                var model = new EditBlogPostRequest
                {
                    Id = blogPosts.Id,
                    Heading = blogPosts.Heading,
                    PageTitle = blogPosts.PageTitle,
                    Content = blogPosts.Content,
                    Author = blogPosts.Author,
                    FeaturedImageUrl = blogPosts.FeaturedImageUrl,
                    UrlHandle = blogPosts.UrlHandle,
                    ShortDescription = blogPosts.ShortDescription,
                    PublishedDate = blogPosts.PublishedDate,
                    Visible = blogPosts.Visible,
                    Tags = tagsDomainModel.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }),
                    SelectedTags = blogPosts.Tags.Select(x => x.Id.ToString()).ToArray(),
                };

                return View(model);

            }
            //Mapping the Domain model to the View model
          
            return View(null);
        }
    }
}
