﻿using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IArticleRepository : IGenericRepository<Article>
{
    Task<IEnumerable<Article>> GetArticlesByAuthorAsync(string author);

    Task<bool> IsTitleUniqueAsync(string title);
}