namespace EmployeeMVC.Models.Domain
{
    public class Notifications
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool IsSeen { get; set; }
    }
}
