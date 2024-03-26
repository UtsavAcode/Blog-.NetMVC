
using EmployeeMVC.Models.Domain;

namespace EmployeeMVC.Repository.Interface
{
    public interface INotification
    {
        Task<Notifications> AddAsync(string userName);
        Task<Notifications?> GetAsync(Guid id);
        Task MarkNotificationSeen(Guid id);
    }
}
