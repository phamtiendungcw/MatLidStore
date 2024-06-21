using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IShipmentRepository : IGenericRepository<Shipment>
{
    Task<IEnumerable<Shipment>> GetShipmentsByOrderIdAsync(int orderId);
}