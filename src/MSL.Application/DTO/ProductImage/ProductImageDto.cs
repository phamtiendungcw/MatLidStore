﻿namespace MLS.Application.DTO.ProductImage;

public class ProductImageDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string? ImageDescription { get; set; }
    public int ProductId { get; set; }
}