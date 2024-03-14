using AspNetCoreHero.ToastNotification.Abstractions;
using EmployeeMVC.Data;
using EmployeeMVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signinManager;
        private readonly AuthDbContext _context;
        private readonly INotyfService _notfy;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> siginManager
            , AuthDbContext context,
            INotyfService notfy
            )
        {
            this.userManager = userManager;
            this.signinManager = siginManager;
            this._context = context;
            _notfy = notfy;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {

            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser
                {
                    UserName = registerViewModel.Username,
                    Email = registerViewModel.Email
                };


                var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);

                if (identityResult.Succeeded)
                {
                    //assign this user the "User" role

                    /*       var roleIdentityResult = await userManager.AddToRoleAsync(identityUser,"User");

                           if(roleIdentityResult.Succeeded)
                           {
                               return RedirectToAction("Register");
                           }*/


                    var userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "User");
                    if (userRole != null)
                    {
                        var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");
                        if (roleIdentityResult.Succeeded)
                        {
                            _notfy.Success("Register Success",3);
                            return RedirectToAction("Login");
                            
                        }
                        else
                        {
                            //error notification
                        }
                    }
                }
            }


            return View();
        }

        //show the error Notification


        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await signinManager.PasswordSignInAsync(login.Username,
              login.Password, false, false);

                if (signInResult != null && signInResult.Succeeded)
                {
                    if (!string.IsNullOrWhiteSpace(login.ReturnUrl))
                    {
                        return Redirect(login.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }

                _notfy.Error("Login Failed. Please Login Again",3);
            }

            //show errors
            return View();


        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signinManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
