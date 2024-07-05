using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    private readonly MatLidStoreDatabaseContext _context;

    public AddressRepository(MatLidStoreDatabaseContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsAddressDuplicateAsync(Address address)
    {
        return await _context.Addresses.AnyAsync(a =>
            a.Street == address.Street &&
            a.City == address.City &&
            a.State == address.State &&
            a.Country == address.Country &&
            a.PostalCode == address.PostalCode &&
            a.UserId == address.UserId);
    }

    public override async Task CreateAsync(Address entity)
    {
        if (await IsAddressDuplicateAsync(entity)) throw new InvalidOperationException("Duplicate address found.");

        await base.CreateAsync(entity);
    }
}