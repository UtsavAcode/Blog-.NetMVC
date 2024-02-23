using EmployeeMVC.Helper.Interface;
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
        private readonly IFileHelper _fileHelper;

        public AdminBlogPostsController(ITagRepository tagRepository, IBlogPostRepository blogRepo, IFileHelper fileHelper)
        {
            this.tagRepository = tagRepository;
            _blogRepo = blogRepo;
            _fileHelper = fileHelper;
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
        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest, IFormFile file)
        {
            //Mapping View Model to The Domain model.
            var blogPost = new BlogPost
            {
                Heading = addBlogPostRequest.Heading,
                PageTitle = addBlogPostRequest.PageTitle,
                ShortDescription = addBlogPostRequest.ShortDescription,
                Content = addBlogPostRequest.Content,
                FeaturedImageUrl = _fileHelper.SaveFileAndReturnName("images",file)?? "",
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


        [HttpPost]
        public async Task<IActionResult> Edit(EditBlogPostRequest edit, IFormFile file)
        {
            //Map View Model back to the domain model.

            var blogPost = new BlogPost
            {
                Id = edit.Id,
                Heading = edit.Heading,
                PageTitle = edit.PageTitle,
                Content = edit.Content,
                Author = edit.Author,
                FeaturedImageUrl = _fileHelper.SaveFileAndReturnName("images", file) ?? "",
                ShortDescription = edit.ShortDescription,
                PublishedDate = edit.PublishedDate.ToUniversalTime(),
                UrlHandle = edit.UrlHandle,
                Visible = edit.Visible,
            };

            //Map Tags into Domain Model.
            var selectedTags = new List<Tag>();
            foreach (var selectedTag in edit.SelectedTags)
            {
                if(Guid.TryParse(selectedTag, out var tag))
                {
                    var foundTag = await tagRepository.GetAsync(tag);

                    if(foundTag != null)
                    {
                        selectedTags.Add(foundTag);
                    }
                }
            }

            blogPost.Tags = selectedTags;

            //Submit Information to the repository to Update.
            var updatedBlog = await _blogRepo.UpdateAsync(blogPost);
            
            if (updatedBlog != null)
            {
                //Show success notification 
                return RedirectToAction("Edit");
            }

            else
            {
                //Failure Notification 
                return RedirectToAction("Edit");
            }
            //Redirect to GET.

        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditBlogPostRequest editBlogPostRequest)
        {
            //Tag to repository to delete this blog and tags.
            var deletedBlog = await _blogRepo.DeleteAsync(editBlogPostRequest.Id);

            if (deletedBlog != null)
            {
                //show the success notification.
                return RedirectToAction("List");
            }

            //show the error notification

            return RedirectToAction("List", new { id = editBlogPostRequest.Id});
        }
    }
}
