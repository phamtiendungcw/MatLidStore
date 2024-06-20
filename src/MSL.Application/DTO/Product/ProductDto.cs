﻿using MLS.Application.DTO.OrderDetail;
using MLS.Application.DTO.ProductColor;
using MLS.Application.DTO.ProductImage;
using MLS.Application.DTO.ProductOption;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.DTO.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<ProductOptionDto> ProductOptions { get; set; }
        public List<ProductColorDto> ProductColors { get; set; }
        public List<ProductImageDto> ProductImages { get; set; }
        public List<ProductReviewDto> ProductReviews { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}