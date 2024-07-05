using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository;

public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
{
    private readonly MatLidStoreDatabaseContext _context;

    public PaymentRepository(MatLidStoreDatabaseContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByOrderIdAsync(int orderId)
    {
        return await _context.Payments.Where(p => p.OrderId == orderId).ToListAsync();
    }
}