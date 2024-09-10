using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface INotificationRepository : IGenericRepository<Notification>
{
    Task<IEnumerable<Notification>> GetUnreadNotificationsByUserIdAsync(int userId);
}