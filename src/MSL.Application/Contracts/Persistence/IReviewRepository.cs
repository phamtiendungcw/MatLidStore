﻿using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
    }
}