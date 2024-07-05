using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    private readonly MatLidStoreDatabaseContext _context;

    public NotificationRepository(MatLidStoreDatabaseContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Notification>> GetUnreadNotificationsByUserIdAsync(int userId)
    {
        return await _context.Notifications.Where(n => n.UserId == userId && !n.IsRead).ToListAsync();
    }
}