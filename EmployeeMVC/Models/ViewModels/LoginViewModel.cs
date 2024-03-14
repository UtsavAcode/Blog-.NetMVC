using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage ="The password must be atleast 6 characters long.")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
