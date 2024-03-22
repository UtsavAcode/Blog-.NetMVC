using EmployeeMVC.Models.Domain;
using EmployeeMVC.Models.ViewModels;
using EmployeeMVC.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogPostRepository _blogRepo;
        private readonly IBlogPostLikeRepository _likesRepo;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBlogPostCommentRepository commentRepo;

        public BlogController(IBlogPostRepository blogRepo,
            IBlogPostLikeRepository likesRepo
            , SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IBlogPostCommentRepository commentRepo)
        {
            _blogRepo = blogRepo;
            _likesRepo = likesRepo;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.commentRepo = commentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var blog = await _blogRepo.GetByUrlHandleAsync(urlHandle);
            var blogDetailsViewModel = new BlogDetailsViewModel();
            var liked = false;

            if (blog != null)
            {
                var totalLikes = await _likesRepo.GetTotalLikes(blog.Id);

                if (signInManager.IsSignedIn(User))
                {
                    //Get Likes for this blog for this user.
                    var likesForBlog = await _likesRepo.GetLikesForBlog(blog.Id);

                    var userId = userManager.GetUserId(User);

                    if (userId != null)
                    {
                        var likeFromUser = likesForBlog.FirstOrDefault(x => x.UserId == Guid.Parse(userId));
                        liked = likeFromUser != null;

                    }
                }

                //Getting Comments for Blog Post
                var blogCommentsDomainModel = await commentRepo.GetCommentsByIdAsync(blog.Id);

                var blogCommentsForView = new List<BlogComment>();

                foreach (var blogComment in blogCommentsDomainModel)
                {
                    var user = await userManager.FindByIdAsync(blogComment.UserId.ToString());
                    if (user != null)
                    {
                        blogCommentsForView.Add(new BlogComment
                        {
                            Description = blogComment.Description,
                            DateAdded = blogComment.DateAdded,
                            UserName = user.UserName,
                        });
                    }
                }

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
                    Liked = liked,
                    Comments = blogCommentsForView,
                };
            }
            return View(blogDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(BlogDetailsViewModel blogDetailsViewModel)
        {
            if (signInManager.IsSignedIn(User))
            {
                var domainModel = new BlogPostComment
                {
                    BlogPostId = blogDetailsViewModel.Id,
                    Description = blogDetailsViewModel.CommentDescription,
                    UserId = Guid.Parse(userManager.GetUserId(User)),
                    DateAdded = DateTime.Now.ToUniversalTime(),
                };

                await commentRepo.AddAsync(domainModel);
                return RedirectToAction("Index", "Blog", new { urlHandle = blogDetailsViewModel.UrlHandle });
            }
            return View();
        }

      

    }
}
