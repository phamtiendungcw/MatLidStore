﻿using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ImageUrl { get; set; }
    }
}