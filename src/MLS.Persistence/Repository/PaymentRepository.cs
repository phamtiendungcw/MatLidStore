﻿using MLS.Application.Contracts.Persistence;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(MatLidStoreDatabaseContext context) : base(context)
        {
        }
    }
}