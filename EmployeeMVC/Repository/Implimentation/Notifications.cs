using AspNetCoreHero.ToastNotification.Abstractions;
using EmployeeMVC.Data;
using EmployeeMVC.Models.Domain;
using EmployeeMVC.Repository.Interface;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Repository.Implimentation
{
    public class Notifications : INotification
    {
        private readonly ApplicationDbContext context;

        public Notifications(ApplicationDbContext context)
        {
            this.context = context;
        }

     

        public async Task<Models.Domain.Notification> AddAsync(Models.Domain.Notification notification)
        {
            await context.Notifications.AddAsync(notification);
            await context.SaveChangesAsync();
            return notification;
        }

        public async Task<IEnumerable<Models.Domain.Notification>> GetAllAsync()
        {
            return await context.Notifications.OrderByDescending(n => n.CreatedAt).ToListAsync();
        }



        public int GetUnreadNotificationCount()
        {
            return context.Notifications.Count(n => !n.IsSeen);
        }

        public void MarkAsRead(Guid id)
        {
            var notification = context.Notifications.Find(id);
            if (notification != null)
            {
                notification.IsSeen = true;
                context.SaveChanges();
            }
        }
    }
}
