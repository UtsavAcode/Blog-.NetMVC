using EmployeeMVC.Models.Domain;

namespace EmployeeMVC.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public IEnumerable<Tag> Tags{ get; set; }
    }
}
