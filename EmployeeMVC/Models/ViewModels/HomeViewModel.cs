using EmployeeMVC.Models.Domain;

namespace EmployeeMVC.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public IEnumerable<Tag> Tags{ get; set; }

        public IEnumerable<Notification> Notifications { get; set; }
        public int UnreadCount { get; set; }
    }
}
