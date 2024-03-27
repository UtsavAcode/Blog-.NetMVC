
using AspNetCoreHero.ToastNotification.Abstractions;
using EmployeeMVC.Models.Domain;

namespace EmployeeMVC.Repository.Interface
{
    public interface INotification
    {
        Task<Models.Domain.Notification> AddAsync(Models.Domain.Notification notification);
        Task<IEnumerable<Models.Domain.Notification>> GetAllAsync();
        public void MarkAsRead(Guid id);
        int GetUnreadNotificationCount();

    }
}
