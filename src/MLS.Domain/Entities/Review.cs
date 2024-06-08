﻿using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Review : BaseEntity
    {
        public string Comment { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public Customer? Customer { get; set; }
    }
}