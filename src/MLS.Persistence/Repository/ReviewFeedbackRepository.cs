﻿using MLS.Application.Contracts.Persistence;
using MLS.Domain;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class ReviewFeedbackRepository : GenericRepository<ReviewFeedback>, IReviewFeedbackRepository
    {
        public ReviewFeedbackRepository(MatLidStoreDatabaseContext context) : base(context)
        {
        }
    }
}