namespace EmployeeMVC.Models.Domain
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool IsSeen { get; set; }
    }
}
