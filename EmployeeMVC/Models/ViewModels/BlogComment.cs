namespace EmployeeMVC.Models.ViewModels
{
    public class BlogComment
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Username {  get; set; }
        public DateTime DateAdded { get; set; }
       
    }
}
