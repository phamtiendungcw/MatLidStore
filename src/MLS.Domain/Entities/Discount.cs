﻿using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string Code { get; set; }
        public decimal Percentage { get; set; } // Percentage discount off the price
        public DateTime StartDate { get; set; } // Start date of the discount
        public DateTime EndDate { get; set; } // End date of the discount
    }
}