﻿using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IDiscountRepository : IGenericRepository<Discount>
{
    Task<Discount?> GetDiscountByCodeAsync(string code);
}