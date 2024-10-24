﻿using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IProductReviewRepository : IGenericRepository<ProductReview>
{
    Task<IEnumerable<ProductReview>> GetReviewsByUserIdAsync(int userId);

    Task<IEnumerable<ProductReview>> GetReviewsByProductIdAsync(int productId);
}