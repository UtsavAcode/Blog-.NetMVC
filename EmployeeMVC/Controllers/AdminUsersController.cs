using EmployeeMVC.Models.ViewModels;
using EmployeeMVC.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : Controller
    {
        private readonly IUserRepository userRepo;
        private readonly UserManager<IdentityUser> userManager;

        public AdminUsersController(IUserRepository userRepo,
            UserManager<IdentityUser> userManager)
        {
            this.userRepo = userRepo;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await userRepo.GetAll();

            var usersViewModel = new UserViewModel();
            usersViewModel.Users = new List<User>();
            foreach (var user in users)
            {
                usersViewModel.Users.Add(new Models.ViewModels.User
                {
                    Id = Guid.Parse(user.Id),
                    UserName = user.UserName,
                    Email = user.Email,
                });
            }
            return View(usersViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> List(UserViewModel request)
        {
            var identityUser = new IdentityUser { 
                UserName = request.UserName,
                Email = request.Email,
            };

            var identityResult = await userManager.CreateAsync(identityUser, request.Password);

            if(identityResult != null)
            {
                if(identityResult.Succeeded)
                {
                    //assigning the roles
                    var roles = new List<string> { "User" };

                    if (request.AdminRoleChecbox)
                    {
                        roles.Add("Admin");

                    }

                    foreach (var role in roles)
                    {
                        identityResult = await userManager.AddToRoleAsync(identityUser, role);

                        if (identityResult != null && identityResult.Succeeded)
                        {
                            //success
                        }
                    }
                    return RedirectToAction("List", "AdminUsers");



                }
            }

            return View();
        }
    }
}
