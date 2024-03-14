using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(6, ErrorMessage ="The Password must be atleast 6 characters long")]
        public string Password { get; set; }

    }
}
