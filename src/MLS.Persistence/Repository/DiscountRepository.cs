﻿using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        private readonly MatLidStoreDatabaseContext _context;

        public DiscountRepository(MatLidStoreDatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Discount?> GetDiscountByCodeAsync(string code)
        {
            return await _context.Discounts.FirstOrDefaultAsync(d => d.Code == code);
        }
    }
}