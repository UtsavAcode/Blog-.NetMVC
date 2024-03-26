using EmployeeMVC.Models.Domain;
using EmployeeMVC.Repository.Interface;

namespace EmployeeMVC.Repository.Implimentation
{
    public class Notifications : INotification
    {
        public Task<Models.Domain.Notifications> AddAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Domain.Notifications?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task MarkNotificationSeen(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
