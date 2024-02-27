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

        public AccountController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> siginManager
            ,AuthDbContext context)
        {
            this.userManager = userManager;
            this.signinManager = siginManager;
            this._context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Register(RegisterViewModel registerViewModel)
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
                        return RedirectToAction("Register");
                    }
                    else
                    {
                        //error notification
                    }
                }
            }

            return View();
        }

        //show the error Notification


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var signInResult = await signinManager.PasswordSignInAsync(login.Username,
                login.Password, false, false);
            
            if (signInResult != null && signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
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
    }
}
