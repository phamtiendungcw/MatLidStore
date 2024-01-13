﻿using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}