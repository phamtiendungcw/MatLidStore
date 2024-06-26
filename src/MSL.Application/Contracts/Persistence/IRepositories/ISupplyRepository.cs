﻿using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface ISupplyRepository : IGenericRepository<Supply>
{
    Task<IEnumerable<Supply>> GetSuppliesByProductIdAsync(int productId);
}