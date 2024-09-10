using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IPaymentRepository : IGenericRepository<Payment>
{
    Task<IEnumerable<Payment>> GetPaymentsByOrderIdAsync(int orderId);
}